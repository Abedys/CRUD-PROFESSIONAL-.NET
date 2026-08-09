using MVC.Data.DTO.Product;
using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.servicios.interfaces
{
    public interface IProductServices
    {

        Task<List<ProductDto>> GetAllProductAsync();

        Task<bool> addProductAsync(AddProductDto add);

        Task<bool> updateProductAsync(UpdateProductDto update);

        Task<bool> DeleteProductAsync(int id);

        //Task<Product> GetProductAsync(int id);
    }
}
