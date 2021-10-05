<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservar.aspx.cs" Inherits="WebTurismoReal.Reservar" %>

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
    <script>    
        
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
                    <a href="/Index1">Home</a>
                </li>
                <li>
                    <a href="/">Servicios</a>
                </li>
                <li>
                    <a href="/Index1">Reservar</a>
                </li><li>
                    <a href="/Login">Log in</a>
                </li>
            </ul>
        </nav>
            </div>
        <div class="row">
                <div class="container-1">
                    <h5 style="font-size:30px; margin-bottom:10px;">Detalle de la reserva</h5>
                </div>
            </div>

            <div class="row" >
                <form id="form1" runat="server">
            <div class="container-main" style="margin-top:5px; height:100%;">
                <div style="margin:20px;">
                    <div class="row">
                        <br />
                        <div class="row" style="border: 3px solid white; height:100%;">
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
                        <asp:Button ID="BtnPagar" CssClass="btn" Text="Pagar" runat="server" OnClick="BtnPagar_Click" />
                            <asp:Label ID="Lbl_Id_Depto" Visible="false" Text="" runat="server" />
                            </div>
                        <br />
                        </div>
                        <br />
                    </div>
                </div>
            </div>
            </form>
            </div>
            
        </div>
</body>
</html>

