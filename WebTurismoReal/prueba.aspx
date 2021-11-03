<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="WebTurismoReal.prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Estilo.css" rel="stylesheet" type="text/css"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimun-scale=1.0" />
    <style> 
        .gridView {
            margin:0 auto;
            text-align:center;
            border:hidden;
            width: 100%;
        }

        .gridView td {
            padding-left:10px;
            padding-right:10px;
            padding-bottom:5px;
            padding-top:5px;
            border:hidden;
            white-space: nowrap;
            border: 1.5px solid darkgray;
            background-color: gainsboro;
        }
        .gridViewHeader{
            height:100%;
        }
 
        .gridViewHeader th {
        background-color:#117A65;
        padding-left:10px;
        padding-right:10px;
        padding-bottom:5px;
        padding-top:5px;
        border:hidden;
        color:white;
        font-weight: lighter;
        white-space:nowrap;
        border: 1px solid gray;
        }

        .gridViewHeader th:first-child {
        border-radius:5px 0 0 0;
        }

        .gridViewHeader th:last-child {
        border-radius:0 5px 0 0;
        }

        .scroll-div {
    margin-top: 10px;
    width: 100%;
    padding: 2px;
    overflow: scroll;
    height: 200px;
}

    .scroll-div::-webkit-scrollbar {
        width: 8px;
        height: 8px;
    }

    .scroll-div::-webkit-scrollbar-thumb {
        background: gray;
        border-radius: 4px;
    }

        .scroll-div::-webkit-scrollbar-thumb:active {
            background: blue;
        }

        .scroll-div::-webkit-scrollbar-thumb:hover {
            background: darkgray;
            box-shadow: 0 0 2px 1px rgba(0, 0, 0, 0.2);
        }

    .scroll-div::-webkit-scrollbar-track {
        background: rgba(255, 255, 255, 0.4);
        border-radius: 4px;
    }

        .scroll-div::-webkit-scrollbar-track:hover,
        .scroll-div::-webkit-scrollbar-track:active {
            background: gainsboro;
        }

::-webkit-scrollbar-corner {
    background-color: rgba(255, 255, 255, 0.4);
}


    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <asp:Panel ID="PanelTour" runat="server">
                    <div class="card" style="margin-top:5px;">
                    <p>Seleccionar tour</p>
                        <div class="scroll-div">
                    <asp:GridView ID="GridTours" runat="server" DataKeyNames="ID" CssClass="gridView" >
                            <AlternatingRowStyle Wrap="False" />
                            <HeaderStyle CssClass="gridViewHeader" />
                            <PagerStyle />
                            <RowStyle Wrap="false" />
                            <SelectedRowStyle CssClass="gridViewSeleccionada" />
                            <Columns>
                                <asp:ButtonField ControlStyle-CssClass="btn" ControlStyle-Height="30" ButtonType="Button" CommandName="Select" ShowHeader="True" Text="Seleccionar">
                                    <ControlStyle CssClass="btn" Height="30px"></ControlStyle>
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                            </div>
                        </div>
                </asp:Panel>
        

        <div class="card">   
            <asp:TextBox ID="txt" runat="server" />
            <asp:ValidationSummary ID="ValidationSummary1" HeaderText="La contraseña debe tener al menos:" DisplayMode="BulletList" ValidationGroup="1" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="1" ControlToValidate="txt" runat="server" Display="None"  ValidationExpression="^(?=.*?[A-Z]).{8,}$" ErrorMessage="1 letra máyuscula"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="1" ControlToValidate="txt" runat="server" Display="None"  ValidationExpression="^(?=.*?[a-z]).{8,}$" ErrorMessage="1 letra minúscula"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="1" ControlToValidate="txt" runat="server" Display="None" ValidationExpression="^(?=.*?[0-9]).{8,}$" ErrorMessage="1 número"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationGroup="1" ControlToValidate="txt" runat="server" Display="None" ValidationExpression="^(?=.*?[#?!@$%^&*-.]).{8,}$" ErrorMessage="1 carácter especial"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationGroup="1" ControlToValidate="txt" runat="server" Display="None" ValidationExpression="^(?=.*?[A-Z]).{8,}$" ErrorMessage="un largo de mínimo 8 carácteres"></asp:RegularExpressionValidator>
            <asp:Button ValidationGroup="1" Text="jaj" runat="server" />
            </div>
                
            
    </form>
</body>
</html>
