using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Collections;
using System.Web.UI.HtmlControls;

public partial class pages_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string nombreSistema = WebConfigurationManager.AppSettings["NomSistema"];
        spanMax.InnerText = nombreSistema;
        spanMin.InnerText = nombreSistema.Substring(0, 1);
        tittle.InnerText = nombreSistema;
        try
        {
            if (Session["idUsuario"].ToString() != "")
            {
                int numero;
                bool EsEntero = Int32.TryParse(Session["idUsuario"].ToString(), out numero);

                if (EsEntero)
                {
                    if (Convert.ToInt32(Session["idUsuario"]) <= 0)
                    {
                        Response.Redirect("~/Login.aspx?error=1");
                    }
                    else
                    {
                        cargarDatosPrincipales();
                        cargarMenus();
                        hf_idUsuario.Value = Convert.ToString(Session["idUsuario"]);
                        btnSalir.Click += BtnSalir_Click;
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx?error=2");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx?error=2");
            }    
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Login.aspx?error=2");
        }
    }

    private void cargarMenus()
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.Int32, Convert.ToInt32(Session["idUsuario"])));
        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_CONSULTAMENU", ConfigurationManager.AppSettings["Sistema"]);

        int administracion = 0;
        int mailbox = 0;

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if(item["Menu"].ToString() == "Administracion")
                {
                    administracion++;
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes["class"] = "active";
                    menuAdministracion.Controls.Add(li);

                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", item["url"].ToString());
                    anchor.InnerText = item["submenu"].ToString();

                    li.Controls.Add(anchor);
                }
                else if(item["Menu"].ToString() == "Mailbox")
                {
                    mailbox++;
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes["class"] = "active";
                    menuMailbox.Controls.Add(li);

                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", item["url"].ToString());
                    anchor.InnerText = item["submenu"].ToString();

                    li.Controls.Add(anchor);
                }
            }
        }

        if(administracion == 0)
        {
            Administracion.Attributes["hidden"] = "hidden";
        }

        if(mailbox == 0)
        {
            Mailbox.Attributes["hidden"] = "hidden";
        }
    }

    private void BtnSalir_Click(object sender, EventArgs e)
    {
        Session["idUsuario"] = "";
        Response.Redirect("~/Login.aspx?error=4");
    }

    private void cargarDatosPrincipales()
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.Int32, Convert.ToInt32(Session["idUsuario"])));
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));
        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_DatosPrincipales", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                lblNombre1.Text = item["Nombre"].ToString();
                lblNombre3.Text = item["Nombre"].ToString();
                lblNombre2.Text = item["Nombre"].ToString() + " - " + item["Rol"].ToString();
            }
        }
    }
}
