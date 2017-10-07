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
        
        Tab_usuario usuarios = new Tab_usuario();
        MetodosTabUsuario metodosUsuario = new MetodosTabUsuario();
        DataSet ds = new DataSet();

        usuarios.Id_usuario = Convert.ToInt32(id_usuario);
        ds = metodosUsuario.obtenerDatosEspecificos(usuarios, 2);

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
        
        DataSet ds = new DataSet();
        Tab_usuario usuarios = new Tab_usuario();
        MetodosTabUsuario metodosUsuarios = new MetodosTabUsuario();

        usuarios.Contrasena = password;
        usuarios.Id_usuario = id_usuario;

        ds = metodosUsuarios.actualizarPassword(usuarios);

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
        Tab_usuario usuarios = new Tab_usuario();
        MetodosTabUsuario metodosUsuarios = new MetodosTabUsuario();
        DataSet ds = new DataSet();

        usuarios.Id_usuario = id_usuario;
        usuarios.Email = email;
        usuarios.Direccion = direccion;
        usuarios.Fono = Convert.ToInt32(fono);

        ds = metodosUsuarios.actualizarDatos(usuarios);

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