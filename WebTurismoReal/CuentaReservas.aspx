<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuentaReservas.aspx.cs" Inherits="WebTurismoReal.CuentaReservas" %>

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
        function SeleccionarDepto() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Debes seleccionar un departamento!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function FechasIncongruentes() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'La fecha de salida no puede ser anterior de la fecha de llegada!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function FechasIncongruentes2() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'La fecha de llegada no puede ser anterior a la fecha de hoy!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function FechasIncongruentes3() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Las reservas se realizan con un día de anticipación como mínimo!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
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
        function ReservaExpirada() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Esta reserva no se puede modificar, la fecha expiró.',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
    </script>
    <script type="text/javascript">
        function scrollToDiv() {
            document.getElementById('PanelModificar').scrollIntoView();
        }
        function scrollToDiv1() {
            document.getElementById('Panel_Guardar_Fecha').scrollIntoView();
        }
        function scrollToDiv2() {
            document.getElementById('Panel_Guardar_Depto').scrollIntoView();
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
                <div class="card" style="margin-top: 5px; margin-bottom:5px;">
                    <h5 style="font-size: 30px; margin-bottom: 10px;">¡Bienvenido/a!</h5>
                    <asp:Label ID="Lbl_Usuario" Text="[Nombre]" runat="server" />
                </div>
            </div>
            <div class="row" style="margin: auto;">

                <div class="card" style="margin-bottom: 5px; padding: 15px;">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Btn_Datos" CssClass="btn" Text="Mis datos" runat="server" OnClick="Btn_Datos_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Btn_Reservas" CssClass="btn-active" Text="Mis reservas" runat="server" OnClick="Btn_Reservas_Click" /></td>
                            <td>
                                <asp:Button ID="Btn_Acompañantes" CssClass="btn" Text="Mis acompañantes" runat="server" OnClick="Btn_Acompañantes_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Btn_Servicios" CssClass="btn" Text="Servicios Extra" runat="server" OnClick="Btn_Servicios_Click" /></td>
                            <td>
                                <asp:Button ID="Btn_Clave" CssClass="btn" Text="Cambiar contraseña" runat="server" OnClick="Btn_Clave_Click" /></td>
                        </tr>
                    </table>
                </div>

                <div class="card" style="margin-bottom: 5px;">
                    <div class="row">
                        <p style="font-weight: 600;">MIS RESERVAS</p>
                    </div>
                    <div class="row">
                        <p>Selecciona una reserva para modificarla</p>
                    </div>
                    <div class="scroll-div" >
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


            </div>

            <asp:Panel ID="PanelModificar" runat="server" Visible="false">
                <div class="card" style="margin-bottom: 5px; padding-left:30px; padding-right:30px;">
                    <div class="row" style="text-align: center; margin-top: 10px;">¿Qué deseas modificar de la reserva?</div>
                    <p>Si deseas modificar la localidad de destino, debes cancelar la reserva y realizarla de nuevo</p>
                    <div class="container-blanco" style="text-align: center; margin-top: 10px; margin-bottom: 10px; border: none;">
                        <asp:DropDownList class="form-control1" AutoPostBack="true" ID="Cmb_Opciones" runat="server" ToolTip="Seleccionar" OnSelectedIndexChanged="Cmb_Opciones_SelectedIndexChanged">
                            <asp:ListItem>Seleccione</asp:ListItem>
                            <asp:ListItem>Fecha ida/vuelta</asp:ListItem>
                            <asp:ListItem>Departamento</asp:ListItem>
                            <asp:ListItem>Cancelar reserva</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:Panel ID="Panel_Departamento" Visible="false" runat="server">
                        <div class="row" style="text-align: center;">Este es el departamento actual asociado a la reserva</div>
                        <div style="margin-top: 10px; width: 100%; padding: 2px; height:100%;">
                            <asp:GridView ID="GridDeptoActual" runat="server" DataKeyNames="ID" OnRowDataBound="GridDeptoActual_RowDataBound" CssClass="gridView" OnSelectedIndexChanged="GridDeptoActual_SelectedIndexChanged">
                            <AlternatingRowStyle Wrap="False" />
                            <HeaderStyle CssClass="gridViewHeader" />
                            <PagerStyle />
                            <RowStyle Wrap="false" />
                            <SelectedRowStyle CssClass="gridViewSeleccionada" />
                        </asp:GridView>
                        </div>
                        <br />
                        <div class="row" style="text-align: center; margin-top:10px;">Selecciona uno de estos departamentos disponibles</div>
                        <div class="scroll-div">
                            <asp:GridView ID="GridDepartamentos" runat="server" DataKeyNames="ID" OnRowDataBound="GridDepartamentos_RowDataBound" CssClass="gridView" OnSelectedIndexChanged="GridDepartamentos_SelectedIndexChanged">
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
                    </asp:Panel>
                    <asp:Panel ID="Panel_Fecha" CssClass="container-blanco" BorderStyle="None" Visible="false" runat="server">
                        <div class="row">
                            <fieldset>
                                <legend>Fecha de ingreso</legend>
                                <div>
                                    <asp:TextBox ID="TxtFechaIda" Text="" TextMode="Date" CssClass="form-control" runat="server" />
                                </div>
                            </fieldset>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar la fecha de ingreso" ControlToValidate="TxtFechaIda" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>

                        </div>
                        <div class="row" style="margin-top: 10px;">
                            <fieldset>
                                <legend>Fecha de regreso</legend>
                                <div>
                                    <asp:TextBox ID="TxtFechaRegreso" Text="" TextMode="Date" CssClass="form-control" runat="server" />
                                </div>
                            </fieldset>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar la fecha de regreso" ControlToValidate="TxtFechaRegreso" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>

                        </div>
                    </asp:Panel>
                    <br />

                    <asp:Panel ID="Panel_Guardar_Fecha" Visible="false" runat="server">
                        <div class="fila">
                            <div class="columna-1" style="padding: 5px; width: 100%;">
                                <asp:Button ID="BtnGuardarFecha" CssClass="btn" Text="Guardar cambios" ValidationGroup="Validador1" runat="server" OnClick="BtnGuardarFecha_Click" />
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Panel_Guardar_Depto" Visible="false" runat="server">
                        <div class="fila">
                            <div class="columna-1" style="padding: 5px; width: 100%;">
                                <asp:Button ID="BtnGuardarDepto" CssClass="btn" Text="Guardar cambios" ValidationGroup="Validador1" runat="server" OnClick="BtnGuardarDepto_Click" />
                            </div>
                        </div>
                    </asp:Panel>

                </div>
            </asp:Panel>
        </div>

    </form>

</body>
</html>
