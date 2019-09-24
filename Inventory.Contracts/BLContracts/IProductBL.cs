using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.Inventory.Entities;

namespace Capgemini.Inventory.Contracts.BLContracts
{
    public interface IProductBL : IDisposable
    {
        Task<bool> AddProductBL(Product newProduct);
        Task<List<Product>> GetAllProductsBL();
        Task<Product> GetProductByProductIDBL(Guid searchProductID);
        Task<Product> GetProductByProductNameBL(string searchProductName);
        Task<Product> GetProductByProductCodeBL(string searchProductCode);
        Task<List<Product>> GetProductsByProductTypeBL(string searchProductType);
        Task<bool> UpdateProductBL(Product updateProduct);
        Task<bool> DeleteProductBL(Guid deleteProductID);
    }
}
