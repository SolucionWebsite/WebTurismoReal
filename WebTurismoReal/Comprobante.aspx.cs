using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PdfSharp;
using PdfSharp.Pdf;
using SistemaTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class Comprobante : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            Btn_1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_1.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_2.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_3.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_3.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_4.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_4.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_5.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_5.Style.Add(HtmlTextWriterStyle.Color, "White");

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "PagoExitoso()", true);

            try
            {
                Lbl_Nombre_1.Text = Session["Usuario"].ToString();
                Lbl_Fecha.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.CurrentCulture);
                Lbl_Nombre.Text = Session["Usuario"].ToString();
                Lbl_Rut.Text = Session["Rut"].ToString();
                Lbl_Direccion.Text = Session["Depto"].ToString();
                Lbl_Ubicacion.Text = Session["Comuna"].ToString() + ", " + Session["Provincia"].ToString() + ", " + Session["Region"].ToString();
                Lbl_Dias.Text = Session["Dias"].ToString();
                Lbl_Tipo_Pago.Text = Session["Tipo_pago"].ToString();
                Lbl_Monto.Text = Session["Abono"].ToString();
                Lbl_Correo.Text = Session["Correo"].ToString();
                CrearPDF();
                EnviarEmail();
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }
        }

        public Stream GetStreamFile(string filePath)
        {
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                MemoryStream memStream = new MemoryStream();
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);
                return memStream;
            }
        }

        public void CrearPDF()
        {
            try
            {
                PDFComprobante comprobante = new PDFComprobante();
                var Renderer = new IronPdf.ChromePdfRenderer();

                PDFComprobante cuerpo = new PDFComprobante();
                cuerpo.Fecha = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.CurrentCulture);
                cuerpo.Nombre = Session["Usuario"].ToString();
                cuerpo.Rut = Session["Rut"].ToString();
                cuerpo.Direccion = Session["Depto"].ToString();
                cuerpo.Ubicacion = Session["Comuna"].ToString() + ", " + Session["Provincia"].ToString() + ", " + Session["Region"].ToString();
                cuerpo.Dias = Session["Dias"].ToString();
                cuerpo.Tipo = Session["Tipo_pago"].ToString();
                cuerpo.Monto = Session["Abono"].ToString();

                var PDF = Renderer.RenderHtmlAsPdf(comprobante.PDFContenido(cuerpo));

                //PDF.SaveAs("C:/Users/franc/source/repos/WebTurismoReal/WebTurismoReal/pdf/comprobante.pdf");
                string CurrentDirectory1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"pdf", @"comprobante.pdf");
                PDF.SaveAs(CurrentDirectory1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void EnviarEmail()
        {
            CrearPDF();

            BodyCorreo body = new BodyCorreo();

            MailMessage message = new MailMessage();

            message.From = new MailAddress("turismorealdeptos@gmail.com");
            message.To.Add(new MailAddress(Lbl_Correo.Text));

            message.Subject = "Felicidades! Has reservado con éxito";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = body.Body(Lbl_Nombre.Text);
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            //Agregar archivo adjunto
            Attachment attachment;
            string CurrentDirectory1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"pdf", @"comprobante.pdf");
            attachment = new Attachment(CurrentDirectory1);
            attachment.Name = "Comprobante.pdf";
            message.Attachments.Add(attachment);

            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential("turismorealdeptos@gmail.com", "123turismo");
            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
