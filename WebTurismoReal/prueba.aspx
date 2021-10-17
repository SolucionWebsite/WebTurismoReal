<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="WebTurismoReal.prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Estilo.css" rel="stylesheet" type="text/css"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimun-scale=1.0" />
    <style> 
        .redondo{
          display: block;
          width: 30px;
          height: 30px;
          border-radius: 50%;
          border-style: solid;
          border-color: white;
          font-size: 16px;
        }
        .contenedor{
            text-align:center;
        }
        .progreso-contenedor{
            display:flex;
            justify-content: space-between;
            position:relative;
            width: 300px;
        }
        .progreso-contenedor::before{
            content: '';
            background-color: gainsboro;
            position: absolute;
            top: 50%;
            left: 0;
            transform: translateY(-50%);
            height: 1px;
            width: 100%;
            z-index: -1;
            transition: 0.4s ease;
        }
        .progreso{
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
<body style="height:100%;">
    
    <form id="form1" runat="server">
        <div>
            <div class="contenerdor">
                <div class="progreso-contenedor">   
                    <div class="progreso" id="progreso"></div>
                    <asp:Button ID="Btn_1" Text="1" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_2" Text="2" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_3" Text="3" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_4" Text="4" CssClass="redondo" runat="server" />
                    <asp:Button ID="Btn_5" Text="5" CssClass="redondo" runat="server" />
                </div>
            </div>

            <div style="height:100%;">   
        <div style="border: 5px solid black; height:100%; position : absolute;">   
            HOLAA
            <asp:TextBox ID="contraseña" runat="server" />
            <asp:Label ID="clavehash" Text="text" runat="server" />
            <asp:Button Text="text" runat="server" OnClick="Unnamed1_Click" />
            <div class="container-main">   
           <fieldset style="text-align:left;">
           <legend style="margin-left:4px;" >Correo</legend>
           <div><asp:TextBox runat="server"  placeholder="Ingresa tu correo" style="outline: none; background-color:rgba(0,0,0,0.0); color:white; border:none;" class="form-control" type="email" ID="TextBox1" />
           </div>
           </fieldset>
            </div>
           <fieldset>
           <legend>Correo</legend>
           <div><asp:TextBox runat="server" placeholder="Ingresa tu correo" legend="Correo" class="form-control" type="email" ID="TextBox2" />
           </div>
           </fieldset>

        </div>
    </div>
        </div>
    </form>
</body>
</html>
