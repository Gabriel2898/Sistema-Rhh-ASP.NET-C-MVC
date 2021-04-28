using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class CD_Departamento
    {
        private CD_Conexion connection = new CD_Conexion();
        private SqlDataReader leer;


        public void agregarDepartamento(int empId, String depNombre)
        {
            String sql = "insertar_departamentos";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@empid", empId);
            comando.Parameters.AddWithValue("@depnombre", depNombre);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void actualizarDepartamento(int id, int empId, String depNombre)
        {
            String sql = "actualizar_departamentos";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@depid", id);
            comando.Parameters.AddWithValue("@empid", empId);
            comando.Parameters.AddWithValue("@depnombre", depNombre);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void eliminarDepartamento(int con_id)
        {
            String sql = "eliminar_departamentos";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@depid", con_id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable mostrarDepartamento()
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("seleccionar_departamentos", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            return datagrid;
        }

        public DataTable buscarDepartamento(int id)
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("buscar_departamentos", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.SelectCommand.Parameters.AddWithValue("@depid", id);
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            comando.Parameters.Clear();
            return datagrid;
        }     

    }
}
