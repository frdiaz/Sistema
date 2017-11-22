using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ventanas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region metodos

    [WebMethod]
    public static bool nuevaVentana(string nombreMenu, string URL, string clas, string submenu)
    {
        bool resultado = true;
        DataSet ds = new DataSet();

        MetodosTabPagina metodosPagina = new MetodosTabPagina();
        Tab_pagina pagina = new Tab_pagina();

        pagina.Menu = nombreMenu;
        pagina.Url = URL;
        pagina.Clases = clas;
        pagina.Submenu = submenu;

        resultado = metodosPagina.crearPagina(pagina);

        return resultado;
    }

    #endregion
}