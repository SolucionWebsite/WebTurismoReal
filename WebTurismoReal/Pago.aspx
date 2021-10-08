<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="WebTurismoReal.Pago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="essss">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" >
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Didact+Gothic&family=Lobster&display=swap" rel="stylesheet">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <title>OnlinePago</title>
    <style>
        .TextBox{
            outline-color: darkorange;
            height:30px;
            border-radius:5px;
            border: 1px solid lightgrey;
            line-height:30px;
            text-indent:10px;
            width: 100%;
        
        }
        .logo {
            font-family: 'Lobster', cursive;
            color:#117A65;
            font-size: 35px;
            line-height: 80px;
            padding-left: 10px;
            margin-bottom: 10px;
        }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <div class="container" style="width:60%; border:3px solid lightgrey; align-content:center">
                <asp:Panel runat="server" style="margin:20px;" >
                    <h3>OnlinePago</h3>
                    <table>
                        <tr>
                            <td><h5 style="margin-top:10px;">Estás comprando en </h5></td>
                            <td><asp:Label Text="Turismo Real" CssClass="logo" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="text-align:right;"><h5>Total a pagar: </h5></td>
                            <td>
                                <h5><asp:Label ID="LblTtotal" Text="" runat="server" /></h5></td>
                        </tr>
                    </table>
                    <br />
                    <div class="container" style="width:50%" >
                        <h5>Método de pago</h5>
                        <asp:DropDownList ID="CmbPago" runat="server" CssClass="TextBox" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="CmbPago_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="Seleccionar" />
                            <asp:ListItem Value="1" Text="Crédito" />
                            <asp:ListItem Value="2" Text="Débito" />
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Panel ID="PanelDebito" runat="server" Visible="false">
                            <asp:DropDownList ID="CmbBanco" runat="server" CssClass="TextBox">
                            <asp:ListItem  Text="Selecciona banco" />
                            <asp:ListItem  Text="Banco Estado" />
                            <asp:ListItem Text="Banco BCI" />
                            <asp:ListItem Text="Banco Scotiabank" />
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="CmbBanco" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                            <br />
                            <br />
                            <asp:TextBox ID="TxtRut" MaxLength="10" CssClass="TextBox" placeholder="Ingrese su rut" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtRut" Display="Dynamic"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                            <asp:TextBox ID="TxtClave" TextMode="Password" MaxLength="4" CssClass="TextBox" placeholder="Ingrese su clave" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtClave" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                            <br />
                            <br />
                            <asp:Panel ID="PanelClave" runat="server">
                                <h6>Coordenadas</h6>
                                <div class="row">
                                    <div class="col"><asp:TextBox ID="TxtCoo1" CssClass="TextBox" placeholder="H1" MaxLength="2" runat="server" /></div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="*" ControlToValidate="TxtCoo1" Display="Dynamic"></asp:RequiredFieldValidator>
                           
                                    <div class="col"><asp:TextBox ID="TxtCoo2" CssClass="TextBox" placeholder="J8" MaxLength="2" runat="server" /></div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ErrorMessage="*" ControlToValidate="TxtCoo2" Display="Dynamic"></asp:RequiredFieldValidator>
                           
                                    <div class="col"><asp:TextBox ID="TxtCoo3" CssClass="TextBox" placeholder="J5" MaxLength="2" runat="server" /></div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ErrorMessage="*" ControlToValidate="TxtCoo3" Display="Dynamic"></asp:RequiredFieldValidator>
                           
                                </div>
                                <br />
                                <asp:Button ID="BtnPagar1" Text="Aceptar" runat="server" class="btn btn-success btn-block" OnClick="BtnPagar1_Click"/>
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel ID="PanelCredito" runat="server" Visible="false">
                            <div class="row">
                                <div class="col">
                                     <asp:TextBox ID="TxtNumero" CssClass="TextBox"  MaxLength="10" placeholder="Ingrese su número de tarjeta" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtNumero" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col">
                                    <asp:TextBox ID="TxtFecha"  AutoCompleteType="None" CssClass="TextBox" MaxLength="5" placeholder="Fecha vencimiento" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtFecha" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                                </div>
                                <div class="col">
                                     <asp:TextBox ID="TxtCodigo" CssClass="TextBox" MaxLength="3" placeholder="Código seguridad" runat="server" AutoCompleteType="None" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtCodigo" Display="Dynamic"></asp:RequiredFieldValidator>
                            
                                </div>
                            </div>
                            <br />
                                <asp:Button ID="BtnPagar2" Text="Aceptar" runat="server" class="btn btn-success btn-block" OnClick="BtnPagar2_Click"/>
                        </asp:Panel>
                    </div>
                </asp:Panel>
            </div>
            
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" ></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" ></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
</body>
</html>