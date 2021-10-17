using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTurismoReal
{
    public partial class Detalle : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer.ToString() != HttpContext.Current.Request.Url.AbsoluteUri)
            {
                ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
            }

            Btn_1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_1.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_3.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_2.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_3.Style.Add(HtmlTextWriterStyle.Color, "White");

            try
            {
                Lbl_Depto.Text = Session["Depto"].ToString();
                Lbl_Region.Text = Session["Region"].ToString();
                Lbl_Provincia.Text = Session["Provincia"].ToString();
                Lbl_Comuna.Text = Session["Comuna"].ToString();
                Lbl_Dias.Text = Session["Dias"].ToString();
                Lbl_Ida.Text = Session["Ida"].ToString();
                Lbl_Vuelta.Text = Session["Vuelta"].ToString();
                Lbl_Acompañantes.Text = Session["Acompañantes"].ToString();
                Lbl_Total.Text = Session["Total"].ToString();
                Lbl_Abono.Text = Session["Abono"].ToString();
                Lbl_Restante.Text = Session["Restante"].ToString();
                Lbl_Id_Depto.Text = Session["Id_Depto"].ToString();
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }

            string paginaAnterior = ViewState["PreviousPageUrl"].ToString();

            if (paginaAnterior.Contains("Login"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "LoginExitoso()", true);
            }
            
        }

        public static string Base64Decode(string base64EncodedData)
        {
            string textoDecodeFinal = base64EncodedData.ToString().Replace("_", "/");
            var base64EncodedBytes = System.Convert.FromBase64String(textoDecodeFinal);
            string textoDecode = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            return textoDecode;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            string textoEncode = System.Convert.ToBase64String(plainTextBytes);
            string textoEncodeFinal = textoEncode.ToString().Replace("/", "_");
            return textoEncodeFinal;
        }

        public void BtnPagar_Click(object sender, EventArgs e)
        {
            string paginaAnterior = ViewState["PreviousPageUrl"].ToString();

            if (paginaAnterior.Contains("Login"))
            {
                string pago = Session["Abono"].ToString();
                string pagoEncode = Base64Encode(pago);
                Response.Redirect($"http://localhost:57174/Acompañantes");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Pagar()", true);
            }
        }

    }
}