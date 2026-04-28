

using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using Do; // חשוב כדי לזהות את החריגות של הנתונים
using static BO.Tools;

namespace BlImplementation
{
    internal class ProductImplementation : IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Product item)
        {
            // 1. בדיקות תקינות נתונים (Logic Validation)
            if (item.Id <= 0)
                throw new BO.BlInvalidDataException("Product ID must be positive.");
            if (string.IsNullOrWhiteSpace(item.ProductName))
                throw new BO.BlInvalidDataException("Product name cannot be empty.");
            if (item.Price < 0)
                throw new BO.BlInvalidDataException("Price cannot be negative.");

            try
            {
                // המרה ל-DO.Product
                Do.Product dalProduct = new Do.Product(
                    item.Id,
                    item.ProductName,
                    (Do.Category)item.category,
                    item.Price,
                    item.Amount
                );

                return _dal.Product.Create(dalProduct);
            }
            catch (Do.DalAlreadyExistsException ex)
            {
                // 2. תרגום חריגת "קיים כבר" מה-DAL ל-BO
                throw new BO.BlAlreadyExistsException($"Product with ID {item.Id} already exists.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("An error occurred while creating the product.", ex);
            }
        }

        public BO.Product? Read(int id)
        {
            try
            {
                var dalProduct = _dal.Product.Read(id);

                // 3. אם לא נמצא - זריקת DoesNotExist
                if (dalProduct == null)
                    throw new BO.BlDoesNotExistException($"Product with ID {id} does not exist.");

                return dalProduct.CopyToBO();
            }
            catch (Do.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Product with ID {id} was not found in data.", ex);
            }
        }

        public BO.Product? Read(Func<BO.Product, bool> filter)
        {
            return ReadAll().FirstOrDefault(filter);
        }

        public IEnumerable<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
        {
            try
            {
                var products = _dal.Product.ReadAll().Select(p => p.CopyToBO());
                return filter == null ? products : products.Where(filter);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("Failed to retrieve products list.", ex);
            }
        }

        public void Update(BO.Product item)
        {
            // בדיקת תקינות לפני עדכון
            if (item.Price < 0)
                throw new BO.BlInvalidDataException("Updated price cannot be negative.");

            try
            {
                Do.Product dalProduct = new Do.Product(
                    item.Id,
                    item.ProductName,
                    (Do.Category)item.category,
                    item.Price,
                    item.Amount
                );

                _dal.Product.Update(dalProduct);
            }
            catch (Do.DalDoesNotExistException ex)
            {
                // 4. תרגום חריגת "לא נמצא" בזמן עדכון
                throw new BO.BlDoesNotExistException($"Cannot update: Product {item.Id} not found.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("An error occurred during product update.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Product.Delete(id);
            }
            catch (Do.DalDoesNotExistException ex)
            {
                // 5. תרגום חריגת "לא נמצא" בזמן מחיקה
                throw new BO.BlDoesNotExistException($"Cannot delete: Product {id} does not exist.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("An error occurred during product deletion.", ex);
            }
        }

        public bool IsCustomerExist()
        {
            // המימוש נשאר לבדיקת קיום מוצרים כללית
            return _dal.Product.ReadAll().Any();
        }
    }
}