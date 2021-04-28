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
    public class CN_Cargo
    {
        CD_Cargo contacto = new CD_Cargo();
        DataTable datagrid;

        public void agregarCargo(String cargo)
        {
            contacto.agregarCargo(cargo);
        }

        public void actualizarCargo(String id, String cargo)
        {
            contacto.actualizarCargo(Convert.ToInt32(id),cargo);
        }

        public void eliminarCargo(String con_id)
        {
            contacto.eliminarCargo(Convert.ToInt32(con_id));
        }

        public DataTable verContacto()
        {
            datagrid = contacto.mostrarCargo();
            return datagrid;
        }

        public DataTable buscarcargo(String id)
        {
            datagrid = contacto.buscarCargo(Convert.ToInt32(id));
            return datagrid;
        }

    }
}
