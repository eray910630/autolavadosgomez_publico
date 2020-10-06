using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DServicios
    {
        private int _IdServicios;

        public int IdServicios
        {
            get { return _IdServicios; }
            set { _IdServicios = value; }
        }
        private string _NombreCliente;

        public string NombreCliente
        {
            get { return _NombreCliente; }
            set { _NombreCliente = value; }
        }
        private string _TelefonoCliente;

        public string TelefonoCliente
        {
            get { return _TelefonoCliente; }
            set { _TelefonoCliente = value; }
        }
        private string _TipoCoches;

        public string TipoCoches
        {
            get { return _TipoCoches; }
            set { _TipoCoches = value; }
        }
        private string _Matricula;

        public string Matricula
        {
            get { return _Matricula; }
            set { _Matricula = value; }
        }
        private string _TipoLavados;

        public string TipoLavados
        {
            get { return _TipoLavados; }
            set { _TipoLavados = value; }
        }
        private decimal _Precio;

        public decimal Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
        private int _AtendidoPor;

        public int AtendidoPor
        {
            get { return _AtendidoPor; }
            set { _AtendidoPor = value; }
        }
        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        private int _Cantdias;

        public int Cantdias
        {
            get { return _Cantdias; }
            set { _Cantdias = value; }
        }

        private DateTime _FechaInicio;

        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }
        private DateTime _FechaFinal;

        public DateTime FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }

        private int _Trabajador;

        public int Trabajador
        {
            get { return _Trabajador; }
            set { _Trabajador = value; }
        }
       
        public DServicios()
        {

        }
        public DServicios(int idservicios,string nombrecliente,string telefono,string tipocoche,string matricula,string tipolavados,decimal precio,int atendidopor,DateTime fecha,string textbuscar,int cantdias,DateTime fechainicio,DateTime fechafinal,int trabajador)
        {
            this.IdServicios = idservicios;
            this.NombreCliente = nombrecliente;
            this.TelefonoCliente = telefono;
            this.TipoCoches = tipocoche;
            this.Matricula = matricula;
            this.TipoLavados = tipolavados;
            this.Precio = precio;
            this.AtendidoPor = atendidopor;
            this.Fecha = fecha;
            this.TextoBuscar = textbuscar;
            this.Cantdias = cantdias;
            this.FechaInicio = fechainicio;
            this.FechaFinal = fechafinal;
            this.Trabajador = trabajador;
        }

        // Metodo insertar

        public string Insertar(DServicios servicios)
        {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.CN;
                sqlcon.Open();

                // establecer comand

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = "insertar_servicios";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdeservicios = new SqlParameter();
                ParIdeservicios.ParameterName = "@idservicios";
                ParIdeservicios.SqlDbType = SqlDbType.Int;
                ParIdeservicios.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ParIdeservicios);


                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre_cliente";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = servicios.NombreCliente;
                cmd.Parameters.Add(ParNombre);


                SqlParameter ParCell = new SqlParameter();
                ParCell.ParameterName = "@telefono_cliente";
                ParCell.SqlDbType = SqlDbType.VarChar;
                ParCell.Size = 15;
                ParCell.Value = servicios.TelefonoCliente;
                cmd.Parameters.Add(ParCell);


                SqlParameter ParTipoCoche = new SqlParameter();
                ParTipoCoche.ParameterName = "@tipo_coche";
                ParTipoCoche.SqlDbType = SqlDbType.VarChar;
                ParTipoCoche.Size = 30;
                ParTipoCoche.Value = servicios.TipoCoches;
                cmd.Parameters.Add(ParTipoCoche);

                SqlParameter ParMatricula = new SqlParameter();
                ParMatricula.ParameterName = "@matricula";
                ParMatricula.SqlDbType = SqlDbType.VarChar;
                ParMatricula.Size = 15;
                ParMatricula.Value = servicios.Matricula;
                cmd.Parameters.Add(ParMatricula);

                SqlParameter ParTipoLavados = new SqlParameter();
                ParTipoLavados.ParameterName = "@tipo_lavados";
                ParTipoLavados.SqlDbType = SqlDbType.VarChar;
                ParTipoLavados.Size = 50;
                ParTipoLavados.Value = servicios.TipoLavados;
                cmd.Parameters.Add(ParTipoLavados);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = servicios.Precio;
                cmd.Parameters.Add(ParPrecio);


                SqlParameter Paratendidopor = new SqlParameter();
                Paratendidopor.ParameterName = "@atendido_por";
                Paratendidopor.SqlDbType = SqlDbType.Int;
                Paratendidopor.Value = servicios.AtendidoPor;
                cmd.Parameters.Add(Paratendidopor);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = servicios.Fecha;
                cmd.Parameters.Add(ParFecha);


                // Ejecutamos comando
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return rpta;

        }

        // Metodo Editar

        public string Editar(DServicios servicios)
        {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.CN;
                sqlcon.Open();

                // establecer comand

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = "editar_servicios";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdServicio = new SqlParameter();
                parIdServicio.ParameterName = "@idservicios";
                parIdServicio.SqlDbType = SqlDbType.Int;
                parIdServicio.Value = servicios.IdServicios;
                cmd.Parameters.Add(parIdServicio);


                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre_cliente";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = servicios.NombreCliente;
                cmd.Parameters.Add(ParNombre);


                SqlParameter ParCell = new SqlParameter();
                ParCell.ParameterName = "@telefono_cliente";
                ParCell.SqlDbType = SqlDbType.VarChar;
                ParCell.Size = 15;
                ParCell.Value = servicios.TelefonoCliente;
                cmd.Parameters.Add(ParCell);


                SqlParameter ParTipoCoche = new SqlParameter();
                ParTipoCoche.ParameterName = "@tipo_coche";
                ParTipoCoche.SqlDbType = SqlDbType.VarChar;
                ParTipoCoche.Size = 30;
                ParTipoCoche.Value = servicios.TipoCoches;
                cmd.Parameters.Add(ParTipoCoche);

                SqlParameter ParMatricula = new SqlParameter();
                ParMatricula.ParameterName = "@matricula";
                ParMatricula.SqlDbType = SqlDbType.VarChar;
                ParMatricula.Size = 15;
                ParMatricula.Value = servicios.Matricula;
                cmd.Parameters.Add(ParMatricula);

                SqlParameter ParTipoLavados = new SqlParameter();
                ParTipoLavados.ParameterName = "@tipo_lavados";
                ParTipoLavados.SqlDbType = SqlDbType.VarChar;
                ParTipoLavados.Size = 50;
                ParTipoLavados.Value = servicios.TipoLavados;
                cmd.Parameters.Add(ParTipoLavados);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = servicios.Precio;
                cmd.Parameters.Add(ParPrecio);


                SqlParameter Paratendidopor = new SqlParameter();
                Paratendidopor.ParameterName = "@atendido_por";
                Paratendidopor.SqlDbType = SqlDbType.Int;
                Paratendidopor.Value = servicios.AtendidoPor;
                cmd.Parameters.Add(Paratendidopor);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = servicios.Fecha;
                cmd.Parameters.Add(ParFecha);


                // Ejecutamos comando
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Registro";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return rpta;


        }


        // metodo eliminar

        public string Eliminar(DServicios servicios)
        {

            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.CN;
                sqlcon.Open();

                // establecer comand

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandText = "eliminar_servicios";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdServicio = new SqlParameter();
                parIdServicio.ParameterName = "@idservicios";
                parIdServicio.SqlDbType = SqlDbType.Int;
                parIdServicio.Value = servicios.IdServicios;
                cmd.Parameters.Add(parIdServicio);


                // Ejecutamos comando
                rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";


            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            return rpta;

        }



        public DataTable Mostrar()
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "mostrar_servicios";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }



        public DataTable BuscarTipoCoches(DServicios servicios)
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "buscar_tipocoches";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParbuscarTexto = new SqlParameter();
                ParbuscarTexto.ParameterName = "@texto_buscar";
                ParbuscarTexto.SqlDbType = SqlDbType.VarChar;
                ParbuscarTexto.Size = 30;
                ParbuscarTexto.Value = servicios.TextoBuscar;
                cmd.Parameters.Add(ParbuscarTexto);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }

        public DataTable CochesDemorados(DServicios servicios)
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "coches_demorados";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCantidadDias = new SqlParameter();
                ParCantidadDias.ParameterName = "@cantdias";
                ParCantidadDias.SqlDbType = SqlDbType.Int;
                ParCantidadDias.Value = servicios.Cantdias;
                cmd.Parameters.Add(ParCantidadDias);

                //SqlParameter ParbuscarTexto = new SqlParameter();
                //ParbuscarTexto.ParameterName = "@matricula";
                //ParbuscarTexto.SqlDbType = SqlDbType.VarChar;
                //ParbuscarTexto.Size = 15;
                //ParbuscarTexto.Value = servicios.TextoBuscar;
                //cmd.Parameters.Add(ParbuscarTexto);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }

        public DataTable CantidadLavados(DServicios servicios)
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "cantidad_lavados";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParbuscarTexto = new SqlParameter();
                ParbuscarTexto.ParameterName = "@matricula";
                ParbuscarTexto.SqlDbType = SqlDbType.VarChar;
                ParbuscarTexto.Size = 15;
                ParbuscarTexto.Value = servicios.TextoBuscar;
                cmd.Parameters.Add(ParbuscarTexto);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }

        public DataTable buscarTelefonoCliente(DServicios servicios)
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "buscar_telefonoclientes";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParbuscarTexto = new SqlParameter();
                ParbuscarTexto.ParameterName = "@texto_buscar";
                ParbuscarTexto.SqlDbType = SqlDbType.VarChar;
                ParbuscarTexto.Size = 15;
                ParbuscarTexto.Value = servicios.TextoBuscar;
                cmd.Parameters.Add(ParbuscarTexto);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }


        public DataTable BuscarFechas(DServicios servicios)
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "buscar_precio";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParfechaInicio = new SqlParameter();
                ParfechaInicio.ParameterName = "@fecha_inicio";
                ParfechaInicio.SqlDbType = SqlDbType.Date;
                ParfechaInicio.Value = servicios.FechaInicio;
                cmd.Parameters.Add(ParfechaInicio);


                SqlParameter ParfechaFinal = new SqlParameter();
                ParfechaFinal.ParameterName = "@fecha_final";
                ParfechaFinal.SqlDbType = SqlDbType.Date;
                ParfechaFinal.Value = servicios.FechaFinal;
                cmd.Parameters.Add(ParfechaFinal);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }

        public DataTable BuscarNombresClientes(DServicios servicios)
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "buscar_nombreclientes";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParbuscarTexto = new SqlParameter();
                ParbuscarTexto.ParameterName = "@texto_buscar";
                ParbuscarTexto.SqlDbType = SqlDbType.VarChar;
                ParbuscarTexto.Size = 50;
                ParbuscarTexto.Value = servicios.TextoBuscar;
                cmd.Parameters.Add(ParbuscarTexto);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }

        public DataTable BuscarMatricula(DServicios servicios)
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "buscar_matricula";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParbuscarTexto = new SqlParameter();
                ParbuscarTexto.ParameterName = "@textobuscar";
                ParbuscarTexto.SqlDbType = SqlDbType.VarChar;
                ParbuscarTexto.Size = 15;
                ParbuscarTexto.Value = servicios.TextoBuscar;
                cmd.Parameters.Add(ParbuscarTexto);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }


        public DataTable GananciaPorFecha(DServicios servicios)
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "ganancia_por_fecha";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechainicio";
                ParFechaInicio.SqlDbType = SqlDbType.Date;
                ParFechaInicio.Value = servicios.FechaInicio;
                cmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaFianl = new SqlParameter();
                ParFechaFianl.ParameterName = "@fechafinal";
                ParFechaFianl.SqlDbType = SqlDbType.Date;
                ParFechaFianl.Value = servicios.FechaFinal;
                cmd.Parameters.Add(ParFechaFianl);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }



        public DataTable BuscarTrabajadorqueatendio(DServicios servicios)
        {
            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "buscar_quien_atendio";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParbuscarTexto = new SqlParameter();
                ParbuscarTexto.ParameterName = "@trabajador";
                ParbuscarTexto.SqlDbType = SqlDbType.Int;
                ParbuscarTexto.Value = servicios.Trabajador;
                cmd.Parameters.Add(ParbuscarTexto);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resultado);


            }
            catch (Exception)
            {

                resultado = null;
            }
            return resultado;
        }

        public DataTable GananciaPorDia(DServicios servicios)
        {

            DataTable resultado = new DataTable("servicios");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.CN;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "gananciadiaria";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaInicio = new SqlParameter();
                ParFechaInicio.ParameterName = "@fechainicio";
                ParFechaInicio.SqlDbType = SqlDbType.Date;
                ParFechaInicio.Value = servicios.FechaInicio;
                cmd.Parameters.Add(ParFechaInicio);

                SqlParameter ParFechaFianl = new SqlParameter();
                ParFechaFianl.ParameterName = "@fechafinal";
                ParFechaFianl.SqlDbType = SqlDbType.Date;
                ParFechaFianl.Value = servicios.FechaFinal;
                cmd.Parameters.Add(ParFechaFianl);

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
