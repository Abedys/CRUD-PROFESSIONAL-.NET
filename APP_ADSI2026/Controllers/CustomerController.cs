using Microsoft.AspNetCore.Mvc;
using MVC.Domain.servicios;
using MVC.Domain.servicios.interfaces;
using MVC.Data.DTO.Customer;
using MVC.Data.Models;
using MVC.Data.DataContext;

namespace APP_ADSI2026.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerServices _customerServices;
        // se coloca guion bajo para indicar que es privado
        public CustomerController(ICustomerServices customerServices) 
        {
            this._customerServices = customerServices;
        
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        //controller de Listar
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            List<Customer> entity= await _customerServices.GetAllCustomersAsync();
            //Instanciar la variable result dentro de returno view para poder que muestre la vista
            
           
            return Ok(entity);
        }

        //controller de Obtener
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomerAsync(string customerId)
        {
            Customer entity = await _customerServices.GetCustomerAsync(customerId);
            return Ok(entity);
        }




        //controller de Eliminar
        [HttpDelete("DeleteCustomer")]
        [Route ("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(string CustomerId)
        {
            bool succes = await _customerServices.DeleteCustomerAsync(CustomerId);
            return Ok(succes);
        }

        //controller de Agregar
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(ADDCustomerDto customer)
        {
            bool succes = await _customerServices.addCustomerAsync(customer);

            return Ok();
        }
        //controller de Actualizar
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDtocs update)
        {
            bool succes = await _customerServices.updateCustomerAsync(update);
            return Ok(succes);
        }


    }
}
