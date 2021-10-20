<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuentaReservas.aspx.cs" Inherits="WebTurismoReal.CuentaReservas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mi cuenta</title>
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
        function SessionExpired() {
        swal.fire({
            title:"Tu sesión expiró!!",
            text: 'Vuelve al login para ingresar nuevamente',
            type: "warning",
                confirmButtonText: 'Volver',
                confirmButtonColor: '#117A65',
                iconColor: '#117A65'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = "/Login";
            }});
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
    </script>
    <style> 
        td{
            width:50%;
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
                    <a href="/CuentaDatos" class="active">Mi Cuenta</a>
                    </li>
                    <%} %>
            </ul>
        </nav>
            </div>
            <form id="form1" runat="server">
            <div class="row">
                <div class="card" style="margin-top:5px;">
                    <h5 style="font-size:30px; margin-bottom:10px;">¡Bienvenido/a!</h5>
                    <asp:Label ID="Lbl_Usuario" Text="[Nombre]" runat="server" />
                </div>
            </div>
                <div class="row" style="margin:auto;">

                    <div class="card" style="margin-top:5px; padding:15px;">
                        <table style="width:100%;">
                            <tr>
                                <td><asp:Button ID="Btn_Datos" CssClass="btn" Text="Mis datos" runat="server" OnClick="Btn_Datos_Click"/></td>
                                <td><asp:Button ID="Btn_Reservas" CssClass="btn-active" Text="Mis reservas" runat="server" OnClick="Btn_Reservas_Click"/></td>
                            
                            </tr>
                            <tr>
                                <td><asp:Button ID="Btn_Servicios" CssClass="btn" Text="Servicios Extra" runat="server" OnClick="Btn_Servicios_Click"/></td>
                                <td><asp:Button ID="Btn_Clave" CssClass="btn" Text="Cambiar contraseña" runat="server" OnClick="Btn_Clave_Click"/></td>
                            </tr>
                            <tr>
                                <td><asp:Button ID="Btn_Acompañantes" CssClass="btn" Text="Mis acompañantes" runat="server" OnClick="Btn_Acompañantes_Click"/></td>
                                <td><asp:Button ID="Btn_Cerrar_Sesion" CssClass="btn" Text="Cerrar Sesión" runat="server" OnClick="Btn_Cerrar_Sesion_Click1"/></td>
                            </tr>
                        </table>
                    </div>

                    <div class="card" style="margin-top:5px; padding:15px;">
                        <div class="row">
                            <h5 style="font-size:18px;">Mis reservas</h5>
                        </div>
                        <div>
                            <div style="margin-top: 10px; width:100%; padding:10px; overflow:scroll; height:100%;" >
                            <asp:GridView ID="GridReservas" runat="server" DataKeyNames="ID" CssClass="gridview" BackColor="#0B5345" BorderStyle="none" BorderColor="#117A65" >
                            <AlternatingRowStyle Wrap="False" />
                            <HeaderStyle BackColor="#117A65" CssClass="Gridheader" Wrap="false" HorizontalAlign="Center" ForeColor="White" />
                            <PagerStyle ForeColor="#117A65" HorizontalAlign="Center"/>
                            <RowStyle BackColor="white" ForeColor="black" Wrap="false" />
                            <SelectedRowStyle BackColor="#0B5345" ForeColor="White" />
                            <Columns>
                                <asp:ButtonField ControlStyle-CssClass="btn" ControlStyle-Height="30px" ButtonType="Button" CommandName="Select" ShowHeader="True" Text="Modificar" >
                                <ControlStyle  CssClass="btn" Height="30px"></ControlStyle>
                                </asp:ButtonField>
                            </Columns>
                            <Columns>
                                <asp:ButtonField ControlStyle-CssClass="btn" ControlStyle-Height="30px" ButtonType="Button" CommandName="Select" ShowHeader="True" Text="Cancelar" >
                                <ControlStyle  CssClass="btn" Height="30px"></ControlStyle>
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                       </div>


                        </div>
                    </div>
                    <asp:Panel ID="PanelModificar" runat="server" Visible="true" >
                    <div class="card" style="margin-top:5px;" >
                     <div class="row" style="text-align:center; margin-top:10px;">¿Qué deseas modificar de la reserva?</div>
                    <div class="container-blanco" style="text-align:center; margin-top:10px; margin-bottom:10px; border:none;">
                        <asp:DropDownList class="form-control1" AutoPostBack="true" ID="Cmb_Opciones" runat="server"  ToolTip="Seleccionar" OnSelectedIndexChanged="Cmb_Opciones_SelectedIndexChanged">
                                    <asp:ListItem>Seleccione</asp:ListItem>
                                    <asp:ListItem>Fecha ida/vuelta</asp:ListItem>
                                    <asp:ListItem>Departamento</asp:ListItem>
                                    </asp:DropDownList>
                    </div>
                     <asp:Panel ID="Panel_Departamento" Visible="false" runat="server">
                        <div class="row" style="text-align:center;">Estos son los departamentos disponibles según las fechas ingresadas</div>
                        <div class="fila" style="margin-top: 10px; width:100%; padding:10px; overflow:scroll; height:100%;" >
                            <asp:GridView ID="GridDepartamentos" runat="server" DataKeyNames="ID" CssClass="gridview" BackColor="#0B5345" BorderStyle="none" BorderColor="#117A65" >
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
                   </asp:Panel>
                   <asp:Panel ID="Panel_Fecha" CssClass="container-blanco" BorderStyle="None" Visible="false" runat="server">
                   <div class="row">
                        <fieldset>
                               <legend>Fecha de ingreso</legend>
                               <div> <asp:TextBox ID="TxtFechaIda"  Text="" TextMode="Date" CssClass="form-control"  runat="server" />
                               </div>
                               </fieldset>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar la fecha de ingreso" ControlToValidate="TxtFechaIda" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                
                   </div>
                   <div class="row" style="margin-top:10px;">
                     <fieldset>
                               <legend>Fecha de regreso</legend>
                               <div> <asp:TextBox ID="TxtFechaRegreso"  Text="" TextMode="Date" CssClass="form-control"  runat="server" />
                               </div>
                               </fieldset>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Olvidaste ingresar la fecha de regreso" ControlToValidate="TxtFechaRegreso" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                
                  </div>
                 </asp:Panel>
                 <br />
                 <asp:Panel ID="Panel_Guardar" Visible="false" runat="server">
                 <div class="fila">
                 <div class="columna-1" style=" padding:5px; width:100%;">
                 <asp:Button CssClass="btn" Text="Guardar cambios" runat="server" />
                 </div>

                 </div>
                 </asp:Panel>
                    </div>
                    </asp:Panel>
                    </div>
            </form>
            </div>
    
</body>
</html>
