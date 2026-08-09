using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.DTO.Product
{
    public class ProductDto : UpdateProductDto
    {
        public string Supplier { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

    }
}
