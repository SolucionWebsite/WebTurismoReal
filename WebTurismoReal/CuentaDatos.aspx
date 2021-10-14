﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuentaDatos.aspx.cs" Inherits="WebTurismoReal.CuentaDatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Mi cuenta</title>
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
    <script> 
        function SessionExpired() {
        swal.fire({
            title:"Tu sesión expiró!!",
            text: 'Vuelve al login para ingresar nuevamente',
            type: "warning",
                confirmButtonText: 'Volver',
                confirmButtonColor: '#117A65',
                iconColor: '#117A65'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = "/Login1";
            }});
        }
    </script>
    <style> 
        td{
            width:50%;
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
                    <a href="/Login1">Log in</a>
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
            <form id="form1" runat="server">
            <div class="row">
                <div class="card" style="margin-top:5px;">
                    <h5 style="font-size:30px; margin-bottom:10px;">¡Bienvenido/a!</h5>
                    <asp:Label ID="Lbl_Usuario" Text="[Nombre]" runat="server" />
                </div>
            </div>
                <div class="row" style="margin:auto;">

                    <div class="card" style="margin-top:5px; padding:15px;">
                        <table style="width:100%;">
                            <tr>
                                <td><asp:Button ID="Button1" CssClass="btn-active" Text="Mis datos" runat="server"/></td>
                                <td><asp:Button ID="Button2" CssClass="btn" Text="Mis reservas" runat="server" OnClick="Btn_Mis_Reservas_Click" /></td>
                            
                            </tr>
                            <tr>
                                <td><asp:Button ID="Button3" CssClass="btn" Text="Servicios Extra" runat="server" OnClick="Btn_Servicio_Extra_Click" /></td>
                                <td><asp:Button ID="Button4" CssClass="btn" Text="Cambiar contraseña" runat="server" OnClick="Btn_Cambiar_Clave_Click"/></td>
                            </tr>
                        </table>
                    </div>

                    <div class="card" style="margin-top:5px; padding:15px;">
                        <div class="row">
                            <h5 style="font-size:18px; margin-bottom:20px;">Información cliente</h5>
                        </div>
                        <div style="margin-top: 30px; border: 2px solid white; padding:10px; height:100%;">

                            <div class="div-r">
                                <fieldset>
                               <legend>Nombre</legend>
                               <div><asp:TextBox ID="Txt_Nombre" Enabled="false" CssClass="form-control"  runat="server" />
                                    <asp:RegularExpressionValidator  runat="server" ErrorMessage="No se permiten carácteres especiales" 
                                    ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Nombre" Display="Dynamic" ForeColor="white" 
                                    ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar tu nombre" 
                                    ControlToValidate="Txt_Nombre" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1">
                                    </asp:RequiredFieldValidator></div>
                               </fieldset>
                            </div>
                            <div class="div-l">
                                <fieldset>
                               <legend>Apellido Paterno</legend>
                               <div><asp:TextBox ID="Txt_Apellido_P" Enabled="false" CssClass="form-control"  runat="server" />
                                    <asp:RegularExpressionValidator  runat="server" ErrorMessage="No se permiten carácteres especiales" ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Apellido_P" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar tu apellido" ControlToValidate="Txt_Apellido_P" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                </div>
                               </fieldset>
                            </div>
                            <div class="div-r">
                                <fieldset>
                               <legend>Apellido Materno</legend>
                               <div><asp:TextBox ID="Txt_Apellido_M" Enabled="false" CssClass="form-control"  runat="server" />
                                    <asp:RegularExpressionValidator  runat="server" ErrorMessage="No se permiten carácteres especiales" ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Apellido_M" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar tu apellido" ControlToValidate="Txt_Apellido_M" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                </div>
                               </fieldset>
                            </div>
                            <div class="div-l">
                                <fieldset>
                               <legend>Fecha de nacimiento</legend>
                               <div><asp:TextBox TextMode="Date" ID="Txt_Fecha_Nacimiento" Enabled="false" CssClass="form-control"  runat="server" />
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar tu fecha de nacimiento" ControlToValidate="Txt_Fecha_Nacimiento" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                               
                               </div>
                               </fieldset>
                            </div>
                            <div class="div-r">
                                <fieldset>
                               <legend>Rut</legend>
                               <div><asp:TextBox ID="Txt_Rut" Enabled="false"  CssClass="form-control"  runat="server" />
                                    <asp:RegularExpressionValidator  runat="server" ErrorMessage="Olidaste puntos y guión" ValidationExpression="^(\d{1,3}(\.?\d{3}){2})\-?([\dkK])$" ControlToValidate="Txt_Rut" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar tu rut" ControlToValidate="Txt_Rut" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                </div>
                               </fieldset>
                            </div>
                            <div class="div-l">
                                <fieldset>
                               <legend>Género</legend>
                               <div><asp:DropDownList ID="Cmb_Genero" Enabled="false" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar el género" ControlToValidate="Cmb_Genero" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                               </div>
                               </fieldset>
                            </div>
                            <div class="div-r">
                                <fieldset>
                               <legend>Teléfono</legend>
                               <div><asp:TextBox TextMode="Number" MaxLength="9" ID="Txt_Telefono" Enabled="false"  CssClass="form-control"  runat="server" />
                                   <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar tu teléfono" ControlToValidate="Txt_Telefono" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                               
                               </div>
                               </fieldset>
                            </div>
                            <div class="div-l">
                                <fieldset>
                               <legend>Nacionalidad</legend>
                               <div><asp:DropDownList ID="Cmb_Nacionalidad" Enabled="false" CssClass="form-control" runat="server">
                                    </asp:DropDownList></div>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar tu nacionalidad" ControlToValidate="Cmb_Nacionalidad" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                               
                               </fieldset>
                            </div>
                            <div>
                                <fieldset>
                               <legend>Correo</legend>
                               <div> <asp:TextBox ID="Txt_Correo"  Text="" TextMode="Email" Enabled="false"  CssClass="form-control"  runat="server" />
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar tu correo" ControlToValidate="Txt_Correo" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator  runat="server" ErrorMessage="Ingresa un correo válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Txt_Apellido_M" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                </div>
                               </fieldset>
                            </div>
                        <div class="fila" style="margin-top:15px;">
                                <div class="columna-1" style=" padding:5px; width:50%;">
                                    <asp:Button ID="Btn_Editar" CssClass="btn" Text="Editar" runat="server" OnClick="Btn_Editar_Click"/>
                                </div>
                                <div class="columna-1" style="width:50%; padding:5px;">
                                    <asp:Button CssClass="btn" Text="Guardar" ValidationGroup="Validador1" runat="server" />
                                </div>
                       </div>
                            </div>
                    </div>
                    </div>
                </form>
                </div>
    
</body>
</html>

