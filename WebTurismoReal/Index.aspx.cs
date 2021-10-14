using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class Index : System.Web.UI.Page
    {
        LocalidadBLL localidad = new LocalidadBLL();

        public void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            
            Btn_1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_1.Style.Add(HtmlTextWriterStyle.Color, "White");

            if (!IsPostBack)
            {
                CargarLocalidad();
            }
        }

        public void CargarLocalidad()
        {
            Cmb_Region.DataSource = localidad.Regiones();
            Cmb_Region.DataMember = "datos";
            Cmb_Region.DataTextField = "NOMBRE_REGION";
            Cmb_Region.DataValueField = "ID_REGION";
            Cmb_Region.DataBind();
            Cmb_Region.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
            Cmb_Provincia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
            Cmb_Comuna.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            string textoEncode = System.Convert.ToBase64String(plainTextBytes);
            string textoEncodeFinal = textoEncode.ToString().Replace("/", "_");
            return textoEncodeFinal;
        }

        public void Btn_Disponibilidad_Click(object sender, EventArgs e)
        {
            DateTime fechaSalida = Convert.ToDateTime(Txt_Fecha_Salida.Text);
            DateTime fechaEntrada = Convert.ToDateTime(Txt_Fecha_Llegada.Text);

            if (fechaSalida < fechaEntrada)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "FechasIncongruentes()", true);
            }
            else if (fechaEntrada < DateTime.Today)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "FechasIncongruentes2()", true);
            }
            else if (fechaEntrada == DateTime.Today)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "FechasIncongruentes3()", true);
            }
            else
            {
                string region = Cmb_Region.SelectedItem.Text;
                string id_region = Cmb_Region.SelectedValue.ToString();
                string provincia = Cmb_Provincia.SelectedItem.Text.TrimEnd();
                string id_provincia = Cmb_Provincia.SelectedValue.ToString();
                string comuna = Cmb_Comuna.SelectedItem.Text;
                string id_comuna = Cmb_Comuna.SelectedValue.ToString();
                TimeSpan difDias = fechaSalida - fechaEntrada;

                string regionEncode = Base64Encode(region);
                string idRegionEncode = Base64Encode(id_region);
                string provinciaEncode = Base64Encode(provincia);
                string idProvinciaEncode = Base64Encode(id_provincia);
                string comunaEncode = Base64Encode(comuna);
                string idComunaEncode = Base64Encode(id_comuna);
                string fechaEntradaEncode = Base64Encode(fechaEntrada.Date.ToShortDateString());
                string fechaSalidaEncode = Base64Encode(fechaSalida.Date.ToShortDateString());
                string diasEncode = Base64Encode(Convert.ToInt32(difDias.Days).ToString());

                if (diasEncode == "0")
                {
                    diasEncode = "1";
                    Response.Redirect($"Disponibilidad/{idRegionEncode}/{idProvinciaEncode}/{idComunaEncode}/{comunaEncode}/{provinciaEncode}/" +
                   $"{regionEncode}/{fechaEntradaEncode}/{fechaSalidaEncode}/{diasEncode}", true);
                }
                else
                { 
                    Response.Redirect($"Disponibilidad/{idRegionEncode}/{idProvinciaEncode}/{idComunaEncode}/{comunaEncode}/{provinciaEncode}/" +
                   $"{regionEncode}/{fechaEntradaEncode}/{fechaSalidaEncode}/{diasEncode}", true);
                    
                }
            }



        }

        public void Cmb_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_region = Convert.ToInt32(Cmb_Region.SelectedValue);

            Cmb_Provincia.DataSource = localidad.Provincias(id_region);
            Cmb_Provincia.DataMember = "datos";
            Cmb_Provincia.DataTextField = "NOMBRE_PROVINCIA";
            Cmb_Provincia.DataValueField = "ID_PROV";
            Cmb_Provincia.DataBind();
            Cmb_Provincia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));

        }

        public void Cmb_Comuna_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Cmb_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_prov = Convert.ToInt32(Cmb_Provincia.SelectedValue);

            Cmb_Comuna.DataSource = localidad.Comunas(id_prov);
            Cmb_Comuna.DataMember = "datos";
            Cmb_Comuna.DataTextField = "NOMBRE_COMUNA";
            Cmb_Comuna.DataValueField = "ID_COMUNA";
            Cmb_Comuna.DataBind();
            Cmb_Comuna.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccionar", "0"));
        }
    }
}
