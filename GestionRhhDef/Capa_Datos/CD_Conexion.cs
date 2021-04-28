using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Capa_Datos
{
    public class CD_Conexion
    {

        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-CQ9HEUB;Initial Catalog=GESTIONRHHDEF;Integrated Security=True;");


        public SqlConnection AbrirConexion()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }

        public SqlConnection CerrarConexion()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            return connection;
        }
    }
}
