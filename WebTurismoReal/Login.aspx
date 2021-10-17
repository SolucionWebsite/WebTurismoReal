<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebTurismoReal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimun-scale=1.0" />
    <link href="css/Estilo.css" rel="stylesheet" type="text/css"/>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Didact+Gothic&family=Lobster&display=swap" rel="stylesheet">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script src="js/sweetAlert2.js" ></script>
    <link href="//cdn.jsdelivr.net/npm/@sweetalert2/theme-minimal@4/minimal.css" rel="stylesheet">
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.js"></script>
    <link rel="stylesheet" href="@sweetalert2/themes/minimal/minimal.css">
    <script src="sweetalert2/dist/sweetalert2.min.js"></script>
    <style>
        .progreso {
    background-color: #117A65;
    position: absolute;
    top: 50%;
    left: 0;
    transform: translateY(-50%);
    height: 2px;
    width: 50%;
    z-index: -1;
    transition: 0.4s ease;
    }
</style>
</head>
<body>
    <div class="container" >
            <div class="row" >
                <nav>  
            <input type="checkbox" id="check"/>
            <label for="check" class="checkbtn">
                <i class="fas fa-bars">
                </i>
            </label>
            <asp:Label Text="Turismo Real" CssClass="logo" runat="server" />
            <ul>
                <li>
                    <a href="/Index" >Home</a>
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
                    <a href="/Login">Log in</a>
                    </li>
                    <%}%>
                   <%else
                    {%>
                    <li>
                    <a href="/CuentaDatos">Mi Cuenta</a>
                    </li>
                    <%} %>
            </ul>
        </nav>
            </div>
            <div class="row">
                <form id="form1" runat="server">
                    <div class="contenedor-50">   
                <div class="progreso-contenedor">   
                    <div class="progreso" id="progreso"></div>
                    <asp:Button ID="Btn_1" Text="1" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_2" Text="2" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_3" Text="3" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_4" Text="4" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_5" Text="5" CssClass="redondo" runat="server" />
                </div>
                </div>
                    <div class="card-login">
                        <div  style="margin: 20px;">
                            <h5>Inicia Sesión</h5>
                            <table class="tabla" >
                                <tr>
                                    <td>
                                        <fieldset>
                                        <legend>Correo</legend>
                                        <div><asp:TextBox runat="server" placeholder="Ingresa tu correo" legend="Correo" class="form-control" type="email" ID="txt_usuario" />
                                        </div>
                                        </fieldset>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_usuario" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu correo" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <fieldset>
                                        <legend>Contraseña</legend>
                                        <div><asp:TextBox runat="server" TextMode="Password" placeholder="Ingresa tu contraseña" type="password" class="form-control" ID="txt_clave" />
                                        </div>
                                        </fieldset>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_clave" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu contraseña" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        <br />
                                    </td>
                                </tr>
                                
                            </table>
                            <asp:Button type="button" class="btn" ID="Btn_Login" runat="server" Text="Ingresar"  ValidationGroup="Validador" OnClick="Btn_Login_Click"/>
                            <br />
                            <div class="footer">
                                <div class="row" style="border-top: 2px white solid; margin-top: 20px;">
                                    <p class="line">¿Aún no tienes una cuenta?</p>
                                    <a class="line" href="/Registro" style="color:black">Regístrate</a>
                                </div>
                      </div>
                        </div>
                    </div>
            </form>
            </div>
            
        </div>
</body>
</html>
