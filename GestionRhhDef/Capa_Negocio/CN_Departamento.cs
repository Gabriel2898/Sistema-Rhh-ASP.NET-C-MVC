using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;
namespace Capa_Negocio
{
    public class CN_Departamento
    {
        CD_Departamento contacto = new CD_Departamento();
        DataTable datagrid;

        public void agregarDepartamento(int empId, String depNombre)
        {
            contacto.agregarDepartamento(empId,depNombre);
        }

        public void actualizarDepartamento(String id, int empId, String depNombre)
        {
            contacto.actualizarDepartamento(Convert.ToInt32(id), empId, depNombre);
        }

        public void eliminarDepartamento(String con_id)
        {
            contacto.eliminarDepartamento(Convert.ToInt32(con_id));
        }

        public DataTable verDepartamento()
        {
            datagrid = contacto.mostrarDepartamento();
            return datagrid;
        }

        public DataTable buscarDepartamento(String id)
        {
            datagrid = contacto.buscarDepartamento(Convert.ToInt32(id));
            return datagrid;
        }
    }
}
