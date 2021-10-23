using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

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
                    CargarReservas();
                }
            }
        }

        public void GridReservas_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
        }

        public void GridReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Validar que la reserva no haya expirado
            int index = GridReservas.SelectedRow.RowIndex;
            int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);
            DateTime fechaIda = DateTime.Now;

            ReservaBLL r = new ReservaBLL();
            List<ReservaBLL> lista = new List<ReservaBLL>();

            lista = r.Reservas(Int32.Parse(Session["IdUsuario"].ToString()));

            foreach (ReservaBLL reserva in lista)
            {
                if (reserva.Id == id)
                {
                    fechaIda = Convert.ToDateTime(reserva.FechaEntrada);
                }
            }

            if (fechaIda <= DateTime.Now)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ReservaExpirada()", true);
                PanelModificar.Visible = false;
                Panel_Departamento.Visible = false;
                Panel_Fecha.Visible = false;
                Panel_Guardar_Depto.Visible = false;
                Panel_Guardar_Fecha.Visible = false;
            }
            else
            {
                PanelModificar.Visible = true;
            }

        }

        public void CargarReservas()
        {
            ReservaBLL reserva = new ReservaBLL();

            if (Session["IdUsuario"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }
            else
            {
                try
                {
                    GridReservas.DataSource = reserva.Reservas(Int32.Parse(Session["IdUsuario"].ToString()));
                    GridReservas.DataBind();

                    GridReservas.HeaderRow.Cells[1].Text = "ID";
                    GridReservas.HeaderRow.Cells[2].Text = "FECHA INGRESO";
                    GridReservas.HeaderRow.Cells[3].Text = "FECHA REGRESO";
                    GridReservas.HeaderRow.Cells[4].Text = "ESTADO";
                    GridReservas.HeaderRow.Cells[5].Text = "FECHA RESERVA";
                    GridReservas.HeaderRow.Cells[6].Text = "VALOR ABONO";
                    GridReservas.HeaderRow.Cells[7].Text = "VALOR FINAL";
                }
                catch (Exception)
                {
                    GridReservas.DataSource = reserva.Reservas(Int32.Parse(Session["IdUsuario"].ToString()));
                    GridReservas.DataBind();
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
                Panel_Guardar_Fecha.Visible = true;
                Panel_Guardar_Depto.Visible = false;
            }
            else if (Cmb_Opciones.SelectedIndex == 2)
            {
                Panel_Fecha.Visible = false;
                Panel_Departamento.Visible = true;
                Panel_Guardar_Depto.Visible = true;
                Panel_Guardar_Fecha.Visible = false;

                int index = GridReservas.SelectedRow.RowIndex;
                int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);

                int idDepto = 0;

                ReservaBLL r = new ReservaBLL();

                List<ReservaBLL> lista = r.Reservas(Int32.Parse(Session["IdUsuario"].ToString()));

                foreach (ReservaBLL item in lista)
                {
                    if (item.Id == id)
                    {
                        idDepto = item.IdDepto;
                    }
                }

                DepartamentoBLL d = new DepartamentoBLL();

                List<DepartamentoBLL> listaDeptos = d.ListaDepartamentosBuscar(idDepto);

                GridDeptoActual.DataSource = listaDeptos;
                GridDeptoActual.DataBind();

                GridDeptoActual.HeaderRow.Cells[2].Text = "DIRECCIÓN";
                GridDeptoActual.HeaderRow.Cells[3].Text = "COMUNA";
                GridDeptoActual.HeaderRow.Cells[4].Text = "PROVINCIA";
                GridDeptoActual.HeaderRow.Cells[5].Text = "REGIÓN";
                GridDeptoActual.HeaderRow.Cells[6].Text = "HABITACIONES";
                GridDeptoActual.HeaderRow.Cells[7].Text = "BAÑOS";
                GridDeptoActual.HeaderRow.Cells[8].Text = "VALOR DÍA";

                string idComuna = "";

                foreach (DepartamentoBLL item in listaDeptos)
                {
                    if (item.Id == idDepto.ToString())
                    {
                        idComuna = item.Comuna;
                    }
                }

                GridDepartamentos.DataSource = d.ListaDepartamentos(Int32.Parse(idComuna));
                GridDepartamentos.DataBind();
                
                GridDepartamentos.HeaderRow.Cells[2].Text = "DIRECCIÓN";
                GridDepartamentos.HeaderRow.Cells[3].Text = "COMUNA";
                GridDepartamentos.HeaderRow.Cells[4].Text = "PROVINCIA";
                GridDepartamentos.HeaderRow.Cells[5].Text = "REGIÓN";
                GridDepartamentos.HeaderRow.Cells[6].Text = "HABITACIONES";
                GridDepartamentos.HeaderRow.Cells[7].Text = "BAÑOS";
                GridDepartamentos.HeaderRow.Cells[8].Text = "VALOR DÍA";
            }
        }

        public void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }

        public void BtnGuardarFecha_Click(object sender, EventArgs e)
        {
            DateTime fechaEntrada = Convert.ToDateTime(TxtFechaIda.Text);
            DateTime fechaSalida = Convert.ToDateTime(TxtFechaRegreso.Text);

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
                int index = GridReservas.SelectedRow.RowIndex;
                int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);

                int idDepto = 0;
                string fechaIngreso = fechaEntrada.Date.ToShortDateString();
                string fechaRegreso = fechaSalida.Date.ToShortDateString();
                string valorDia = "";
                string valorAbono = "";

                ReservaBLL r = new ReservaBLL();

                List<ReservaBLL> lista = r.Reservas(Int32.Parse(Session["IdUsuario"].ToString()));

                foreach (ReservaBLL item in lista)
                {
                    if (item.Id == id)
                    {
                        idDepto = item.IdDepto;
                        valorAbono = item.Abono;
                    }
                }

                DepartamentoBLL d = new DepartamentoBLL();

                List<DepartamentoBLL> listaDeptos =  d.ListaDepartamentosBuscar(idDepto);

                foreach (DepartamentoBLL item in listaDeptos)
                {
                    if (item.Id == idDepto.ToString())
                    {
                        valorDia = item.Valor_Dia;
                    }
                }

                //Calcular abono y total
                TimeSpan difDias = fechaSalida - fechaEntrada;
                int dias = Convert.ToInt32(difDias.Days);
                int total = Int32.Parse(valorDia) * dias;

                r.Id = id;
                r.FechaEntrada = fechaIngreso;
                r.FechaSalida = fechaRegreso;
                r.Abono = valorAbono.Replace(".","").Remove(0,1);
                r.ValorFinal = total.ToString();
                r.IdCliente = Int32.Parse(Session["IdUsuario"].ToString());
                r.IdDepto = idDepto;

                if (r.ModificarReserva(r) == 1)
                {
                    CargarReservas();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionExitosa()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionFallida()", true);
                }
            }

        }

        public void BtnGuardarDepto_Click(object sender, EventArgs e)
        {
            int indexR = GridReservas.SelectedRow.RowIndex;
            int idR = Convert.ToInt32(GridReservas.DataKeys[indexR].Value);

            if (GridDepartamentos.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SeleccionarDepto()", true);
            }
            else
            {
                int index = GridDepartamentos.SelectedRow.RowIndex;
                int id = Convert.ToInt32(GridDepartamentos.DataKeys[index].Value);

                ReservaBLL r = new ReservaBLL();

                r.Id = idR;
                r.IdCliente = Int32.Parse(Session["IdUsuario"].ToString());
                r.IdDepto = id;

                if (r.ModificarReserva(r) == 1)
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionExitosa()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionFallida()", true);
                }
            }

        }

        public void GridDeptoActual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        public void GridDepartamentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        public void GridDeptoActual_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void GridDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}