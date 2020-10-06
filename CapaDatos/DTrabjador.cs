using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabjador
    {
        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public DTrabjador()
        {

        }
        public DTrabjador(string usuario,string password)
        {
            this.Usuario = usuario;
            this.Password = password;
        }

        public DataTable Login(DTrabjador trabajador)
        {
            DataTable resultado = new DataTable("trabajador");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "login_autolavados";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parusuario = new SqlParameter();
                parusuario.ParameterName = "@usuario";
                parusuario.SqlDbType = SqlDbType.VarChar;
                parusuario.Size = 20;
                parusuario.Value = trabajador.Usuario;
                cmd.Parameters.Add(parusuario);


                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 25;
                ParPassword.Value = trabajador.Password;
                cmd.Parameters.Add(ParPassword);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }



    }
}
