using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTurismoReal
{
    public partial class CuentaReservas : System.Web.UI.Page
    {
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
                    //cargar reservas
                    //cargar deptos
                }
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

        public void Cmb_Opciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Opciones.SelectedIndex == 1)
            {
                Panel_Departamento.Visible = false;
                Panel_Fecha.Visible = true;
                Panel_Guardar.Visible = true;
            }
            else if (Cmb_Opciones.SelectedIndex == 2)
            {
                Panel_Fecha.Visible = false;
                Panel_Departamento.Visible = true;
                Panel_Guardar.Visible = true;
            }
        }
    }
}