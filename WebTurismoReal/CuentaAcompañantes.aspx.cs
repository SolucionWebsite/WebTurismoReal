using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
                    CargarNacionalidad();
                    CargarGenero();
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
        
        public void CargarTabla()
        {
            AcompañanteBLL bll = new AcompañanteBLL();

            if (Session["IdUsuario"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }
            else
            {
                try
                {
                    int index = GridReservas.SelectedRow.RowIndex;
                    int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);

                    List<AcompañanteBLL> lista = bll.ListaAcompañantes(Int32.Parse(Session["IdUsuario"].ToString()), id);

                    List<AcompañanteBLL> listaNueva = new List<AcompañanteBLL>();

                    foreach (AcompañanteBLL a in lista)
                    {
                        AcompañanteBLL acompañante = new AcompañanteBLL();

                        acompañante.Id = a.Id;
                        acompañante.Nombre = a.Nombre;
                        acompañante.ApellidoP = a.ApellidoP;
                        acompañante.ApellidoM = a.ApellidoM;
                        acompañante.Rut = a.Rut;
                        acompañante.FechaNac = a.FechaNac.Remove(10, 8);
                        acompañante.Telefono = a.Telefono;
                        acompañante.Correo = a.Correo;

                        listaNueva.Add(acompañante);
                    }

                    GridAcompañantes.DataSource = listaNueva;
                    GridAcompañantes.DataBind();

                    if (lista.Count == 0)
                    {
                        PanelNoAcompañantes.Visible = true;
                        PanelSiAcompañantes.Visible = false;
                    }
                    else
                    {
                        PanelSiAcompañantes.Visible = true;
                        PanelNoAcompañantes.Visible = false;

                        GridAcompañantes.HeaderRow.Cells[1].Text = "ID";
                        GridAcompañantes.HeaderRow.Cells[2].Text = "RUT";
                        GridAcompañantes.HeaderRow.Cells[3].Text = "NOMBRE";
                        GridAcompañantes.HeaderRow.Cells[4].Text = "PRIMER APELLIDO";
                        GridAcompañantes.HeaderRow.Cells[5].Text = "SEGUNDO APELLIDO";
                        GridAcompañantes.HeaderRow.Cells[6].Text = "TELÉFONO";
                        GridAcompañantes.HeaderRow.Cells[7].Text = "CORREO";
                        GridAcompañantes.HeaderRow.Cells[8].Text = "FECHA DE NACIMIENTO";
                    }
                }
                catch (Exception)
                {
                    int index = GridReservas.SelectedRow.RowIndex;

                    int id = Convert.ToInt32(GridReservas.DataKeys[index].Value);

                    List<AcompañanteBLL> lista = bll.ListaAcompañantes(Int32.Parse(Session["IdUsuario"].ToString()), id);

                    List<AcompañanteBLL> listaNueva = new List<AcompañanteBLL>();

                    foreach (AcompañanteBLL a in lista)
                    {
                        AcompañanteBLL acompañante = new AcompañanteBLL();

                        acompañante.Id = a.Id;
                        acompañante.Nombre = a.Nombre;
                        acompañante.ApellidoP = a.ApellidoP;
                        acompañante.ApellidoM = a.ApellidoM;
                        acompañante.Rut = a.Rut;
                        acompañante.FechaNac = a.FechaNac.Remove(10, 8);
                        acompañante.Telefono = a.Telefono;
                        acompañante.Correo = a.Correo;

                        listaNueva.Add(acompañante);
                    }

                    GridAcompañantes.DataSource = listaNueva;
                    GridAcompañantes.DataBind();
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
        
        public void Btn_Añadir_Acompañante_Click(object sender, EventArgs e)
        {
            PanelAñadirAcompañantes.Visible = true;
            
            GridAcompañantes.SelectRow(-1);

            Limpiar();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv1", "setTimeout(scrollToDiv1, 1);", true);

        }

        public void Limpiar()
        {
            Txt_Nombre_A.Text = "";
            Txt_Apellido_A.Text = "";
            Txt_Apellido_M.Text = "";
            Txt_Correo_A.Text = "";
            Txt_Nacimiento_A.Text = "";
            Txt_Rut_A.Text = "";
            Txt_Telefono_A.Text = "";
            CmbGenero.SelectedIndex = 0;
            CmbNacionalidad.SelectedIndex = 0;
        }

        public void Btn_Guardar_Click(object sender, EventArgs e)
        {
            AcompañanteBLL acompañante = new AcompañanteBLL();

            if (Session["IdUsuario"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }
            else
            {
                int indexR = GridReservas.SelectedRow.RowIndex;

                int idR = Convert.ToInt32(GridReservas.DataKeys[indexR].Value);

                List<AcompañanteBLL> lista = acompañante.ListaAcompañantes(Int32.Parse(Session["IdUsuario"].ToString()), idR);

                if (GridAcompañantes.SelectedRow == null)
                {
                    //Agregar
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
                        acompañante.IdReserva = idR;

                        bool existe = lista.Any(x => x.Rut == Txt_Rut_A.Text);

                        if (existe == true)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Existente()", true);
                        }
                        else
                        {
                            if (acompañante.AgregarAcompañante(acompañante) == 1)
                            {
                                CargarTabla();
                                Limpiar();
                                PanelAñadirAcompañantes.Visible = false;
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Exitoso()", true);
                            }
                            else if (acompañante.AgregarAcompañante(acompañante) == 0)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Error()", true);
                            }
                        }
                    }
                }
                else
                {
                    //modificar

                    int index = GridAcompañantes.SelectedRow.RowIndex;
                    int id = Convert.ToInt32(GridAcompañantes.DataKeys[index].Value);

                    bool existe = lista.Any(x => x.Id == id.ToString());

                    DateTime fechaToDate = Convert.ToDateTime(Txt_Nacimiento_A.Text);
                    string fechaString = fechaToDate.ToString("dd-MM-yyyy", CultureInfo.CurrentCulture);

                    if (existe == true)
                    {
                        string rut = "";
                        int idCliente = 0;
                        int idReserva = 0;

                        foreach(AcompañanteBLL a in lista)
                        {
                            if (a.Id == id.ToString())
                            {
                                rut = a.Rut; 
                                idCliente = a.IdCliente;
                                idReserva = a.IdReserva;
                            }
                        }

                        AcompañanteBLL c = new AcompañanteBLL();

                        c.Nombre = Txt_Nombre_A.Text;
                        c.ApellidoP = Txt_Apellido_A.Text;
                        c.ApellidoM = Txt_Apellido_M.Text;
                        c.Rut = Txt_Rut_A.Text;
                        c.Telefono = "+569" + Txt_Telefono_A.Text;
                        c.FechaNac = fechaString;
                        c.Correo = Txt_Correo_A.Text;
                        c.GeneroC = Int32.Parse(CmbGenero.SelectedValue);
                        c.NacionalidadC = Int32.Parse(CmbNacionalidad.SelectedValue);
                        c.IdCliente = idCliente;
                        c.IdReserva = idReserva;
                        
                        if (c.ModificarAcompañante(rut, c) == 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionFallida()", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "ActualizacionExitosa()", true);
                            CargarTabla();
                            Limpiar();
                            PanelAñadirAcompañantes.Visible = false;

                        }

                    }


                }
            }
        }

        public void GridAcompañantes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void GridAcompañantes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;
        }

        public void Btn_Modificar_Acompañante_Click(object sender, EventArgs e)
        {
            PanelAñadirAcompañantes.Visible = true;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv1", "setTimeout(scrollToDiv1, 1);", true);


            if (Session["IdUsuario"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SessionExpired()", true);
            }
            else
            {
                int indexR = GridReservas.SelectedRow.RowIndex;

                int idR = Convert.ToInt32(GridReservas.DataKeys[indexR].Value);

                List<AcompañanteBLL> lista = acompañante.ListaAcompañantes(Int32.Parse(Session["IdUsuario"].ToString()), idR);

                if (GridAcompañantes.SelectedRow == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SeleccionarAcompañante()", true);
                }
                else
                {
                    int index = GridAcompañantes.SelectedRow.RowIndex;
                    int id = Convert.ToInt32(GridAcompañantes.DataKeys[index].Value);

                    bool existe = lista.Any(x => x.Id == id.ToString());

                    if (existe == true)
                    {
                        Txt_Nombre_A.Enabled = true;
                        Txt_Apellido_A.Enabled = true;
                        Txt_Apellido_M.Enabled = true;
                        Txt_Rut_A.Enabled = true;
                        Txt_Telefono_A.Enabled = true;
                        Txt_Nacimiento_A.Enabled = true;
                        Txt_Correo_A.Enabled = true;
                        CmbGenero.Enabled = true;
                        CmbNacionalidad.Enabled = true;

                        foreach (AcompañanteBLL c in lista)
                        {
                            if (c.Id == id.ToString())
                            {
                                Txt_Nombre_A.Text = c.Nombre;
                                Txt_Apellido_A.Text = c.ApellidoP;
                                Txt_Apellido_M.Text = c.ApellidoM;
                                Txt_Rut_A.Text = c.Rut;
                                Txt_Telefono_A.Text = c.Telefono.Remove(0, 4);
                                DateTime date = new DateTime();
                                date = Convert.ToDateTime(c.FechaNac);
                                Txt_Nacimiento_A.Text = date.ToString("yyyy-MM-dd");
                                Txt_Correo_A.Text = c.Correo;
                                CmbGenero.SelectedValue = c.GeneroC.ToString();
                                CmbNacionalidad.SelectedValue = c.NacionalidadC.ToString();
                            }
                        }
                    }
                }
            }
        }
        
        public void Btn_Eliminar_Acompañante_Click(object sender, EventArgs e)
        {
            PanelAñadirAcompañantes.Visible = false;

            if (GridAcompañantes.SelectedRow == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SeleccionarAcompañante()", true);
            }
            else
            {
                string rutA = "";

                int idC = Int32.Parse(Session["IdUsuario"].ToString());

                int index = GridAcompañantes.SelectedRow.RowIndex;
                int idA = Convert.ToInt32(GridAcompañantes.DataKeys[index].Value);

                int indexR = GridReservas.SelectedRow.RowIndex;
                int idR = Convert.ToInt32(GridReservas.DataKeys[indexR].Value);

                List<AcompañanteBLL> lista = acompañante.ListaAcompañantes(idC, idR);

                foreach(AcompañanteBLL a in lista)
                {
                    if (idA == Int32.Parse(a.Id))
                    {
                        rutA = a.Rut;
                    }
                }

                if (acompañante.EliminarAcompañantes(rutA, idR.ToString()) == 1)
                {
                    CargarTabla();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "EliminacionExitosa()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "EliminacionFallida()", true);
                }
                
                
            }
        }

        public void GridReservas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
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

            foreach(ReservaBLL reserva in lista)
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
                PanelAcompañantes.Visible = true;
                CargarTabla();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv", "setTimeout(scrollToDiv, 1);", true);

            }


        }

        public void GridReservas_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
        }

        public void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}