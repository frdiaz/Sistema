using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static ArrayList cargarPerfiles()
    {
        DataTable dt = new DataTable();
        ArrayList perfiles = new ArrayList();
        dt.Columns.Add("id", typeof(int));
        dt.Columns.Add("nombre", typeof(string));
        
        procesaPerfiles(perfiles, dt);
        HttpContext.Current.Session["DatatablePerfiles"] = dt;
        return perfiles;
    }
    public static void procesaPerfiles(ArrayList perfiles, DataTable dt)
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));//1 = consulta id y nombre

        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaPerfiles", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string nombre = item["nombre"].ToString();

                dt.Rows.Add(id, nombre);
                perfiles.Add(new { id = id, nombre = nombre});
            }
        }
    }

    [WebMethod]
    public static ArrayList cargarTablaUsuarios()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("id", typeof(Int32));
        dt.Columns.Add("Rut", typeof(string));
        dt.Columns.Add("Nombre", typeof(string));
        dt.Columns.Add("Email", typeof(string));
        dt.Columns.Add("Activo", typeof(string));

        ArrayList mensajes = new ArrayList();

        procesaUsuarios(mensajes, dt);

        HttpContext.Current.Session["Datatable"] = dt;

        return mensajes;
    }

    [WebMethod]
    public static ArrayList cargarEditarUsuarios(int id)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("id", typeof(Int32));
        dt.Columns.Add("Rut", typeof(string));
        dt.Columns.Add("Email", typeof(string));
        dt.Columns.Add("Nombre", typeof(string));
        dt.Columns.Add("apellidoPaterno", typeof(string));
        dt.Columns.Add("apellidoMaterno", typeof(string));
        dt.Columns.Add("direccion", typeof(string));
        dt.Columns.Add("fono", typeof(string));
        dt.Columns.Add("activo", typeof(string));
        dt.Columns.Add("rol", typeof(string));

        ArrayList mensajes = new ArrayList();

        procesaEditarUsuarios(mensajes, dt, id);

        HttpContext.Current.Session["Datatable"] = dt;

        return mensajes;
    }

    private static void procesaEditarUsuarios(ArrayList mensajes, DataTable dt, int id_usuario)
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 3));//1=con fechas en el sp
        Parametros.Add(new Parametro("@ID", DbType.Int32, id_usuario));
        Parametros.Add(new Parametro("@RUT", DbType.String, ""));
        Parametros.Add(new Parametro("@EMAIL", DbType.String, ""));
        Parametros.Add(new Parametro("@NOMBRE", DbType.String, ""));
        Parametros.Add(new Parametro("@APELLIDOPATERNO", DbType.String, ""));
        Parametros.Add(new Parametro("@APELLIDOMATERNO", DbType.String, ""));
        Parametros.Add(new Parametro("@CONTRASENA", DbType.String, ""));
        Parametros.Add(new Parametro("@DIRECCION", DbType.String, ""));
        Parametros.Add(new Parametro("@FONO", DbType.Int32, 0));
        Parametros.Add(new Parametro("@IDROL", DbType.Int32, 0));

        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_Usuario", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string rut = item["rut"].ToString();
                string email = item["email"].ToString();
                string nombre = item["nombre"].ToString();
                string apellidoPaterno = item["apellidoPaterno"].ToString();
                string apellidoMaterno = item["apellidoMaterno"].ToString();
                string direccion = item["direccion"].ToString();
                string fono = item["fono"].ToString();
                int activo = Convert.ToInt32(item["activo"]);
                int rol = Convert.ToInt32(item["rol"]);

                dt.Rows.Add(id, rut, email, nombre, apellidoPaterno, apellidoMaterno, direccion, fono, activo, rol);
                mensajes.Add(new { id = id, rut = rut, email = email, nombre = nombre, apellidoPaterno = apellidoPaterno, apellidoMaterno = apellidoMaterno, direccion = direccion, fono = fono, activo = activo, rol = rol});
            }
        }
    }

    private static void procesaUsuarios(ArrayList mensajes, DataTable dt)
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 2));//1=con fechas en el sp
        Parametros.Add(new Parametro("@ID", DbType.Int32, 0));
        Parametros.Add(new Parametro("@RUT", DbType.String, ""));
        Parametros.Add(new Parametro("@EMAIL", DbType.String, ""));
        Parametros.Add(new Parametro("@NOMBRE", DbType.String, ""));
        Parametros.Add(new Parametro("@APELLIDOPATERNO", DbType.String, ""));
        Parametros.Add(new Parametro("@APELLIDOMATERNO", DbType.String, 1));
        Parametros.Add(new Parametro("@CONTRASENA", DbType.String, ""));
        Parametros.Add(new Parametro("@DIRECCION", DbType.String, ""));
        Parametros.Add(new Parametro("@FONO", DbType.Int32, 0));
        Parametros.Add(new Parametro("@IDROL", DbType.Int32, 0));

        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_Usuario", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string rut = item["Rut"].ToString();
                string nombre = item["Nombre"].ToString();
                string email = item["Email"].ToString();
                string activo = "";

                if(Convert.ToInt32(item["Activo"]) == 1)
                {
                    activo = "Activa";
                }
                else
                {
                    activo = "Desactivada";
                }

                dt.Rows.Add(id, rut, nombre, email, activo);
                mensajes.Add(new {id = id, rut = rut, nombre = nombre, email = email, activo = activo});
            }
        }
    }

    [WebMethod]
    public static bool nuevoUsuario(string nombre, string apellidoPaterno, 
        string apellidoMaterno, string email, string direccion, string fono, 
        string password, string rut, int perfil)
    {
        bool resultado = true;

        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.String, 1));
        Parametros.Add(new Parametro("@ID", DbType.Int32, 0));
        Parametros.Add(new Parametro("@RUT", DbType.String, rut));
        Parametros.Add(new Parametro("@EMAIL", DbType.String, email));
        Parametros.Add(new Parametro("@NOMBRE", DbType.String, nombre));
        Parametros.Add(new Parametro("@APELLIDOPATERNO", DbType.String, apellidoPaterno));
        Parametros.Add(new Parametro("@APELLIDOMATERNO", DbType.String, apellidoMaterno));
        Parametros.Add(new Parametro("@CONTRASENA", DbType.String, password));
        Parametros.Add(new Parametro("@DIRECCION", DbType.String, direccion));
        Parametros.Add(new Parametro("@FONO", DbType.String, fono));
        Parametros.Add(new Parametro("@IDROL", DbType.Int32, perfil));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_Usuario", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(item["RESULTADO"]) == 1)
                {
                    resultado = true;
                }
            }
        }

        return resultado;
    }

    [WebMethod]
    public static bool resetearPassword(int id_usuario)
    {
        bool resultado = false;

        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.String, id_usuario));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_RESETEARPASSWORD", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(item["RESULTADO"]) == 1)
                {
                    resultado = true;
                }
            }
        }

        return resultado;
    }

    [WebMethod]
    public static bool actualizarUsuario(int id, string nombre, string apellidoPaterno,
        string apellidoMaterno, string rut, string email, string direccion, string fono,
        string perfil, string estado)
    {
        bool resultado = true;

        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID", DbType.Int32, id));
        Parametros.Add(new Parametro("@RUT", DbType.String, rut));
        Parametros.Add(new Parametro("@EMAIL", DbType.String, email));
        Parametros.Add(new Parametro("@NOMBRE", DbType.String, nombre));
        Parametros.Add(new Parametro("@APELLIDOPATERNO", DbType.String, apellidoPaterno));
        Parametros.Add(new Parametro("@APELLIDOMATERNO", DbType.String, apellidoMaterno));
        Parametros.Add(new Parametro("@DIRECCION", DbType.String, direccion));
        if(fono == "")
        {
            fono = "0";
        }
        Parametros.Add(new Parametro("@FONO", DbType.Int32, Convert.ToInt32(fono)));
        Parametros.Add(new Parametro("@IDROL", DbType.Int32, Convert.ToInt32(perfil)));
        Parametros.Add(new Parametro("@ACTIVO", DbType.Int32, Convert.ToInt32(estado)));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ACTUALIZARDATOSUSUARIO", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if (Convert.ToInt32(item["RESULTADO"]) == 1)
                {
                    resultado = true;
                }
            }
        }

        return resultado;
    }
}