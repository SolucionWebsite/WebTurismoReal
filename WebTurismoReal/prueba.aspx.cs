using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class prueba : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            AcompañanteBLL a = new AcompañanteBLL();

            CargarTabla();
        }

        public void CargarTabla()
        {
            AcompañanteBLL bll = new AcompañanteBLL();
            
                List<AcompañanteBLL> lista = bll.ListaAcompañantes(28,61);

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

        protected void GridAcompañantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridAcompañantes.SelectedRowStyle.BackColor = Color.Blue;
        }
    }
}