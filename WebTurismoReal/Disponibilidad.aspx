<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Disponibilidad.aspx.cs" Inherits="WebTurismoReal.Disponibilidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Disponibilidad</title>
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
        function DepartamentoNoSeleccionado() {
            Swal.fire({
                  icon: 'warning',
                  title: 'Oops...',
                  text: 'Debes seleccionar un departamento!',
                  iconColor: '#117A65',
                  confirmButtonColor: '#117A65'
                })
        }
        function LimiteAcompañantes() {
            Swal.fire({
                  icon: 'warning',
                  title: 'Oops...',
                  text: 'El límite de acompañantes es 9 por departamento!',
                  iconColor: '#117A65',
                  confirmButtonColor: '#117A65'
                })
        } 
        function SinCalcular() {
            Swal.fire({
                  icon: 'warning',
                  title: 'Oops...',
                  text: 'Debes calcular para poder reservar',
                  iconColor: '#117A65',
                  confirmButtonColor: '#117A65'
                })
        }
        function SinDepartamentos() {
        swal.fire({
            title: "Oops...",
            text: 'No hay departamentos disponibles para esta zona',
            type: "warning",
                confirmButtonText: 'Buscar en otra zona',
                confirmButtonColor: '#117A65',
                showCloseButton: true,
                iconColor: '#117A65'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = "/Index";
            }
        }
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
                </li><li>
                    <a href="/Login2">Log in</a>
                </li>
            </ul>
        </nav>
            </div>
        <div class="row">
                <div class="container-1">
                    <h5 style="font-size:30px; margin-bottom:10px;">Departamentos disponibles en</h5>
                    <asp:Label ID="Lbl_Comuna" Text="" runat="server" />
                    <asp:Label ID="Lbl_Id_Comuna" Text="" Visible="false" runat="server" />
                    <asp:Label ID="Lbl_Provincia" Text="" runat="server" />
                    <asp:Label ID="Lbl_Id_Provincia" Text="" Visible="false" runat="server" />
                    <asp:Label ID="Lbl_Región" Text="" runat="server" />
                    <asp:Label ID="Lbl_Id_Region" Text="" Visible="false" runat="server" />
                </div>
            </div>

            <div class="row" >
                <form id="form1" runat="server">
                    <div class="col-1">
                <div style="margin:20px; border:3px solid white; overflow:scroll; height:460px;">
                <asp:GridView ID="GridDepartamentos" runat="server" DataKeyNames="ID" CssClass="gridview" Font-Bold="false" BackColor="#0B5345" BorderStyle="none" BorderColor="#117A65" OnSelectedIndexChanged="GridDepartamentos_SelectedIndexChanged" >
                    <AlternatingRowStyle Wrap="False" />
                    <HeaderStyle BackColor="#117A65" CssClass="Gridheader" Wrap="false" HorizontalAlign="Center" Font-Size="Smaller" ForeColor="White" Font-Bold="False" />
                    <PagerStyle ForeColor="#117A65" HorizontalAlign="Center"/>
                    <RowStyle BackColor="white" ForeColor="black" Wrap="false" />
                    <SelectedRowStyle BackColor="#0B5345" Font-Bold="False" ForeColor="White" />
                    <Columns>
                        <asp:ButtonField ControlStyle-CssClass="btn" ControlStyle-Height="30px" ButtonType="Button" ControlStyle-Font-Size="Smaller" CommandName="Select" HeaderText="SELECCIONA" ShowHeader="True" Text="Seleccionar" >
                        <ControlStyle CssClass="btn" Font-Size="Smaller" Height="30px"></ControlStyle>
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
                </div>
            </div>
            <div class="col-2">
                <div style="margin:20px;">
                    <div class="row">
                        <table style="text-align: center; width:100%">
                            <tr>
                                <td>Fechas de estadía</td>
                                <td>
                                    <asp:Label ID="Lbl_Fechas" text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>Número de acompañantes</td>
                                <td><asp:TextBox TextMode="Number" runat="server" placeholder="Ingresa n° de acompañantes" class="form-control" type="texbox" ID="txt_acompañantes" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_acompañantes" Display="Dynamic" ErrorMessage="Olvidaste ingresar n° de acompañantes" ForeColor="#A2D9CE" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                        
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div class="row">
                        <asp:Button ID="Btn_Calcular" CssClass="btn" Text="Calcular" runat="server" ValidationGroup="Validador1" OnClick="Btn_Calcular_Click" />
                        </div>
                        <br />
                        <div class="row" style="border: 3px solid white; height:150px;">
                            <table style="padding:30px; text-align: right; width:100%">
                                <tr>
                                    <td style="width:50%">Días de reserva: </td>
                                    <td style="text-align:left; width:50%; margin-left:15px; font-weight: bold;">
                                        <asp:Label ID="Lbl_Dias" Text="" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Acompañantes: </td>
                                    <td style="text-align:left; width:50%; margin-left:5px; font-weight: bold;">
                                        <asp:Label ID="Lbl_acompañantes" Text="" runat="server" />

                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:50%">Total: </td>
                                        
                                    <td style="text-align:left; width:50%; margin-left:5px; font-weight: bold;"
                                      ><asp:Label ID="Lbl_Total" Text="" runat="server" /></td>
                                </tr>
                            </table>
                             <br />
                        <div class="row">
                        <asp:Button ID="Btn_Reservar" CssClass="btn" Text="Reservar" runat="server" OnClick="Btn_Reservar_Click" />
                            <p style="text-align:center;">Podrás contratar un servicio posterior a la reserva, para más información visita la pestaña "Servicios".</p>
                        </div>
                        <br />
                        </div>
                    </div>
                </div>
            </div>
            </form>
            </div>
            
        </div>
</body>
</html>
