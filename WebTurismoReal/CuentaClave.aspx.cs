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
    public partial class CuentaClave : System.Web.UI.Page
    {
        ClienteBLL cliente = new ClienteBLL();

        public void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;

            if (Session["Usuario"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }
            else
            {
                Lbl_Usuario.Text = Session["Usuario"].ToString();
            }
        }

        public void Btn_Datos_Click(object sender, EventArgs e)
        {
            Response.Redirect("CuentaDatos.aspx");
        }

        public void Btn_Reservas_Click(object sender, EventArgs e)
        {
            Response.Redirect("CuentaReservas.aspx");
        }

        public void Btn_Servicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("CuentaServicioExtra.aspx");
        }

        public void Btn_Clave_Click(object sender, EventArgs e)
        {
            Response.Redirect("CuentaClave.aspx");
        }

        public void Btn_Acompañantes_Click(object sender, EventArgs e)
        {
            Response.Redirect("CuentaAcompañantes.aspx");
        }

        public void Btn_Cerrar_Sesion_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }

        public string GenerarHash(String clave)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(clave);
            System.Security.Cryptography.SHA256Managed sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256.ComputeHash(bytes);

            string hashString = Encoding.Default.GetString(hash);

            return hashString;
        }

        public void Btn_Guardar_Click(object sender, EventArgs e)
        {
            List<ClienteBLL> lista = cliente.ListaUsuarios();

            string idUsuario = Session["IdUsuario"].ToString();

            bool existe = lista.Any(x => x.Id == idUsuario);

            string claveHash = GenerarHash(Txt_Clave_Actual.Text);
            string claveUsuario = "";
            string rut = "";
            int genero = 0;
            int nacionalidad = 0;

            if (existe == true)
            {
                foreach (ClienteBLL c in lista)
                {
                    if (c.Id == idUsuario)
                    {
                        claveUsuario = c.Clave.ToString();
                        rut = c.Rut;
                        genero = c.GeneroC;
                        nacionalidad = c.NacionalidadC;
                    }
                }

                if (claveHash != claveUsuario)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ClaveNoIguales()", true);
                }
                else
                {
                    cliente.GeneroC = genero;
                    cliente.NacionalidadC = nacionalidad;

                    cliente.Clave = GenerarHash(Txt_Clave_Nueva.Text);

                    if (cliente.ModificarCliente(rut, cliente) == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionExitosa()", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionFallida()", true);
                    }
                    
                }
            }
        }

        public void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}