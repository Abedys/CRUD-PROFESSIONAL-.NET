using Microsoft.EntityFrameworkCore;
using MVC.Data.DataContext;
using MVC.Data.DTO.Customer;
using MVC.Data.DTO.Supplier;
using MVC.Data.Models;
using MVC.Domain.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.servicios
{
    //hereda todas las firmas de ISupplierServices
    public class SupplierServices: ISupplierServices
    {
        #region Propiedades
        //Esta es una propiedad de solo lectura de Norwindcontext  para poder utilizar durante todos los servicios
        //_context es mi conexión con la base de datos mediante Entity Framework.

        private readonly NorthwindContext _context; 
        #endregion

        #region Constructor
        //Constructor que recibe el contexto mediante inyección de dependencias
        public SupplierServices(NorthwindContext context)
        {
            //Toma el parámetro context que llegó al constructor y guárdalo en el campo _context de esta instancia de la clase
            this._context = context;

        }
        #endregion


        #region Method public
        //Listar todos los registros
        public async Task<List<SupplierDto>> GetAllSupplierAsync()
        {
            //mientras sean menos de 500 registros puedo usar esta conexion
            List<Supplier> entity = await _context.Suppliers.ToListAsync();
            //Instanciar la variable result dentro de returno view para poder que muestre la vista


            //esoty creando una nueva lista para almacenar los valores que me traer SupplierDto

            //Esto que hicimos aqui se llama un select para cambiar por medio de linq
            //Esto es 100  veces mas rapido que foreach esto se llama trasnformar la data por medio de select
            List<SupplierDto> result = entity.Select(x => new SupplierDto()
            {
                SupplierId = x.SupplierId,
                Address = x.Address,
                City = x.City,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                Country = x.Country,
                Phone = x.Phone,

            }).ToList();

            //Ahora para recorrer estas listas hay dos metodos

            //Esta forma de recorrer una lista cuando son muchos registros es poco eficienten
            //foreach (var item in result)
            //{
            //    result.Add(new SupplierDto()
            //    {
            //        SupplierId = item.SupplierId,
            //        Address = item.Address,
            //        City = item.City,
            //        CompanyName = item.CompanyName,
            //        Country = item.Country,
            //        Phone = item.Phone,
            //    });
            //}

            //Hay algo que es 100 veecs mas pontente que se hace con "linq"

            return result;
        }



        // la variable add esla que se va utilizar desde la clase
        public async Task<bool> addSupplierAsync(AddSupplierDto add)
        {
            //De esta manera estoy pasando la informacion desde el models customer
            //ah esta nueva instancia que estoy creando
            Supplier entity = new Supplier()
            {
                CompanyName = add.CompanyName,
                ContactName = add.ContactName,
                Address = add.Address,
                City = add.City,
                Country = add.Country,
                Phone = add.Phone,
            };
            // 
            _context.Suppliers.Add(entity);
            //Esto es para que esto se vea reflejado en la base de datos
            //el savechages guarda los registros
            bool succes = await _context.SaveChangesAsync() > 0;
            return succes;

        }

        public async Task<bool> updateSupplierAsync(UpdateSupplierDto update)
        {
            Supplier entity = await GetSupplierAsync(update.SupplierId);

            //entity.SupplierId = update.SupplierId;
            entity.CompanyName = update.CompanyName;
            entity.ContactName = update.ContactName;
            entity.Address = update.Address;
            entity.City = update.City;
            entity.Country = update.Country;
            entity.Phone = update.Phone;


            _context.Suppliers.Update(entity);
            //Esto es para que esto se vea reflejado en la base de datos
            //el savechages guarda los registros si hay registros actulizados guarda los cambios
            return await _context.SaveChangesAsync() > 0;

        }


        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            Supplier entity = await GetSupplierAsync(supplierId);

            //con esta sentencia le indicamos  la base de datos que elimine el registro
            _context.Suppliers.Remove(entity);
            //Esto es para que esto se vea reflejado en la base de datos
            //el savechages guarda los registros si hay registros los elimina y  guarda los cambios
            return await _context.SaveChangesAsync() > 0;

        }
        #endregion


        #region Method private
        //Obtener un solo registro
        private async Task<Supplier> GetSupplierAsync(int id)
        {
            //para buscar y traer la informacion de la base datos de forma asincrona 
            var entity = await _context.Suppliers.FirstOrDefaultAsync(x => x.SupplierId == id);
            //hacer una validacion por si la informacion que traigo es nulla
            if (entity == null)
            {
                // que es para capturar una exepcion de negocio
                throw new Exception($"El provedor con el ID {id} no existe , porfavor revisar el Id enviado");
            }

            return entity;
        } 
        #endregion

    }
}
