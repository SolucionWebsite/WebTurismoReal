using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class Disponibilidad : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;

            Btn_1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_1.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_2.Style.Add(HtmlTextWriterStyle.Color, "White");
            
            try
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                string[] separado = url.Split('/');
                string fechaSalida = separado[separado.Length - 2];
                string fechaEntrada = separado[separado.Length - 3];
                string region = separado[separado.Length - 4];
                string provincia = separado[separado.Length - 5];
                string comuna = separado[separado.Length - 6];
                string id_comuna = separado[separado.Length - 7];
                string id_provincia = separado[separado.Length - 8];
                string id_region = separado[separado.Length - 9];


                string fechaSalidaDecode = Base64Decode(fechaSalida);
                string fechaEntradaDecode = Base64Decode(fechaEntrada);
                string regionDecode = Base64Decode(region);
                string provinciaDecode = Base64Decode(provincia);
                string comunaDecode = Base64Decode(comuna);
                string idComunaDecode = Base64Decode(id_comuna);
                string idProvinciaDecode = Base64Decode(id_provincia);
                string idRegionDecode = Base64Decode(id_region);

                Lbl_Región.Text = regionDecode;
                Lbl_Provincia.Text = provinciaDecode + ",";
                Lbl_Comuna.Text = comunaDecode + ",";
                Lbl_Fechas.Text = fechaEntradaDecode + " " + "-" + " " + fechaSalidaDecode;
                Lbl_Id_Comuna.Text = idComunaDecode;
                Lbl_Id_Provincia.Text = idProvinciaDecode;
                Lbl_Id_Region.Text = idRegionDecode;

                DepartamentoBLL departamentos = new DepartamentoBLL();
                
                List<DepartamentoBLL> listadepto = departamentos.ListaDepartamentos(Convert.ToInt32(Lbl_Id_Comuna.Text));
                
                GridDepartamentos.DataSource = listadepto;
                GridDepartamentos.DataBind();

                if (GridDepartamentos.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SinDepartamentos()", true);
                }
                else
                {
                    GridDepartamentos.HeaderRow.Cells[1].Text = "ID";
                    GridDepartamentos.HeaderRow.Cells[2].Text = "DIRECCIÓN";
                    GridDepartamentos.HeaderRow.Cells[3].Text = "COMUNA";
                    GridDepartamentos.HeaderRow.Cells[4].Text = "PROVINCIA";
                    GridDepartamentos.HeaderRow.Cells[5].Text = "REGIÓN";
                    GridDepartamentos.HeaderRow.Cells[6].Text = "HABITACIONES";
                    GridDepartamentos.HeaderRow.Cells[7].Text = "BAÑOS";
                    GridDepartamentos.HeaderRow.Cells[8].Text = "VALOR DÍA";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        public static string Base64Decode(string base64EncodedData)
        {
            string textoDecodeFinal = base64EncodedData.ToString().Replace("_", "/");
            var base64EncodedBytes = System.Convert.FromBase64String(textoDecodeFinal);
            string textoDecode = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            return textoDecode;
        }

        public void GridDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartamentoBLL depto = new DepartamentoBLL();

            int index = GridDepartamentos.SelectedRow.RowIndex;
            int id = Convert.ToInt32(GridDepartamentos.DataKeys[index].Value);

            List<DepartamentoBLL> lista = depto.ListaDepartamentos(Convert.ToInt32(Lbl_Id_Comuna.Text));

            string rutaFoto = "";

            foreach (DepartamentoBLL d in lista)
            {
                if (Int32.Parse(d.Id) == id)
                {
                    rutaFoto = ConvertirImagen(d.Imagen);
                }
            }
            
            ImgFotoDepto.ImageUrl = rutaFoto;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "FotoDepto()", true);
        }

        public void Btn_Calcular_Click(object sender, EventArgs e)
        {
            try
            {
                int index = GridDepartamentos.SelectedRow.RowIndex;

                int id = Convert.ToInt32(GridDepartamentos.DataKeys[index].Value);

                DepartamentoBLL depto = new DepartamentoBLL();

                if (Convert.ToInt32(txt_acompañantes.Text) <= 9)
                {
                    if (depto.BuscarDepartamento(id) == true)
                    {
                        string url = HttpContext.Current.Request.Url.AbsoluteUri;
                        string[] separado = url.Split('/');
                        string dias = separado[separado.Length - 1];
                        string diasDecode = Base64Decode(dias);

                        string valor_dia = depto.Valor_Dia;

                        string total2 = valor_dia.Replace(".", "");
                        string total3 = total2.Trim(new Char[] { '$', ' ' });

                        string cantidad_dias = diasDecode;
                        int valor_total;
                        string valor_final;

                        valor_total = Convert.ToInt32(total3) * Convert.ToInt32(cantidad_dias);
                        valor_final = valor_total.ToString("C", CultureInfo.CurrentCulture);

                        Lbl_Dias.Text = diasDecode;
                        Lbl_acompañantes.Text = txt_acompañantes.Text;
                        Lbl_Total.Text = valor_final;

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ScrollToADiv", "setTimeout(scrollToDiv, 1);", true);

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "LimiteAcompañantes()", true);
                }

            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "DepartamentoNoSeleccionado()", true);

            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            string textoEncode = System.Convert.ToBase64String(plainTextBytes);
            string textoEncodeFinal = textoEncode.ToString().Replace("/", "_");
            return textoEncodeFinal;
        }

        public void Btn_Reservar_Click(object sender, EventArgs e)
        {
            if (Lbl_Total.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SinCalcular()", true);
            }
            else
            {
                DepartamentoBLL depto = new DepartamentoBLL();

                int index = GridDepartamentos.SelectedRow.RowIndex;
                int id = Convert.ToInt32(GridDepartamentos.DataKeys[index].Value);

                if (depto.BuscarDepartamento(id) == true)
                {
                    string total2 = Lbl_Total.Text.Replace(".", "");
                    string total3 = total2.Trim(new Char[] { '$', ' ' });

                    int abono = Convert.ToInt32(total3) * 30 / 100;
                    int pago_restante = Convert.ToInt32(total3) - abono;

                    string abono1 = abono.ToString("C", CultureInfo.CurrentCulture);
                    string restante = pago_restante.ToString("C", CultureInfo.CurrentCulture);

                    Session.Timeout = 60;
                    Session["Id_Depto"] = depto.Id;
                    Session["Depto"] = depto.Direccion;
                    Session["Region"] = depto.Region;
                    Session["Provincia"] = depto.Provincia.Replace(" ", String.Empty);
                    Session["Comuna"] = depto.Comuna;
                    Session["Dias"] = Lbl_Dias.Text;
                    Session["Ida"] = Lbl_Fechas.Text.Substring(0, 10);
                    Session["Vuelta"] = Lbl_Fechas.Text.Substring(13, 10);
                    Session["Acompañantes"] = Lbl_acompañantes.Text;
                    Session["Total"] = Lbl_Total.Text;
                    Session["Abono"] = abono1;
                    Session["Restante"] = restante;
                    
                    Response.Redirect($"http://localhost:57174/Detalle");
                        
                    
                }
            }
        }

        public void GridDepartamentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        public void Btn_LogOut_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }

        public string ConvertirImagen(byte[] _image)
        {
            string imagen = null;

            string ruta = Server.MapPath("/assets/img/");
            ruta = Path.Combine(ruta, _image.Length.ToString() + ".jpeg");
            MemoryStream ms = new MemoryStream(_image);
            try
            {
                Bitmap SA = (Bitmap)System.Drawing.Image.FromStream(ms);
                SA.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);
                imagen = "/assets/img/" + _image.Length.ToString() + ".jpeg";
            }
            catch (Exception)
            {
                imagen = "/assets/img/NoImg.png";
            }
            
            return imagen;
        }
    }
}