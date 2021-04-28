<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Capa_Presentacion.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     
        <!-- Our CSS stylesheet file -->
        <link rel="stylesheet" href="Css/styles.css" />
        
        <!-- Including the Lobster font from Google's Font Directory -->
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Lobster" />
        
        <!-- Enabling HTML5 support for Internet Explorer -->
        <!--[if lt IE 9]>
          <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->
</head>

    
    <body>

        <header>
            <h1>CSS3 Animated Navigation Menu</h1>
            <h2><a href="http://tutorialzine.com/2011/05/css3-animated-navigation-menu/">&laquo; Read and download on Tutorialzine</a></h2>
        </header>
        
        <nav>
            <ul class="fancyNav">
                <li id="home"><a href="Empresa.aspx" >Empresa</a></li>
                <li id="news"><a href="Departamento.aspx">Departamentos</a></li>                
                <li id="services"><a href="Cargos.aspx">Cargos</a></li>
                <li id="contact"><a href="Empleados.aspx">Empleados</a></li>
                <li id="about"><a href="#about">Referencias</a></li>
                <li id="Li1"><a href="Capacitacion.aspx">Capacitaciones</a></li>
                <li id="Li2"><a href="Familiar.aspx">Familiares</a></li>
                <li id="Li3"><a href="REporte.aspx">Reporte</a></li>
            </ul>
        </nav>
        
        <footer>Looks best in Firefox 4, usable everywhere. <b>To download the source code, visit <a href="http://tutorialzine.com/2011/05/css3-animated-navigation-menu/">Tutorialzine.com</a></b></footer>
            
    </body>
</html>
