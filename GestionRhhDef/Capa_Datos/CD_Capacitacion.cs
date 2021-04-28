using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Capacitacion
    {

        private CD_Conexion connection = new CD_Conexion();
        private SqlDataReader leer;


        public void agregarCapacitacion(int emplid, String capDescripcion,DateTime capFechaInicio,DateTime capFechafin)
        {
            String sql = "insertar_capacitaciones";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@emplid", emplid);
            comando.Parameters.AddWithValue("@capdescripcion", capDescripcion);
            comando.Parameters.AddWithValue("@capfechainicio", capFechaInicio);
            comando.Parameters.AddWithValue("@capfechafin", capFechafin); 
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void actualizarCapacitacion(int capId, int emplid, String capDescripcion, DateTime capFechaInicio, DateTime capFechafin)
        {
            String sql = "actualizar_capacitaciones";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@capid", capId);
            comando.Parameters.AddWithValue("@emplid", emplid);            
            comando.Parameters.AddWithValue("@capdescripcion", capDescripcion);
            comando.Parameters.AddWithValue("@capfechainicio", capFechaInicio);
            comando.Parameters.AddWithValue("@capfechafin", capFechafin); 
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void eliminarCapacitacion(int capId)
        {
            String sql = "eliminar_capacitaciones";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@capid", capId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable mostrarCapacitacion()
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("seleccionar_capacitaciones", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            return datagrid;
        }

        public DataTable buscarCapacitacion(int emplId)
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("buscar_capacitaciones", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.SelectCommand.Parameters.AddWithValue("@capid", emplId);
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            comando.Parameters.Clear();
            return datagrid;
        }     

    }
}
