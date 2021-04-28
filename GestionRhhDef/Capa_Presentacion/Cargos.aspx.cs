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
    public partial class Cargos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarCargo();
        }
        public void cargarCargo()
        {
            try
            {
                CN_Cargo cargo = new CN_Cargo();
                GrvCargo.DataSource = cargo.verContacto();
                GrvCargo.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            CN_Cargo cargo = new CN_Cargo();
            cargo.eliminarCargo(hf_id.Value);
            cargarCargo();
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {   if(txt_cargo.Text==""){
            lbl_error.Text = "Los Campos son Requeridos";
            } else{
             if(hf_id.Value==""){
            CN_Cargo cargo = new CN_Cargo();
            cargo.agregarCargo(txt_cargo.Text);
            cargarCargo();
            txt_cargo.Text = "";
            
            lbl_error.Text = "Cargo agregado";
            }else{
                CN_Cargo cargo = new CN_Cargo();
                cargo.actualizarCargo(hf_id.Value,txt_cargo.Text);
                cargarCargo();
                hf_id.Value = "";
                txt_cargo.Text = "";
                lbl_error.Text = "Cargo actualizado";
            

            }
            }
           
            
            
        }

        protected void linkVer_Click(object sender, EventArgs e)
        {
            CN_Cargo cargo = new CN_Cargo();
            DataTable tbl = cargo.buscarcargo((sender as LinkButton).CommandArgument);
            hf_id.Value = (sender as LinkButton).CommandArgument;
            txt_cargo.Text = tbl.Rows[0]["CARDESCRIPCION"].ToString();                        
        }
    }
}