<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="REporte.aspx.cs" Inherits="Capa_Presentacion.REporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div>

    </div>
     
      
        <table class="auto-style1">
            <tr>
                <td>EMPRESA<asp:TextBox ID="txt_cedula" runat="server" Width="284px"></asp:TextBox>
                    <asp:Button ID="btn_generar" runat="server" OnClick="btn_generar_Click" 
                        Text="Generar Reporte" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                        <LocalReport ReportEmbeddedResource="Capa_Presentacion.Report3.rdlc" ReportPath="Report3.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Capa_Presentacion.reportedatosTableAdapters.SP_REPORTETableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txt_cedula" DefaultValue="123456789" Name="EMPID" PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>

        

    </form>
</body>
</html>
