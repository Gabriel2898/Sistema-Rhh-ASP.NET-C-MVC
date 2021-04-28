using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Negocio;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Presentacion
{
    public partial class Capacitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarCbxEmpleado();
            cargarCapacitacion();
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_capacitacion.Text == "")
            {
                lbl_error.Text = "campos requeridos";
            }
            else
            {
                if (hf_id.Value == "")
                {
                    CN_Capacitacion dep = new CN_Capacitacion();
                    dep.agregarCapacitacion(cbx_empleado.SelectedItem.Value, txt_capacitacion.Text, Convert.ToString(txt_fechaInicio.SelectedDate), Convert.ToString(txt_fechaFin.SelectedDate));
                    lbl_error.Text = "registro agregado";
                    txt_capacitacion.Text = "";
                    hf_id.Value = "";
                    cargarCapacitacion();
                }
                else
                {
                    CN_Capacitacion dep = new CN_Capacitacion();
                    dep.actualizarCapacitacion(hf_id.Value, cbx_empleado.SelectedItem.Value, txt_capacitacion.Text, Convert.ToString(txt_fechaInicio.SelectedDate), Convert.ToString(txt_fechaFin.SelectedDate));
                    lbl_error.Text = "registro agregado";
                    txt_capacitacion.Text = "";
                    hf_id.Value = "";
                    cargarCapacitacion();

                }
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            CN_Capacitacion dep = new CN_Capacitacion();
            dep.eliminarCapacitacion(hf_id.Value);
            lbl_error.Text = "registro eliminado";
            txt_capacitacion.Text = "";
            hf_id.Value = "";
            cargarCapacitacion();

        }

        protected void linkVer_Click(object sender, EventArgs e)
        {
            CN_Capacitacion dep = new CN_Capacitacion();
            DataTable tbl = dep.buscarCapacitacion((sender as LinkButton).CommandArgument);
            hf_id.Value = (sender as LinkButton).CommandArgument;
            txt_capacitacion.Text = tbl.Rows[0]["CAPDESCRIPCION"].ToString();
           
        }
        public void cargarCbxEmpleado()
        {
            try
            {
                CN_Empleados empr = new CN_Empleados();
                cbx_empleado.DataSource = empr.verEmpleados();
                cbx_empleado.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

        }

        public void cargarCapacitacion()
        {
            try
            {
                CN_Capacitacion cargo = new CN_Capacitacion();
                GrvCapacitacion.DataSource = cargo.verCapacitacion();
                GrvCapacitacion.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

        }

        protected void GrvCapacitacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}