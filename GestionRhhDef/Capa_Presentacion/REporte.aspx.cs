using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;

namespace Capa_Presentacion
{
    public partial class REporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        

        }

        protected void btn_generar_Click(object sender, EventArgs e)
        {
            String cedula = txt_cedula.Text;
            ReportViewer1.LocalReport.Refresh();
        }
    }
}