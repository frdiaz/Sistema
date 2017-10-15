using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Socios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static ArrayList cargarTablaSocios()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Nombre", typeof(string));
        dt.Columns.Add("id", typeof(string));

        ArrayList mensajes = new ArrayList();

        obtenerSocios(mensajes, dt);

        HttpContext.Current.Session["Datatable"] = dt;

        return mensajes;
    }

    private static void obtenerSocios(ArrayList mensajes, DataTable dt)
    {
        DataSet ds = new DataSet();
        MetodosTabSocios metodosSocios = new MetodosTabSocios();
        ds = metodosSocios.obtenerTodos();

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id_socio"]);
                string nombre = item["nombre"].ToString() + " " + item["apellidoPaterno"].ToString() + " " + item["apellidoMaterno"].ToString();

                dt.Rows.Add(nombre, id);
                mensajes.Add(new { nombre = nombre, id = id });
            }
        }
    }

    [WebMethod]
    public static bool nuevoSocio(string rut, string nombre, string apellidoPaterno, string apellidoMaterno,
        string fechaNacimiento, string sexo, string email, string fono)
    {
        bool resultado = true;

        DataSet ds = new DataSet();

        MetodosTabSocios metodosSocios = new MetodosTabSocios();
        Tab_socios socios = new Tab_socios();

        socios.Rut = rut;
        socios.Nombre = nombre;
        socios.ApellidoPaterno = apellidoPaterno;
        socios.ApellidoMaterno = apellidoMaterno;
        socios.FechaNacimiento = Convert.ToDateTime(fechaNacimiento);
        socios.Sexo = Convert.ToInt32(sexo);
        socios.Email = email;
        socios.Fono = fono != "" ? Convert.ToInt32(fono) : 0;

        resultado = metodosSocios.crearSocio(socios);

        return resultado;
    }

    [WebMethod]
    public static ArrayList cargarEditarSocios(int id)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("id", typeof(Int32));
        dt.Columns.Add("Rut", typeof(string));
        dt.Columns.Add("Nombre", typeof(string));
        dt.Columns.Add("apellidoPaterno", typeof(string));
        dt.Columns.Add("apellidoMaterno", typeof(string));
        dt.Columns.Add("fechaNacimiento", typeof(string));
        dt.Columns.Add("sexo", typeof(string));
        dt.Columns.Add("fono", typeof(string));
        dt.Columns.Add("Email", typeof(string));

        ArrayList mensajes = new ArrayList();

        procesaEditarSocios(mensajes, dt, id);

        HttpContext.Current.Session["Datatable"] = dt;

        return mensajes;
    }

    private static void procesaEditarSocios(ArrayList mensajes, DataTable dt, int id_socio)
    {
        DataSet ds = new DataSet();
        MetodosTabSocios metodosSocios = new MetodosTabSocios();
        Tab_socios socios = new Tab_socios();
        socios.Id_socio = id_socio;
        ds = metodosSocios.obtenerPorID(socios);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id_socio"]);
                string rut = item["rut"].ToString();
                string nombre = item["nombre"].ToString();
                string apellidoPaterno = item["apellidoPaterno"].ToString();
                string apellidoMaterno = item["apellidoMaterno"].ToString();
                DateTime fecha = Convert.ToDateTime(item["fechaNacimiento"]);
                string fechaNacimiento = fecha.ToString("yyyy-MM-dd");
                string sessxo = item["sexo"].ToString();
                int sexo = item["sexo"].ToString() == "True" ? 1 : 0;
                string fono = item["fono"].ToString() != "0" ? item["fono"].ToString() : "";
                string email = item["email"].ToString();

                //CALCULA LA EDAD
                //int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1; 

                dt.Rows.Add(id, rut, nombre, apellidoPaterno, apellidoMaterno, fechaNacimiento, sexo, fono, email);
                mensajes.Add(new { id = id, rut = rut, nombre = nombre, apellidoPaterno = apellidoPaterno, apellidoMaterno = apellidoMaterno, fechaNacimiento = fechaNacimiento, sexo = sexo, fono = fono, email = email });
            }
        }
    }

    [WebMethod]
    public static bool actualizarSocio(string id, string rut, string nombre, string apellidoPaterno, string apellidoMaterno,
        string fechaNacimiento, string sexo, string email, string fono)
    {
        bool resultado = true;

        DataSet ds = new DataSet();

        MetodosTabSocios metodosSocios = new MetodosTabSocios();
        Tab_socios socios = new Tab_socios();

        socios.Id_socio = Convert.ToInt32(id);
        socios.Rut = rut;
        socios.Nombre = nombre;
        socios.ApellidoPaterno = apellidoPaterno;
        socios.ApellidoMaterno = apellidoMaterno;
        socios.FechaNacimiento = Convert.ToDateTime(fechaNacimiento);
        socios.Sexo = Convert.ToInt32(sexo);
        socios.Email = email;
        socios.Fono = fono != "" ? Convert.ToInt32(fono) : 0;

        resultado = metodosSocios.actualizarSocio(socios);

        return resultado;
    }
}