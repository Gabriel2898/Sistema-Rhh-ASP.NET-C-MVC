using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Negocio
{
    public class CN_LogIn
    {
        private CD_LogIn logear = new CD_LogIn();

        public SqlDataReader iniciarSesion(String user, String pass)
        {
            SqlDataReader log;
            log = logear.iniciarSesion(user, pass);
            return log;
        }

        public SqlDataReader validarUsuario(String user)
        {
            SqlDataReader log;
            log = logear.validarUsuario(user);
            return log;
        }
    }
}
