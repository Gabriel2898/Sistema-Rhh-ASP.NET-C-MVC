using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Empresa
    {
        private CD_Conexion connection = new CD_Conexion();
        private SqlDataReader leer;


        public void agregarEmpresa(String empresa,String ruc,String direccion)
        {
            String sql = "insertar_empresa";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@empnombre", empresa);
            comando.Parameters.AddWithValue("@empruc", ruc);
            comando.Parameters.AddWithValue("@empdireccion", direccion);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void actualizarEmpresa(int id, String empresa, String ruc, String direccion)
        {
            String sql = "actualizar_empresa";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@empid", id);
            comando.Parameters.AddWithValue("@empnombre", empresa);
            comando.Parameters.AddWithValue("@empruc", ruc);
            comando.Parameters.AddWithValue("@empdireccion", direccion);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void eliminarEmpresa(int id)
        {
            String sql = "eliminar_empresa";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@empid", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable mostrarEmpresa()
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("seleccionar_empresa", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            return datagrid;
        }

        public DataTable buscarEmpresa(int id)
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("buscar_empresa", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.SelectCommand.Parameters.AddWithValue("@empid", id);
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            comando.Parameters.Clear();
            return datagrid;
        }
     
    

    }
}
