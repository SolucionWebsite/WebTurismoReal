<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuentaAcompañantes.aspx.cs" Inherits="WebTurismoReal.CuentaAcompañantes" %>

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
    <style>
        @media (max-width: 952px) {
            .td-after {
                display: inline-block;
                width: 100%;
                margin-bottom: 2px;
            }
        }
    </style>
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
        function Exitoso() {
            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 2000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })

            Toast.fire({
                icon: 'success',
                title: 'Acompañante añadido!'
            })
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
                text: 'Los datos NO se guardaron!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function ReservaExpirada() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Esta reserva no se puede modificar, la fecha expiró.',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function EliminacionExitosa() {
            Swal.fire({
                icon: 'success',
                title: 'Bien!',
                text: 'El acompañante se ha eliminado de la reserva',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function EliminacionFallida() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'No se pudo eliminar el acompañante de la reserva',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function SeleccionarAcompañante() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Debes seleccionar un acompañante!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
    </script>
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
                            <td style="width: 50%">
                                <asp:Button ID="Btn_Reservas" CssClass="btn" Text="Mis reservas" runat="server" OnClick="Btn_Reservas_Click" /></td>
                            <td style="width: 50%">
                                <asp:Button ID="Btn_Acompañantes" CssClass="btn-active" Text="Mis acompañantes" runat="server" OnClick="Btn_Acompañantes_Click" /></td>
                        </tr>
                        <tr>
                            <td style="width: 50%">
                                <asp:Button ID="Btn_Servicios" CssClass="btn" Text="Servicios Extra" runat="server" OnClick="Btn_Servicios_Click" /></td>
                            <td style="width: 50%">
                                <asp:Button ID="Btn_Clave" CssClass="btn" Text="Cambiar contraseña" runat="server" OnClick="Btn_Clave_Click" /></td>
                        </tr>
                    </table>
                </div>
                <asp:Panel ID="PanelReservas" Visible="true" runat="server">
                    <div class="card" style="margin-top: 5px;">
                        <div class="row">
                            <p style="font-weight: 600;">MIS RESERVAS</p>
                        </div>
                        <div class="row">
                            <p>La tabla de acompañantes se cargará según la reserva que selecciones</p>
                        </div>
                        <div style="margin-top: 10px; width: 100%; padding: 10px; overflow: scroll; margin-bottom: 5px; height: 200px;">
                            <asp:GridView ID="GridReservas" runat="server" DataKeyNames="ID" OnRowDataBound="GridReservas_RowDataBound1" CssClass="gridView" OnSelectedIndexChanged="GridReservas_SelectedIndexChanged">
                                <AlternatingRowStyle Wrap="False" />
                                <HeaderStyle CssClass="gridViewHeader" />
                                <PagerStyle />
                                <RowStyle Wrap="false" />
                                <SelectedRowStyle CssClass="gridViewSeleccionada" />
                                <Columns>
                                    <asp:ButtonField ControlStyle-CssClass="btn" ControlStyle-Height="30" ButtonType="Button" CommandName="Select" ShowHeader="True" Text="Seleccionar">
                                        <ControlStyle CssClass="btn" Height="30px"></ControlStyle>
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelAcompañantes" Visible="false" runat="server">
                    <div class="card" style="margin-top: 5px; padding: 15px;">
                        <div class="row">
                            <p style="font-weight: 600">MIS ACOMPAÑANTES</p>
                        </div>
                        <div>

                            <div style="margin-top: 10px; width: 100%; padding: 10px; overflow: scroll; height: 200px;">
                                <asp:GridView ID="GridAcompañantes" runat="server" DataKeyNames="ID" OnRowDataBound="GridAcompañantes_RowDataBound" CssClass="gridView" OnSelectedIndexChanged="GridAcompañantes_SelectedIndexChanged">
                                    <AlternatingRowStyle Wrap="False" />
                                    <HeaderStyle CssClass="gridViewHeader" />
                                    <PagerStyle />
                                    <RowStyle Wrap="false" />
                                    <SelectedRowStyle CssClass="gridViewSeleccionada" />
                                    <Columns>
                                        <asp:ButtonField ControlStyle-CssClass="btn" ControlStyle-Height="30" ButtonType="Button" CommandName="Select" ShowHeader="True" Text="Seleccionar">
                                            <ControlStyle CssClass="btn" Height="30px"></ControlStyle>
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <br />
                            <table style="width: 100%">
                                <tr>
                                    <td class="td-after">
                                        <asp:Button ID="Btn_Añadir_Acompañante" Text="Añadir acompañante" CssClass="btn" runat="server" OnClick="Btn_Añadir_Acompañante_Click" /></td>
                                    <td class="td-after">
                                        <asp:Button ID="Btn_Modificar_Acompañante" CssClass="btn" Text="Modificar acompañante" runat="server" OnClick="Btn_Modificar_Acompañante_Click" /></td>
                                    <td class="td-after">
                                        <asp:Button ID="Btn_Eliminar_Acompañante" CssClass="btn" Text="Quitar acompañante" runat="server" OnClick="Btn_Eliminar_Acompañante_Click" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelAñadirAcompañantes" Visible="false" runat="server">
                    <div class="card" style="margin-top: 5px;">
                        <div class="row">
                            <p style="font-weight: 600;">DATOS DE ACOMPAÑANTE</p>
                        </div>
                        <div class="rowlist">
                            <div class="a-container">
                                <div class="fila">
                                    <div class="columna-1" style="width: 100%;">
                                        <asp:TextBox ID="Txt_Nombre_A" CssClass="form-control1" placeholder="Ingresa el nombre" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txt_Nombre_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el nombre" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ErrorMessage="No se permiten carácteres especiales"
                                            ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Nombre_A" Display="Dynamic" ForeColor="white"
                                            ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="fila">
                                    <div class="columna-1" style="width: 100%;">
                                        <asp:TextBox ID="Txt_Apellido_A" CssClass="form-control1" placeholder="Ingresa el apellido paterno" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txt_Apellido_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el apellido paterno" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ErrorMessage="No se permiten carácteres especiales"
                                            ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Apellido_A" Display="Dynamic" ForeColor="white"
                                            ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="fila">
                                    <div class="columna-1" style="width: 100%;">
                                        <asp:TextBox ID="Txt_Apellido_M" CssClass="form-control1" placeholder="Ingresa el apellido materno" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txt_Apellido_M" Display="Dynamic" ErrorMessage="Olvidaste ingresar el apellido materno" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ErrorMessage="No se permiten carácteres especiales"
                                            ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Apellido_M" Display="Dynamic" ForeColor="white"
                                            ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="fila">
                                    <div class="columna-1" style="width: 100%;">
                                        <asp:TextBox ID="Txt_Telefono_A" CssClass="form-control1" placeholder="Teléfono sin código +569" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txt_Telefono_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el teléfono" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                            ControlToValidate="Txt_Telefono_A" ErrorMessage="El teléfono debe ser de 8 números"
                                            ForeColor="white"
                                            ValidationExpression="^[0-9]{8}$" Display="Dynamic" ValidationGroup="Validador1">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="fila">
                                    <div class="columna-1" style="width: 100%;">
                                        <asp:TextBox ID="Txt_Rut_A" CssClass="form-control1" placeholder="Rut con puntos y guíon" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Txt_Rut_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el teléfono" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ErrorMessage="Olidaste puntos y guión" ValidationExpression="^(\d{1,3}(\.?\d{3}){2})\-?([\dkK])$" ControlToValidate="Txt_Rut_A" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                                <div class="fila">
                                    <div class="columna-1" style="width: 100%;">
                                        <asp:TextBox ID="Txt_Nacimiento_A" CssClass="form-control1" placeholder="Ingresa la fecha de nacimiento" TextMode="Date" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Txt_Nacimiento_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar la fecha de nacimiento" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="fila">
                                    <div class="columna-1" style="width: 100%;">
                                        <asp:TextBox ID="Txt_Correo_A" CssClass="form-control1" TextMode="Email" placeholder="Ingresa el correo" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Txt_Correo_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el correo" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="fila">
                                    <div class="columna-1" style="width: 100%;">
                                        <asp:DropDownList ID="CmbGenero" CssClass="form-control1" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" InitialValue="0" runat="server" ControlToValidate="CmbGenero" Display="Dynamic" ErrorMessage="Olvidaste ingresar el género" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="fila">
                                    <div class="columna-1" style="width: 100%;">
                                        <asp:DropDownList ID="CmbNacionalidad" CssClass="form-control1" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ControlToValidate="CmbNacionalidad" Display="Dynamic" ErrorMessage="Olvidaste ingresar el nacionalidad" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <br />
                                <div>
                                    <asp:Button ID="Btn_Guardar" ValidationGroup="Validador1" CssClass="btn" Text="Guardar" runat="server" OnClick="Btn_Guardar_Click" />
                                </div>
                            </div>

                        </div>

                    </div>
                </asp:Panel>

            </div>

        </div>
    </form>

</body>
</html>
