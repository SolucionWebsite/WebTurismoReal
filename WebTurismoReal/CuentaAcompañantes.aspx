<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuentaAcompañantes.aspx.cs" Inherits="WebTurismoReal.CuentaAcompañantes" %>

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
    <style> 
        td{
            padding-left:10px;
            padding-right:10px;
            padding-bottom:5px;
            padding-top:5px;
        }
        .scroll-div {
            margin-top: 10px; 
            width:1020px;
            padding: 2px; 
            overflow:scroll; 
            height:100%;
        }

        @media (max-width: 952px) {
            .scroll-div {
                margin-top: 10px;
                width: 100%;
                padding: 2px;
                overflow: scroll;
                height: 100%;
            }
        }
    </style>
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
                  text: 'Algo ocurrió!',
                  iconColor: '#117A65',
                  confirmButtonColor: '#117A65'
                })
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
                                <td><asp:Button ID="Btn_Reservas" CssClass="btn" Text="Mis reservas" runat="server" OnClick="Btn_Reservas_Click"/></td>
                            
                            </tr>
                            <tr>
                                <td><asp:Button ID="Btn_Servicios" CssClass="btn" Text="Servicios Extra" runat="server" OnClick="Btn_Servicios_Click"/></td>
                                <td><asp:Button ID="Btn_Clave" CssClass="btn" Text="Cambiar contraseña" runat="server" OnClick="Btn_Clave_Click"/></td>
                            </tr>
                            <tr>
                                <td><asp:Button ID="Btn_Acompañantes" CssClass="btn-active" Text="Mis acompañantes" runat="server" OnClick="Btn_Acompañantes_Click"/></td>
                                <td><asp:Button ID="Btn_Cerrar_Sesion" CssClass="btn" Text="Cerrar Sesión" runat="server" OnClick="Btn_Cerrar_Sesion_Click1"/></td>
                            </tr>
                        </table>
                    </div>

                    <div class="card" style="margin-top:5px; padding:15px;">
                        <div class="row">
                            <h5 style="font-size:18px;">Mis acompañantes</h5>
                        </div>
                        <div class="scroll-div" >
                           <% WebTurismoReal.BLL.AcompañanteBLL a = new WebTurismoReal.BLL.AcompañanteBLL();
                               var coleccion = a.ListaA(Int32.Parse(Session["IdUsuario"].ToString()));
                               if (coleccion == null || coleccion.Count == 0)
                               {%>
                            <div class="row">
                                <div class="col">
                                <h6>No tienes acompañantes ingresados.</h6>
                                </div>
                            </div>
                            <%}%>
                            <%else
                            {%>
                            <table >
                                <tr style="width:100%; white-space:nowrap; margin-top:3px; height:100%; color:white; background-color:#117A65; " >
                                    <td>
                                        
                                    </td>
                                    <td style="visibility:collapse; display:none; ">
                                        
                                    </td>
                                    <td>
                                        NOMBRE
                                    </td>
                                    <td>
                                        PRIMER APELLIDO
                                    </td>
                                    <td>
                                        SEGUNDO APELLIDO
                                    </td>
                                    <td>
                                        RUT
                                    </td>
                                    <td>
                                        FECHA DE NACIMIENTO
                                    </td>
                                    <td>
                                        TELÉFONO
                                    </td>
                                    <td>
                                        CORREO
                                    </td>
                                </tr>
                            <asp:Repeater runat="server" id="Repeater1" OnItemCommand="ItemSelect" EnableVIewState = "true">
                                <ItemTemplate>
                                    <asp:Panel id="FilaRepeater" runat="server" BackColor="Gainsboro" style="width:100%; margin-top:3px; height:100%; color:black;" >
                                    <tr style="white-space:nowrap; color:black;">
                                    <td>
                                        <asp:Button Text="SELECCIONAR" CssClass="btn" style="height:30px;" runat="server" /></td>
                                    <td  style="visibility:collapse; display:none;">
                                        <asp:Label Text="" runat="server" /><%# DataBinder.Eval(Container.DataItem, "Id")%>
                                        
                                    </td>
                                    <td><p><%# DataBinder.Eval(Container.DataItem, "Nombre")%></p></td>
                                    <td><p><%# DataBinder.Eval(Container.DataItem, "ApellidoP")%></p></td>
                                    <td><p><%# DataBinder.Eval(Container.DataItem, "ApellidoM")%></p></td>
                                    <td>
                                        <asp:Label ID="LblRut" Text="text" runat="server" /><%# DataBinder.Eval(Container.DataItem, "Rut")%></td>
                                    <td><p><%# DataBinder.Eval(Container.DataItem, "FechaNac")%></p></td>
                                    <td><p><%# DataBinder.Eval(Container.DataItem, "Telefono")%></p></td>
                                    <td><p><%# DataBinder.Eval(Container.DataItem, "Correo")%></p></td>
                                    
                                </tr>
                                        </asp:Panel>
                            
                                </ItemTemplate>
                            </asp:Repeater>
                                </table>
                            <%}%>
                               
                            </div>
                        <div>
                            <div style="margin-top: 10px; width:100%; padding:10px; overflow:scroll; height:100%;" >
                            <asp:GridView ID="GridAcompañantes" runat="server" DataKeyNames="ID" CssClass="gridview" BackColor="#0B5345" BorderStyle="none" BorderColor="#117A65" OnSelectedIndexChanged="GridAcompañantes_SelectedIndexChanged" >
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
                            <br />
                            <div>
                                <asp:Button ID="Btn_Añadir_Acompañante" Text="Añadir acompañante" CssClass="btn" style="width:50%; " runat="server" OnClick="Btn_Añadir_Acompañante_Click" />
                            </div>
                      </div>
                    </div>

                    <asp:Panel ID="PanelAñadirAcompañantes" Visible="false" runat="server">
                    <div class="card" style="margin-top:5px;">
                        <div class="rowlist">
                        <div class="a-container">
                                <div class="fila">
                                        <div class="columna-1" style="width:100%;">
                                            <asp:TextBox ID="Txt_Nombre_A" CssClass="form-control1" placeholder="Ingresa el nombre" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txt_Nombre_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el nombre" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator  runat="server" ErrorMessage="No se permiten carácteres especiales" 
                                            ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Nombre_A" Display="Dynamic" ForeColor="white" 
                                            ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                            <div class="fila">
                                        <div class="columna-1" style="width:100%;">
                                            <asp:TextBox ID="Txt_Apellido_A" CssClass="form-control1" placeholder="Ingresa el apellido paterno" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txt_Apellido_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el apellido paterno" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator  runat="server" ErrorMessage="No se permiten carácteres especiales" 
                                            ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Apellido_A" Display="Dynamic" ForeColor="white" 
                                            ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                            <div class="fila">
                                        <div class="columna-1" style="width:100%;">
                                            <asp:TextBox ID="Txt_Apellido_M" CssClass="form-control1" placeholder="Ingresa el apellido materno" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txt_Apellido_M" Display="Dynamic" ErrorMessage="Olvidaste ingresar el apellido materno" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator  runat="server" ErrorMessage="No se permiten carácteres especiales" 
                                            ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Apellido_M" Display="Dynamic" ForeColor="white" 
                                            ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                            <div class="fila">
                                        <div class="columna-1" style="width:100%;">
                                            <asp:TextBox ID="Txt_Telefono_A" CssClass="form-control1" placeholder="Teléfono sin código +569"  runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txt_Telefono_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el teléfono" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                    ControlToValidate="Txt_Telefono_A" ErrorMessage="El teléfono debe ser de 8 números"
                                                                    ForeColor="white"
                                                                    ValidationExpression="^[0-9]{8}$" Display="Dynamic">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="fila">
                                            <div class="columna-1" style="width:100%;">
                                                <asp:TextBox ID="Txt_Rut_A" CssClass="form-control1" placeholder="Rut con puntos y guíon"  runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Txt_Rut_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el teléfono" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator  runat="server" ErrorMessage="Olidaste puntos y guión" ValidationExpression="^(\d{1,3}(\.?\d{3}){2})\-?([\dkK])$" ControlToValidate="Txt_Rut_A" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                    
                                            </div>
                                        </div>
                                            <div class="fila">
                                        <div class="columna-1" style="width:100%;">
                                            <asp:TextBox ID="Txt_Nacimiento_A" CssClass="form-control1" placeholder="Ingresa la fecha de nacimiento"  textmode="Date"  runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Txt_Nacimiento_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar la fecha de nacimiento" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        
                                        </div>
                                    </div>
                                            <div class="fila">
                                        <div class="columna-1" style="width:100%;">
                                            <asp:TextBox ID="Txt_Correo_A" CssClass="form-control1" TextMode="Email" placeholder="Ingresa el correo" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Txt_Correo_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el correo" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        
                                        </div>
                                    </div>
                                            <div class="fila">
                                        <div class="columna-1" style="width:100%;">
                                            <asp:DropDownList ID="CmbGenero" CssClass="form-control1" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" InitialValue="0" runat="server" ControlToValidate="CmbGenero" Display="Dynamic" ErrorMessage="Olvidaste ingresar el género" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        
                                        </div>
                                    </div>
                                            <div class="fila">
                                        <div class="columna-1" style="width:100%;">
                                            <asp:DropDownList ID="CmbNacionalidad" CssClass="form-control1" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ControlToValidate="CmbNacionalidad" Display="Dynamic" ErrorMessage="Olvidaste ingresar el nacionalidad" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                        
                                        </div>
                                    </div>
                                    <br />
                            <div>
                                            <asp:Button ID="Btn_Guardar" CssClass="btn" Text="Guardar" runat="server" OnClick="Btn_Guardar_Click" />
                                        </div>
                            </div>
                            
                    </div>
                        
                        </div>
                    </asp:Panel>

                    </div>
                </form>
                </div>
    
</body>
</html>
