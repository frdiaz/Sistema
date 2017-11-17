using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Perfiles : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region metodos
    
    [WebMethod]
    public static ArrayList cargarVentanas()
    { 
        ArrayList perfiles = new ArrayList();

        procesaCargarVentanas(perfiles);
        return perfiles;
    }

    [WebMethod]
    public static ArrayList cargarTablaPerfiles()
    {
        ArrayList perfiles = new ArrayList();

        procesaPerfiles(perfiles);
        return perfiles;
    }

    public static void procesaCargarVentanas(ArrayList perfiles)
    {
        MetodosTabPagina metodosPaginas = new MetodosTabPagina();
        DataSet ds = new DataSet();

        ds = metodosPaginas.obtenerEspecifico();
        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string pagina = item["pagina"].ToString();
                
                perfiles.Add(new { id = id, pagina = pagina });
            }
        }
    }

    public static void procesaPerfiles(ArrayList perfiles)
    {
        MetodosTabPagina metodosPaginas = new MetodosTabPagina();
        DataSet ds = new DataSet();

        ds = metodosPaginas.consultaPerfiles();

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string nombre = item["nombre"].ToString();
                string descripcion = item["descripcion"].ToString();

                perfiles.Add(new { id = id, nombre = nombre, descripcion = descripcion});
            }
        }
    }

    #endregion
}