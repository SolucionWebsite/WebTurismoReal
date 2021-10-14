using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

                DataTable registros = departamentos.Departamentos(Convert.ToInt32(Lbl_Id_Region.Text), Convert.ToInt32(Lbl_Id_Provincia.Text), Convert.ToInt32(Lbl_Id_Comuna.Text));

                List<DepartamentoBLL> listadepto = new List<DepartamentoBLL>();

                for (int i = 0; i < registros.Rows.Count; i++)
                {
                    DepartamentoBLL depto = new DepartamentoBLL();

                    depto.Id = registros.Rows[i]["ID"].ToString();
                    depto.Direccion = registros.Rows[i]["DIRECCION"].ToString();
                    depto.Region = registros.Rows[i]["REGION"].ToString();
                    depto.Provincia = registros.Rows[i]["PROVINCIA"].ToString();
                    depto.Comuna = registros.Rows[i]["COMUNA"].ToString();
                    depto.Habitaciones = registros.Rows[i]["HABITACIONES"].ToString();
                    depto.Baños = registros.Rows[i]["BAÑOS"].ToString();
                    int deptoTable = Convert.ToInt32(registros.Rows[i]["VALOR_DÍA"]);
                    string deptoTableCulture = deptoTable.ToString("C", CultureInfo.CurrentCulture);
                    depto.Valor_Dia = deptoTableCulture;
                    listadepto.Add(depto);
                }

                GridDepartamentos.DataSource = listadepto;
                GridDepartamentos.DataBind();

                if (GridDepartamentos.Rows.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "SinDepartamentos()", true);
                }
                else
                {
                    GridDepartamentos.HeaderStyle.Font.Bold = false;
                    GridDepartamentos.HeaderRow.Cells[1].Width = 50;
                    GridDepartamentos.HeaderStyle.Height = 30;
                    
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

        protected void GridDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    string id_depto = depto.Id;
                    string direccion = depto.Direccion;
                    string region = depto.Region;
                    string provincia = depto.Provincia.Replace(" ", String.Empty);
                    string comuna = depto.Comuna;
                    string dias = Lbl_Dias.Text;
                    string fecha_ida = Lbl_Fechas.Text.Substring(0, 10);
                    string fecha_vuelta = Lbl_Fechas.Text.Substring(13, 10);
                    string acompañantes = Lbl_acompañantes.Text;
                    string total_pago = Lbl_Total.Text;

                    string total2 = total_pago.Replace(".", "");
                    string total3 = total2.Trim(new Char[] { '$', ' ' });

                    int abono = Convert.ToInt32(total3) * 30 / 100;
                    int pago_restante = Convert.ToInt32(total3) - abono;

                    string abono1 = abono.ToString("C", CultureInfo.CurrentCulture);
                    string restante = pago_restante.ToString("C", CultureInfo.CurrentCulture);

                    string id_deptoEncode = Base64Encode(id_depto);
                    string direccionEncode = Base64Encode(direccion);
                    string regionEncode = Base64Encode(region);
                    string provinciaEncode = Base64Encode(provincia);
                    string comunaEncode = Base64Encode(comuna);
                    string diasEncode = Base64Encode(dias);
                    string fecha_i_Encode = Base64Encode(fecha_ida);
                    string fecha_v_Encode = Base64Encode(fecha_vuelta);
                    string acompañantesEncode = Base64Encode(acompañantes);
                    string totalEncode = Base64Encode(total_pago);
                    string abonoEncode = Base64Encode(abono1);
                    string restanteEncode = Base64Encode(restante);

                    if (Session["IdUsuario"] == null)
                    {
                        Response.Redirect($"http://localhost:57174/Detalle/{id_deptoEncode}/{direccionEncode}/{regionEncode}/{provinciaEncode}/{comunaEncode}/" +
                        $"{diasEncode}/{fecha_i_Encode}/{fecha_v_Encode}/{acompañantesEncode}/{totalEncode}/{abonoEncode}/{restanteEncode}");

                    }
                    else
                    {
                        Response.Redirect($"http://localhost:57174/Detalle2/{id_deptoEncode}/{direccionEncode}/{regionEncode}/{provinciaEncode}/{comunaEncode}/" +
                                $"{diasEncode}/{fecha_i_Encode}/{fecha_v_Encode}/{acompañantesEncode}/{totalEncode}/{abonoEncode}/{restanteEncode}");
                    }
                    
                }
            }
        }
    }
}