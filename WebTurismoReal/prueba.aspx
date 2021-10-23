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


    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <div class="card">
            <div style="overflow:scroll">
                <asp:GridView ID="GridAcompañantes" CssClass="gridView" runat="server" OnSelectedIndexChanged="GridAcompañantes_SelectedIndexChanged">
                    <AlternatingRowStyle Wrap="false"/>
                            <HeaderStyle CssClass="gridViewHeader" />
                            <PagerStyle ForeColor="#117A65" HorizontalAlign="Center" />
                            <RowStyle CssClass="rowStyle" BackColor="gainsboro" ForeColor="black" Wrap="false" BorderStyle="Solid" BorderColor="LightGray" BorderWidth="5px"/>
                            <SelectedRowStyle BackColor="#117A65" ForeColor="black" Wrap="False"/>
                            <Columns>
                                <asp:ButtonField ControlStyle-CssClass="btn" ControlStyle-Height="30px" ButtonType="Button" CommandName="Select" ShowHeader="True" Text="Seleccionar" >
                                <HeaderStyle/>
                                <ControlStyle  CssClass="btn"></ControlStyle>
                                </asp:ButtonField>
                            </Columns>
            </asp:GridView>
            </div>
        </div>
        
            
    </form>
</body>
</html>
