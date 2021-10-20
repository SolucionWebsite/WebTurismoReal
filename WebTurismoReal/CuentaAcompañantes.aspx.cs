using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class CuentaAcompañantes : System.Web.UI.Page
    {
        ClienteBLL cliente = new ClienteBLL();
        AcompañanteBLL acompañante = new AcompañanteBLL();

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
                    CargarTabla();
                    CargarNacionalidad();
                    CargarGenero();
                    Repeater1.DataSource = acompañante.ListaA(Int32.Parse(Session["IdUsuario"].ToString()));
                    Repeater1.DataBind();
                }
            }
        }
        
        public void CargarTabla()
        {
            AcompañanteBLL bll = new AcompañanteBLL();

            if (Session["IdUsuario"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }
            else
            {
                List<AcompañanteBLL> lista = bll.ListaAcompañantes(Int32.Parse(Session["IdUsuario"].ToString()));

                List<AcompañanteBLL> listaNueva = new List<AcompañanteBLL>();

                foreach (AcompañanteBLL a in lista)
                {
                    AcompañanteBLL acompañante = new AcompañanteBLL();

                    acompañante.Id = a.Id;
                    acompañante.Nombre = a.Nombre;
                    acompañante.ApellidoP = a.ApellidoP;
                    acompañante.ApellidoM = a.ApellidoM;
                    acompañante.Rut = a.Rut;
                    acompañante.FechaNac = a.FechaNac;
                    acompañante.Telefono = a.Telefono;
                    acompañante.Correo = a.Correo;

                    listaNueva.Add(acompañante);
                }

                GridAcompañantes.DataSource = listaNueva;
                GridAcompañantes.DataBind();

                GridAcompañantes.HeaderStyle.Font.Bold = false;
                GridAcompañantes.HeaderRow.Cells[1].Width = 50;
                GridAcompañantes.HeaderStyle.Height = 30;

                GridAcompañantes.HeaderRow.Cells[1].Text = "ID";
                GridAcompañantes.HeaderRow.Cells[2].Text = "NOMBRE";
                GridAcompañantes.HeaderRow.Cells[3].Text = "PRIMER APELLIDO";
                GridAcompañantes.HeaderRow.Cells[4].Text = "SEGUNDO APELLIDO";
                GridAcompañantes.HeaderRow.Cells[5].Text = "RUT";
                GridAcompañantes.HeaderRow.Cells[6].Text = "FECHA DE NACIMIENTO";
                GridAcompañantes.HeaderRow.Cells[7].Text = "TELÉFONO";
                GridAcompañantes.HeaderRow.Cells[8].Text = "CORREO";

                GridAcompañantes.HeaderRow.Cells[1].Visible = false;

                
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

        public void Btn_Añadir_Acompañante_Click(object sender, EventArgs e)
        {
            PanelAñadirAcompañantes.Visible = true;
        }

        public void Btn_Guardar_Click(object sender, EventArgs e)
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
                    Txt_Telefono_A.Text = "";
                    CargarTabla();
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

        public void GridAcompañantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //modificar
        }

        public void ItemSelect(object source, RepeaterCommandEventArgs e)
        {
            int posicion = Repeater1.Items[e.Item.ItemIndex].ItemIndex;

            Label t = (Label)Repeater1.Items[posicion].FindControl("LblRut");
            string rut = t.Text;
        }
    }
}