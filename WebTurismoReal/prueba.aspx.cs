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

        public void jaja()
        {
            string jaja = "djjd";
        }
        public void CargarTabla()
        {
            TourBLL t = new TourBLL();

            GridTours.DataSource = t.ListaTour(1);
            GridTours.DataBind();
        }

        protected void GridAcompañantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridTours.SelectedRowStyle.BackColor = Color.Blue;
        }
    }
}