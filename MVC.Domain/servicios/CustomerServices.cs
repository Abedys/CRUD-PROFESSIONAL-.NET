using Microsoft.EntityFrameworkCore;
using MVC.Data.DataContext;
using MVC.Data.DTO.Customer;
using MVC.Data.Models;
using MVC.Domain.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MVC.Domain.servicios
{
    public class CustomerServices: ICustomerServices
    {
        //Esta es una propiedad de solo lectura de Norwindcontext  para poder utilizar durante todos los servicios
        //_context es mi conexión con la base de datos mediante Entity Framework.

        private readonly NorthwindContext _context;
        //Constructor que recibe el contexto mediante inyección de dependencias
        public CustomerServices(NorthwindContext context)
        {
            //Toma el parámetro context que llegó al constructor y guárdalo en el campo _context de esta instancia de la clase
            this._context = context;

        }

        public async Task<Customer> GetCustomerAsync(string CustomerId)
        {
            //para buscar y traer la informacion de la base datos de forma asincrona 
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
            //hacer una validacion por si la informacion que traigo es nulla
            if (entity == null)
            {
                // que es para capturar una exepcion de negocio
                throw new Exception($"El customer con el ID {CustomerId} no existe , porfavor revisar el Id enviado");
            }

            return entity;
        }

        //Creamos el servicio GetALLCustomer que es un metodo publico que devuleve una lista
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            // Variable encargada de Convertir los registros de Customers en una lista de objetos Customer asincrona
            List <Customer> customer =  await _context.Customers.ToListAsync();
            // Retorna la lista de clientes obtenida
            return customer;
        }

        // la variable add esla que se va utilizar desde la clase
        public async Task<bool> addCustomerAsync(ADDCustomerDto add)
        {
            //De esta manera estoy pasando la informacion desde el models customer
            //ah esta nueva instancia que estoy creando
            Customer entity = new Customer()
            {
                CustomerId = add.CustomerId,
                CompanyName = add.CompanyName,
                ContactName = add.ContacName,
                Country = add.Country,
                Phone = add.Phone,
            };
            // 
            _context.Customers.Add(entity);
            //Esto es para que esto se vea reflejado en la base de datos
            //el savechages guarda los registros
            bool succes = await _context.SaveChangesAsync() > 0;
            return succes;

        }

        public async Task<bool> updateCustomerAsync(UpdateCustomerDtocs update)
        {
            Customer entity = await GetCustomerAsync(update.CustomerId);

            entity.CustomerId = update.CustomerId;
            entity.CompanyName = update.CompanyName;
            entity.ContactName = update.ContacName;
            entity.Country = update.Country;
            entity.Phone = update.Phone;

  
            _context.Customers.Update(entity);
            //Esto es para que esto se vea reflejado en la base de datos
            //el savechages guarda los registros si hay registros actulizados guarda los cambios
            return await _context.SaveChangesAsync() > 0;
        
        }


        public async Task<bool> DeleteCustomerAsync (string CustomerId)
        {
           Customer entity = await GetCustomerAsync(CustomerId);

            //con esta sentencia le indicamos  la base de datos que elimine el registro
            _context.Customers.Remove(entity);
            //Esto es para que esto se vea reflejado en la base de datos
            //el savechages guarda los registros si hay registros los elimina y  guarda los cambios
            return await _context.SaveChangesAsync() > 0;

        }

       



    }

}
