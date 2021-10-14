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

            try
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                string[] separado = url.Split('/');
                string restante = separado[separado.Length - 1];
                string abono = separado[separado.Length - 2];
                string total = separado[separado.Length - 3];
                string acompañantes = separado[separado.Length - 4];
                string fecha_vuelta = separado[separado.Length - 5];
                string fecha_ida = separado[separado.Length - 6];
                string dias = separado[separado.Length - 7];
                string comuna = separado[separado.Length - 8];
                string provincia = separado[separado.Length - 9];
                string region = separado[separado.Length - 10];
                string direccion = separado[separado.Length - 11];
                string id_depto = separado[separado.Length - 12];

                string restanteDecode = Base64Decode(restante);
                string abonoDecode = Base64Decode(abono);
                string totalDecode = Base64Decode(total);
                string acompañantesDecode = Base64Decode(acompañantes);
                string fecha_vueltaDecode = Base64Decode(fecha_vuelta);
                string fecha_idaDecode = Base64Decode(fecha_ida);
                string diasDecode = Base64Decode(dias);
                string comunaDecode = Base64Decode(comuna);
                string provinciaDecode = Base64Decode(provincia);
                string regionDecode = Base64Decode(region);
                string direccionDecode = Base64Decode(direccion);
                string id_deptoDecode = Base64Decode(id_depto);


                Lbl_Depto.Text = direccionDecode;
                Lbl_Region.Text = regionDecode;
                Lbl_Provincia.Text = provinciaDecode;
                Lbl_Comuna.Text = comunaDecode;
                Lbl_Dias.Text = diasDecode;
                Lbl_Ida.Text = fecha_idaDecode;
                Lbl_Vuelta.Text = fecha_vueltaDecode;
                Lbl_Acompañantes.Text = acompañantesDecode;
                Lbl_Total.Text = totalDecode;
                Lbl_Abono.Text = abonoDecode;
                Lbl_Restante.Text = restanteDecode;
                Lbl_Depto.Text = id_deptoDecode;
            }
            catch (Exception)
            {
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
            string pago = Session["Abono"].ToString();
            string pagoEncode = Base64Encode(pago);
            Response.Redirect($"http://localhost:57174/Acompañantes/{pagoEncode}");
        }
    }
}