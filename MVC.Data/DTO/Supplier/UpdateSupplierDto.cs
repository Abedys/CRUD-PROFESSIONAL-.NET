using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.DTO.Supplier
{
    public class UpdateSupplierDto : AddSupplierDto
    {
        public int SupplierId { get; set; } = 0; //forma de decirle que el valor no va ser nullo para enteros
    }
}
