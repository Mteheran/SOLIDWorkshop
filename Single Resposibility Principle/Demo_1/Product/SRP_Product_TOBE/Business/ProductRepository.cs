using SRP_Productos_ToBe.Entities;
using SRP_Productos_ToBe.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace SRP_Productos_ToBe.Business
{
    public class ProductRepository
    {
        string filePath = "products.xml";
        public bool SaveProduct(Product product)
        {
            List<Product> productsList = XmlSerializerHelper.Deserialize(filePath);

            if (!productsList.Any(x => x.Id == product.Id))
            {
                productsList.Add(product);
                XmlSerializerHelper.Serialize(filePath, productsList);
                return true;
            }

            return false;
        }
    }
}
