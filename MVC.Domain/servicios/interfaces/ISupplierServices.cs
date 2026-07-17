using MVC.Data.DTO.Supplier;
using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.servicios.interfaces
{
    //aqui no sea crea una clase si no una interface
    public interface ISupplierServices
    {

        Task<List<SupplierDto>> GetAllSupplierAsync();

        Task<bool> addSupplierAsync(AddSupplierDto add);

        Task<bool> updateSupplierAsync(UpdateSupplierDto update);

        Task<bool> DeleteSupplierAsync(int supplierId);


    }
}
