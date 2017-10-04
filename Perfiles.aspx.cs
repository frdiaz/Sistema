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
    public static ArrayList cargarTablaPerfiles()
    {
        DataTable dt = new DataTable();
        ArrayList perfiles = new ArrayList();
        dt.Columns.Add("id", typeof(int));
        dt.Columns.Add("nombre", typeof(string));
        dt.Columns.Add("descripcion", typeof(string));
        dt.Columns.Add("activo", typeof(int));

        procesaPerfiles(perfiles, dt);
        HttpContext.Current.Session["DatatablePerfiles"] = dt;
        return perfiles;
    }

    public static void procesaPerfiles(ArrayList perfiles, DataTable dt)
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));

        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros,"SP_ConsultaPerfiles", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string nombre = item["nombre"].ToString();
                string descripcion = item["descripcion"].ToString();

                dt.Rows.Add(id, nombre, descripcion);
                perfiles.Add(new { id = id, nombre = nombre, descripcion = descripcion});
            }
        }
    }

}
