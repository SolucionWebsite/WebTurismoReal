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

            if (!IsPostBack)
            {
                CargarNacionalidad();
                CargarGenero();
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

        public string GenerarHash(String clave)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(clave);
            System.Security.Cryptography.SHA256Managed sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256.ComputeHash(bytes);

            string hashString = Encoding.Default.GetString(hash);

            return hashString;
        }
    }
}