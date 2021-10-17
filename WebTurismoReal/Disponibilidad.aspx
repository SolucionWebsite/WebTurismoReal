<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Disponibilidad.aspx.cs" Inherits="WebTurismoReal.Disponibilidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Disponibilidad</title>
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
    <script type="text/javascript">
    $(document).ready(function(){

          var height = $(window).height();

          $('.col-2').height(height);
    });
</script>
<style>
        .progreso {
    background-color: #117A65;
    position: absolute;
    top: 50%;
    left: 0;
    transform: translateY(-50%);
    height: 2px;
    width: 25%;
    z-index: -1;
    transition: 0.4s ease;
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
        <form id="form1" runat="server">
        
        <div class="row">
                <div class="card" style="margin-top:5px; color:black;">
                    <h5 style="font-size:25px; margin-bottom:4px;">Departamentos disponibles en</h5>
                    <asp:Label ID="Lbl_Comuna" Text="" runat="server" />
                    <asp:Label ID="Lbl_Id_Comuna" Text="" Visible="false" runat="server" />
                    <asp:Label ID="Lbl_Provincia" Text="" runat="server" />
                    <asp:Label ID="Lbl_Id_Provincia" Text="" Visible="false" runat="server" />
                    <asp:Label ID="Lbl_Región" Text="" runat="server" />
                    <asp:Label ID="Lbl_Id_Region" Text="" Visible="false" runat="server" />

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
            

            <div class="row" >
                    <div class="card">
                <div class="div-blanco">
                <asp:GridView ID="GridDepartamentos" runat="server" DataKeyNames="ID" CssClass="gridview" BackColor="#0B5345" BorderStyle="none" BorderColor="#117A65" OnSelectedIndexChanged="GridDepartamentos_SelectedIndexChanged" >
                    <AlternatingRowStyle Wrap="False" />
                    <HeaderStyle BackColor="#117A65" CssClass="Gridheader" Wrap="false" HorizontalAlign="Center" ForeColor="White" />
                    <PagerStyle ForeColor="#117A65" HorizontalAlign="Center"/>
                    <RowStyle BackColor="white" ForeColor="black" Wrap="false" />
                    <SelectedRowStyle BackColor="#0B5345" ForeColor="White" />
                    <Columns>
                        <asp:ButtonField ControlStyle-CssClass="btn" ControlStyle-Height="30px" ButtonType="Button" CommandName="Select" ShowHeader="True" Text="Seleccionar" >
                        <ControlStyle  CssClass="btn" Height="30px"></ControlStyle>
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
                </div>
            </div>
            <div class="card" style="margin-top:5px;">
                <div style="margin:20px; height:100%;">
                    <div class="row" style="height:100%;">
                        <table class="tabla1">
                            <tr>
                                <td style="text-align:right;">Fechas de estadía</td>
                                <td style="text-align:left; padding-left:10px;">
                                    <asp:Label ID="Lbl_Fechas" text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">Número de acompañantes</td>
                                <td style="text-align:left; padding-left:10px;"><asp:TextBox TextMode="Number" runat="server" placeholder="Ingresa tus acompañantes" class="form-control1" type="texbox" ID="txt_acompañantes" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_acompañantes" Display="Dynamic" ErrorMessage="Olvidaste ingresar n° de acompañantes" ForeColor="#A2D9CE" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                        
                                </td>
                            </tr>
                        </table>
                        <br />
                        <div class="row">
                        <asp:Button ID="Btn_Calcular" CssClass="btn" Text="Calcular total" runat="server" ValidationGroup="Validador1" OnClick="Btn_Calcular_Click" />
                        </div>
                        <br />
                        <div class="row" style="border: 1px solid black; height:150px;">
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
                            </div>
                        <br />
                        <div class="row">
                        <asp:Button ID="Btn_Reservar" CssClass="btn" Text="Continuar" runat="server" OnClick="Btn_Reservar_Click" />
                            <p style="text-align:center;">Podrás contratar un servicio posterior a la reserva, para más información visita la pestaña "Servicios".</p>
                        </div>
                        
                    </div>
                </div>
            </div>
            
            </div>
            </form>
        </div>
            
</body>
</html>
