using Microsoft.EntityFrameworkCore;
using MVC.Data.DataContext;
using MVC.Data.DTO.Product;
using MVC.Data.DTO.Supplier;
using MVC.Data.Models;
using MVC.Domain.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.servicios
{
    
    public class ProductServices : IProductServices
    {

        private readonly NorthwindContext _context;
        public ProductServices( NorthwindContext context)
        {
            this._context = context;
        
        }


        
        #region Method public
        //Listar todos los registros
        public async Task<List<ProductDto>> GetAllProductAsync()
        {
            //mientras sean menos de 500 registros puedo usar esta conexion
            List<Product> entity = await _context.Products
                                                 .Include(x=>x.Supplier)
                                                 .Include(x=>x.Category)
                                                 .ToListAsync();
            //Instanciar la variable result dentro de returno view para poder que muestre la vista


            //esoty creando una nueva lista para almacenar los valores que me traer SupplierDto

            //Esto que hicimos aqui se llama un select para cambiar por medio de linq
            //Esto es 100  veces mas rapido que foreach esto se llama trasnformar la data por medio de select
            List<ProductDto> result = entity.Select(x => new ProductDto()
            {

                CategoryId = x.CategoryId ??0, //esto e sun ternariu para decir que este valor si o si va
                SupplierId = x.SupplierId ??0,
                //SupplierId = x.SupplierId == null ? 1 : 2,  //esto es otra forma de ternariu para decir que este valor si o si va
                //CategoryId = (int)x.CategoryId!,//sirve para decir que esto no va ser nullo
                //SupplierId = (int)x.SupplierId!,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                ProductId = x.ProductId,
                Category = x.Category?.CategoryName ??"sin categoria",
                Supplier = x.Supplier?.CompanyName ?? "Sin proveedor"

            }).ToList();

            return result;
        }



        // la variable add esla que se va utilizar desde la clase
        public async Task<bool> addProductAsync(AddProductDto add)
        {
            //De esta manera estoy pasando la informacion desde el models customer
            //ah esta nueva instancia que estoy creando
            Product entity = new Product()
            {
                CategoryId = add.CategoryId,
                SupplierId = add.SupplierId,
                ProductName = add.ProductName,
                UnitPrice = add.UnitPrice,
                UnitsInStock = add.UnitsInStock,
            };

            try
            {
                _context.Products.Add(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<bool> updateProductAsync(UpdateProductDto update)
        {
            Product entity = await GetProductAsync(update.ProductId);

            entity.ProductId = update.ProductId;
            entity.CategoryId = update.CategoryId;
            entity.SupplierId = update.SupplierId;
            entity.ProductName = update.ProductName;
            entity.UnitPrice = update.UnitPrice;
            entity.UnitsInStock = update.UnitsInStock;

            _context.Products.Update(entity);
            //Esto es para que esto se vea reflejado en la base de datos
            //el savechages guarda los registros si hay registros actulizados guarda los cambios
            return await _context.SaveChangesAsync() > 0;

        }


        public async Task<bool> DeleteProductAsync(int id)
        {
            Product entity = await GetProductAsync(id);

            //con esta sentencia le indicamos  la base de datos que elimine el registro
            _context.Products.Remove(entity);
            //Esto es para que esto se vea reflejado en la base de datos
            //el savechages guarda los registros si hay registros los elimina y  guarda los cambios
            return await _context.SaveChangesAsync() > 0;

        }
        #endregion



        #region Method private
        //Obtener un solo registro
        private async Task<Product> GetProductAsync(int id)
        {
            //para buscar y traer la informacion de la base datos de forma asincrona 
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
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
