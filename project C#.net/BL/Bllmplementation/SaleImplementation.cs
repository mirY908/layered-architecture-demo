using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using Do; // גישה לשכבת הנתונים עבור החריגות
using System.Reflection;

namespace BlImplementation
{
    internal class SaleImplementation : ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Sale item)
        {
            // 1. בדיקות תקינות לוגיות (Validation)
            //if (item.Id <= 0)
            //    throw new BO.BlInvalidDataException("Sale ID must be positive.");

            if (item.EndSale <= item.StartSale)
                throw new BO.BlInvalidDataException("End date must be after start date.");

            if (item.SumPriceSale < 0)
                throw new BO.BlInvalidDataException("Sale price cannot be negative.");

            try
            {
                // המרה מ-BO ל-DO.Sale
                Do.Sale dalSale = new Do.Sale(
                    item.Id,
                    item.ProductId,
                    item.MinProductSale ?? 0,
                    (float)item.SumPriceSale,
                    item.IfEveryOne,
                    item.StartSale,
                    item.EndSale
                );

                return _dal.Sale.Create(dalSale);
            }
            catch (Do.DalAlreadyExistsException ex)
            {
                // 2. תפיסת חריגת "כבר קיים" מה-DAL
                throw new BO.BlAlreadyExistsException($"Sale with ID {item.Id} already exists.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("An unexpected error occurred while creating the sale.", ex);
            }
        }

        public BO.Sale? Read(int id)
        {
            try
            {
                var dalSale = _dal.Sale.Read(id);

                // 3. אם המבצע לא נמצא בנתונים
                if (dalSale == null)
                    throw new BO.BlDoesNotExistException($"Sale with ID {id} does not exist.");

                return dalSale.CopyToBO();
            }
            catch (Do.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Sale with ID {id} was not found.", ex);
            }
        }

        public BO.Sale? Read(Func<BO.Sale, bool> filter)
        {
            return ReadAll().FirstOrDefault(filter);
        }

        public IEnumerable<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            try
            {
                var sales = _dal.Sale.ReadAll().Select(s => s.CopyToBO());
                return filter == null ? sales : sales.Where(filter);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("Failed to retrieve sales list.", ex);
            }
        }

        public void Update(BO.Sale item)
        {
            // בדיקת תקינות לפני עדכון
            if (item.EndSale <= item.StartSale)
                throw new BO.BlInvalidDataException("Cannot update: End date must be after start date.");

            try
            {
                Do.Sale dalSale = new Do.Sale(
                    item.Id,
                    item.ProductId,
                    item.MinProductSale ?? 0,
                    (float)item.SumPriceSale,
                    item.IfEveryOne,
                    item.StartSale,
                    item.EndSale
                );

                _dal.Sale.Update(dalSale);
            }
            catch (Do.DalDoesNotExistException ex)
            {
                // 4. תפיסת חריגת "לא קיים" בזמן עדכון
                throw new BO.BlDoesNotExistException($"Cannot update: Sale with ID {item.Id} not found.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("An error occurred during sale update.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Sale.Delete(id);
            }
            catch (Do.DalDoesNotExistException ex)
            {
                // 5. תפיסת חריגת "לא קיים" בזמן מחיקה
                throw new BO.BlDoesNotExistException($"Cannot delete: Sale with ID {id} does not exist.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("An error occurred during sale deletion.", ex);
            }
        }

        public bool IsCustomerExist()
        {
            // בדיקה כללית אם קיימים מבצעים
            return _dal.Sale.ReadAll().Any();
        }
    }
}