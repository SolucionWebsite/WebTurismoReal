using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class CuentaServicioExtra : System.Web.UI.Page
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

            }
            else
            {
                ServicioExtraBLL servicio = new ServicioExtraBLL();

                PanelServiciosExtraActual.Visible = true;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv", "setTimeout(scrollToDiv, 1);", true);


                List<ServicioExtraBLL> listaServicios = servicio.ListaServiciosExtra(id);

                List<ServicioExtraBLL> listaServiciosActualesTour = new List<ServicioExtraBLL>();
                List<ServicioExtraBLL> listaServiciosActualesTrans = new List<ServicioExtraBLL>();

                if (listaServicios.Count == 0)
                {
                    PanelNoServicios.Visible = true;
                }
                else
                {

                    foreach (ServicioExtraBLL item in listaServicios)
                    {
                        if (item.IdTour != null)
                        {
                            ServicioExtraBLL s = new ServicioExtraBLL();

                            s.Id = item.Id;
                            s.ValorTotal = item.ValorTotal;
                            s.FechaAsistencia = item.FechaAsistencia;
                            s.Hora = item.Hora;
                            s.Asistentes = item.Asistentes;
                            s.IdTour = item.IdTour;
                            s.NombreTour = item.NombreTour;
                            s.ValorPTour = item.ValorPTour;
                            s.IdReserva = item.IdReserva;

                            listaServiciosActualesTour.Add(s);

                        }
                        else if (item.IdTour == null)
                        {
                            ServicioExtraBLL s = new ServicioExtraBLL();

                            s.Id = item.Id;
                            s.ValorTotal = item.ValorTotal;
                            s.FechaAsistencia = item.FechaAsistencia;
                            s.Hora = item.Hora;
                            s.Asistentes = item.Asistentes;
                            s.IdTransporte = item.IdTransporte;
                            s.Trayecto = item.Trayecto;
                            s.Vehiculo = item.Vehiculo;
                            s.Asientos = item.Asientos;
                            s.ValorPTransporte = item.ValorPTransporte;
                            s.IdReserva = item.IdReserva;

                            listaServiciosActualesTrans.Add(s);

                        }
                    }

                    foreach (ServicioExtraBLL item in listaServicios)
                    {
                        if (item.IdTour != null)
                        {
                            GridTourActual.DataSource = listaServiciosActualesTour;
                            GridTourActual.DataBind();

                            GridTourActual.HeaderRow.Cells[3].Text = "NOMBRE TOUR";
                            GridTourActual.HeaderRow.Cells[4].Text = "VALOR POR PERSONA";
                            GridTourActual.HeaderRow.Cells[10].Text = "ASISTENTES";
                            GridTourActual.HeaderRow.Cells[11].Text = "VALOR TOTAL";
                            GridTourActual.HeaderRow.Cells[12].Text = "FECHA ASISTENCIA";

                            PanelTourActual.Visible = true;
                            PanelNoServicios.Visible = false;
                        }
                        else if (item.IdTransporte != null)
                        {
                            GridTransporteActual.DataSource = listaServiciosActualesTrans;
                            GridTransporteActual.DataBind();

                            GridTransporteActual.HeaderRow.Cells[6].Text = "TIPO TRAYECTO";
                            GridTransporteActual.HeaderRow.Cells[7].Text = "VEHÍCULO";
                            GridTransporteActual.HeaderRow.Cells[8].Text = "ASIENTOS";
                            GridTransporteActual.HeaderRow.Cells[9].Text = "VALOR POR PERSONA";
                            GridTransporteActual.HeaderRow.Cells[10].Text = "ASISTENTES";
                            GridTransporteActual.HeaderRow.Cells[11].Text = "VALOR TOTAL";
                            GridTransporteActual.HeaderRow.Cells[12].Text = "FECHA ASISTENCIA";

                            PanelTransporteActual.Visible = true;
                            PanelNoServicios.Visible = false;
                        }
                    }
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

        public void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }

        public void CargarTours()
        {
            ReservaBLL r = new ReservaBLL();
            DepartamentoBLL d = new DepartamentoBLL();
            TourBLL t = new TourBLL();

            if (GridReservas.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Olvidar_Selecccionar_Reserva()", true);
            }
            else
            {
                int index = GridReservas.SelectedRow.RowIndex;
                int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);

                int idDepto = 0;
                int idComuna = 0;

                List<ReservaBLL> listaReservas = r.Reservas(Int32.Parse(Session["IdUsuario"].ToString()));

                foreach (ReservaBLL item in listaReservas)
                {
                    if (item.Id == id)
                    {
                        idDepto = item.IdDepto;
                    }
                }

                List<DepartamentoBLL> listaDeptos = d.ListaDepartamentosBuscar(idDepto);

                foreach (DepartamentoBLL item in listaDeptos)
                {
                    if (item.Id == idDepto.ToString())
                    {
                        idComuna = Int32.Parse(item.Comuna);
                    }
                }

                GridTours.DataSource = t.ListaTour(idComuna);
                GridTours.DataBind();

                GridTours.HeaderRow.Cells[2].Text = "NOMBRE TOUR";
                GridTours.HeaderRow.Cells[3].Text = "VALOR POR PERSONA";
                GridTours.HeaderRow.Cells[6].Text = "ZONA";
            }


        }

        public void Btn_Añadir_SE_Click(object sender, EventArgs e)
        {
            PanelAgregarSE.Visible = true;
            PanelDetalleTour.Visible = false;
            PanelDetalleTransporte.Visible = false;
            PanelDatosTransporte.Visible = false;
            PanelTourDatos.Visible = false;
            GridTourActual.SelectRow(-1);
            GridTransporteActual.SelectRow(-1);

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv1", "setTimeout(scrollToDiv1, 1);", true);

        }

        public void Btn_Modificar_SE_Click(object sender, EventArgs e)
        {
            PanelAgregarSE.Visible = false;
            PanelTour.Visible = false;
            PanelTransporte.Visible = false;
            PanelTourDatos.Visible = false;
            PanelDatosTransporte.Visible = false;
            PanelDetalleTour.Visible = false;
            PanelDetalleTransporte.Visible = false;

            int index = GridReservas.SelectedRow.RowIndex;
            int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);

            if (GridTourActual.SelectedRow == null && GridTransporteActual.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Olvidar_Selecccionar_Servicio()", true);
            }
            else
            {
                if (GridTourActual.SelectedRow != null && GridTransporteActual.SelectedRow != null)
                {
                    GridTourActual.SelectRow(-1);
                    GridTransporteActual.SelectRow(-1);
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ModificarUnServicio()", true);
                }
                else if (GridTourActual.SelectedRow != null && GridTransporteActual.SelectedRow == null)
                {
                    //Modificar Tour
                    PanelTourDatos.Visible = true;

                    int indexTour = GridTourActual.SelectedRow.RowIndex;
                    int idTour = Int32.Parse(GridTourActual.Rows[indexTour].Cells[1].Text);

                    ServicioExtraBLL s = new ServicioExtraBLL();
                    List<ServicioExtraBLL> listaTours = s.ListaServiciosExtra(id);

                    string fechaAsistencia = "";
                    string cantidadAsistentes = "";

                    foreach (ServicioExtraBLL item in listaTours)
                    {
                        if (item.Id == idTour)
                        {
                            fechaAsistencia = item.FechaAsistencia;
                            cantidadAsistentes = item.Asistentes.ToString();
                        }
                    }

                    DateTime date = new DateTime();
                    date = Convert.ToDateTime(fechaAsistencia);
                    fechaAsistencia = date.ToString("yyyy-MM-dd");

                    TxtFecha.Text = fechaAsistencia;
                    TxtCantidadA.Text = cantidadAsistentes;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv4", "setTimeout(scrollToDiv4, 1);", true);

                }
                else if (GridTourActual.SelectedRow == null && GridTransporteActual.SelectedRow != null)
                {
                    //Modificar Transporte
                    PanelDatosTransporte.Visible = true;

                    int indexTrans = GridTransporteActual.SelectedRow.RowIndex;
                    int idTrans = Int32.Parse(GridTransporteActual.Rows[indexTrans].Cells[1].Text);

                    ServicioExtraBLL s = new ServicioExtraBLL();
                    List<ServicioExtraBLL> listaTours = s.ListaServiciosExtra(id);

                    string fechaAbordo = "";
                    string horaAbordo = "";
                    string pasajeros = "";

                    foreach (ServicioExtraBLL item in listaTours)
                    {
                        if (item.Id == idTrans)
                        {
                            fechaAbordo = item.FechaAsistencia;
                            horaAbordo = item.Hora;
                            pasajeros = item.Asistentes.ToString();
                        }
                    }

                    DateTime date = new DateTime();
                    date = Convert.ToDateTime(fechaAbordo);
                    fechaAbordo = date.ToString("yyyy-MM-dd");

                    TxtFechaAbordo.Text = fechaAbordo;
                    TxtHora.Text = horaAbordo;
                    TxtCantidadA.Text = pasajeros;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv7", "setTimeout(scrollToDiv7, 1);", true);

                }
            }
        }

        public void Btn_Eliminar_SE_Click(object sender, EventArgs e)
        {
            PanelAgregarSE.Visible = false;
            PanelTour.Visible = false;
            PanelTransporte.Visible = false;
            PanelTourDatos.Visible = false;
            PanelDatosTransporte.Visible = false;
            PanelDetalleTour.Visible = false;
            PanelDetalleTransporte.Visible = false;

            ServicioExtraBLL s = new ServicioExtraBLL();

            int index = GridReservas.SelectedRow.RowIndex;
            int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);

            if (GridTourActual.SelectedRow == null && GridTransporteActual.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Olvidar_Selecccionar_Servicio()", true);
            }
            else if (GridTourActual.SelectedRow != null && GridTransporteActual.SelectedRow == null)
            {
                //Eliminar Tour
                int indexServicio = GridTourActual.SelectedRow.RowIndex;
                int idServicio = Int32.Parse(GridTourActual.Rows[indexServicio].Cells[1].Text);

                if (s.EliminarServicioExtra(idServicio, id) == 1)
                {
                    PanelServiciosExtraActual.Visible = false;
                    PanelAgregarSE.Visible = false;
                    PanelDetalleTour.Visible = false;
                    PanelTour.Visible = false;
                    PanelTourActual.Visible = false;
                    PanelTourDatos.Visible = false;

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Eliminar()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "EliminarFallido()", true);
                }
                
            }
            else if (GridTourActual.SelectedRow == null && GridTransporteActual.SelectedRow != null)
            {
                //Eliminar Transporte
                int indexServicio = GridTransporteActual.SelectedRow.RowIndex;
                int idServicio = Int32.Parse(GridTransporteActual.Rows[indexServicio].Cells[1].Text);

                if (s.EliminarServicioExtra(idServicio, id) == 1)
                {
                    PanelServiciosExtraActual.Visible = false;
                    PanelAgregarSE.Visible = false;
                    PanelDatosTransporte.Visible = false;
                    PanelDetalleTransporte.Visible = false;
                    PanelTransporte.Visible = false;
                    PanelTransporteActual.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Eliminar()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "EliminarFallido()", true);
                }

            }
        }

        public void GridTours_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
        }

        public void GridTours_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridTours.SelectedRow.RowIndex;

            string nombreTour = GridTours.Rows[index].Cells[2].Text;
            string descripcion = GridTours.Rows[index].Cells[4].Text;

            if (nombreTour.Contains("Caburgua"))
            {
                ImgTour.ImageUrl = "assets/img/caburgua.jpg";
            }
            else if (nombreTour.Contains("Villarrica"))
            {
                ImgTour.ImageUrl = "assets/img/volcan.jpg";
            }
            else if (nombreTour.Contains("Termas"))
            {
                ImgTour.ImageUrl = "assets/img/termas.jpg";
            }

            TextDesc.InnerText = HttpUtility.HtmlDecode(descripcion); //Parsear a UTF8
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "InfoTour()", true);

            PanelTourDatos.Visible = true;
            
        }

        public void ListaSE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListaSE.SelectedIndex == 1)//Tour
            {
                PanelTour.Visible = true;
                PanelTipoTrayecto.Visible = false;
                PanelTransporte.Visible = false;

                CargarTours();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv2", "setTimeout(scrollToDiv2, 1);", true);

            }
            else if (ListaSE.SelectedIndex == 2)//Transporte
            {
                PanelTour.Visible = false;
                PanelTourDatos.Visible = false;
                PanelDetalleTour.Visible = false;
                PanelTipoTrayecto.Visible = true;

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv3", "setTimeout(scrollToDiv3, 1);", true);

            }
        }

        public void CargarTransporte()
        {
            TransporteBLL t = new TransporteBLL();

            if (CmbTipoTrayecto.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "OlvidarSeleccionarTrayecto()", true);
            }
            else
            {
                if (CmbTipoTrayecto.SelectedIndex == 1)//Ida
                {
                    GridTransporte.DataSource = t.ListaTransporte(1);
                    GridTransporte.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv6", "setTimeout(scrollToDiv6, 1);", true);

                }
                else if(CmbTipoTrayecto.SelectedIndex == 2)//Vuelta
                {
                    GridTransporte.DataSource = t.ListaTransporte(2);
                    GridTransporte.DataBind();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv6", "setTimeout(scrollToDiv6, 1);", true);

                }

                GridTransporte.HeaderRow.Cells[2].Text = "VALOR POR PERSONA";
                GridTransporte.HeaderRow.Cells[4].Text = "TIPO DE VEHICULO";
                GridTransporte.HeaderRow.Cells[5].Text = "CANTIDAD DE ASIENTOS";
                GridTransporte.HeaderRow.Cells[7].Text = "TRAYECTO";
            }
        }

        public void GridTransporte_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[6].Visible = false;
        }

        public void GridTransporte_SelectedIndexChanged1(object sender, EventArgs e)
        {
            PanelDatosTransporte.Visible = true;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv7", "setTimeout(scrollToDiv7, 1);", true);

        }

        public void GridTransporteActual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
        }

        public void GridTransporteActual_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void GridTourActual_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
        }

        public void GridTourActual_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void CmbTipoTrayecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTransporte();
            PanelTransporte.Visible = true;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv", "setTimeout(scrollToDiv, 1);", true);
            
        }

        public void BtnCalcularTour_Click(object sender, EventArgs e)
        {
            ServicioExtraBLL s = new ServicioExtraBLL();

            DateTime fechaIngresada = Convert.ToDateTime(TxtFecha.Text);

            int index = GridReservas.SelectedRow.RowIndex;
            int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);
            DateTime fechaIdaReserva = Convert.ToDateTime(GridReservas.Rows[index].Cells[2].Text);
            DateTime fechaRegresoReserva = Convert.ToDateTime(GridReservas.Rows[index].Cells[3].Text);

            List<ServicioExtraBLL> listaServiciosActual = s.ListaServiciosExtra(id);
            
            if (fechaIngresada < fechaIdaReserva || fechaIngresada > fechaRegresoReserva)
            {
                string fechasReserva = fechaIdaReserva.ToShortDateString() + " - " + fechaRegresoReserva.ToShortDateString();
                LblFechasReserva.InnerText = fechasReserva;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ImposibleFechasTour()", true);
            }
            else
            {
                if (GridTourActual.SelectedRow == null)
                {
                    //Calcular desde botón agregar

                    int indexT = GridTours.SelectedRow.RowIndex;

                    int valorTour = Int32.Parse(GridTours.Rows[indexT].Cells[3].Text.Replace("$", "").Replace(".", ""));
                    int cantidadPersonas = Int32.Parse(TxtCantidadA.Text);

                    int total = valorTour * cantidadPersonas;

                    PanelDetalleTour.Visible = true;

                    string nombre = GridTours.Rows[indexT].Cells[2].Text;
                    string zona = GridTours.Rows[indexT].Cells[6].Text;
                    string valorPP = GridTours.Rows[indexT].Cells[3].Text;

                    LblNombreTour.Text = nombre;
                    LblZona.Text = zona;
                    LblFechaAsistencia.Text = Convert.ToDateTime(TxtFecha.Text).ToShortDateString();
                    LblAsistentesTour.Text = TxtCantidadA.Text;
                    LblValorPersonaTour.Text = valorPP;
                    LblTotalTour.Text = total.ToString("C", CultureInfo.CurrentCulture);

                    foreach (ServicioExtraBLL item in listaServiciosActual)
                    {
                        DateTime fechaServicio = Convert.ToDateTime(item.FechaAsistencia);
                        if (fechaIngresada == fechaServicio)
                        {
                            LblFechaServicio.InnerText = item.FechaAsistencia;
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ImposibleFechasTour2()", true);
                            PanelDetalleTour.Visible = false;
                        }
                        else
                        {
                            FilaBotonContratar.Visible = true;
                            FilaBotonModificar.Visible = false;
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv5", "setTimeout(scrollToDiv5, 1);", true);

                        }
                    }
                }
                else if (GridTours.SelectedRow == null)
                {
                    //Calcular desde botón modificar

                    int indexT = GridTourActual.SelectedRow.RowIndex;

                    int valorTour = Int32.Parse(GridTourActual.Rows[indexT].Cells[4].Text.Replace("$", "").Replace(".", ""));
                    int cantidadPersonas = Int32.Parse(TxtCantidadA.Text);

                    int total = valorTour * cantidadPersonas;

                    PanelDetalleTour.Visible = true;

                    string nombre = GridTourActual.Rows[indexT].Cells[3].Text;

                    LblNombreTour.Text = nombre;
                    FilaZona.Visible = false;
                    LblFechaAsistencia.Text = Convert.ToDateTime(TxtFecha.Text).ToShortDateString();
                    LblAsistentesTour.Text = TxtCantidadA.Text;
                    LblValorPersonaTour.Text = valorTour.ToString("C", CultureInfo.CurrentCulture);
                    LblTotalTour.Text = total.ToString("C", CultureInfo.CurrentCulture);

                    foreach (ServicioExtraBLL item in listaServiciosActual)
                    {
                        DateTime fechaServicio = Convert.ToDateTime(item.FechaAsistencia);
                        if (fechaIngresada == fechaServicio)
                        {
                            LblFechaServicio.InnerText = item.FechaAsistencia;
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ImposibleFechasTour2()", true);
                            PanelDetalleTour.Visible = false;
                        }
                        else
                        {
                            FilaBotonContratar.Visible = false;
                            FilaBotonModificar.Visible = true;
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv5", "setTimeout(scrollToDiv5, 1);", true);
                        }
                    }
                }
            }
        }

        public void BtnContratarTour_Click(object sender, EventArgs e)
        {
            ServicioExtraBLL s = new ServicioExtraBLL();

            int index = GridTours.SelectedRow.RowIndex;
            int idTour = Convert.ToInt32(GridTours.DataKeys[index].Value);

            int indexR = GridReservas.SelectedRow.RowIndex;
            int idReserva = Convert.ToInt32(GridReservas.DataKeys[indexR].Value);

            s.FechaAsistencia = LblFechaAsistencia.Text;
            s.Asistentes = Int32.Parse(LblAsistentesTour.Text);
            s.IdTour = idTour;
            s.IdTransporte = null;
            s.IdReserva = idReserva;
            
            if (s.AgregarServicioExtra(s) == 1)
            {
                ReservaBLL r = new ReservaBLL();
                
                string idCliente = GridReservas.Rows[indexR].Cells[8].Text;
                string idDepto = GridReservas.Rows[indexR].Cells[9].Text;
                string valorFinal = GridReservas.Rows[indexR].Cells[7].Text;
                int valorFinalReserva = Int32.Parse(LblTotalTour.Text.Replace("$", "").Replace(".", "")) + Int32.Parse(valorFinal.Replace("$", "").Replace(".", ""));

                r.Id = idReserva;
                r.ValorFinal = valorFinalReserva.ToString();
                r.IdCliente = Int32.Parse(idCliente);
                r.IdDepto = Int32.Parse(idDepto);

                if (r.ModificarReserva(r) == 1)
                {
                    CargarReservas();
                    PanelServiciosExtraActual.Visible = false;
                    PanelAgregarSE.Visible = false;
                    PanelTour.Visible = false;
                    PanelTourDatos.Visible = false;
                    PanelDetalleTour.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ServicioAgregadoExito()", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ServicioAgregadoFallido()", true);
            }
        }

        public void BtnCalcularTransporte_Click(object sender, EventArgs e)
        {
            ServicioExtraBLL s = new ServicioExtraBLL();

            DateTime fechaIngresada = Convert.ToDateTime(TxtFechaAbordo.Text);

            int index = GridReservas.SelectedRow.RowIndex;
            int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);
            DateTime fechaIdaReserva = Convert.ToDateTime(GridReservas.Rows[index].Cells[2].Text);
            DateTime fechaRegresoReserva = Convert.ToDateTime(GridReservas.Rows[index].Cells[3].Text);

            int pasajerosIngresados = Int32.Parse(TxtPasajeros.Text);
            int indexT = GridTransporte.SelectedRow.RowIndex;
            int capacidadPasajeros = Int32.Parse(GridTransporte.Rows[indexT].Cells[5].Text);

            int valorPTransporte = Int32.Parse(GridTransporte.Rows[indexT].Cells[2].Text.Replace("$", "").Replace(".", ""));
            int pasajeros = Int32.Parse(TxtPasajeros.Text);
            int valorTotal = valorPTransporte * pasajeros;

            List<ServicioExtraBLL> listaServiciosActual = s.ListaServiciosExtra(id);

            if (fechaIngresada < fechaIdaReserva || fechaIngresada > fechaRegresoReserva)
            {
                PanelDetalleTransporte.Visible = false;
                string fechasReserva = fechaIdaReserva.ToShortDateString() + " - " + fechaRegresoReserva.ToShortDateString();
                LblFechasReserva2.InnerText = fechasReserva;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ImposibleFechasTransporte()", true);
            }
            else if (pasajerosIngresados > capacidadPasajeros)
            {
                PanelDetalleTransporte.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "CapacidadPasajeros()", true);
            }
            else
            {
                LblTipoTrayecto.Text = CmbTipoTrayecto.SelectedValue;
                LblFechayHora.Text = Convert.ToDateTime(TxtFechaAbordo.Text).ToShortDateString() + " " +TxtHora.Text;
                LblTipoVehiculo.Text = GridTransporte.Rows[indexT].Cells[4].Text;
                LblAsientos.Text = capacidadPasajeros.ToString();
                LblPasajeros.Text = TxtPasajeros.Text;
                LblValorPTransporte.Text = GridTransporte.Rows[indexT].Cells[2].Text;
                LblValorTotalTransporte.Text = valorTotal.ToString("C", CultureInfo.CurrentCulture);

                PanelTipoTrayecto.Visible = false;
                PanelDetalleTransporte.Visible = true;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv8", "setTimeout(scrollToDiv8, 1);", true);

            }
        }

        public void BtnContratarTransporte_Click(object sender, EventArgs e)
        {
            ServicioExtraBLL s = new ServicioExtraBLL();

            int index = GridTransporte.SelectedRow.RowIndex;
            int idTransporte = Convert.ToInt32(GridTransporte.DataKeys[index].Value);

            int indexR = GridReservas.SelectedRow.RowIndex;
            int idReserva = Convert.ToInt32(GridReservas.DataKeys[indexR].Value);

            DateTime fechaHora = Convert.ToDateTime(LblFechayHora.Text);

            s.FechaAsistencia = fechaHora.ToString("dd/MM/yyyy HH:mm");
            s.Asistentes = Int32.Parse(LblPasajeros.Text);
            s.IdTour = null;
            s.IdTransporte = idTransporte;
            s.IdReserva = idReserva;

            if (s.AgregarServicioExtra(s) == 1)
            {
                ReservaBLL r = new ReservaBLL();

                string idCliente = GridReservas.Rows[indexR].Cells[8].Text;
                string idDepto = GridReservas.Rows[indexR].Cells[9].Text;
                string valorFinal = GridReservas.Rows[indexR].Cells[7].Text;
                int valorFinalReserva = Int32.Parse(LblValorTotalTransporte.Text.Replace("$", "").Replace(".", "")) + Int32.Parse(valorFinal.Replace("$", "").Replace(".", ""));

                r.Id = idReserva;
                r.ValorFinal = valorFinalReserva.ToString();
                r.IdCliente = Int32.Parse(idCliente);
                r.IdDepto = Int32.Parse(idDepto);

                if (r.ModificarReserva(r) == 1)
                {
                    CargarReservas();
                    PanelServiciosExtraActual.Visible = false;
                    PanelAgregarSE.Visible = false;
                    PanelTransporte.Visible = false;
                    PanelDatosTransporte.Visible = false;
                    PanelDetalleTransporte.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ServicioAgregadoExito()", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ServicioAgregadoFallido()", true);
            }
        }

        public void BtnModificarTransporte_Click(object sender, EventArgs e)
        {
            
        }

        public void BtnModificarTour_Click(object sender, EventArgs e)
        {
            ServicioExtraBLL s = new ServicioExtraBLL();

            int indexS = GridTourActual.SelectedRow.RowIndex;
            int idServicio = Convert.ToInt32(GridTourActual.DataKeys[indexS].Value);

            int indexT = GridTourActual.SelectedRow.RowIndex;
            int idTour = Int32.Parse(GridTourActual.Rows[indexT].Cells[2].Text);

            int indexR = GridTourActual.SelectedRow.RowIndex;
            int idReserva = Int32.Parse(GridTourActual.Rows[indexT].Cells[14].Text);

            DateTime fecha = Convert.ToDateTime(TxtFecha.Text);

            s.Id = idServicio;
            s.FechaAsistencia = fecha.Date.ToShortDateString();
            s.Asistentes = Int32.Parse(TxtCantidadA.Text);
            s.IdTour = idTour;
            s.IdTransporte = null;
            s.IdReserva = idReserva;

            if (s.ModificarServicioExtra(s) == 1)
            {
                PanelTourDatos.Visible = false;
                PanelDetalleTour.Visible = false;
                PanelServiciosExtraActual.Visible = false;
                CargarReservas();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ServicioModificadoExito()", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ServicioModificadoFallido()", true);
            }
            
        }
    }
}