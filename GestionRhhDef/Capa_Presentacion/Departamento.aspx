<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Departamento.aspx.cs" Inherits="Capa_Presentacion.Departamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Departamento</title>

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
            width:750px;
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
            width:100%;
            height:100%;
        }
    </style>

</head>


<body>
    <form id="form1" runat="server">
    
    <div class="form">
    <h1 class="titulo_form">Gestión de Departaentos</h1>
    <br />    
    <asp:HiddenField runat="server" ID="hf_id" />
    <asp:Label runat="server" Text="EMPRESA :" ID="Label1" CssClass="label"></asp:Label>
    <br />
   <asp:DropDownList runat="server" ID="cbx_empresa" DataTextField="EMPNOMBRE" DataValueField="EMPID" CssClass="text" AutoPostBack="true">

   </asp:DropDownList>
    <br />  
    <br />
    <asp:Label runat="server" Text="DEPARTAMENTO :" ID="Label2" CssClass="label">
    </asp:Label><br />
    <asp:TextBox runat="server" ID="txt_departamento" CssClass="text"  Onkeypress="return soloLetras(event)"></asp:TextBox>
    <br />    
    <br />
    <asp:Button Text="Guardar" ID="btn_Guardar"  runat="server" CssClass="boton_form" OnClick="btn_Guardar_Click" />
    <br />
    <asp:Button Text="Eliminar" ID="btn_eliminar"  runat="server" CssClass="boton_form" OnClick="btn_eliminar_Click" />
    <asp:Label Text="" ID="lbl_error" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="GrvDepartamento" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DEPID" HeaderText="CODIGO" />
                    <asp:BoundField DataField="EMPRESA" HeaderText="EMPRESA" />                    
                    <asp:BoundField DataField="DEPNOMBRE" HeaderText="DEPARTAMENTO" />                                        
                    <asp:TemplateField HeaderText="Accion">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkVer" runat="server" CommandArgument='<%# Eval("DEPID")%>' OnClick="linkVer_Click" >VER</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    <div class="image">
    <img src="Images/imagen_principal.jpg" class="imagenes"/>
    </div>
    
    </form>
    <script src="jquery/validacion.js"></script>
</body>
</html>
