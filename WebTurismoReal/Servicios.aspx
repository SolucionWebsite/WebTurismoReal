<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="WebTurismoReal.Servicios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Servicios</title>
    <link href="css/Estilo.css" rel="stylesheet" type="text/css"/>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Didact+Gothic&family=Lobster&display=swap" rel="stylesheet">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <style>
        .imagen{
            background-repeat: no-repeat;
            background-size: cover;
            background-attachment: fixed;
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
                    <a href="/Servicios" class="active">Servicios</a>
                </li>
                <li>
                    <a href="/Index">Reservar</a>
                </li><%if (Session["IdUsuario"] == null)
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
                <div class="card-login">
                    <h5 style="font-size:30px; margin-bottom:10px;">Servicios que ofrecemos</h5>
                </div>
                <div style="width:100%; justify-content:center; align-content:center; text-align:center;">
                    <div class="card-login">
                        <div >
                            <img src="/assets/img/Arriendo.jpg" class="imagen" style="width:100%; height:200px;"/>
                        </div>
                        <div >
                            <h5 style="font-size: 25px;">Arriendo de departamentos</h5>
                            <p>Nuestra empresa Turismo Real ofrece arriendo por día de departamentos ubicados en zonas
                                de alto turismo, el arriendo por día incluye acceso a todas las instalaciones del departamento
                                y el uso de servicios comúnes como luz, agua y electricidad.
                            </p>
                            <h5 style="font-size: 15px; color:white; margin-top:5px;">
                                El valor por día depende de la dirección de destino y días a reservar.
                            </h5>
                        </div>
                </div>
                <div class="card-login">
                        <div>
                            <img src="/assets/img/Tour.jpg" style="width:100%; height:200px;"/>
                        </div>
                        <div>
                            <h5 style="font-size: 25px;">Tour guíado por la zona</h5>
                            <p> Si ya reservaste un departamento puedes incluir un tour guíado por la zona que escogiste de 
                                destino, el encargado visitará los puntos más turísticos de la zona explicando su origen,
                                el tour comienza a las 9:00 am y termina a las 16:00 pm, 
                                incluye bienvenida con regalo, snack y almuerzo.
                            </p>
                            <h5 style="font-size: 15px; color:white; margin-top:5px;">
                                El tour se puede reservar 3 veces por reserva de arriendo y tiene un valor de $15.000 por
                                persona.
                            </h5>
                        </div>
                </div>
                    <div class="card-login">
                        <div>
                            <img src="/assets/img/Transporte.jpg" style="width:100%; height:200px;"/>
                        </div>
                        <div>
                            <h5 style="font-size: 25px;">Transporte desde/hacia destino</h5>
                            <p> Si ya reservaste un departamento puedes incluir un el servicio de transporte, este puede
                                ser hacia y/o desde destino, puedes escoger tu transporte dependiendo de la cantidad de personas
                                que te acompañen en el viaje.
                            </p>
                            <h5 style="font-size: 15px; color:white; margin-top:15px;">
                                El valor depende de la capacidad del vehículo de transporte que elijas.
                            </h5>
                        </div>
                </div>
                    </div>
                </div>
            </form>
            </div>
</body>
</html>

