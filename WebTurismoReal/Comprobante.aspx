<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comprobante.aspx.cs" Inherits="WebTurismoReal.Comprobante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Comprobante de reserva</title>
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
        function PagoExitoso() {
            Swal.fire({
                position: 'top-end',
                icon: 'success',
                title: 'Pago exitoso!',
                showConfirmButton: false,
                timer: 2000
            })
        }
        function SessionExpired() {
            swal.fire({
                title: "Tu sesión expiró!!",
                text: 'Vuelve a la página principal para tomar la reserva otra vez',
                type: "warning",
                confirmButtonText: 'Volver',
                confirmButtonColor: '#117A65',
                iconColor: '#117A65'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = "/Index";
                }
            }
            );
        }
    </script>
    <style>
        .progreso {
            background-color: #117A65;
            position: absolute;
            top: 50%;
            left: 0;
            transform: translateY(-50%);
            height: 2px;
            width: 100%;
            z-index: -1;
            transition: 0.4s ease;
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
                            <a href="/CuentaDatos">Mi cuenta</a>
                        </li>
                        <li>
                            <asp:LinkButton ID="Btn_LogOut" Text="Cerrar sesión" runat="server" OnClick="Btn_LogOut_Click" />
                        </li>
                        <%} %>
                    </ul>
                </nav>
            </div>
            <div class="row">
                <div class="card">
                    <h5 style="font-size: 30px; margin-bottom: 10px; margin-top: 5px;">COMPROBANTE DE COMPRA</h5>
                    <asp:Label ID="Lbl_Nombre_1" Text="" runat="server" />, Recibimos tu solicitud de reserva!
                    <p>Gracias por preferir a Turismo Real! Se ha enviado un correo con este comprobante adjunto y la información sobre la reserva a</p>
                    <asp:Label ID="Lbl_Correo" Text="" Style="padding-left: 3px;" runat="server" />
                </div>
            </div>

            <div class="contenedor">
                <div class="progreso-contenedor">
                    <div class="progreso" id="progreso"></div>
                    <asp:Button ID="Btn_1" Text="1" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_2" Text="2" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_3" Text="3" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_4" Text="4" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_5" Text="5" CssClass="redondo" runat="server" />
                </div>
            </div>

            <div class="row">

                <div class="card" style="margin-top: 5px; height: 100%;">
                    <div style="margin: 10px;">
                        <div class="row">
                            <div class="row" style="border: 1px solid black; height: 100%;">
                                <br />
                                <div class="row" style="text-align: center;">
                                    <p>DETALLE DE LA COMPRA</p>
                                </div>
                                <table style="padding: 10px; text-align: right; width: 100%">
                                    <tr>
                                        <td style="width: 50%">Comprobante N°:</td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label ID="Lbl_Comprobante" Text="" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%">Fecha y hora: </td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label ID="Lbl_Fecha" Text="" runat="server" /></td>
                                    </tr>
                                </table>
                                <div class="row" style="text-align: center;">
                                    <p>INFORMACIÓN CLIENTE</p>
                                </div>
                                <table style="padding: 10px; text-align: right; width: 100%">
                                    <tr>
                                        <td style="width: 50%">Nombre:</td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label ID="Lbl_Nombre" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%">Rut:</td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label ID="Lbl_Rut" Text="" runat="server" /></td>
                                    </tr>
                                </table>
                                <div class="row" style="text-align: center;">
                                    <p>RESUMEN DE COMPRA</p>
                                </div>
                                <table style="padding: 10px; text-align: right; width: 100%">
                                    <tr>
                                        <td style="width: 50%">Servicio contratado:</td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label Text="Reserva de departamento" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%">Dirección:</td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label ID="Lbl_Direccion" Text="" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%">Ubicación:</td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label ID="Lbl_Ubicacion" Text="" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%">Días:</td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label ID="Lbl_Dias" Text="" runat="server" /></td>
                                    </tr>
                                </table>
                                <div class="row" style="text-align: center;">
                                    <p>DETALLE DE PAGO</p>
                                </div>
                                <table style="padding: 10px; text-align: right; width: 100%">
                                    <tr>
                                        <td style="width: 50%">Tipo de pago:</td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label ID="Lbl_Tipo_Pago" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%">Monto pagado:</td>
                                        <td style="text-align: left; width: 50%; padding-left: 10px;">
                                            <asp:Label ID="Lbl_Monto" Text="" runat="server" /></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </form>
</body>
</html>
