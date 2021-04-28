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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btn_logeo_Click(object sender, EventArgs e)
        {
            if(txt_usuario.Text=="" || txt_password.Text==""){
                lbl_error.Text = "todos los campos son requeridos";
            }else{
            CN_LogIn  log= new CN_LogIn();
            SqlDataReader logear;
            logear = log.validarUsuario(txt_usuario.Text);
            if (logear.Read() == true)
            {
                log = new CN_LogIn();
                logear = log.iniciarSesion(txt_usuario.Text, txt_password.Text);
            if (logear.Read() == true)
            {
                Response.Redirect("Menu.aspx");
            }
            else
            {
                lbl_error.Text = "LA CONTRASEÑA ES INCORRECTA";
            }
            }else{
             lbl_error.Text = "EL USUARIO NO EXISTE";
            }
            }
        }

       
    }
}