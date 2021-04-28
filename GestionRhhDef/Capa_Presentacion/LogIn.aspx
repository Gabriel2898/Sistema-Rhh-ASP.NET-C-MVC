<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Capa_Presentacion.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LogIn</title>

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
    <h1 class="titulo_form">Sistema de Gestión RHH</h1>
    <br />
    <div class="user_icon">
     <img src="Images/login.png" class="imagenes"/>
    </div>

    <asp:Label runat="server" Text="Usuairo :" ID="lbl_usuario" CssClass="label">
    </asp:Label><br />
    <asp:TextBox runat="server" ID="txt_usuario" CssClass="text"></asp:TextBox>
    <br />
    <br />
    <asp:Label runat="server" Text="Password :" ID="Label1" CssClass="label">
    </asp:Label><br />
    <asp:TextBox runat="server" ID="txt_password" CssClass="text" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Button runat="server" Text="Acceder" ID="btn_logeo" CssClass="boton_form" OnClick="btn_logeo_Click"/>
    <br />

    <asp:Label Text="" ID="lbl_error" runat="server"></asp:Label>
        </div>
    <div class="image">
    <img src="Images/imagen_principal.jpg" class="imagenes"/>
    </div>
    
    </form>
</body>
</html>
