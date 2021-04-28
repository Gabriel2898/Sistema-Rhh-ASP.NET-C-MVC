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
    public partial class Familiar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cargarFamiliar();
                cargarCbxEmpleado();
            }
            catch (Exception ex) { lbl_error.Text = "error" + ex; }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            CN_Familiar empresa = new CN_Familiar();
            empresa.eliminarFamiliar(hf_id.Value);
            lbl_error.Text = "registro eliminado";
            txt_nombres.Text = "";
            txt_apellidos.Text = "";
            txt_parentesco.Text = "";
            hf_id.Value = "";
            cargarFamiliar();
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_nombres.Text == "" ||
                txt_apellidos.Text == "" ||
                txt_parentesco.Text == "")
            {
                lbl_error.Text = "Todos los campos son rqueridos";
            }
            else
            {
                if (hf_id.Value == "")
                {
                    CN_Familiar dep = new CN_Familiar();
                    dep.agregarFamiliar(cbx_empleado.SelectedItem.Value, txt_nombres.Text, txt_apellidos.Text, txt_parentesco.Text);
                    lbl_error.Text = "registro agregado";
                    txt_nombres.Text = "";
                    txt_apellidos.Text = "";
                    txt_parentesco.Text = "";
                    hf_id.Value = "";
                    cargarFamiliar();
                }
                else
                {
                    CN_Familiar dep = new CN_Familiar();
                    dep.actualizarFamiliar(hf_id.Value, cbx_empleado.SelectedItem.Value, txt_nombres.Text, txt_apellidos.Text, txt_parentesco.Text);
                    lbl_error.Text = "registro agregado";
                    txt_nombres.Text = "";
                    txt_apellidos.Text = "";
                    txt_parentesco.Text = "";
                    hf_id.Value = "";
                    cargarFamiliar();

                }
            }
        }

        protected void linkVer_Click(object sender, EventArgs e)
        {
            CN_Familiar cargo = new CN_Familiar();
            DataTable tbl = cargo.buscarcargo((sender as LinkButton).CommandArgument);
            hf_id.Value = (sender as LinkButton).CommandArgument;
            txt_nombres.Text = tbl.Rows[0]["FAMNOMBRES"].ToString();
            txt_apellidos.Text = tbl.Rows[0]["FAMAPELLIDOS"].ToString();
            txt_parentesco.Text = tbl.Rows[0]["FAMPARENTESCO"].ToString();
        }

        public void cargarFamiliar()
        {
            try
            {
                CN_Familiar cargo = new CN_Familiar();
                GrvFamiliar.DataSource = cargo.verFamiliar();
                GrvFamiliar.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

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
    }
}