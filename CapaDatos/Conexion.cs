using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CapaDatos
{
    public class Conexion
    {
        private static string nombre = Dns.GetHostName();
        private static string cn = "Data Source=" + nombre + ";Initial Catalog=dbautolavadosgomez;Integrated Security=True";
        public static string CN = cn;
            // Properties.Settings.Default.cn;
        // "Data Source=DESKTOP-DPKFN4D; Initial Catalog=dbautolavadosgomez; Integrated Security=True";
    }
}
