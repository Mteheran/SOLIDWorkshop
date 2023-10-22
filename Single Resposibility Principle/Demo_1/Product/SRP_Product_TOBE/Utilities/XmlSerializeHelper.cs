using SRP_Productos_ToBe.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SRP_Productos_ToBe.Utilities
{

    public static class XmlSerializerHelper
    {
        public static List<Product> Deserialize(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    return (List<Product>)serializer.Deserialize(fileStream);
                }
            }
            catch
            {
                return new List<Product>();
            }
        }

        public static void Serialize(string filePath, List<Product> productList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            File.Delete(filePath);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, productList);
            }

        }
    }
}
