using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class Registro : System.Web.UI.Page
    {
        ClienteBLL cliente = new ClienteBLL();

        public void Page_Load(object sender, EventArgs e)
        {
            Btn_1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_1.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_3.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_2.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_3.Style.Add(HtmlTextWriterStyle.Color, "White");

            PanelProgreso.Visible = false;

            try
            {
                if (Request.UrlReferrer.ToString() != HttpContext.Current.Request.Url.AbsoluteUri)
                {
                    Session["PreviousPageUrlRegistro"] = Request.UrlReferrer.ToString();

                    if (Session["PreviousPageUrlRegistro"].ToString().Contains("Detalle"))
                    {
                        PanelProgreso.Visible = true;
                    }
                }

                if (!IsPostBack)
                {
                    CargarNacionalidad();
                    CargarGenero();
                }
            }
            catch (Exception)
            {
                Session.Abandon();
                Response.Redirect("PaginaNotFound.aspx");
            }
        }

        public void CargarNacionalidad()
        {
            CmbNacionalidad.DataSource = cliente.Nacionalidad();
            CmbNacionalidad.DataMember = "datos";
            CmbNacionalidad.DataTextField = "DESC_NACIONALIDAD";
            CmbNacionalidad.DataValueField = "ID_NACIONALIDAD";
            CmbNacionalidad.DataBind();
            CmbNacionalidad.Items.Insert(0, new ListItem("Seleccionar nacionalidad", "0"));

        }

        public void CargarGenero()
        {
            CmbGenero.DataSource = cliente.Genero();
            CmbGenero.DataMember = "datos";
            CmbGenero.DataTextField = "DESC_GEN";
            CmbGenero.DataValueField = "ID_GEN";
            CmbGenero.DataBind();
            CmbGenero.Items.Insert(0, new ListItem("Seleccionar género", "0"));

        }

        public void Btn_Registro_Click(object sender, EventArgs e)
        {
            if (TxtTelefono.Text.Length < 8)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "TelefonoNoValido()", true);
            }
            else
            {
                string telefonoCodigo = "+569" + TxtTelefono.Text;
                string claveHash = GenerarHash(TxtClave2.Text);
                int id_genero = Convert.ToInt32(CmbGenero.SelectedValue);
                int id_nacionalidad = Convert.ToInt32(CmbNacionalidad.SelectedValue);
                DateTime FechaToDate = Convert.ToDateTime(TxtFechaNac.Text);
                int lenghtHash = claveHash.Length;

                if (FechaToDate > DateTime.Now)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Imposible()", true);
                }
                else
                {
                    cliente.Rut = TxtRut.Text;
                    cliente.Nombre = TxtNombre.Text;
                    cliente.ApellidoP = TxtApellidoP.Text;
                    cliente.ApellidoM = TxtApellidoM.Text;
                    cliente.Telefono = telefonoCodigo;
                    cliente.Correo = TxtCorreo.Text;
                    cliente.FechaNac = FechaToDate.ToShortDateString();
                    cliente.Clave = claveHash;
                    cliente.GeneroC = id_genero;
                    cliente.NacionalidadC = id_nacionalidad;
                    
                    if (cliente.RegistroCliente(cliente) == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Exitoso()", true);
                    }
                    else if (cliente.RegistroCliente(cliente) == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Existente()", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Error()", true);
                    }
                }
                
            }
        }

        public string GenerarHash(String clave)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(clave);
            System.Security.Cryptography.SHA256Managed sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256.ComputeHash(bytes);

            string hashString = Encoding.Default.GetString(hash);

            return hashString;
        }

        public void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }

        public void TxtRut_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //-x
                string ultimaParte = TxtRut.Text.Substring(TxtRut.Text.Length - 1, 1);
                //.xxx-x
                string penultimaParte = TxtRut.Text.Substring(TxtRut.Text.Length - 4, 4);
                string penultimaParte2 = penultimaParte.Remove(3, 1);
                //.xxx.xxx-x
                string antepenultimaParte = TxtRut.Text.Substring(TxtRut.Text.Length - 7, 7);
                string antepenultimaParte2 = antepenultimaParte.Remove(3, 4);
                //xx.xxx.xxx-x
                string source = TxtRut.Text;
                // Remove a substring from the middle of the string.
                string toRemove = antepenultimaParte;
                string result = string.Empty;
                int i = source.IndexOf(toRemove);
                if (i >= 0)
                {
                    result = source.Remove(i, toRemove.Length);
                }
                
                TxtRut.Text = result +  "." + antepenultimaParte2 + "." + penultimaParte2 + "-" + ultimaParte;
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "FormatoRut()", true);
            }
            
        }
    }
}