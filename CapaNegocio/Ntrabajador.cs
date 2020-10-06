using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class Ntrabajador
    {
        public static DataTable Login(string usuario, string password)
        {
            DTrabjador obj = new DTrabjador();
            obj.Usuario = usuario;
            obj.Password = password;
            return obj.Login(obj);

        }
    }
}
