using SRP_Productos_ToBe.Entities;
using SRP_Productos_ToBe.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_Productos_ToBe.Business
{
    public class ProductFacadeManager
    {
        ProductRepository productRepository;
        Logger _logger;
        public ProductFacadeManager()
        {
            productRepository = new ProductRepository();
            _logger = new Logger("Log.txt");
        }

        public bool AddProduct(Product product)
        {
            try
            {
                var result = productRepository.SaveProduct(product);
                _logger.Log("Guardo Correctamente");
                return result;
            }
            catch (Exception ex)
            {
                _logger.Log($"Error al guardar {ex.ToString()}");
                throw;
            }
        }
    }
}
