using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

    [WebMethod]
    public static ArrayList cargarTablaPaginas()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Nombre", typeof(string));
        dt.Columns.Add("id", typeof(string));

        ArrayList arreglo = new ArrayList();

        obtenerPaginas(arreglo);

        return arreglo;
    }

    private static void obtenerPaginas(ArrayList arreglo)
    {
        DataSet ds = new DataSet();
        
        MetodosTabPagina metodosPaginas = new MetodosTabPagina();

        ds = metodosPaginas.obtenerTodos();

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id_pagina = Convert.ToInt32(item["id_pagina"]);
                string menu = item["menu"].ToString();
                string url = item["url"].ToString();
                int activo = Convert.ToInt32(item["activo"]);
                string activa = "";
                if(activo == 1)
                {
                    activa = "Activa";
                }else
                {
                    activa = "Desactivada";
                }

                string clase = item["class"].ToString();
                string submenu = item["submenu"].ToString();

                arreglo.Add(new { id_pagina = id_pagina, menu = menu, url = url, activa = activa, clase = clase, submenu = submenu });
            }
        }
    }

    [WebMethod]
    public static ArrayList cargarEditarPaginas(int id)
    {
        ArrayList arreglo = new ArrayList();

        procesaEditarPaginas(arreglo, id);

        return arreglo;
    }

    private static void procesaEditarPaginas(ArrayList arreglo, int id_paginas)
    {
        DataSet ds = new DataSet();

        MetodosTabPagina metodosPaginas = new MetodosTabPagina();
        Tab_pagina pagina = new Tab_pagina();

        pagina.Id_pagina = id_paginas;

        ds = metodosPaginas.obtenerTodoPorIDPagina(pagina);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id_pagina = Convert.ToInt32(item["id_pagina"]);
                string menu = item["menu"].ToString();
                string url = item["url"].ToString();
                int activo = Convert.ToInt32(item["activo"]);
                string clase = item["class"].ToString();
                string submenu = item["submenu"].ToString();

                arreglo.Add(new { id_pagina = id_pagina, menu = menu, url = url, activo = activo, clase = clase, submenu = submenu });
            }
        }
    }

    [WebMethod]
    public static bool actualizarPagina(string id_pagina, string menu, string URL, string activo, string clase, string submenu)
    {
        bool resultado = true;
        DataSet ds = new DataSet();

        MetodosTabPagina metodosPagina = new MetodosTabPagina();
        Tab_pagina pagina = new Tab_pagina();

        pagina.Id_pagina = Convert.ToInt32(id_pagina);
        pagina.Menu = menu;
        pagina.Url = URL;
        pagina.Activo = Convert.ToInt32(activo);
        pagina.Clases = clase;
        pagina.Submenu = submenu;

        resultado = metodosPagina.actualizarPagina(pagina);

        return resultado;
    }

    #endregion
}