<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acompañantes.aspx.cs" Inherits="WebTurismoReal.Acompañantes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acompañantes</title>
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
        .progreso {
            background-color: #117A65;
            position: absolute;
            top: 50%;
            left: 0;
            transform: translateY(-50%);
            height: 2px;
            width: 75%;
            z-index: -1;
            transition: 0.4s ease;
        }
    </style>
</head>
<script>
    function Pagar() {
        swal.fire({
            title: "Es momento de pagar!",
            text: 'Para reservar es necesario abonar un 30% del total de la reserva, si continúas serás redirigido a una página web de pago',
            type: "question",
            showDenyButton: true,
            confirmButtonText: 'Continuar',
            confirmButtonColor: '#117A65',
            denyButtonText: 'Cancelar',
            denyButtonColor: '#117A65',
            showCloseButton: true,
            iconColor: '#117A65'
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = "/Pago";
            }
            else if (result.isDenied) {
                window.location.href = "/Index";
            }
        }
        );
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
    function Imposible() {
        Swal.fire({
            icon: 'warning',
            title: 'Oops, revisa la fecha de nacimiento...',
            text: 'La fecha no puede ser mayor a la fecha de hoy!',
            iconColor: '#117A65',
            confirmButtonColor: '#117A65'
        })
    }
    function ReservaConFechaRepetida() {
        swal.fire({
            title: "La fecha de ingreso ya tiene una reserva!",
            text: 'Vuelve a la página principal para cambiar la fecha de reserva',
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
                <div class="card" style="margin-top: 5px;">
                    <h5 style="font-size: 30px; margin-bottom: 5px;">Registra a tus acompañantes</h5>
                    <asp:Label Text="Este paso es opcional por ahora, puedes añadir, modificar o quitar acompañantes en tu cuenta más tarde, pero obligatoriamente debes registrarlos al menos 24 horas antes del ingreso al departamento" runat="server" />
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
            <div class="row" style="height: 100%">
                <div class="card" style="margin-top: 5px; height: 100%; padding: 30px;">
                    <div class="rowlist">
                        <fieldset style="border: 2px solid white;">
                            <legend style="font-weight: 200;">Lista de acompañantes</legend>
                            <div>
                                <asp:ListBox ID="ListaAcompanantes" CssClass="form-control" Style="height: 100px;" runat="server">
                                    <asp:ListItem Text="ksdsk" />
                                    <asp:ListItem Text="" />
                                </asp:ListBox>
                            </div>
                        </fieldset>

                        <div class="a-container">
                            <div class="fila">
                                <div class="columna-1" style="width: 100%;">
                                    <asp:TextBox ID="Txt_Nombre_A" CssClass="form-control1" placeholder="Ingresa el nombre" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txt_Nombre_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el nombre" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="No se permiten carácteres especiales"
                                        ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Nombre_A" Display="Dynamic" ForeColor="white"
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="fila">
                                <div class="columna-1" style="width: 100%;">
                                    <asp:TextBox ID="Txt_Apellido_A" CssClass="form-control1" placeholder="Ingresa el apellido paterno" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txt_Apellido_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el apellido paterno" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="No se permiten carácteres especiales"
                                        ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Apellido_A" Display="Dynamic" ForeColor="white"
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="fila">
                                <div class="columna-1" style="width: 100%;">
                                    <asp:TextBox ID="Txt_Apellido_M" CssClass="form-control1" placeholder="Ingresa el apellido materno" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Txt_Apellido_M" Display="Dynamic" ErrorMessage="Olvidaste ingresar el apellido materno" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="No se permiten carácteres especiales"
                                        ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="Txt_Apellido_M" Display="Dynamic" ForeColor="white"
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="fila">
                                <div class="columna-1" style="width: 100%;">
                                    <asp:TextBox ID="Txt_Telefono_A" CssClass="form-control1" placeholder="Teléfono sin código +569" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txt_Telefono_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el teléfono" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                        ControlToValidate="Txt_Telefono_A" ErrorMessage="El teléfono debe ser de 8 números"
                                        ForeColor="white"
                                        ValidationExpression="^[0-9]{8}$" Display="Dynamic">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="fila">
                                <div class="columna-1" style="width: 100%;">
                                    <asp:TextBox ID="Txt_Rut_A" CssClass="form-control1" placeholder="Rut con puntos y guíon" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Txt_Rut_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el teléfono" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="Olidaste puntos y guión" ValidationExpression="^(\d{1,3}(\.?\d{3}){2})\-?([\dkK])$" ControlToValidate="Txt_Rut_A" Display="Dynamic" ForeColor="white" ValidationGroup="Validador1"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="fila">
                                <div class="columna-1" style="width: 100%;">
                                    <asp:TextBox ID="Txt_Nacimiento_A" CssClass="form-control1" placeholder="Ingresa la fecha de nacimiento" TextMode="Date" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Txt_Nacimiento_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar la fecha de nacimiento" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="fila">
                                <div class="columna-1" style="width: 100%;">
                                    <asp:TextBox ID="Txt_Correo_A" CssClass="form-control1" TextMode="Email" placeholder="Ingresa el correo" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Txt_Correo_A" Display="Dynamic" ErrorMessage="Olvidaste ingresar el correo" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="fila">
                                <div class="columna-1" style="width: 100%;">
                                    <asp:DropDownList ID="CmbGenero" CssClass="form-control1" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" InitialValue="0" runat="server" ControlToValidate="CmbGenero" Display="Dynamic" ErrorMessage="Olvidaste ingresar el género" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="fila">
                                <div class="columna-1" style="width: 100%;">
                                    <asp:DropDownList ID="CmbNacionalidad" CssClass="form-control1" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ControlToValidate="CmbNacionalidad" Display="Dynamic" ErrorMessage="Olvidaste ingresar el nacionalidad" ForeColor="white" ValidationGroup="Validador"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <br />
                        </div>

                        <div class="fila">
                            <div class="columna-1" style="width: 50%; padding: 10px;">
                                <asp:Button ID="Btn_Añadir" CssClass="btn" Text="Añadir" runat="server" ValidationGroup="Validador" OnClick="Btn_Añadir_Click" />
                            </div>
                            <div class="columna-2" style="width: 50%;">
                                <asp:Button ID="Btn_Continuar" CssClass="btn" Text="Continuar" runat="server" OnClick="Btn_Continuar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
