using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_LogIn
    {

        private CD_Conexion connection = new CD_Conexion();
        private SqlDataReader leer;

        public SqlDataReader iniciarSesion(String user, String pass)
        {
            String sql = "logeo";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuusuario", user);
            comando.Parameters.AddWithValue("@usupassword", pass);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            return leer;
        }

        public SqlDataReader validarUsuario(String user)
        {
            String sql = "validar_usuario";
            SqlCommand comando = new SqlCommand(sql);
            comando.Connection = connection.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuusuario", user);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            return leer;
        }
    }
}
