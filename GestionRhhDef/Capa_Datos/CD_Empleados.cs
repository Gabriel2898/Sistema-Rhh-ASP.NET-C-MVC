using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Datos
{
    public class CD_Empleados
    {
        private CD_Conexion connection = new CD_Conexion();
        private SqlDataReader leer;


        public void agregarEmpleados(int carId,int depId, String emplCedula,String emplNombre,String emplApellidos,String emplTelefono,String emplDireccion)
        {
            String sql = "insertar_emplados";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@carid", carId);
            comando.Parameters.AddWithValue("@depid", depId);
            comando.Parameters.AddWithValue("@emplcedula", emplCedula);
            comando.Parameters.AddWithValue("@emplnombres", emplNombre);
            comando.Parameters.AddWithValue("@emplapellidos", emplApellidos);
            comando.Parameters.AddWithValue("@empltelefono", emplTelefono);
            comando.Parameters.AddWithValue("@empldireccion", emplDireccion);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void actualizarEmpleados(int emplId,int carId, int depId, String emplCedula, String emplNombre, String emplApellidos, String emplTelefono, String emplDireccion)
        {
            String sql = "actualizar_emplados";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@emplid", carId);
            comando.Parameters.AddWithValue("@carid", carId);
            comando.Parameters.AddWithValue("@depid", depId);
            comando.Parameters.AddWithValue("@emplcedula", emplCedula);
            comando.Parameters.AddWithValue("@emplnombres", emplNombre);
            comando.Parameters.AddWithValue("@emplapellidos", emplApellidos);
            comando.Parameters.AddWithValue("@empltelefono", emplTelefono);
            comando.Parameters.AddWithValue("@empldireccion", emplDireccion);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
        }

        public void eliminarEmpleados(int emplId)
        {
            String sql = "eliminar_empleados";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@emplid", emplId);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable mostrarEmpleados()
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("seleccionar_empleados", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            return datagrid;
        }

        public DataTable buscarEmpleados(int emplId)
        {
            SqlCommand comando = new SqlCommand();
            DataTable datagrid = new DataTable();
            SqlDataAdapter tabla = new SqlDataAdapter("buscar_empleados", connection.AbrirConexion());
            tabla.SelectCommand.CommandType = CommandType.StoredProcedure;
            tabla.SelectCommand.Parameters.AddWithValue("@emplId", emplId);
            tabla.Fill(datagrid);
            connection.CerrarConexion();
            comando.Parameters.Clear();
            return datagrid;
        }     

    }
}
