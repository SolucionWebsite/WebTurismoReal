using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class Pago : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (Session["Abono"] == null)
            {
                LblTtotal.Text = "$0";
            }
            else
            {
                LblTtotal.Text = Session["Abono"].ToString();
            }
        }

        public static string Base64Decode(string base64EncodedData)
        {
            string textoDecodeFinal = base64EncodedData.ToString().Replace("_", "/");
            var base64EncodedBytes = System.Convert.FromBase64String(textoDecodeFinal);
            string textoDecode = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            return textoDecode;
        }

        public void CmbPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPago.SelectedValue == "1")
            {
                PanelCredito.Visible = true;
                PanelDebito.Visible = false;
            }
            else if (CmbPago.SelectedValue == "2")
            {
                PanelDebito.Visible = true;
                PanelCredito.Visible = false;
            }
        }

        public void BtnPagar1_Click(object sender, EventArgs e)
        {
            Session["Tipo_pago"] = "Débito";
            CrearReserva();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ValidarPago()", true);
        }

        public void BtnPagar2_Click(object sender, EventArgs e)
        {
            Session["Tipo_pago"] = "Crédito";
            CrearReserva();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ValidarPago()", true);
        }

        public void CrearReserva()
        {
            ReservaBLL reserva = new ReservaBLL();
            
            reserva.FechaEntrada = Session["Ida"].ToString();
            reserva.FechaSalida = Session["Vuelta"].ToString();
            reserva.Estado = "Pagada";
            reserva.FechaReserva = DateTime.Now.ToString("dd-MM-yyyy", CultureInfo.CurrentCulture);
            reserva.IdCliente = Int32.Parse(Session["IdUsuario"].ToString());
            reserva.IdDepto = Int32.Parse(Session["Id_Depto"].ToString());

            reserva.CrearReserva(reserva);
        }
    }
}
