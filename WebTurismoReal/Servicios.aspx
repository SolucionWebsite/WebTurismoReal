<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="WebTurismoReal.Servicios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Servicios</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimun-scale=1.0" />
    
    <link href="css/Estilo.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Didact+Gothic&family=Lobster&display=swap" rel="stylesheet">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <style>
        .box img {
            width: 100%;
            height: auto;
        }

        @supports(object-fit: cover) {
            .box img {
                height: 100%;
                object-fit: cover;
                object-position: center center;
            }
        }
    </style>
</head>
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
                            <a href="/Servicios" class="active">Servicios</a>
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
                <div class="card-login">
                    <h5 style="font-size: 30px; margin-bottom: 10px;">Servicios que ofrecemos</h5>
                </div>
                <div style="width: 100%; justify-content: center; align-content: center; text-align: center;">
                    <div class="card-login">
                        <div class="box" style="height: 250px;">
                            <img src="/assets/img/Arriendo.jpg" />
                        </div>
                        <div>
                            <h5 style="font-size: 25px;">Arriendo de departamentos</h5>
                            <p>
                                Nuestra empresa Turismo Real ofrece arriendo por día de departamentos ubicados en zonas
                                de alto turismo, el arriendo por día incluye acceso a todas las instalaciones del departamento
                                y el uso de servicios comúnes como luz, agua y electricidad.
                            </p>
                            <p style="font-size: 15px; color: white; text-transform: uppercase; margin-top: 5px;">
                                El valor por día depende de la dirección de destino y días a reservar.
                            </p>
                        </div>
                    </div>
                    <div class="card-login">
                        <div class="box" style="height: 250px;">
                            <img src="/assets/img/Tour.jpg" />
                        </div>
                        <div>
                            <h5 style="font-size: 25px;">Diversos Tours</h5>
                            <p>
                                Si ya reservaste un departamento puedes incluir un tour en la zona que escogiste de 
                                destino, el encargado visitará los puntos más turísticos de la zona explicando su origen y otros aspectos,
                                cada tour comienza a las 9:00 am y termina a las 16:00 pm, 
                                incluye bienvenida con regalo, snack y almuerzo.
                            </p>
                            <p style="font-size: 15px; color: white; text-transform: uppercase; margin-top: 5px;">
                                Un tour se puede reservar 3 veces como máximo por reserva de arriendo y el valor depende del tipo de tour.
                            </p>
                        </div>
                    </div>
                    <div class="card-login" style="margin-bottom: 5px;">
                        <div class="box" style="height: 250px;">
                            <img src="/assets/img/Transporte.jpg" />
                        </div>
                        <div>
                            <h5 style="font-size: 25px;">Transporte desde/hacia destino</h5>
                            <p>
                                Si ya reservaste un departamento puedes incluir un el servicio de transporte, este puede
                                ser hacia y/o desde destino, puedes escoger tu transporte dependiendo de la cantidad de personas
                                que te acompañen en el viaje.
                            </p>
                            <p style="font-size: 15px; text-transform: uppercase; color: white; margin-top: 15px;">
                                El valor depende de la capacidad del vehículo de transporte que elijas.
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>

