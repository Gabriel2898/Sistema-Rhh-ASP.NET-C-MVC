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
    public class CN_Empresa
    {

        CD_Empresa contacto = new CD_Empresa();
        DataTable datagrid;

        public void agregarEmpresa(String empresa, String ruc, String direccion)
        {
            contacto.agregarEmpresa(empresa,ruc,direccion);
        }

        public void actualizarEmpresa(String id, String empresa, String ruc, String direccion)
        {
            contacto.actualizarEmpresa(Convert.ToInt32(id), empresa, ruc, direccion);
        }

        public void eliminarEmpresa(String con_id)
        {
            contacto.eliminarEmpresa(Convert.ToInt32(con_id));
        }

        public DataTable verEmpresa()
        {
            datagrid = contacto.mostrarEmpresa();
            return datagrid;
        }

        public DataTable buscarEmpresa(String id)
        {
            datagrid = contacto.buscarEmpresa(Convert.ToInt32(id));
            return datagrid;
        }

    }
}
