using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.DTO.Supplier
{
    public class AddSupplierDto
    {
        public string CompanyName { get; set; } = string.Empty;

        public string? ContactName { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        public string? City { get; set; } = string.Empty;

        public string? Country { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;
    }   
}
