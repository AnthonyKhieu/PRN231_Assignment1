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
        void SaveProduct(ProductRespond p);

        Product GetProductByID(int id);

        void DeleteProduct(Product p);

        void UpdateProduct(int id,ProductRespond p);

        List<ProductRespond> GetProducts(string search);
    }
}
