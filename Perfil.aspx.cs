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

public partial class Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public class datos
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string direccion { get; set; }
        public string fono { get; set; }
    }

    [WebMethod]
    public static string cargarDatosPrincipales(string id_usuario)
    {
        string json = "";
        
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.Int32, id_usuario));
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 2));
        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_DatosPrincipales", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                datos dt = new datos
                {
                    rut = item["Rut"].ToString(),
                    nombre = item["nombre"].ToString(),
                    email = item["email"].ToString(),
                    apellidoPaterno = item["apellidoPaterno"].ToString(),
                    apellidoMaterno = item["apellidoMaterno"].ToString(),
                    direccion = item["direccion"].ToString(),
                    fono = item["fono"].ToString()

                };
                json = JsonConvert.SerializeObject(dt);
            }
        }
        return json;
    }

    [WebMethod]
    public static bool actualizarPassword(int id_usuario, string password)
    {
        bool resultado = true;

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.Int32, id_usuario));
        Parametros.Add(new Parametro("@PASSWORD", DbType.String, password));
        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ACTUALIZARPASSWORD", ConfigurationManager.AppSettings["Sistema"]);

        if(ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if(Convert.ToInt32(item["Resultado"]) != 1)
                {
                    resultado = false;
                }
            }
        }
        else
        {
            resultado = false;
        }
        return resultado;
    }

    [WebMethod]
    public static bool actualizarDatos(int id_usuario, string email, string direccion, string fono)
    {
        bool resultado = true;

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.Int32, id_usuario));
        Parametros.Add(new Parametro("@EMAIL", DbType.String, email));
        Parametros.Add(new Parametro("@DIRECCION", DbType.String, direccion));

        if(fono == "")
        {
            fono = "0";
        }

        Parametros.Add(new Parametro("@FONO", DbType.Int32, Convert.ToInt32(fono)));
        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ACTUALIZARDATOS", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(item["Resultado"]) != 1)
                {
                    resultado = false;
                }
            }
        }
        else
        {
            resultado = false;
        }
        return resultado;
    }
}