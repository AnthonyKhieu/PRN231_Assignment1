using BusinessObject;
using DataAccess;
using eStoreAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product p)
        {
            ProductDAO.DeleteProduct(p);
        }

        public Product GetProductByID(int id)
        {
           return ProductDAO.FindProductById(id);
        }

        public List<ProductDTO> GetProducts(string search)
        {
            return ProductDAO.GetProducts(search);
        }

        public void SaveProduct(ProductDTO p)
        {
            ProductDAO.SaveProduct(p);
        }

        public void UpdateProduct(int id ,ProductDTO p)
        {
            ProductDAO.UpdateProduct(id,p);
        }
    }
}
