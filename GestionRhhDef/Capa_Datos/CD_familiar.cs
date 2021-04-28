using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_familiar
    {

        private CD_Conexion connection = new CD_Conexion();
        private SqlDataReader leer;


        public void agregarFamiliar(int emplid,String famNombres,String famApellidos,String famParentesco)
        {
            String sql = "insertar_familiares";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@emplid", emplid);
            comando.Parameters.AddWithValue("@famnombres", famNombres);
            comando.Parameters.AddWithValue("@famapellidos", famApellidos);
            comando.Parameters.AddWithValue("@famparentesco", famParentesco);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void actualizarFamiliar(int famid, int emplid, String famNombres, String famApellidos, String famParentesco)
        {
            String sql = "actualizar_familiares";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@famid", famid);
            comando.Parameters.AddWithValue("@emplid", emplid);
            comando.Parameters.AddWithValue("@famnombres", famNombres);
            comando.Parameters.AddWithValue("@famapellidos", famApellidos);
            comando.Parameters.AddWithValue("@famparentesco", famParentesco);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void eliminarFamiliar(int famid)
        {
            String sql = "eleminar_familiares";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("famid", famid);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable mostrarFamiliar()
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("seleccionar_familiares", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            return datagrid;
        }

        public DataTable buscarFamiliar(int id)
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("buscar_familiares", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.SelectCommand.Parameters.AddWithValue("@famid", id);
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            comando.Parameters.Clear();
            return datagrid;
        }     

    }
}
