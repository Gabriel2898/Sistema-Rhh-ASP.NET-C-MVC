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
    public partial class Empresa : System.Web.UI.Page
    {

        public void cargarEmpresa()
        {
            try
            {
                CN_Empresa cargo = new CN_Empresa();
                GrvEmpresa.DataSource = cargo.verEmpresa();
                GrvEmpresa.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarEmpresa();
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (txt_empresa.Text == "" ||
            txt_ruc.Text == "" ||
            txt_direccion.Text == "")
            {
                lbl_error.Text = "Todos los campos son requeridos";
            }
            else
            {
                if (hf_id.Value == "")
                {
                    CN_Empresa empresa = new CN_Empresa();
                    empresa.agregarEmpresa(txt_empresa.Text, txt_ruc.Text, txt_direccion.Text);
                    lbl_error.Text = "registro agregado";
                    txt_empresa.Text = "";
                    txt_ruc.Text = "";
                    txt_direccion.Text = "";
                    hf_id.Value = "";
                    cargarEmpresa();
                }
                else
                {
                    CN_Empresa empresa = new CN_Empresa();
                    empresa.actualizarEmpresa(hf_id.Value, txt_empresa.Text, txt_ruc.Text, txt_direccion.Text);
                    lbl_error.Text = "registro actualizado";
                    txt_empresa.Text = "";
                    txt_ruc.Text = "";
                    txt_direccion.Text = "";
                    hf_id.Value = "";
                    cargarEmpresa();

                }
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            CN_Empresa empresa = new CN_Empresa();
            empresa.eliminarEmpresa(hf_id.Value);
            lbl_error.Text = "registro eliminado";
            txt_empresa.Text = "";
            txt_ruc.Text = "";
            txt_direccion.Text = "";
            hf_id.Value = "";
            cargarEmpresa();
        }

        protected void linkVer_Click(object sender, EventArgs e)
        {
            CN_Empresa cargo = new CN_Empresa();
            DataTable tbl = cargo.buscarEmpresa((sender as LinkButton).CommandArgument);
            hf_id.Value = (sender as LinkButton).CommandArgument;
            txt_empresa.Text = tbl.Rows[0]["EMPNOMBRE"].ToString();
            txt_ruc.Text = tbl.Rows[0]["EMPRUC"].ToString();
            txt_direccion.Text = tbl.Rows[0]["EMPDIRECCION"].ToString(); 
        }
    }
}