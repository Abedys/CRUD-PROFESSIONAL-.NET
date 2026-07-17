using MVC.Data.DTO.Customer;
using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.servicios.interfaces
{
    public interface ICustomerServices
    {
        //Firma de listar clientes
        Task<List<Customer>> GetAllCustomersAsync();

        //Obtner un solo clinete
        Task<Customer> GetCustomerAsync(string CustomerId);

        //Agregar o crear un cliente
        Task<bool> addCustomerAsync(ADDCustomerDto customer);

        //Actualizar o editar un cliente
        Task<bool> updateCustomerAsync(UpdateCustomerDtocs update);

        //Eliminar cliente
        Task<bool> DeleteCustomerAsync(string CustomerId);
    }

}
