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
    public class CN_Familiar
    {

        CD_familiar contacto = new CD_familiar();
        DataTable datagrid;

        public void agregarFamiliar(String emplid,String famNombres, String famApellidos, String famParentesco)
        {
            contacto.agregarFamiliar(Convert.ToInt32(emplid),famNombres, famApellidos, famParentesco);
        }

        public void actualizarFamiliar(String famid, String emplid,String famNombres, String famApellidos, String famParentesco)
        {
            contacto.actualizarFamiliar(Convert.ToInt32(famid),Convert.ToInt32(emplid), famNombres, famApellidos, famParentesco);
        }

        public void eliminarFamiliar(String con_id)
        {
            contacto.eliminarFamiliar(Convert.ToInt32(con_id));
        }

        public DataTable verFamiliar()
        {
            datagrid = contacto.mostrarFamiliar();
            return datagrid;
        }

        public DataTable buscarcargo(String id)
        {
            datagrid = contacto.buscarFamiliar(Convert.ToInt32(id));
            return datagrid;
        }

    }
}
