using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bllmplementation
{
    internal class OrderImplementation:IOrder
    {
    //    private DalApi.IDal _dal = DalApi.Factory.Get;

    //    public List<SaleInProduct> AddProductToOrder(int code, int amount)
    //    {
    //        Order order = new Order { ProductList = new List<ProductInOrder>() };
    //        return AddProductToOrder(order, code, amount);
    //    }
    //    public List<SaleInProduct> AddProductToOrder(Order order, int productId, int amountInOrder)
    //    {
    //        try
    //        {
    //            Product product = _dal.Product.Read(productId).ConvertDoProductToBoProduct();

    //            ProductInOrder productInOrder = order.ProductList.FirstOrDefault(p => p.ProductId == productId);
    //            if (productInOrder != null)
    //            {
    //                if (product.AmountInStock < productInOrder.AmountOfOrder)
    //                    throw new Exception("Not enough in stock");
    //                else
    //                    productInOrder.AmountOfOrder += amountInOrder;
    //                return productInOrder.SalesOfProduct;
    //            }

    //            else
    //            {
    //                if (product.AmountInStock < amountInOrder)
    //                    throw new Exception("Not enough in stock");
    //            }
    //            ProductInOrder newProduct = new ProductInOrder(product.IdProduct, product.Price, amountInOrder);
    //            SearchSaleForProduct(newProduct, order.IsFavoriteCustomer);
    //            CalcTotalPriceForProduct(newProduct);
    //            order.ProductList.Add(newProduct);
    //            CalcTotalPrice(order);
    //            return newProduct.SalesOfProduct;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message, ex);
    //        }
    //    }

    //    public void CalcTotalPrice(Order order)
    //    {
    //        order.TotalPrice = order.ProductList.Sum(p => p.TotalPrice);
    //    }

    //    public void CalcTotalPriceForProduct(ProductInOrder productInOrder)
    //    {
    //        List<SaleInProduct> useSaleInOrder = new List<SaleInProduct>();
    //        foreach (SaleInProduct item in productInOrder.SalesOfProduct)
    //        {
    //            if (productInOrder.AmountOfOrder < item.AmountForSale) continue;
    //            productInOrder.TotalPrice += productInOrder.AmountOfOrder / item.AmountForSale * item.Price;
    //            productInOrder.AmountOfOrder %= item.AmountForSale;
    //            useSaleInOrder.Add(item);
    //            if (productInOrder.AmountOfOrder == 0) break;
    //        }
    //        if (productInOrder.AmountOfOrder != 0)
    //        {
    //            productInOrder.TotalPrice = productInOrder.AmountOfOrder * productInOrder.BasePrice;
    //        }
    //        productInOrder.SalesOfProduct = useSaleInOrder;
    //    }


    //    public void DoOrder(Order order)
    //    {
    //        try
    //        {
    //            foreach (ProductInOrder product in order.ProductList)
    //            {
    //                DO.Product prod = _dal.Product.Read(product.ProductId) ?? throw new Exception("Product not found");

    //                if (product.AmountOfOrder > prod.AmountInStock)
    //                    throw new Exception($"Not enough stock for product {prod.IdProduct}");

    //                prod = prod with { AmountInStock = prod.AmountInStock - product.AmountOfOrder };
    //                _dal.Product.Update(prod);
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            throw new Exception("Failed to perform order", e);
    //        }
    //    }


    //    public void SearchSaleForProduct(ProductInOrder productInOrder, bool isFavorate)
    //    {
    //        try
    //        {
    //            productInOrder.SalesOfProduct = _dal.Sale.ReadAll(s => s.ProductId == productInOrder.ProductId &&
    //            s.StartDate <= DateTime.Now && s.EndDate >= DateTime.Now && s.RequiredAmount <= productInOrder.AmountOfOrder && (isFavorate == true && s.IsForClubMembers == true) || (isFavorate == false))
    //                .Select(s => new BO.SaleInProduct(s.IdSale, s.ProductId, s.RequiredAmount, s.PriceSale, s.IsForClubMembers))
    //                .OrderBy(s => s.Price).ToList();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception(ex.Message, ex);
    //        }
    //    }
    //}
}
