<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="WebTurismoReal.Pago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="essss">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimun-scale=1.0" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
    <link href="css/StylePago.css" rel="stylesheet" type="text/css" />
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
        function ValidarPago() {
            Swal.fire({
                title: 'Estamos validando tu pago!',
                timer: 5000,
                timerProgressBar: true,
                didOpen: () => {
                    Swal.showLoading()
                },
                willClose: () => {
                    window.location.href = "/Comprobante";
                }
            })

        }
    </script>
    <title>OnlinePago</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <div class="container-pago">
                <asp:Panel runat="server" Style="margin: 20px;">
                    <h3>OnlinePago</h3>
                    <table>
                        <tr>
                            <td>
                                <h5 style="margin-top: 10px;">Estás comprando en </h5>
                            </td>
                            <td>
                                <asp:Label Text="Turismo Real" CssClass="logo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <h5>Total a pagar: </h5>
                            </td>
                            <td>
                                <h5>
                                    <asp:Label ID="LblTtotal" Text="" runat="server" /></h5>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="container-pago2">
                        <h5>Método de pago</h5>
                        <asp:DropDownList ID="CmbPago" runat="server" CssClass="TextBox" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="CmbPago_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Seleccionar" />
                            <asp:ListItem Value="1" Text="Crédito" />
                            <asp:ListItem Value="2" Text="Débito" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" InitialValue="0" runat="server" ControlToValidate="CmbPago" Display="Dynamic" ErrorMessage="Debes ingresar tipo de pago" ForeColor="red" ValidationGroup="Validador2"></asp:RequiredFieldValidator>

                        <br />
                        <br />
                        <asp:Panel ID="PanelDebito" runat="server" Visible="false">
                            <asp:DropDownList ID="CmbBanco" runat="server" CssClass="TextBox">
                                <asp:ListItem Text="Selecciona banco" Value="0" />
                                <asp:ListItem Text="Banco Estado" />
                                <asp:ListItem Text="Banco BCI" />
                                <asp:ListItem Text="Banco Scotiabank" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="CmbBanco" ForeColor="Red" Display="Dynamic" ValidationGroup="Validador2"></asp:RequiredFieldValidator>

                            <br />
                            <br />
                            <asp:TextBox ID="TxtRut" MaxLength="12" CssClass="TextBox" placeholder="Ingrese su rut" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtRut" Display="Dynamic" ValidationGroup="Validador2"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ErrorMessage="Olidaste puntos y guión" ValidationExpression="^(\d{1,3}(\.?\d{3}){2})\-?([\dkK])$" ControlToValidate="TxtRut" Display="Dynamic" ForeColor="red" ValidationGroup="Validador2"></asp:RegularExpressionValidator>
                            <br />
                            <br />
                            <asp:TextBox ID="TxtClave" TextMode="Password" MaxLength="4" CssClass="TextBox" placeholder="Ingrese su clave" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtClave" Display="Dynamic" ValidationGroup="Validador2"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ErrorMessage="La clave debe contener 4 números"
                                ValidationExpression="^[0-9]{4}$" ControlToValidate="TxtClave" Display="Dynamic" ForeColor="red"
                                ValidationGroup="Validador2"></asp:RegularExpressionValidator>
                            <br />
                            <br />
                            <asp:Panel ID="PanelClave" runat="server">
                                <h6>Coordenadas</h6>
                                <div class="row">
                                    <div class="col">
                                        <asp:TextBox ID="TxtCoo1" CssClass="TextBox" placeholder="H1" MaxLength="2" runat="server" /></div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Validador2" ForeColor="Red" runat="server" ErrorMessage="*" ControlToValidate="TxtCoo1" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="La coordenada debe contener 2 números"
                                        ValidationExpression="^[0-9]{2}$" ControlToValidate="TxtCoo1" Display="Dynamic" ForeColor="red"
                                        ValidationGroup="Validador2"></asp:RegularExpressionValidator>

                                    <div class="col">
                                        <asp:TextBox ID="TxtCoo2" CssClass="TextBox" placeholder="J8" MaxLength="2" runat="server" /></div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Validador2" ForeColor="Red" runat="server" ErrorMessage="*" ControlToValidate="TxtCoo2" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="La coordenada debe contener 2 números"
                                        ValidationExpression="^[0-9]{2}$" ControlToValidate="TxtCoo2" Display="Dynamic" ForeColor="red"
                                        ValidationGroup="Validador2"></asp:RegularExpressionValidator>

                                    <div class="col">
                                        <asp:TextBox ID="TxtCoo3" CssClass="TextBox" placeholder="J5" MaxLength="2" runat="server" /></div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Validador2" ForeColor="Red" runat="server" ErrorMessage="*" ControlToValidate="TxtCoo3" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="La coordenada debe contener 2 números"
                                        ValidationExpression="^[0-9]{2}$" ControlToValidate="TxtCoo3" Display="Dynamic" ForeColor="red"
                                        ValidationGroup="Validador2"></asp:RegularExpressionValidator>
                                </div>
                                <br />
                                <asp:Button ID="BtnPagar1" Text="Aceptar" runat="server" ValidationGroup="Validador2" class="btn btn-success btn-block" OnClick="BtnPagar1_Click" />
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="PanelCredito" runat="server" Visible="false">
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox runat="server" placeholder="Ingresa el nombre del titular" class="TextBox" type="texbox" ID="TxtNombre" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtNombre" Display="Dynamic" ErrorMessage="Olvidaste ingresar el nombre del titular" ForeColor="red" ValidationGroup="Validador1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="No se permiten carácteres especiales"
                                        ValidationExpression="^[a-z A-Z ñÑ]*$" ControlToValidate="TxtNombre" Display="Dynamic" ForeColor="red"
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="TxtNumero" CssClass="TextBox" MaxLength="10" placeholder="Ingrese su número de tarjeta" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="Validador1" ID="ValidadoNumeroCredito" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtNumero" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="El número de tarjeta debe contener 10 números"
                                        ValidationExpression="^[0-9]{10}$" ControlToValidate="TxtNumero" Display="Dynamic" ForeColor="red"
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="TxtFecha" AutoCompleteType="None" CssClass="TextBox" MaxLength="5" placeholder="Fecha vencimiento" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="Validador1" ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtFecha" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="El formato debe ser MM/yy"
                                        ValidationExpression="^[0-9]{2}/[0-9]{2}$" ControlToValidate="TxtFecha" Display="Dynamic" ForeColor="red"
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="TxtCodigo" CssClass="TextBox" MaxLength="3" placeholder="Código seguridad" runat="server" AutoCompleteType="None" />
                                    <asp:RequiredFieldValidator ValidationGroup="Validador1" ID="RequiredFieldValidator9" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtCodigo" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator runat="server" ErrorMessage="El código debe contener 3 números"
                                        ValidationExpression="^[0-9]{3}$" ControlToValidate="TxtCodigo" Display="Dynamic" ForeColor="red"
                                        ValidationGroup="Validador1"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <br />
                            <asp:Button ID="BtnPagar2" Text="Aceptar" runat="server" class="btn btn-success btn-block" ValidationGroup="Validador1" OnClick="BtnPagar2_Click" />
                        </asp:Panel>
                    </div>
                </asp:Panel>
            </div>

        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
</body>
</html>
