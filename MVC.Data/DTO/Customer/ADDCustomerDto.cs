using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.DTO.Customer
{
    public class ADDCustomerDto
    {
        //  = "string.Empty;" si no coloca ningun tipo de valor que sea nulo
        //esto porque la norma establce que de ser asi : asignacion de vacios
        public string CustomerId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty; 
        public string ContacName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
