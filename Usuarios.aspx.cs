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
        MetodosTabRol metodosRol = new MetodosTabRol();
        DataSet ds = new DataSet();

        ds = metodosRol.obtenerPerfiles();

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

        obtenerUsuarios(mensajes, dt);

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
        DataSet ds = new DataSet();
        MetodosTabUsuario metodosUsuarios = new MetodosTabUsuario();
        Tab_usuario usuarios = new Tab_usuario();

        usuarios.Id_usuario = id_usuario;

        ds = metodosUsuarios.obtenerUsuario(usuarios);

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

    private static void obtenerUsuarios(ArrayList mensajes, DataTable dt)
    {
        DataSet ds = new DataSet();
        MetodosTabUsuario metodosUsuarios = new MetodosTabUsuario();
        ds = metodosUsuarios.obtenerUsuarios();

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id_usuario"]);
                string rut = item["rut"].ToString();
                string nombre = item["nombre"].ToString() + " " + item["apellidoPaterno"].ToString() + " " + item["apellidoPaterno"].ToString();
                string email = item["email"].ToString();
                string activo = "";

                if(Convert.ToInt32(item["activo"]) == 1)
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

        MetodosTabUsuario metodosUsuarios = new MetodosTabUsuario();
        Tab_usuario usuarios = new Tab_usuario();

        usuarios.Nombre = nombre;
        usuarios.ApellidoPaterno = apellidoPaterno;
        usuarios.ApellidoMaterno = apellidoMaterno;
        usuarios.Email = email;
        usuarios.Direccion = direccion;
        usuarios.Fono = Convert.ToInt32(fono == "" ? fono = "0": fono);
        usuarios.Contrasena = password;
        usuarios.Rut = rut;
        usuarios.Id_rol = perfil;

        ds = metodosUsuarios.nuevoUsuario(usuarios);
       
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
        MetodosTabUsuario metodosUsuarios = new MetodosTabUsuario();
        Tab_usuario usuarios = new Tab_usuario();

        usuarios.Id_usuario = id_usuario;

        ds = metodosUsuarios.resetearPassword(usuarios);

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
        MetodosTabUsuario metodosUsuarios = new MetodosTabUsuario();
        Tab_usuario usuarios = new Tab_usuario();

        usuarios.Id_usuario = id;
        usuarios.Nombre = nombre;
        usuarios.ApellidoPaterno = apellidoPaterno;
        usuarios.ApellidoMaterno = apellidoMaterno;
        usuarios.Rut = rut;
        usuarios.Email = email;
        usuarios.Direccion = direccion;
        usuarios.Fono = Convert.ToInt32(fono);
        usuarios.Id_rol = Convert.ToInt32(perfil);
        usuarios.Activo = Convert.ToInt32(estado);

        DataSet ds = new DataSet();

        ds = metodosUsuarios.actualizarUsuario(usuarios);
        
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