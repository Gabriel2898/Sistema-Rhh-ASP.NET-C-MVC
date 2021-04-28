using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Capa_Negocio;
namespace Capa_Presentacion
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarEmpleados();
            cargarCbxDepartamentos();
            cargarCbxCargos();
        }

        protected void linkVer_Click(object sender, EventArgs e)
        {
            CN_Empleados cargo = new CN_Empleados();
            DataTable tbl = cargo.buscarEmpleados((sender as LinkButton).CommandArgument);
            hf_id.Value = (sender as LinkButton).CommandArgument;
            txt_cedula.Text = tbl.Rows[0]["EMPLCEDULA"].ToString();
            txt_nombres.Text = tbl.Rows[0]["EMPLNOMBRES"].ToString();
            txt_apellidos.Text = tbl.Rows[0]["EMPLAPELLIDOS"].ToString();
            txt_telefono.Text = tbl.Rows[0]["EMPLTELEFONO"].ToString();
            txt_direccion.Text = tbl.Rows[0]["EMPLDIRECCION"].ToString();
                        
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            CN_Empleados empresa = new CN_Empleados();
            empresa.eliminarEmpleados(hf_id.Value);
            lbl_error.Text = "registro eliminado";
            txt_cedula.Text = "";
            txt_nombres.Text = "";
            txt_apellidos.Text = "";
            txt_telefono.Text = "";
            txt_direccion.Text = "";
            hf_id.Value = "";
            cargarEmpleados();
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
         
        }

        protected void btn_guardar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (txt_cedula.Text == "" ||
                txt_nombres.Text == "" ||
                txt_apellidos.Text == "" ||
                txt_telefono.Text == "" ||
                txt_direccion.Text == "" )
                {
                    lbl_error.Text = "Los Campos Son requeridos";
                }
                else
                {   CN_Empleados ot = new CN_Empleados();
                    if(!ot.ValidarCedula(txt_cedula.Text)){
                        lbl_error.Text = "La Cedula no es válida";
                    }else{

                    if (hf_id.Value == "")
                    {
                        CN_Empleados dep = new CN_Empleados();
                        dep.agregarEmpleados(cbx_cargo.Text, cbx_departamento.Text, txt_cedula.Text, txt_nombres.Text, txt_apellidos.Text, txt_telefono.Text, txt_direccion.Text);
                        lbl_error.Text = "registro agregado";
                        txt_cedula.Text = "";
                        txt_nombres.Text = "";
                        txt_apellidos.Text = "";
                        txt_telefono.Text = "";
                        txt_direccion.Text = "";
                        hf_id.Value = "";
                        cargarEmpleados();
                    }
                    else
                    {
                        CN_Empleados dep = new CN_Empleados();
                        dep.actualizarEmpleados(hf_id.Value, cbx_cargo.Text, cbx_departamento.Text, txt_cedula.Text, txt_nombres.Text, txt_apellidos.Text, txt_telefono.Text, txt_direccion.Text);
                        lbl_error.Text = "registro actualizado";
                        txt_cedula.Text = "";
                        txt_nombres.Text = "";
                        txt_apellidos.Text = "";
                        txt_telefono.Text = "";
                        txt_direccion.Text = "";
                        hf_id.Value = "";
                        cargarEmpleados();

                    }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_error.Text = "error" + ex;
            }
        }

        public void cargarEmpleados()
        {
            try
            {
                CN_Empleados cargo = new CN_Empleados();
                GrvEmpleados.DataSource = cargo.verEmpleados();
                GrvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

        }


        public void cargarCbxCargos()
        {
            try
            {
                CN_Cargo empr = new CN_Cargo();
                cbx_cargo.DataSource = empr.verContacto();
                cbx_cargo.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

        }

        public void cargarCbxDepartamentos()
        {
            try
            {
                CN_Departamento empr = new CN_Departamento();
                cbx_departamento.DataSource = empr.verDepartamento();
                cbx_departamento.DataBind();
            }
            catch (Exception ex)
            {
                lbl_error.Text = "Error" + ex;
            }

        }
    }
}