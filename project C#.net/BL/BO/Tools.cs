using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BO;

public static class Tools
{
    public static string ToStringProperty<T>(this T obj)
    {
        if (obj == null) return "";

        string result = "";

        var properties = obj.GetType().GetProperties();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj, null);

            if (value is System.Collections.IEnumerable list && !(value is string))
            {
                result += $"{prop.Name}: [";
                foreach (var item in list)
                {
                    result += $"\n  {item}";
                }
                result += " ]\n";
            }
            else
            {
                result += $"{prop.Name}: {value}\n";
            }
        }

        return result;
    }


    public static BO.Customer CopyToBO(this Do.Custemer doCust)
    {
        return new BO.Customer()
        {
            ClientId = doCust.CustemerId,
            ClientName = doCust.CustemerName,
            Adress = doCust.Adress,
            phone = doCust.phone
        };
    }
    public static Do.Custemer CopyToDO(this BO.Customer boCust)
    {
        return new Do.Custemer(
            boCust.ClientId ,
            boCust.ClientName,
            boCust.Adress,
            boCust.phone 
        );
    }
    public static BO.Product CopyToBO(this Do.Product doProd)
    {
        return new BO.Product()
        {
            Id = doProd.Id,
            ProductName = doProd.ProductName,
            category = (BO.Category)doProd.Category,
            Price = doProd.Price,
            Amount = (int)doProd.Amount
        };
    }
    public static Do.Product CopyToDO(this BO.Product boProd)
    {
        return new Do.Product(
            boProd.Id,
            boProd.ProductName,
            (Do.Category)boProd.category,
            boProd.Price,
            boProd.Amount
        );
    }
    public static BO.Sale CopyToBO(this Do.Sale doSale)
    {
        return new BO.Sale()
        {
            Id = doSale.Id,
            ProductId = doSale.ProductId,
            MinProductSale = doSale.MinProductSale,
            SumPriceSale =(double) doSale.SumPriceSale,
            IfEveryOne = doSale.IfEveryOne,
            StartSale = doSale.StartSale,
            EndSale =(DateTime) doSale.EndSale
        };
    }
    public static Do.Sale CopyToDO(this BO.Sale boSale)
    {
        return new Do.Sale(
            boSale.Id,
            boSale.ProductId,
            boSale.MinProductSale,
            boSale.SumPriceSale,
            boSale.IfEveryOne,
            boSale.StartSale,
            boSale.EndSale
        );
    }
}
