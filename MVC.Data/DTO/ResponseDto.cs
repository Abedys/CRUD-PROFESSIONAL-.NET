using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data.DTO
{
    //Esta clase es para tener una respuesta estandarizada para todas las peticiones
    //toda respuesta debe llevar un succes, un mensaje y un result
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Result { get; set; }
        //el signo de  ? es para decirle al compilador que esta bien que esa propiedad sea null
    }
}
