using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class Acompañantes : System.Web.UI.Page
    {
        ClienteBLL cliente = new ClienteBLL();

        public void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            
            Btn_1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_1.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_2.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_3.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_3.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_4.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_4.Style.Add(HtmlTextWriterStyle.Color, "White");

            if (!IsPostBack)
            {
                CargarNacionalidad();
                CargarGenero();
                CargarLista();
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

        public void CargarLista()
        {
            AcompañanteBLL bll = new AcompañanteBLL();

            try
            {
                List<AcompañanteBLL> lista = bll.ListaAcompañantes(Int32.Parse(Session["IdUsuario"].ToString()));

                List<string> ListaNombresAcompanantes = new List<string>();

                foreach (AcompañanteBLL c in lista)
                {
                    string nombre = "";

                    nombre = c.Nombre + " " + c.ApellidoP + " " + c.ApellidoM;

                    ListaNombresAcompanantes.Add(nombre);
                }

                ListaAcompanantes.DataSource = ListaNombresAcompanantes;
                ListaAcompanantes.DataBind();
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }

            

        }

        public void Btn_Continuar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Pagar()", true);
        }

        public void Btn_Añadir_Click(object sender, EventArgs e)
        {
            AcompañanteBLL acompañante = new AcompañanteBLL();

            DateTime FechaToDate = Convert.ToDateTime(Txt_Nacimiento_A.Text);

            if (FechaToDate > DateTime.Now)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Imposible()", true);
            }
            else
            {
                int id_genero = Convert.ToInt32(CmbGenero.SelectedValue);
                int id_nacionalidad = Convert.ToInt32(CmbNacionalidad.SelectedValue);
                string telefonoCodigo = "+569" + Txt_Telefono_A.Text;

                acompañante.Rut = Txt_Rut_A.Text;
                acompañante.Nombre = Txt_Nombre_A.Text;
                acompañante.ApellidoP = Txt_Apellido_A.Text;
                acompañante.ApellidoM = Txt_Apellido_M.Text;
                acompañante.Telefono = telefonoCodigo;
                acompañante.Correo = Txt_Correo_A.Text;
                acompañante.FechaNac = FechaToDate.ToShortDateString();
                acompañante.GeneroC = id_genero;
                acompañante.NacionalidadC = id_nacionalidad;
                acompañante.IdCliente = Int32.Parse(Session["IdUsuario"].ToString());
                acompañante.IdReserva = 1;

                if (acompañante.AgregarAcompañante(acompañante) == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Exitoso()", true);
                    Txt_Rut_A.Text = "";
                    Txt_Nombre_A.Text = "";
                    Txt_Apellido_A.Text = "";
                    Txt_Apellido_M.Text = "";
                    Txt_Correo_A.Text = "";
                    Txt_Nacimiento_A.Text = "";
                    CmbGenero.SelectedValue = "0";
                    CmbNacionalidad.SelectedValue = "0";
                    Txt_Telefono_A.Text = "0";
                    CargarLista();
                }
                else if (acompañante.AgregarAcompañante(acompañante) == 0)
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
}