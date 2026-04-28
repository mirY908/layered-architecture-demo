using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using Do; // הוספתי גישה ל-DO עבור החריגות של הנתונים

namespace BlImplementation
{
    internal class OrderImplementation : IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public List<SaleInProduct> AddProductToOrder(int code, int amount)
        {
            Order order = new Order { ProductList = new List<ProductInOrder>() };
            return AddProductToOrder(order, code, amount);
        }

        public List<SaleInProduct> AddProductToOrder(Order order, int productId, int amountInOrder)
        {
            try
            {
                // שליפת מוצר מה-DAL. אם לא נמצא, ה-DAL (או ה-CopyToBO) יחזיר שגיאה
                var dalProduct = _dal.Product.Read(productId);
                if (dalProduct == null)
                    throw new BO.BlDoesNotExistException($"Product with ID {productId} was not found.");

                BO.Product product = dalProduct.CopyToBO();

                ProductInOrder productInOrder = order.ProductList.FirstOrDefault(p => p.id == productId);

                if (productInOrder != null)
                {
                    // בדיקת מלאי - שימוש בחריגת נתונים לא תקינים מה-BO
                    if (product.Amount < (productInOrder.amount + amountInOrder))
                        throw new BO.BlInvalidDataException($"Not enough in stock for product {product.Id}. Available: {product.Amount}");

                    productInOrder.amount += amountInOrder;
                    SearchSaleForProduct(productInOrder, order.IsFavoriteCustomer);
                    CalcTotalPriceForProduct(productInOrder);
                    CalcTotalPrice(order);

                    return productInOrder.products;
                }
                else
                {
                    if (product.Amount < amountInOrder)
                        throw new BO.BlInvalidDataException($"Not enough in stock for product {product.Id}. Available: {product.Amount}");
                }

                ProductInOrder newProduct = new ProductInOrder(product.Id, product.Price, amountInOrder);
                SearchSaleForProduct(newProduct, order.IsFavoriteCustomer);
                CalcTotalPriceForProduct(newProduct);

                order.ProductList.Add(newProduct);
                CalcTotalPrice(order);

                return newProduct.products;
            }
            catch (BO.BlDoesNotExistException) { throw; }
            catch (BO.BlInvalidDataException) { throw; }
            catch (Exception ex)
            {
                throw new BO.BlException("An error occurred while adding product to order.", ex);
            }
        }

        public void DoOrder(Order order)
        {
            try
            {
                foreach (ProductInOrder pInOrder in order.ProductList)
                {
                    Do.Product prod = _dal.Product.Read(pInOrder.id)
                                      ?? throw new BO.BlDoesNotExistException($"Product {pInOrder.id} not found during order finalization.");

                    if (pInOrder.amount > prod.Amount)
                        throw new BO.BlInvalidDataException($"Insufficient stock for product {prod.Id} during checkout.");

                    // עדכון מלאי ב-DAL
                    prod = prod with { Amount = prod.Amount - (int)pInOrder.amount };
                    _dal.Product.Update(prod);
                }
            }
            catch (Do.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException("Database sync error: Product missing.", ex);
            }
            catch (BO.BlInvalidDataException) { throw; }
            catch (Exception e)
            {
                throw new BO.BlException("Failed to perform order completion.", e);
            }
        }

        public void SearchSaleForProduct(ProductInOrder productInOrder, bool isFavorate)
        {
            try
            {
                var salesFromDal = _dal.Sale.ReadAll(s =>
                    s.ProductId == productInOrder.id &&
                    s.StartSale <= DateTime.Now &&
                    s.EndSale >= DateTime.Now &&
                    s.MinProductSale <= productInOrder.amount);

                productInOrder.products = salesFromDal
                    .Where(s => (isFavorate && s.IfEveryOne) || !s.IfEveryOne)
                    .Select(s => new BO.SaleInProduct(s.Id, (int)s.MinProductSale, (int)s.SumPriceSale, s.IfEveryOne))
                    .OrderBy(s => s.price).ToList();
            }
            catch (Exception ex)
            {
                throw new BO.BlException("Error searching for applicable sales.", ex);
            }
        }

        // פונקציות עזר נשארות ללא שינוי לוגי כי הן לא פונות ל-DAL
        public void CalcTotalPrice(Order order)
        {
            order.TotalPrice = order.ProductList.Sum(p => p.finalPrice);
        }

        public void CalcTotalPriceForProduct(ProductInOrder productInOrder)
        {
            List<SaleInProduct> usedSales = new List<SaleInProduct>();
            double tempTotal = 0;
            int tempAmount = (int)productInOrder.amount;

            if (productInOrder.products != null)
            {
                foreach (SaleInProduct item in productInOrder.products)
                {
                    if (tempAmount < item.amount) continue;

                    int sets = tempAmount / item.amount;
                    tempTotal += sets * item.price;
                    tempAmount %= item.amount;

                    usedSales.Add(item);
                    if (tempAmount == 0) break;
                }
            }

            if (tempAmount > 0)
            {
                tempTotal += tempAmount * productInOrder.minPrice;
            }

            productInOrder.finalPrice = tempTotal;
            productInOrder.products = usedSales;
        }
        public IEnumerable<object> ReadAll()
        {
            // החזרה של רשימה ריקה של אובייקטים כדי לקיים את החוזה של הממשק
            return new List<object>();

            // אם בעתיד תרצי להחזיר את כל ההזמנות מה-DAL (בהנחה שיש כזה):
            // return _dal.Order.ReadAll().Select(s => s.CopyToBO());
        }
    }
}