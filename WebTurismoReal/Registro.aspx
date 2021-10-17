<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebTurismoReal.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro</title>
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
    <script>
        function TelefonoNoValido() {
            Swal.fire({
                  icon: 'warning',
                  title: 'Oops...',
                  text: 'Faltan dígitos en tu número de teléfono, deben ser 8 números!',
                  iconColor: '#117A65',
                  confirmButtonColor: '#117A65'
                })
        }
        function Imposible() {
            Swal.fire({
                  icon: 'warning',
                  title: 'Oops, revisa la fecha de nacimiento...',
                  text: 'La fecha no puede ser mayor a la fecha de hoy!',
                  iconColor: '#117A65',
                  confirmButtonColor: '#117A65'
                })
        }
        function Exitoso() {
            swal.fire({
                title: "Registro exitoso",
                text: 'Presiona continuar para ingresar con tu correo y contraseña',
                type: "success",
                    confirmButtonText: 'Continuar',
                    confirmButtonColor: '#117A65',
                    showCloseButton: true,
                    iconColor: '#117A65'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = "/Login";
                }
            }
               );
        }
        function Existente() {
            Swal.fire({
                  icon: 'warning',
                  title: 'Oops...',
                  text: 'Ya existe un registro con estos datos!',
                  iconColor: '#117A65',
                  confirmButtonColor: '#117A65'
                })
        }
        function Error() {
            Swal.fire({
                  icon: 'warning',
                  title: 'Error :(',
                  text: 'Algo ocurrió!',
                  iconColor: '#117A65',
                  confirmButtonColor: '#117A65'
                })
        }
    </script>
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
            <div class="row" >
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
                    <div class="card-login" style="margin-top:0px;">
                        <div class="card-" style="margin: 10px;">
                            <h5>Regístrate</h5>
                            <table class="tabla" >
                                <tr>
                                    <td class="auto-style1">Primer nombre</td>
                                    <td>
                                        <asp:TextBox runat="server" placeholder="Ingresa tu nombre" class="form-control1" type="texbox" ID="TxtNombre" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu nombre" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator  runat="server" ErrorMessage="No se permiten carácteres especiales" 
                                        ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="TxtNombre" Display="Dynamic" ForeColor="white" 
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Apellido paterno</td>
                                    <td>
                                        <asp:TextBox runat="server" placeholder="Ingresa tu apellido paterno" class="form-control1" type="texbox" ID="TxtApellidoP" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtApellidoP" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu apellido paterno" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator  runat="server" ErrorMessage="No se permiten carácteres especiales" 
                                        ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="TxtApellidoP" Display="Dynamic" ForeColor="white" 
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Apellido materno</td>
                                    <td>
                                        <asp:TextBox runat="server" placeholder="Ingresa tu apellido materno" class="form-control1" type="texbox" ID="TxtApellidoM" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtApellidoM" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu apellido materno" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator  runat="server" ErrorMessage="No se permiten carácteres especiales" 
                                        ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="TxtApellidoM" Display="Dynamic" ForeColor="white" 
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Nacionalidad</td>
                                    <td>
                                        <asp:DropDownList ID="CmbNacionalidad" CssClass="form-control1" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ControlToValidate="CmbNacionalidad" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu nacionalidad" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Rut</td>
                                    <td>
                                        <asp:TextBox runat="server" placeholder="Rut Ej: 12.345.678-9" class="form-control1" type="texbox" ID="TxtRut" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtRut" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu rut" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator  runat="server" ErrorMessage="Olidaste puntos y guión" ValidationExpression="^(\d{1,3}(\.?\d{3}){2})\-?([\dkK])$" ControlToValidate="TxtRut" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Género</td>
                                    <td>
                                        <asp:DropDownList ID="CmbGenero" CssClass="form-control1" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" InitialValue="0" runat="server" ControlToValidate="CmbGenero" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu género" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Teléfono</td>
                                    <td>
                                        <asp:TextBox runat="server" placeholder="Teléfono Ej: 12334566" class="form-control1" TextMode="Phone" ID="TxtTelefono" MaxLength="8" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtTelefono" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu telefono" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                    ControlToValidate="TxtTelefono" ErrorMessage="Ingrese sólo números"
                                                                    ForeColor="white"
                                                                    ValidationExpression="^[0-9]*" Display="Dynamic">
                                        </asp:RegularExpressionValidator>
                                        </td>
                                    
                                </tr>
                                <tr>
                                    <td class="auto-style1">Fecha nacimiento</td>
                                    <td>
                                        <asp:TextBox runat="server"  class="form-control1" textmode="Date" ID="TxtFechaNac" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtFechaNac" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu fecha de nacimiento" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                       </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Correo</td>
                                    <td>
                                        <asp:TextBox runat="server" placeholder="Ingresa tu correo" class="form-control1" TextMode="Email" ID="TxtCorreo" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtCorreo" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu correo" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                       
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Contraseña</td>
                                    <td>
                                        <asp:TextBox runat="server" placeholder="Ingresa tu contraseña" type="password" class="form-control1" ID="TxtClave" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtClave" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu contraseña" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        
                                        
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Contraseña</td>
                                    <td>
                                        <asp:TextBox runat="server" placeholder="Ingresa tu contraseña de nuevo" type="password" class="form-control1" ID="TxtClave2" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtClave2" Display="Dynamic" ErrorMessage="Olvidaste ingresar tu contraseña" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Las contraseñas no coinciden" Display="Dynamic" ControlToValidate="TxtClave" ForeColor="white"></asp:CompareValidator>
                                        
                                        <br />
                                        
                                    </td>
                                </tr>
                                
                            </table>
                            <asp:Button type="button" class="btn" ID="Btn_Registro" runat="server" Text="Registrarme"  ValidationGroup="Validador" OnClick="Btn_Registro_Click"/>
                            <br />
                            <div class="footer">
                                <div class="row" style="border-top: 2px white solid; margin-top: 20px;">
                                    <p class="line">¿Ya tienes cuenta?</p>
                                    <a class="line" href="/Login" style="color:white">Inicia Sesión</a>
                                </div>
                              
                              
                      </div>
                        </div>
                    </div>
            </form>
            </div>
            
        </div>
</body>
</html>
