using BusinessObject;
using eStoreAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(ProductDTO p);

        Product GetProductByID(int id);

        void DeleteProduct(Product p);

        void UpdateProduct(int id,ProductDTO p);

        List<ProductDTO> GetProducts(string search);
    }
}
