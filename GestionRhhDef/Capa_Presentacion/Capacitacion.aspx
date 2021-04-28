<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Capacitacion.aspx.cs" Inherits="Capa_Presentacion.Capacitacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Familiar</title>

   <style>      
        .form
        {
            width:500px;
            height:500px;
            border-radius:5px;
            padding:30px;            
            background:#808080;
            float:left;
        }
        .user_icon
        {
            width:150px;
            height:150px;
            background:#4cff00;            
            border-radius:3px;
            margin-left:90px;
        }
        .image
        {
            float:right;
            background:#ff6a00;
            width:500px;
            height:550px;
            
            border-radius:5px;
        }
        .titulo_form
        {

        }
        .text
        {
            padding:5px;
            width:60%;

        }
        .boton_form
        {
            background-color:#ffffff;
            width:200px;
            height:auto;
            padding:5px;
            width:62%;
        }
        .label
        {
            width:100px;
            padding:3px;
            font:12px;
            font-family:Arial;
            font-style:inherit;
        }
        .imagenes
        {
            width:84%;
            height:100%;
           margin-right: 0px;
       }
    </style>

</head>


<body>
    <form id="form1" runat="server">
    
    <div class="form">
    <h1 class="titulo_form">Gestión de Familiar</h1>
    <br />    
    <asp:HiddenField runat="server" ID="hf_id" />
    <br />
        <asp:Label runat="server" Text="EMPLEADO :" ID="Label3" CssClass="label"></asp:Label>
    <br />
        <asp:DropDownList ID="cbx_empleado" runat="server" AutoPostBack="True" 
            Height="16px" Width="304px">
        </asp:DropDownList>
    <br /> 
     <asp:Label runat="server" Text="CAPACITACION :" ID="lbl_cedula" CssClass="label"></asp:Label> 
   <br />
   <asp:TextBox runat="server" ID="txt_capacitacion" CssClass="text"  Onkeypress="return soloLetras(event)"></asp:TextBox>
        <br />
        <br />
        FECHA INICIO<br />
        <asp:Calendar ID="txt_fechaInicio" runat="server"></asp:Calendar>
        FECHA FIN<br />
        <asp:Calendar ID="txt_fechaFin" runat="server"></asp:Calendar>
        <br />
 <br />
 
 <asp:Label Text="" ID="lbl_error" runat="server"></asp:Label>
 <br />
    <asp:Button Text="ELIMINAR" ID="btn_eliminar"  runat="server" CssClass="boton_form" OnClick="btn_eliminar_Click" />
    <br />
    <br />
    <asp:Button Text="GUARDAR" ID="btn_guardar"  runat="server" CssClass="boton_form" OnClick="btn_guardar_Click" />
    
    <br />
    <asp:GridView ID="GrvCapacitacion" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GrvCapacitacion_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="CAPID" HeaderText="CODIGO" />
                    <asp:BoundField DataField="EMPLID" HeaderText="EMPLEADO" />                    
                    <asp:BoundField DataField="CAPDESCRIPCION" HeaderText="NOMBRES" /> 
                    <asp:BoundField DataField="CAPFECHAINICIO" HeaderText="FECHA INICIO" /> 
                    <asp:BoundField DataField="CAPFECHAFIN" HeaderText="FECHA FIN " />                                                                                  
                    <asp:TemplateField HeaderText="Accion">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkVer" runat="server" CommandArgument='<%# Eval("CAPID")%>' OnClick="linkVer_Click" >VER</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    <div class="image">
    &nbsp;<img src="Images/imagen_principal.jpg" class="imagenes"/></div>
    
    </form>
    <script src="jquery/validacion.js"></script>
</body>
</html>