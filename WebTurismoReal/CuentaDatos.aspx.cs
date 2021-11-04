using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class CuentaDatos : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    CargarNacionalidad();
                    CargarGenero();
                    CargarDatosCliente();
                }
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

        public void Btn_Editar_Click(object sender, EventArgs e)
        {
            Txt_Nombre.Enabled = true;
            Txt_Apellido_P.Enabled = true;
            Txt_Apellido_M.Enabled = true;
            Txt_Correo.Enabled = true;
            Txt_Fecha_Nacimiento.Enabled = true;
            CmbGenero.Enabled = true;
            CmbNacionalidad.Enabled = true;
            Txt_Rut.Enabled = true;
            Txt_Telefono.Enabled = true;
        }

        public void CargarDatosCliente()
        {
            List<ClienteBLL> lista = cliente.ListaUsuarios();

            string id = Session["IdUsuario"].ToString();

            bool existe = lista.Any(x => x.Id == id);

            string nombre = "";
            string apellidoP = "";
            string apellidoM = "";
            string fechaNac = "";
            string rut = "";
            int genero = 0;
            string telefono = "";
            int nacionalidad = 0;
            string correo = "";

            if (existe == true)
            {
                foreach (ClienteBLL c in lista)
                {
                    if (c.Id == id)
                    {
                        nombre = c.Nombre;
                        apellidoP = c.ApellidoP;
                        apellidoM = c.ApellidoM;
                        DateTime date = new DateTime();
                        date = Convert.ToDateTime(c.FechaNac);
                        fechaNac = date.ToString("yyyy-MM-dd");
                        rut = c.Rut;
                        genero = c.GeneroC;
                        telefono = c.Telefono.Remove(0, 4);
                        nacionalidad = c.NacionalidadC;
                        correo = c.Correo;
                    }
                }

                Txt_Nombre.Text = nombre;
                Txt_Apellido_P.Text = apellidoP;
                Txt_Apellido_M.Text = apellidoM;
                Txt_Fecha_Nacimiento.Text = fechaNac;
                Txt_Rut.Text = rut;
                CmbGenero.SelectedValue = genero.ToString();
                Txt_Telefono.Text = telefono;
                CmbNacionalidad.SelectedValue = nacionalidad.ToString();
                Txt_Correo.Text = correo;

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

        public void Btn_Guardar_Cambios_Click(object sender, EventArgs e)
        {
            string rutCliente = Session["Rut"].ToString();

            string telefonoCodigo = "+569" + Txt_Telefono.Text;
            DateTime fechaToDate = Convert.ToDateTime(Txt_Fecha_Nacimiento.Text);
            string fechaString = fechaToDate.ToString("dd-MM-yyyy", CultureInfo.CurrentCulture);

            cliente.Rut = Txt_Rut.Text;
            cliente.Nombre = Txt_Nombre.Text;
            cliente.ApellidoP = Txt_Apellido_P.Text;
            cliente.ApellidoM = Txt_Apellido_M.Text;
            cliente.Telefono = telefonoCodigo;
            cliente.Correo = Txt_Correo.Text;
            cliente.FechaNac = fechaString;
            cliente.GeneroC = Int32.Parse(CmbGenero.SelectedValue);
            cliente.NacionalidadC = Int32.Parse(CmbNacionalidad.SelectedValue);
            
            if (cliente.ModificarCliente(rutCliente, cliente) == 1)
            {
                CargarDatosCliente();

                Txt_Nombre.Enabled = false;
                Txt_Apellido_P.Enabled = false;
                Txt_Apellido_M.Enabled = false;
                Txt_Correo.Enabled = false;
                Txt_Fecha_Nacimiento.Enabled = false;
                CmbGenero.Enabled = false;
                CmbNacionalidad.Enabled = false;
                Txt_Rut.Enabled = false;
                Txt_Telefono.Enabled = false;

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionExitosa()", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionFallida()", true);
            }

        }

        public void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }

        public void BtnEliminarCuenta_Click(object sender, EventArgs e)
        {
            ClienteBLL c = new ClienteBLL();

            c.Rut = Txt_Rut.Text;
            c.Nombre = Txt_Nombre.Text;
            c.ApellidoP = Txt_Apellido_P.Text;
            c.ApellidoM = Txt_Apellido_M.Text;
            c.Correo = "sincorreo@gmail.com";
            c.GeneroC = Int32.Parse(CmbGenero.SelectedValue);
            c.NacionalidadC = Int32.Parse(CmbNacionalidad.SelectedValue);

            if (c.ModificarCliente(c.Rut, c) == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "EliminarCuenta()", true);
            }
            
        }
    }
}
