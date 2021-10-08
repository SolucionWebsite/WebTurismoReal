using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTurismoReal
{
    public partial class Detalle2 : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            Btn_1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_1.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_3.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_2.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_3.Style.Add(HtmlTextWriterStyle.Color, "White");

            if (Session["Depto"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "LoginExitoso()", true);

                string direccion = Session["Depto"].ToString();
                string region = Session["Region"].ToString();
                string provincia = Session["Provincia"].ToString();
                string comuna = Session["Comuna"].ToString();
                string dias = Session["Dias"].ToString();
                string fecha_ida = Session["Ida"].ToString();
                string fecha_vuelta = Session["Vuelta"].ToString();
                string acompañantes = Session["Acompañantes"].ToString();
                string total = Session["Total"].ToString();
                string abono = Session["Abono"].ToString();
                string restante = Session["Restante"].ToString();

                Lbl_Depto.Text = direccion;
                Lbl_Region.Text = region;
                Lbl_Provincia.Text = provincia;
                Lbl_Comuna.Text = comuna;
                Lbl_Dias.Text = dias;
                Lbl_Ida.Text = fecha_ida;
                Lbl_Vuelta.Text = fecha_vuelta;
                Lbl_Acompañantes.Text = acompañantes;
                Lbl_Total.Text = total;
                Lbl_Abono.Text = abono;
                Lbl_Restante.Text = restante;
            }
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
            string pago = Session["Abono"].ToString();
            string pagoEncode = Base64Encode(pago);
            Response.Redirect($"http://localhost:57174/Acompañantes/{pagoEncode}");
        }
    }
}