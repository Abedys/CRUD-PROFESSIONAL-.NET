using MVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.DTO.Product
{
    public class AddProductDto
    {
        public string ProductName { get; set; } = null!;

        public int SupplierId { get; set; }

        public int CategoryId { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

    }
}
