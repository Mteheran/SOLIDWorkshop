using SRP_Productos_ToBe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace SRP_Productos_ToBe.Business
{
    public static class ProductFormValidator
    {
        public static bool InvalidProductData(Product product)
        {
            if (string.IsNullOrEmpty(product.Name) || product.Price == 0 || string.IsNullOrEmpty(product.Description) || string.IsNullOrEmpty(product.Manufacturer) || string.IsNullOrEmpty(product.SerialNumber))
            {

                return true;
            }
            return false;
        }

        public static bool InvalidPrice(string price, out decimal outPRiceValue) => !decimal.TryParse(price, out outPRiceValue);
    }
}
