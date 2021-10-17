<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebTurismoReal.Detalle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalle reserva</title>
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
    function LoginExitoso() {
            Swal.fire({
                  position: 'top-end',
                  icon: 'success',
                  title: 'Has ingresado con éxito!',
                  showConfirmButton: false,
                  timer: 3000
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
    function Pagar() {
        swal.fire({
            title: "¿Tienes una cuenta?",
            text: 'Para reservar un departamento necesitas estar registrado en nuestra página web.',
            type: "question",
                showDenyButton: true,
                confirmButtonText: 'Ya tengo cuenta',
                confirmButtonColor: '#117A65',
                denyButtonText: 'Quiero registrarme',
                denyButtonColor: '#117A65',
                showCloseButton: true,
                iconColor: '#117A65'
           }).then((result) => {
               if (result.isConfirmed) {
                   window.location.href = "/Login";
               }
               else if (result.isDenied) {
                   window.location.href = "/Registro";
                }}
           );
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
        <form id="form2" runat="server">
        <div class="row">
                <div class="card" style="margin-top:5px;">
                    <h5 style="font-size:30px; margin-bottom:10px;">Detalle de la reserva</h5>
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
            </div>

            <div class="row" >
            <div class="card" style="margin-top:5px; height:100%;">
                <div style="margin:20px;">
                    <div class="row">
                        <br />
                        <div class="container-blanco" style="border: 1px solid white;">
                            <table style="padding:20px; text-align: right; width:100%">
                                <tr>
                                    <td style="width:50%">Departamento:</td>
                                    <td style="text-align:left; width:50%; padding-left:10px;">
                                        <asp:Label ID="Lbl_Depto" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Región: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;">
                                        <asp:Label ID="Lbl_Region" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Provincia: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;">
                                        <asp:Label ID="Lbl_Provincia" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Comuna: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;">
                                        <asp:Label ID="Lbl_Comuna" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Días de reserva: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;">
                                        <asp:Label ID="Lbl_Dias" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Fecha de ida: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;">
                                        <asp:Label ID="Lbl_Ida" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Fecha de vuelta: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;">
                                        <asp:Label ID="Lbl_Vuelta" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Acompañantes: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;">
                                        <asp:Label ID="Lbl_Acompañantes" Text="" runat="server" />

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Total pago: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;"
                                      ><asp:Label ID="Lbl_Total" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Abono a pagar: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;"
                                      ><asp:Label ID="Lbl_Abono" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Pago restante: </td>
                                    <td style="text-align:left; width:50%; padding-left:10px;"
                                      ><asp:Label ID="Lbl_Restante" Text="" runat="server" /></td>
                                </tr>
                            </table>
                        <div class="row">
                        <asp:Button ID="BtnPagar" CssClass="btn" Text="Continuar" runat="server" OnClick="BtnPagar_Click" />
                            <asp:Label ID="Lbl_Id_Depto" Visible="false" Text="" runat="server" />
                            </div>
                        <br />
                        </div>
                        <br />
                    </div>
                </div>
            </div>
            
            </div>
            </form>
        </div>
</body>
</html>
