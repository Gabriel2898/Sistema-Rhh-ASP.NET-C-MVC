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
    public class CN_Capacitacion
    {
        CD_Capacitacion contacto = new CD_Capacitacion();
        DataTable datagrid;

        public void agregarCapacitacion(String emplid, String capDescripcion, String capFechaInicio, String capFechaFin)
        {
            contacto.agregarCapacitacion(Convert.ToInt32(emplid), capDescripcion, Convert.ToDateTime(capFechaInicio), Convert.ToDateTime(capFechaFin));
        }

        public void actualizarCapacitacion(String capId, String emplid, String capDescripcion, String capFechaInicio, String capFechaFin)
        {
            contacto.actualizarCapacitacion(Convert.ToInt32(capId), Convert.ToInt32(emplid), capDescripcion, Convert.ToDateTime(capFechaInicio), Convert.ToDateTime(capFechaFin));
        }

        public void eliminarCapacitacion(String con_id)
        {
            contacto.eliminarCapacitacion(Convert.ToInt32(con_id));
        }

        public DataTable verCapacitacion()
        {
            datagrid = contacto.mostrarCapacitacion();
            return datagrid;
        }

        public DataTable buscarCapacitacion(String id)
        {
            datagrid = contacto.buscarCapacitacion(Convert.ToInt32(id));
            return datagrid;
        }

    }
}
