using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTurismoReal.BLL
{
    public class PDFComprobante
    {
        public string Comprobante { get; set; }
        public string Fecha { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public string Ubicacion { get; set; }
        public string Dias { get; set; }
        public string Tipo { get; set; }
        public string ValorReserva { get; set; }
        public string Abono { get; set; }
        public string ValorRestante { get; set; }

        public string PDFContenido(PDFComprobante comprobante)
        {
            string cuerpo = "<div style=\"text-align:center;\">  " +
                "<h2>COMPROBANTE DE COMPRA<h2></div>" +
                "<br/>"+
                "<div style=\"text-align:center;\">  " +
                "<p>DETALLE DE LA COMPRA</p></div>" +
                "<table style=\"padding:10px; text-align:right; width:100%; border: 1px solid black; \">"+
                "<tr ><td style=\"width:50%\">Comprobante N°:</td>"+
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                "<p>" +
                comprobante.Comprobante + 
                "</p></td ></tr >" +
                "<tr ><td style=\"width:50%\">Fecha y hora:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.Fecha + 
                "</td ></tr >" +
                "</table >"+

                "<div style=\"text-align:center;\">  " +
                "<p>INFORMACIÓN DEL CLIENTE</p></div>" +
                "<table style=\"padding:10px; text-align:right; width:100%; border: 1px solid black; \">" +
                "<tr ><td style=\"width:50%\">Nombre:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.Nombre +
                "</td ></tr >" +
                "<tr ><td style=\"width:50%\">Rut:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.Rut +
                "</td ></tr >" +
                "</table >"+

                "<div style=\"text-align:center;\">  " +
                "<p>RESUMEN DE COMPRA</p></div>" +
                "<table style=\"padding:10px; text-align:right; width:100%; border: 1px solid black; \">" +
                "<tr ><td style=\"width:50%\">Servicio contratado:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                "Reserva de departamento" +
                "</td ></tr >" +
                "<tr ><td style=\"width:50%\">Dirección:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.Direccion +
                "</td ></tr >" +
                "<tr ><td style=\"width:50%\">Ubicación:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.Ubicacion +
                "</td ></tr >" +
                "<tr ><td style=\"width:50%\">Días:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.Dias +
                "</td ></tr >" +
                "</table >" +

                "<div style=\"text-align:center;\">  " +
                "<p>DETALLE DE PAGO</p></div>" +
                "<table style=\"padding:10px; text-align:right; width:100%; border: 1px solid black; \">" +
                "<tr ><td style=\"width:50%\">Tipo de pago:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.Tipo +
                "</td ></tr >" +
                "<tr ><td style=\"width:50%\">Valor de la reserva:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.ValorReserva +
                "</td ></tr >" +
                "<tr ><td style=\"width:50%\">Abono pagado:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.Abono +
                "</td ></tr >" +
                "<tr ><td style=\"width:50%\">Valor restante a pagar:</td>" +
                "<td style=\"text-align:left; width:50%; padding-left:10px;\">" +
                comprobante.ValorRestante +
                "</td ></tr >" +
                "</table >";

            return cuerpo;
        }

    }
}
