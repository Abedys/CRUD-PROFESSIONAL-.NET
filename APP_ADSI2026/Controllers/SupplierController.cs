using Microsoft.AspNetCore.Mvc;
using MVC.Data.DTO.Customer;
using MVC.Data.DTO.Supplier;
using MVC.Data.Models;
using MVC.Domain.servicios;
using MVC.Domain.servicios.interfaces;

namespace APP_ADSI2026.Controllers
{
    public class SupplierController : Controller
    {

        private readonly ISupplierServices _suppliersServices;

        public SupplierController(ISupplierServices supplierServices)
        {
            this._suppliersServices = supplierServices;

        }

       //Controller de la vista del index html
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //controller de Listar
        [HttpGet("GetAllSupplier")]
        [Route("GetAllSupplier")]
        public async Task<IActionResult> GetAllSupplier()
        {
            List<SupplierDto> entity = await _suppliersServices.GetAllSupplierAsync();
            //Instanciar la variable result dentro de returno view para poder que muestre la vista


            return Ok(entity);
        }

        //controller de Eliminar
        [HttpDelete("DeleteSupplier")]
        [Route("DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier(int supplierId)
        {
            bool succes = await _suppliersServices.DeleteSupplierAsync( supplierId);
            return Ok(succes);
        }

        //controller de Agregar
        [HttpPost("addSupplier")]
        public async Task<IActionResult> addSupplier(AddSupplierDto add)
        {
            bool succes = await _suppliersServices.addSupplierAsync(add);

            return Ok();
        }
        //controller de Actualizar
        [HttpPut("updateSupplier")]
        [Route("updateSupplier")]
        public async Task<IActionResult> updateSupplier(UpdateSupplierDto update)
        {
            bool succes = await _suppliersServices.updateSupplierAsync( update);
            return Ok(succes);
        }

    }
}
