<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebTurismoReal.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Turismo Real</title>
    <link href="css/Style.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" >
    <link href="https://fonts.googleapis.com/css2?family=Didact+Gothic&family=Lobster&display=swap" rel="stylesheet">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimun-scale=1.0" />
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <script src="js/sweetAlert2.js" ></script>
    <link href="//cdn.jsdelivr.net/npm/@sweetalert2/theme-minimal@4/minimal.css" rel="stylesheet">
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.js"></script>
    <link rel="stylesheet" href="@sweetalert2/themes/minimal/minimal.css">
    <script src="sweetalert2/dist/sweetalert2.min.js"></script>
    <script>
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
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 142px;
        }
    </style>
</head>
<body>
    <video class="bg-video" autoplay="autoplay" muted="muted" loop="loop" poster="assets/img/bg.jpg"><source src="assets/mp4/bg.mp4" type="video/mp4" /></video>

        <div class="container" >
            <div class="row" >
                <nav style="border-bottom: 3px solid black;">  
            <input type="checkbox" id="check"/>
            <label for="check" class="checkbtn">
                <i class="fas fa-bars">
                </i>
            </label>
            <asp:Label Text="Turismo Real" CssClass="logo" runat="server" />
            <ul>
                <li>
                    <a href="/Index1" class="active">Home</a>
                </li>
                <li>
                    <a href="/Servicios">Servicios</a>
                </li>
                <li>
                    <a href="/Index1">Reservar</a>
                </li><li>
                    <a href="/Login1">Log in</a>
                </li>
            </ul>
        </nav>
            </div>
            <div class="row" style="height:100%;" >
                <form id="form1" runat="server">
            <div class="container-main" >
                <div class="card" style="margin: 20px;" >
                    <h5 style="font-family: 'Lobster'; font-size: 55px;">¿Buscas arriendo?</h5>
                    <br />
                    <p>
                        Somos una empresa dedicada al arriendo de departamentos ubicados en diferentes zonas turísticas a lo
                        largo de Chile, además, ofrecemos servicios de transporte y tours guiados para mejorar su experencia con nosotros.
                    </p>
                    <h2 style="margin-top:20px;">RESERVA AQUÍ</h2>
                    <div class="container">
                        <table class="tabla" >
                            <tr>
                               <td class="auto-style1">
                                   Región
                               </td>
                                  
                                <td>
                                    <asp:DropDownList  class="form-control" AutoPostBack="true" ID="Cmb_Region" runat="server"  ToolTip="Seleccionar región de destino" OnSelectedIndexChanged="Cmb_Region_SelectedIndexChanged">

                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Cmb_Region" Display="Dynamic" ErrorMessage="Olvidaste seleccionar región" ForeColor="#A2D9CE" ValidationGroup="Validador1" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                               <td class="auto-style1">
                                   Provincia
                               </td>
                                  
                                <td>
                                    <asp:DropDownList  class="form-control" AutoPostBack="true"  ID="Cmb_Provincia" runat="server"  ToolTip="Seleccionar región" OnSelectedIndexChanged="Cmb_Provincia_SelectedIndexChanged">
                                    
                                </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Cmb_Provincia" Display="Dynamic" ErrorMessage="Olvidaste seleccionar provincia" ForeColor="#A2D9CE" ValidationGroup="Validador1" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                               <td class="auto-style1">
                                   Comuna
                               </td>
                                  
                                <td>
                                    <asp:DropDownList  class="form-control" AutoPostBack="true" ID="Cmb_Comuna" runat="server"  ToolTip="Seleccionar región" OnSelectedIndexChanged="Cmb_Comuna_SelectedIndexChanged">
                                   
                                </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Cmb_Comuna" Display="Dynamic" ErrorMessage="Olvidaste seleccionar comuna" ForeColor="#A2D9CE" ValidationGroup="Validador1" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                               <td class="auto-style1">
                                   Fecha llegada
                               </td>
                                  
                                <td>
                                    <asp:TextBox ID="Txt_Fecha_Llegada" CssClass="form-control" runat="server" ToolTip="Seleccionar fecha de llegada" Textmode="Date" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txt_Fecha_Llegada" Display="Dynamic" ErrorMessage="Olvidaste ingresar fecha de llegada" ForeColor="#A2D9CE" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                               <td class="auto-style1">
                                   Fecha salida
                               </td>
                                  
                                <td>
                                    <asp:TextBox ID="Txt_Fecha_Salida" CssClass="form-control" runat="server" ToolTip="Seleccionar fecha de salida" Textmode="Date" ></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Txt_Fecha_Salida" Display="Dynamic" ErrorMessage="Olvidaste ingresar fecha de salida" ForeColor="#A2D9CE" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="Btn_Disponibilidad" CssClass="btn-disponibilidad" Text="ver disponibilidad" runat="server" ValidationGroup="Validador1" OnClick="Btn_Disponibilidad_Click"/>
                        
                        ¿Ya reservaste y necesitas contratar un servicio extra? <a href="/Login" style="color:white"> Ingresa aquí</a>
                    </div>
                    <br />
                </div>
            </div>
            </form>
            </div>
            
        </div>
</body>
</html>

