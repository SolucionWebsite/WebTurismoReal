<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuentaServicioExtra.aspx.cs" Inherits="WebTurismoReal.CuentaServicioExtra" %>

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

        .box img {
            width: 100%;
            height: auto;
        }

        @supports(object-fit: cover) {
            .box img {
                height: 100%;
                object-fit: cover;
                object-position: center center;
            }
        }
    </style>
    <script>
        function InfoTour() {
            Swal.fire({
                html: `
                <p style="text-align:center; font-size:24px;">Descripción del Tour</p>
                <br>
                <div class="box" style="height:200px; width:490px;">
                    <asp:Image ID="ImgTour" runat="server" />
                </div>
                <div>
                <p runat="server" style="margin-top:20px;" id="TextDesc" ></p>
                </div>
                `,
                confirmButtonText: 'Ok',
                confirmButtonColor: '#117A65'
            }).then((result) => {
                  if (result.isConfirmed) {
                    document.getElementById('PanelTourDatos').scrollIntoView();
                  }
            })
        }
        function Eliminar() {
            Swal.fire({
                icon: 'success',
                title: 'Eliminado!',
                text: 'Se ha eliminado el servicio extra de la reserva',
                confirmButtonText: 'Ok',
                confirmButtonColor: '#117A65'
            })
        }
        function EliminarFallido() {
            Swal.fire({
                icon: 'warning',
                title: 'Algo ocurrió!',
                text: 'No se ha eliminado el servicio extra de la reserva',
                confirmButtonText: 'Ok',
                confirmButtonColor: '#117A65'
            })
        }
        function Olvidar_Selecccionar_Reserva() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Olvidaste seleccionar una reserva!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function OlvidarSeleccionarTrayecto() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Olvidaste seleccionar el tipo de trayecto!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function ServicioAgregadoFallido() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops... ocurrió un problema',
                text: 'El servicio extra no se agregó a la reserva!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function ServicioAgregadoExito() {
            Swal.fire({
                icon: 'success',
                title: 'Éxito',
                text: 'El servicio extra se agregó correctamente a la reserva!',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function Olvidar_Selecccionar_Servicio() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Olvidaste seleccionar una servicio extra!',
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
        function ReservaExpirada() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'Esta reserva no se puede modificar, la fecha expiró.',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function CapacidadPasajeros() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'La cantidad de pasajeros no puede exceder la cantidad de asientos del vehículo seleccionado',
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function ImposibleFechasTour() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                html: `
                <div style="text-align:center;">
                <p> La fecha de asistencia al Tour no debe ser anterior a la fecha de ida ni posterior a la fecha de regreso de la reserva</p>
                <p runat="server" style="margin-top:5px;" id="LblFechasReserva" ></p>
                </div>
                `,
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function scrollToDiv() {
            document.getElementById('PanelTransporte').scrollIntoView();
        }
        function ImposibleFechasTransporte() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                html: `
                <div style="text-align:center;">
                <p> La fecha de abordo al vehículo no debe ser anterior a la fecha de ida ni posterior a la fecha de regreso de la reserva</p>
                <p runat="server" style="margin-top:5px;" id="LblFechasReserva2" ></p>
                </div>
                `,
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
        function ImposibleFechasTour2() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                html: `
                <div style="text-align:center;">
                <p> La fecha ingresada ya está asociada a un servicio extra</p>
                <p runat="server" style="margin-top:5px;" id="LblFechaServicio" ></p>
                </div>
                `,
                iconColor: '#117A65',
                confirmButtonColor: '#117A65'
            })
        }
    </script>
    <script type="text/javascript">
        function scrollToDiv() {
            document.getElementById('PanelServiciosExtraActual').scrollIntoView();
        }
        function scrollToDiv1() {
            document.getElementById('PanelAgregarSE').scrollIntoView();
        }
        function scrollToDiv2() {
            document.getElementById('PanelTour').scrollIntoView();
        }
        function scrollToDiv3() {
            document.getElementById('PanelTipoTrayecto').scrollIntoView();
        }
        function scrollToDiv5() {
            document.getElementById('PanelDetalleTour').scrollIntoView();
        }
        function scrollToDiv6() {
            document.getElementById('PanelTransporte').scrollIntoView();
        }
        function scrollToDiv7() {
            document.getElementById('PanelDatosTransporte').scrollIntoView();
        }
        function scrollToDiv8() {
            document.getElementById('PanelDetalleTransporte').scrollIntoView();
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
                <div class="card" style="margin-top: 5px; margin-bottom: 5px;">
                    <h5 style="font-size: 30px; margin-bottom: 10px;">¡Bienvenido/a!</h5>
                    <asp:Label ID="Lbl_Usuario" Text="[Nombre]" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="card" style="margin-bottom: 5px; padding: 15px;">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Btn_Datos" CssClass="btn" Text="Mis datos" runat="server" OnClick="Btn_Datos_Click" /></td>
                        </tr>
                        <tr>
                            <td style="width: 50%">
                                <asp:Button ID="Btn_Reservas" CssClass="btn" Text="Mis reservas" runat="server" OnClick="Btn_Reservas_Click" /></td>
                            <td style="width: 50%">
                                <asp:Button ID="Btn_Acompañantes" CssClass="btn" Text="Mis acompañantes" runat="server" OnClick="Btn_Acompañantes_Click" /></td>
                        </tr>
                        <tr>
                            <td style="width: 50%">
                                <asp:Button ID="Btn_Servicios" CssClass="btn-active" Text="Servicios Extra" runat="server" OnClick="Btn_Servicios_Click" /></td>
                            <td style="width: 50%">
                                <asp:Button ID="Btn_Clave" CssClass="btn" Text="Cambiar contraseña" runat="server" OnClick="Btn_Clave_Click" /></td>
                        </tr>
                    </table>
                </div>

                <div class="card" style="margin-bottom: 5px;">
                    <p style="margin-top: 5px;">Selecciona una reserva para agregar, modificar o eliminar un servicio extra.</p>
                    <div class="scroll-div">
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

                <asp:Panel ID="PanelServiciosExtraActual" Visible="false" runat="server">
                    <div class="card" style="margin-bottom: 5px;">
                        <p style="font-weight: 600;">SERVICIOS EXTRA</p>
                        <p>Servicios extra asociados a la reserva</p>
                        <br />
                        <asp:Panel ID="PanelNoServicios" Visible="false" runat="server">
                            <p>No tienes servicios asociados a la reserva seleccionada.</p>
                        </asp:Panel>
                        <asp:Panel ID="PanelTourActual" Visible="false" runat="server">
                            <p style="font-weight: 600;">TOUR</p>
                            <div class="scroll-div" style="height:100%;">
                                <asp:GridView ID="GridTourActual" runat="server" DataKeyNames="ID" OnRowDataBound="GridTourActual_RowDataBound" CssClass="gridView" OnSelectedIndexChanged="GridTourActual_SelectedIndexChanged">
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
                        <br />
                        <asp:Panel ID="PanelTransporteActual" Visible="false" runat="server">
                            <p style="font-weight: 600;">TRANSPORTE</p>
                            <div class="scroll-div" style="height:100%;">
                                <asp:GridView ID="GridTransporteActual" runat="server" DataKeyNames="ID" OnRowDataBound="GridTransporteActual_RowDataBound" CssClass="gridView" OnSelectedIndexChanged="GridTransporteActual_SelectedIndexChanged">
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

                        <table style="width: 100%">
                            <tr>
                                <td class="td-after">
                                    <asp:Button ID="Btn_Añadir_SE" Text="Añadir servicio extra" CssClass="btn" runat="server" OnClick="Btn_Añadir_SE_Click" /></td>
                                <td class="td-after">
                                    <asp:Button ID="Btn_Modificar_SE" CssClass="btn" Text="Modificar servicio extra" runat="server" OnClick="Btn_Modificar_SE_Click" /></td>
                                <td class="td-after">
                                    <asp:Button ID="Btn_Eliminar_SE" CssClass="btn" Text="Quitar servicio extra" runat="server" OnClick="Btn_Eliminar_SE_Click" /></td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

                <asp:Panel ID="PanelAgregarSE" Visible="false" runat="server">
                    <div class="card" style="margin-bottom: 5px; padding-left: 30px; padding-right: 30px;">
                        <div class="row" style="text-align: center; margin-top: 10px;">Selecciona el tipo de servicio extra que deseas agregar a la reserva</div>
                        <div class="container-blanco" style="text-align: center; margin-top: 10px; margin-bottom: 10px; border: none;">
                            <asp:DropDownList class="form-control1" AutoPostBack="true" ID="ListaSE" runat="server" ToolTip="Seleccionar" OnSelectedIndexChanged="ListaSE_SelectedIndexChanged">
                                <asp:ListItem Text="Seleccionar" />
                                <asp:ListItem Text="Tour guíado" />
                                <asp:ListItem Text="Transporte" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="PanelTour" Visible="false" runat="server">
                    <div class="card" style="margin-bottom: 5px;">
                        <p>Seleccionar tour</p>
                        <div class="scroll-div">
                            <asp:GridView ID="GridTours" runat="server" DataKeyNames="ID" OnRowDataBound="GridTours_RowDataBound" CssClass="gridView" OnSelectedIndexChanged="GridTours_SelectedIndexChanged">
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

                <asp:Panel ID="PanelTipoTrayecto" Visible="false" runat="server">
                    <div class="card" style="margin-bottom: 5px; padding-left: 30px; padding-right: 30px;">
                        <div class="row" style="text-align: center; margin-top: 10px;">Selecciona el tipo de trayecto</div>
                        <div class="container-blanco" style="text-align: center; margin-top: 10px; margin-bottom: 10px; border: none;">
                            <asp:DropDownList class="form-control1" AutoPostBack="true" ID="CmbTipoTrayecto" runat="server" ToolTip="Seleccionar" OnSelectedIndexChanged="CmbTipoTrayecto_SelectedIndexChanged">
                                <asp:ListItem>Seleccione</asp:ListItem>
                                <asp:ListItem>Ida</asp:ListItem>
                                <asp:ListItem>Vuelta</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="PanelTransporte" Name="AnclaPanelTransporte" Visible="false" runat="server">
                    <div class="card" style="margin-bottom: 5px;">
                        <p>Seleccionar transporte</p>
                        <div class="scroll-div">
                            <asp:GridView ID="GridTransporte" runat="server" DataKeyNames="ID" OnRowDataBound="GridTransporte_RowDataBound1" CssClass="gridView" OnSelectedIndexChanged="GridTransporte_SelectedIndexChanged1">
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

                <asp:Panel ID="PanelTourDatos" Visible="false" runat="server">
                    <div class="card" style="margin-bottom: 5px;">
                        <table class="tabla" style="width: 500px;">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend>Fecha de asistencia a tour</legend>
                                        <div>
                                            <asp:TextBox TextMode="Date" ID="TxtFecha" CssClass="form-control" runat="server" />
                                        </div>
                                    </fieldset>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFecha" Display="Dynamic" ErrorMessage="Olvidaste ingresar la fecha" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend>Cantidad de asistentes</legend>
                                        <div>
                                            <asp:TextBox TextMode="Number" ID="TxtCantidadA" CssClass="form-control" runat="server" />
                                        </div>
                                    </fieldset>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtCantidadA" Display="Dynamic" ErrorMessage="Olvidaste ingresar la cantidad de asistentes" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <asp:Button ID="BtnCalcularTour" CssClass="btn" Text="Calcular total" runat="server" OnClick="BtnCalcularTour_Click" ValidationGroup="Validador1" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

                <asp:Panel ID="PanelDetalleTour" Visible="false" runat="server">
                    <div class="card" style="margin-bottom: 5px;">
                        <br />
                        <p>DETALLE DEL SERICIO DE TOUR</p>
                        <br />
                        <table style="margin: 0 auto; width: 700px;">
                            <tr>
                                <td style="text-align: right; width: 50%;">Nombre del tour:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblNombreTour" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Zona a visitar:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblZona" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Fecha de asistencia:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblFechaAsistencia" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Asistentes:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblAsistentesTour" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Valor por persona:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblValorPersonaTour" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Valor total por día:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblTotalTour" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:Button ID="BtnContratarTour" Text="Contratar" CssClass="btn" runat="server" OnClick="BtnContratarTour_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

                <asp:Panel ID="PanelDatosTransporte" Visible="false" runat="server">
                    <div class="card" style="margin-bottom: 5px;">
                        <table class="tabla" style="width: 500px;">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend>Fecha de abordo</legend>
                                        <div>
                                            <asp:TextBox TextMode="Date" ID="TxtFechaAbordo" CssClass="form-control" runat="server" />
                                        </div>
                                    </fieldset>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtFechaAbordo" Display="Dynamic" ErrorMessage="Olvidaste ingresar la fecha" ForeColor="white" ValidationGroup="Validador2"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend>Hora de abordo</legend>
                                        <div>
                                            <asp:TextBox TextMode="Time" ID="TxtHora" CssClass="form-control" runat="server" />
                                        </div>
                                    </fieldset>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtHora" Display="Dynamic" ErrorMessage="Olvidaste ingresar la hora" ForeColor="white" ValidationGroup="Validador2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend>Cantidad de pasajeros</legend>
                                        <div>
                                            <asp:TextBox TextMode="Number" ID="TxtPasajeros" CssClass="form-control" runat="server" />
                                        </div>
                                    </fieldset>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtPasajeros" Display="Dynamic" ErrorMessage="Olvidaste ingresar la cantidad de pasajeros" ForeColor="white" ValidationGroup="Validador2"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <asp:Button ID="BtnCalcularTransporte" CssClass="btn" Text="Calcular total" runat="server" OnClick="BtnCalcularTransporte_Click" ValidationGroup="Validador2" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

                <asp:Panel ID="PanelDetalleTransporte" Visible="false" runat="server">
                    <div class="card" style="margin-bottom: 5px;">
                        <br />
                        <p>DETALLE DEL SERVICIO DE TRANSPORTE</p>
                        <br />
                        <table style="margin: 0 auto; width: 700px;">
                            <tr>
                                <td style="text-align: right; width: 50%;">Tipo de trayecto:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblTipoTrayecto" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%;">Fecha y hora de abordo:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblFechayHora" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Tipo de vehículo:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblTipoVehiculo" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Asientos:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblAsientos" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Pasajeros:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblPasajeros" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Valor por persona:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblValorPTransporte" runat="server" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 50%">Valor total servicio:</td>
                                <td style="text-align: left; width: 50%; padding-left: 10px;">
                                    <asp:Label ID="LblValorTotalTransporte" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                    <asp:Button ID="BtnContratarTransporte" Text="Contratar" CssClass="btn" runat="server" OnClick="BtnContratarTransporte_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

            </div>
        </div>
    </form>
</body>
</html>
