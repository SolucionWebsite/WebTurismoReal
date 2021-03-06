using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTurismoReal.BLL;

namespace WebTurismoReal
{
    public partial class Login : System.Web.UI.Page
    {
        ClienteBLL cliente = new ClienteBLL();

        public void Page_Load(object sender, EventArgs e)
        {
            Btn_1.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_1.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_2.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_3.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#117A65");
            Btn_2.Style.Add(HtmlTextWriterStyle.Color, "White");
            Btn_3.Style.Add(HtmlTextWriterStyle.Color, "White");

            PanelProgreso.Visible = false;

            try
            {
                if (Request.UrlReferrer.ToString() != HttpContext.Current.Request.Url.AbsoluteUri)
                {
                    ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();

                    if (ViewState["PreviousPageUrl"].ToString().Contains("Detalle") || ViewState["PreviousPageUrl"].ToString().Contains("Registro"))
                    {
                        PanelProgreso.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                Session.Abandon();
                Response.Redirect("PaginaNotFound.aspx");
            }
        }

        public void Btn_Login_Click(object sender, EventArgs e)
        {
            List<ClienteBLL> lista = cliente.ListaUsuarios();

            bool existe = lista.Any(x => x.Correo == txt_usuario.Text);

            string claveHash = GenerarHash(txt_clave.Text);
            string claveUsuario = "";
            string usuario = "";
            string correo = "";
            string rut = "";
            string id = "";

            if (existe == true)
            {
                foreach (ClienteBLL c in lista)
                {
                    if (c.Correo == txt_usuario.Text)
                    {
                        claveUsuario = c.Clave.ToString();
                        usuario = c.Nombre + " " + c.ApellidoP;
                        correo = c.Correo;
                        rut = c.Rut;
                        id = c.Id;
                    }
                }

                if (claveHash == claveUsuario)
                {
                    Session.Timeout = 60;
                    Session["Correo"] = correo;
                    Session["Rut"] = rut;
                    Session["Usuario"] = usuario;
                    Session["IdUsuario"] = id;

                    string paginaAnteriorRegistro = "";
                    string paginaAnterior = ViewState["PreviousPageUrl"].ToString();

                    if (Session["PreviousPageUrlRegistro"] != null)
                    {
                        paginaAnteriorRegistro = Session["PreviousPageUrlRegistro"].ToString();

                        if (paginaAnterior.Contains("Detalle"))
                        {
                            Response.Redirect("Detalle.aspx");
                        }
                        else if (paginaAnterior.Contains("Registro"))
                        {
                            if (paginaAnteriorRegistro.Contains("Detalle"))
                            {
                                Response.Redirect("Detalle.aspx");
                            }
                            else
                            {
                                Response.Redirect("CuentaDatos.aspx");
                            }
                        }
                        else
                        {
                            Response.Redirect("CuentaDatos.aspx");
                        }
                    }
                    else
                    {
                        if (paginaAnterior.Contains("Detalle") || paginaAnterior.Contains("Registro"))
                        {
                            Response.Redirect("Detalle.aspx");
                        }
                        else
                        {
                            Response.Redirect($"CuentaDatos.aspx");
                        }
                    }
                }
                else
                {
                    RequiredFieldValidator1.IsValid = false;
                    RequiredFieldValidator1.ErrorMessage = "Clave incorrecta";
                    txt_clave.Text = "";
                }
            }
            else
            {
                RequiredFieldValidator3.IsValid = false;
                RequiredFieldValidator3.ErrorMessage = "Email no registrado";
                txt_usuario.Text = "";

            }

        }

        public string GenerarHash(String clave)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(clave);
            System.Security.Cryptography.SHA256Managed sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256.ComputeHash(bytes);

            string hashString = Encoding.Default.GetString(hash);

            return hashString;
        }

        public void Btn_LogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}
