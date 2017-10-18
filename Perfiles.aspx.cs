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

    [WebMethod]
    public static ArrayList cargarVentanas()
    {
        //DataTable dt = new DataTable();
        ArrayList perfiles = new ArrayList();
        //dt.Columns.Add("id", typeof(int));
        //dt.Columns.Add("pagina", typeof(string));

        procesaCargarVentanas(perfiles/*, dt*/);
        return perfiles;
    }
    public static void procesaCargarVentanas(ArrayList perfiles/*, DataTable dt*/)
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

                //dt.Rows.Add(id, pagina);
                perfiles.Add(new { id = id, pagina = pagina });
            }
        }
    }

    [WebMethod]
    public static ArrayList cargarTablaPerfiles()
    {
        //DataTable dt = new DataTable();
        ArrayList perfiles = new ArrayList();
        //dt.Columns.Add("id", typeof(int));
        //dt.Columns.Add("nombre", typeof(string));
        //dt.Columns.Add("descripcion", typeof(string));
        //dt.Columns.Add("activo", typeof(int));

        procesaPerfiles(perfiles/*, dt*/);
        //HttpContext.Current.Session["DatatablePerfiles"] = dt;
        return perfiles;
    }

    public static void procesaPerfiles(ArrayList perfiles/*, DataTable dt*/)
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

                //dt.Rows.Add(id, nombre, descripcion);
                perfiles.Add(new { id = id, nombre = nombre, descripcion = descripcion});
            }
        }
    }
}