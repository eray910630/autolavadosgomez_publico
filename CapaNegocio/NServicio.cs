using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NServicio
    {
        public static string Insertar(string nombre_cliente,string telefono_cliente,string tipocoche,string matricula,string tipo_lavados,decimal precio,int atendidopor,DateTime fecha)
        {
            DServicios obj = new DServicios();
            obj.Fecha = fecha;
            obj.NombreCliente = nombre_cliente;
            obj.TelefonoCliente = telefono_cliente;
            obj.TipoCoches = tipocoche;
            obj.Matricula = matricula;
            obj.TipoLavados = tipo_lavados;
            obj.Precio = precio;
            obj.AtendidoPor = atendidopor;
            
            return obj.Insertar(obj);
        }

        // Metodo editar 

        public static string Editar(int idservicio, string nombre_cliente, string telefono_cliente, string tipocoche, string matricula, string tipo_lavados, decimal precio, int atendidopor, DateTime fecha)
        {
            DServicios obj = new DServicios();
            obj.Fecha = fecha;
            obj.IdServicios = idservicio;
            obj.NombreCliente = nombre_cliente;
            obj.TelefonoCliente = telefono_cliente;
            obj.TipoCoches = tipocoche;
            obj.Matricula = matricula;
            obj.TipoLavados = tipo_lavados;
            obj.Precio = precio;
            obj.AtendidoPor = atendidopor;
            return obj.Editar(obj);
        }


        public static string Eliminar(int idservicios)
        {
            DServicios obj = new DServicios();
            obj.IdServicios = idservicios;
            return obj.Eliminar(obj);
        }

        // Metodo Mostrar Clientes

        public static DataTable Mostrar()
        {
            return new DServicios().Mostrar();
        }


        public static DataTable BuscarTipoCoches(string textobuscar)
        {

            DServicios obj = new DServicios();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarTipoCoches(obj);

        }

        public static DataTable CochesDemorados(int cantdias)
        {

            DServicios obj = new DServicios();
            obj.Cantdias = cantdias;
            
            return obj.CochesDemorados(obj);

        }

        public static DataTable CantidadLavados(string matricula)
        {

            DServicios obj = new DServicios();       
            obj.TextoBuscar = matricula;
            return obj.CantidadLavados(obj);

        }


        public static DataTable buscarTelefonoCliente(string textobuscar)
        {

            DServicios obj = new DServicios();
            obj.TextoBuscar = textobuscar;
            return obj.buscarTelefonoCliente(obj);

        }

        public static DataTable BuscarFechas(DateTime fecha1,DateTime fecha2)
        {

            DServicios obj = new DServicios();
            obj.FechaInicio = fecha1;
            obj.FechaFinal = fecha2;
            return obj.BuscarFechas(obj);

        }

        public static DataTable BuscarNombresClientes(string textobuscar)
        {

            DServicios obj = new DServicios();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombresClientes(obj);

        }

        public static DataTable BuscarMatricula(string textobuscar)
        {

            DServicios obj = new DServicios();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarMatricula(obj);

        }

        public static DataTable GananciaPorFecha(DateTime fechainicio, DateTime fechafinal)
        {
            DServicios obj = new DServicios();
            obj.FechaInicio = fechainicio;
            obj.FechaFinal = fechafinal;
            return obj.GananciaPorFecha(obj);
        
        }

        public static DataTable GananciaPorDias(DateTime fechainicio, DateTime fechafinal)
        {
            DServicios obj = new DServicios();
            obj.FechaInicio = fechainicio;
            obj.FechaFinal = fechafinal;
            return obj.GananciaPorDia(obj);

        }

        public static DataTable Trabajadorqatendioelcoche(int trabajador)
        {
            DServicios obj = new DServicios();
            obj.Trabajador = trabajador;       
            return obj.BuscarTrabajadorqueatendio(obj);

        }

    }
}
