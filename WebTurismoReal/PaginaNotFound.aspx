<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaNotFound.aspx.cs" Inherits="WebTurismoReal.PaginaNotFound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimun-scale=1.0" />
    <link href="css/Estilo.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Didact+Gothic&family=Lobster&display=swap" rel="stylesheet">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script src="js/sweetAlert2.js"></script>
    <link href="//cdn.jsdelivr.net/npm/@sweetalert2/theme-minimal@4/minimal.css" rel="stylesheet">
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.js"></script>
    <link rel="stylesheet" href="@sweetalert2/themes/minimal/minimal.css">
    <script src="sweetalert2/dist/sweetalert2.min.js"></script>
    <style>
        body {
            margin: 0;
            background-image: url(/assets/img/bg3.jpg);
            background-repeat: no-repeat;
            background-size: cover;
            background-position: top;
            background-attachment: fixed;
            font-family: 'Didact Gothic', sans-serif;
            font-size: 20px;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <nav>
                    <input type="checkbox" id="check" />
                    <label for="check" class="checkbtn">
                        <i class="fas fa-bars"></i>
                    </label>
                    <asp:Label Text="Turismo Real" CssClass="logo" runat="server" />
                    <ul>
                        <li>
                            <a href="/Index">Home</a>
                        </li>
                        <li>
                            <a href="/Servicios">Servicios</a>
                        </li>
                        <li>
                            <a href="/Index">Reservar</a>
                        </li>
                        <%if (Session["IdUsuario"] == null)
                            {%>
                        <li>
                            <a href="/Login">Iniciar sesión</a>
                        </li>
                        <li>
                            <a href="/Registro">Regístrate</a>
                        </li>
                        <%}%>
                        <%else
                            {%>
                        <li>
                            <a href="/CuentaDatos">Mi Cuenta</a>
                        </li>
                        <li>
                            <asp:LinkButton ID="Btn_LogOut" Text="Cerrar sesión" runat="server" OnClick="Btn_LogOut_Click" />
                        </li>
                        <%} %>
                    </ul>
                </nav>
            </div>
            <div style="background-color: white; width: 100%; height: 100%;" class="row">
                <div style="margin: auto; margin: 150px; text-align: left;">
                    <p style="font-weight: 900; font-size: 45px; margin-left: 150px;">LO SENTIMOS, TU RUTA SE HA PERDIDO... :(</p>
                    <br />
                    <p style="text-align: left; margin-left: 150px;">Esto puede ser provocado por:</p>
                    <p style="text-align: left; margin-left: 150px;">• Recargar la página Login o Registro.</p>
                    <p style="text-align: left; margin-left: 150px;">• Ingresar a la página Login o Registro directamente desde la URL.</p>
                    <p style="text-align: left; margin-left: 150px;">• Tu conexión a internet se perdió por un momento.</p>
                    <br />
                    <p style="text-align: left; margin-left: 150px;">No te preocupes, puedes volver a lo que estabas haciendo.</p>
                    <br />
                    <asp:Button ID="BtnLogin" Text="Volver a Home" Style="width: 300px; margin-left: 150px; align-self: flex-start;" CssClass="btn" runat="server" OnClick="BtnLogin_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
