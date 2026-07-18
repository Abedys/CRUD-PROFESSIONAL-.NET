using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Common.Exceptions
    //estamos usando polimorfismo que es darle a un mismo metodo varias funcionalidades
    //pero reciben diferentes propiedades
{
    //aqui heredamos de exception
    public class BusinessException: Exception
    {
        //esto son contructores
        //constructor vacio crea una exceppcion sin infromacion adicional
        public BusinessException(): base()
        { 
        }

        //xontructor con mnesaje crea una excepcion con  un mensaje
        public BusinessException(string message) : base(message)
        {
        }

        //constructor con excepcion interna aqui se guardan dos cosas un menssaje
        //y la excepcion original que queda almacena en iiner
        public BusinessException( string message, Exception inner) : base(message, inner) 
        {
        }

     }
}
