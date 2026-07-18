using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Common.Exceptions
{
    //Esta clase es para darle orden a las excepciones
    public class HTTPResponseException : Exception
    {
        //un estado para dar el tipo de eror 200, 300 400, 500
        public int Status {  get; set; }

        // y value es el valor que vamos a responder
        public object Value { get; set; } = null!;

    }
}
