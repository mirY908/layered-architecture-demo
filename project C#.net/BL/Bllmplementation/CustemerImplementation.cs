


using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using DalApi;
using Do; // הוספתי כדי שה-catch יזהה את החריגות של הנתונים
using static BO.Tools;

namespace BlImplementation
{
    internal class CustemerImplementation : ICastumer
    {
        // גישה לשכבת הנתונים (DAL) דרך ה-Factory
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Customer item)
        {
            // 1. בדיקת תקינות נתונים (שימוש ב-BlInvalidDataException)
            if (item.ClientId <= 0)
                throw new BO.BlInvalidDataException("ID must be a positive number.");

            if (string.IsNullOrWhiteSpace(item.ClientName))
                throw new BO.BlInvalidDataException("Customer name cannot be empty.");

            try
            {
                // המרה מ-BO ל-DO (משתמשים ב-Do.Custemer כי זה המחסן)
                Do.Custemer dalCustomer = new Do.Custemer(
                    item.ClientId,
                    item.ClientName,
                    item.Adress,
                    item.phone
                );

                return _dal.Custemer.Create(dalCustomer);
            }
            // 2. תופסים את החריגה מה-DAL (נמצאת ב-Do)
            catch (Do.DalAlreadyExistsException ex)
            {
                // וזורקים את החריגה המקבילה מה-BO
                throw new BO.BlAlreadyExistsException($"Customer with ID {item.ClientId} already exists in the system.", ex);
            }
            catch (Exception ex)
            {
                // 3. שימוש ב-BlException הכללית לכל תקלה אחרת
                throw new BO.BlException("An unexpected error occurred while creating the customer.", ex);
            }
        }

        public BO.Customer? Read(int id)
        {
            try
            {
                var dalCustomer = _dal.Custemer.Read(id);

                // 4. שימוש ב-BlDoesNotExistException אם חזר null
                if (dalCustomer == null)
                    throw new BO.BlDoesNotExistException($"Customer with ID {id} does not exist.");

                return dalCustomer.CopyToBO();
            }
            // תופסים חריגה מה-DAL במידה והוא זרק כזו
            catch (Do.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Customer with ID {id} was not found in data files.", ex);
            }
        }

        public IEnumerable<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
        {
            try
            {
                var customers = _dal.Custemer.ReadAll().Select(s => s.CopyToBO());
                return filter == null ? customers : customers.Where(filter);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("Failed to retrieve customers list.", ex);
            }
        }

        public void Update(BO.Customer item)
        {
            // בדיקת תקינות לפני עדכון
            if (string.IsNullOrWhiteSpace(item.ClientName))
                throw new BO.BlInvalidDataException("Cannot update to an empty name.");

            try
            {
                Do.Custemer dalCustomer = new Do.Custemer(
                    item.ClientId,
                    item.ClientName,
                    item.Adress,
                    item.phone
                );
                _dal.Custemer.Update(dalCustomer);
            }
            catch (Do.DalDoesNotExistException ex)
            {
                // 5. שימוש ב-BlDoesNotExistException בתוך עדכון
                throw new BO.BlDoesNotExistException($"Cannot update: Customer with ID {item.ClientId} not found.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("An error occurred during update.", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Custemer.Delete(id);
            }
            catch (Do.DalDoesNotExistException ex)
            {
                // שימוש ב-BlDoesNotExistException במחיקה
                throw new BO.BlDoesNotExistException($"Cannot delete: Customer with ID {id} does not exist.", ex);
            }
            catch (Exception ex)
            {
                throw new BO.BlException("An error occurred during deletion.", ex);
            }
        }

        public BO.Customer? Read(Func<BO.Customer, bool> filter)
        {
            return ReadAll().FirstOrDefault(filter);
        }

        public bool IsCustomerExist()
        {
            return _dal.Custemer.ReadAll().Any();
        }
    }
}

