using System;
using System.Data.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Data;
using System.Web.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string nombreSistema = WebConfigurationManager.AppSettings["NomSistema"];
        lblTitulo.Text = nombreSistema;
        tittle.InnerText = nombreSistema + " | Log in";

        if (Request.QueryString["error"] != null)
        {
            int numero;
            bool EsEntero = Int32.TryParse(Request.QueryString["error"], out numero);
            if(EsEntero)
            {
                mensajeError(Convert.ToInt32(Request.QueryString["error"]));
            }
        }

        btnLogin.Click += BtnLogin_Click;
    }

    #region eventos
    private void BtnLogin_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        int identificador = 0;
        Tab_usuario usuarios = new Tab_usuario();
        MetodosTabUsuario metodosUsuarios = new MetodosTabUsuario();

        usuarios.Email = txtEmail.Text;
        usuarios.Contrasena = txtPassword.Text;

        ds = metodosUsuarios.login(usuarios);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                identificador = Convert.ToInt32(item["id"]);
            }
        }

        if(identificador >= 1)
        {
            Session["idUsuario"] = identificador;
            Response.Redirect("~/Dashboard.aspx");
        }
        else
        {
            mensajeError(3);
        }
    }

    #endregion

    #region metodos
    public void mensajeError(int numeroError)
    {
        Tab_alertas alertas = new Tab_alertas();
        MetodosTabAlertas metodosAlertas = new MetodosTabAlertas();
        DataSet ds = new DataSet();
        alertas.Id_alerta = numeroError;

        ds = metodosAlertas.obtenerAlertaPorID(alertas);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                lblError.Text = item["mensaje"].ToString();
            }
        }
    }

    #endregion
}