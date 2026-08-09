using Microsoft.AspNetCore.Mvc;
using MVC.Data.DTO.Product;
using MVC.Domain.servicios;
using MVC.Domain.servicios.interfaces;

namespace APP_ADSI2026.Controllers
{
    public class ProductController : Controller
    {
        #region properties
        private readonly IProductServices _productServices;
        #endregion

        #region Builder
        public ProductController(IProductServices productServices)
        {
           this._productServices = productServices;
        }
        #endregion
        #region Views
        public IActionResult Index()
        {
            return View();
        }
        #endregion


        #region Services

        //controller de Listar
        [HttpGet("GetAllProduct")]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            List<ProductDto> entity = await _productServices.GetAllProductAsync();
            //Instanciar la variable result dentro de returno view para poder que muestre la vista


            return Ok(entity);
        }

        //controller de Eliminar
        [HttpDelete("DeleteProduct")]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            bool succes = await _productServices.DeleteProductAsync(ProductId);
            return Ok(succes);
        }

        //controller de Agregar
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDto add)
        {
            bool succes = await _productServices.addProductAsync(add);

            return Ok();
        }
        //controller de Actualizar
        [HttpPut("updateProduct")]
        [Route("updateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto update)
        {
            bool succes = await _productServices.updateProductAsync(update);
            return Ok(succes);
        }

        #endregion
    }
}
