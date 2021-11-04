<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuentaClave.aspx.cs" Inherits="WebTurismoReal.CuentaClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Mi cuenta</title>
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
    <script> 
        function SessionExpired() {
            swal.fire({
                title: "Tu sesión expiró!!",
                text: 'Vuelve al login para ingresar nuevamente',
                type: "warning",
                confirmButtonText: 'Volver',
                confirmButtonColor: '#117A65',
                iconColor: '#117A65'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = "/Login";
                }
            });
        }
        function ActualizacionExitosa() {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Los cambios se guardaron con éxito!',
                showConfirmButton: false,
                timer: 2000
            })
        }
        function ActualizacionFallida() {
            Swal.fire({
                position: 'top-end',
                icon: 'warning',
                title: 'Los cambios no se guardaron!',
                showConfirmButton: false,
                timer: 2000
            })
        }
        function ClaveNoIguales() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'La contraseña ingresada no es igual a la contraseña registrada en nuestra base de datos!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
    </script>
    <style>
        td {
            width: 50%;
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

            <div class="row">
                <div class="card" style="margin-top: 5px;">
                    <h5 style="font-size: 30px; margin-bottom: 10px;">¡Bienvenido/a!</h5>
                    <asp:Label ID="Lbl_Usuario" Text="[Nombre]" runat="server" />
                </div>
            </div>
            <div class="row" style="margin: auto;">

                <div class="card" style="margin-top: 5px; padding: 15px;">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Btn_Datos" CssClass="btn" Text="Mis datos" runat="server" OnClick="Btn_Datos_Click" /></td>
                        </tr>
                        <tr>
                            <td class="td-after">
                                <asp:Button ID="Btn_Reservas" CssClass="btn" Text="Mis reservas" runat="server" OnClick="Btn_Reservas_Click" /></td>
                            <td class="td-after">
                                <asp:Button ID="Btn_Acompañantes" CssClass="btn" Text="Mis acompañantes" runat="server" OnClick="Btn_Acompañantes_Click" /></td>
                        </tr>
                        <tr>
                            <td class="td-after">
                                <asp:Button ID="Btn_Servicios" CssClass="btn" Text="Servicios Extra" runat="server" OnClick="Btn_Servicios_Click" /></td>
                            <td class="td-after">
                                <asp:Button ID="Btn_Clave" CssClass="btn-active" Text="Cambiar contraseña" runat="server" OnClick="Btn_Clave_Click" /></td>
                        </tr>
                    </table>
                </div>

                <div class="card" style="margin-top: 5px; padding: 15px;">
                    <div class="row">
                        <h5 style="font-size: 18px;">Cambiar contraseña</h5>
                    </div>
                    <div>
                        <div class="row" style="text-align: center;">
                            <div class="container-blanco" style="border: none;">
                                <div>
                                    <fieldset>
                                        <legend>Contraseña actual</legend>
                                        <div>
                                            <asp:TextBox ID="Txt_Clave_Actual" placeholder="Ingresa tu contraseña actual" Text="" TextMode="Password" CssClass="form-control" runat="server" />
                                        </div>
                                    </fieldset>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar la clave actual" ControlToValidate="Txt_Clave_Actual" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>

                                </div>
                                <div>
                                    <fieldset>
                                        <legend>Contraseña nueva</legend>
                                        <div>
                                            <asp:TextBox ID="Txt_Clave_Nueva" placeholder="Ingresa tu contraseña nueva" Text="" TextMode="Password" CssClass="form-control" runat="server" />
                                        </div>
                                    </fieldset>
                                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar la nueva clave" ControlToValidate="Txt_Clave_Nueva" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="Validador" ControlToValidate="Txt_Clave_Nueva" runat="server" Display="Dynamic" ForeColor="White"  ValidationExpression="^(?=.*?[A-Z]).{8,}$" ErrorMessage="Falta al menos 1 letra máyuscula"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="Validador" ControlToValidate="Txt_Clave_Nueva" runat="server" Display="Dynamic" ForeColor="White"  ValidationExpression="^(?=.*?[a-z]).{8,}$" ErrorMessage=",1 letra minúscula"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationGroup="Validador" ControlToValidate="Txt_Clave_Nueva" runat="server" Display="Dynamic" ForeColor="White" ValidationExpression="^(?=.*?[0-9]).{8,}$" ErrorMessage=",1 número"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationGroup="Validador" ControlToValidate="Txt_Clave_Nueva" runat="server" Display="Dynamic" ForeColor="White"  ValidationExpression="^(?=.*?[#?!@$%^&*-.]).{8,}$" ErrorMessage=",1 carácter especial"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ValidationGroup="Validador" ControlToValidate="Txt_Clave_Nueva" runat="server" Display="Dynamic" ForeColor="White"  ValidationExpression="^(?=.*?[A-Z]).{8,}$" ErrorMessage="y un largo de mínimo 8 carácteres"></asp:RegularExpressionValidator>
            
                                </div>
                                <div class="fila">
                                    <div class="columna-1" style="padding: 5px; width: 100%;">
                                        <asp:Button ID="Btn_Guardar" CssClass="btn" Text="Cambiar contraseña" runat="server" ValidationGroup="Validador1" OnClick="Btn_Guardar_Click" />
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
