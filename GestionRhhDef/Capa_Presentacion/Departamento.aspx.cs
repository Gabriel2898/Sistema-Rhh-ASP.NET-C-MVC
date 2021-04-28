using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Negocio;
using System.Data.SqlClient;
using System.Data;
namespace Capa_Presentacion
{
    public partial class Departamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDepartamento();
            cargarCbxEmpresa();
        }

        protected void linkVer_Click(object sender, EventArgs e)
        {
            CN_Departamento cargo = new CN_Departamento();
            DataTable tbl = cargo.buscarDepartamento((sender as LinkButton).CommandArgument);
            hf_id.Value = (sender as LinkButton).CommandArgument;
            txt_departamento.Text = tbl.Rows[0]["DEPNOMBRE"].ToString();
                        
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            CN_Departamento empresa = new CN_Departamento();
            empresa.eliminarDepartamento(hf_id.Value);
            lbl_error.Text = "registro eliminado";
            txt_departamento.Text = "";            
            hf_id.Value = "";
            cargarDepartamento();
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (txt_departamento.Text == "")
            {
                lbl_error.Text = "Los campos son requeridos";
            }else{
            if (hf_id.Value == "")
            {
                CN_Departamento dep = new CN_Departamento();
                dep.agregarDepartamento(Convert.ToInt32(cbx_empresa.SelectedItem.Selected), txt_departamento.Text);
                lbl_error.Text = "registro agregado";
                txt_departamento.Text = "";               
                hf_id.Value = "";
                cargarDepartamento();
            }
            else
            {
                CN_Departamento dep = new CN_Departamento();
                dep.actualizarDepartamento(hf_id.Value, Convert.ToInt32(cbx_empresa.SelectedItem.Selected), txt_departamento.Text);
                lbl_error.Text = "registro actualizado";
                txt_departamento.Text = "";
                hf_id.Value = "";
                cargarDepartamento();

            }
            }
        }

        public void cargarDepartamento()
        {
            try
            {
                CN_Departamento cargo = new CN_Departamento();
                GrvDepartamento.DataSource = cargo.verDepartamento();
                GrvDepartamento.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

        }
        public void cargarCbxEmpresa()
        {
            try
            {
                CN_Empresa empr = new CN_Empresa();
                cbx_empresa.DataSource = empr.verEmpresa();
                cbx_empresa.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

        }
    }
}