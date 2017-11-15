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

public partial class Pacientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static ArrayList cargarTablaPacientes()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Nombre", typeof(string));
        dt.Columns.Add("id", typeof(string));

        ArrayList mensajes = new ArrayList();

        obtenerPacientes(mensajes, dt);

        HttpContext.Current.Session["Datatable"] = dt;

        return mensajes;
    }

    private static void obtenerPacientes(ArrayList mensajes, DataTable dt)
    {
        DataSet ds = new DataSet();
        MetodosTabPacientes metodosPacientes = new MetodosTabPacientes();
        ds = metodosPacientes.obtenerTodos();

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id_paciente"]);
                string nombre = item["nombre"].ToString() + " " + item["apellidoPaterno"].ToString() + " " + item["apellidoMaterno"].ToString();

                dt.Rows.Add(nombre, id);
                mensajes.Add(new { nombre = nombre, id = id });
            }
        }
    }

    [WebMethod]
    public static bool nuevoPaciente(string rut, string nombre, string apellidoPaterno, string apellidoMaterno,
        string fechaNacimiento, string sexo, string email, string fono)
    {
        bool resultado = true;

        DataSet ds = new DataSet();

        MetodosTabPacientes metodosPacientes = new MetodosTabPacientes();
        Tab_pacientes pacientes = new Tab_pacientes();

        pacientes.Rut = rut;
        pacientes.Nombre = nombre;
        pacientes.ApellidoPaterno = apellidoPaterno;
        pacientes.ApellidoMaterno = apellidoMaterno;
        pacientes.FechaNacimiento = Convert.ToDateTime(fechaNacimiento);
        pacientes.Sexo = Convert.ToInt32(sexo);
        pacientes.Email = email;
        pacientes.Fono = fono != "" ? Convert.ToInt32(fono) : 0;

        resultado = metodosPacientes.crearPaciente(pacientes);

        return resultado;
    }

    [WebMethod]
    public static ArrayList cargarEditarPacientes(int id)
    {
        ArrayList mensajes = new ArrayList();

        procesaEditarPacientes(mensajes, id);
        
        return mensajes;
    }

    private static void procesaEditarPacientes(ArrayList mensajes, int id_socio)
    {
        DataSet ds = new DataSet();
        MetodosTabPacientes metodosPacientes = new MetodosTabPacientes();
        Tab_pacientes pacientes = new Tab_pacientes();
        pacientes.Id_paciente = id_socio;
        ds = metodosPacientes.obtenerPorID(pacientes);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id_paciente"]);
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
                string edad = Convert.ToString(DateTime.Today.AddTicks(-fecha.Ticks).Year - 1);

                //CALCULA LA EDAD
                //int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1; 
                mensajes.Add(new { id = id, rut = rut, nombre = nombre, apellidoPaterno = apellidoPaterno, apellidoMaterno = apellidoMaterno, fechaNacimiento = fechaNacimiento, sexo = sexo, fono = fono, email = email, edad = edad });
            }
        }
    }

    [WebMethod]
    public static bool actualizarPaciente(string id, string rut, string nombre, string apellidoPaterno, string apellidoMaterno,
        string fechaNacimiento, string sexo, string email, string fono)
    {
        bool resultado = true;

        DataSet ds = new DataSet();

        MetodosTabPacientes metodosPacientes = new MetodosTabPacientes();
        Tab_pacientes pacientes = new Tab_pacientes();

        pacientes.Id_paciente = Convert.ToInt32(id);
        pacientes.Rut = rut;
        pacientes.Nombre = nombre;
        pacientes.ApellidoPaterno = apellidoPaterno;
        pacientes.ApellidoMaterno = apellidoMaterno;
        pacientes.FechaNacimiento = Convert.ToDateTime(fechaNacimiento);
        pacientes.Sexo = Convert.ToInt32(sexo);
        pacientes.Email = email;
        pacientes.Fono = fono != "" ? Convert.ToInt32(fono) : 0;

        resultado = metodosPacientes.actualizarSocio(pacientes);

        return resultado;
    }

    [WebMethod]
    public static int insertarFichaNutricional(string id, string id_ficha, string peso, string talla, string cintura, string imc, string alcohol,
        string tabaco, string tipoConsulta, string anamnesis, string diagnostico, string indicaciones)
    {
        bool resultado;
        int ultimo = -1;

        MetodosTabFichaNutricional metodosFichaNutricional = new MetodosTabFichaNutricional();
        Tab_fichaNutricional fichaNutricional = new Tab_fichaNutricional();

        fichaNutricional.Id = Convert.ToInt32(id_ficha);
        fichaNutricional.Id_paciente = Convert.ToInt32(id);
        fichaNutricional.Peso = Convert.ToSingle(peso.Replace(".", ","));
        fichaNutricional.Talla = Convert.ToSingle(talla.Replace(".", ","));
        fichaNutricional.Cintura = Convert.ToSingle(cintura.Replace(".", ","));
        fichaNutricional.IMC = Convert.ToSingle(imc.Replace(".", ","));
        fichaNutricional.Alcohol = Convert.ToInt32(alcohol);
        fichaNutricional.Tabaco = Convert.ToInt32(tabaco);
        fichaNutricional.IdTipoConsulta = Convert.ToInt32(tipoConsulta);
        fichaNutricional.Anamnesis = anamnesis;
        fichaNutricional.Diagnostico = diagnostico;
        fichaNutricional.FechaRegistro = DateTime.Now;
        fichaNutricional.Indicaciones = indicaciones;

        if(fichaNutricional.Id > 0)
        {
            resultado = metodosFichaNutricional.updateFicha(fichaNutricional);
            ultimo = fichaNutricional.Id;
        }
        else
        {
            resultado = metodosFichaNutricional.insertarFicha(fichaNutricional);
            if(resultado)
            {
                ultimo = metodosFichaNutricional.obtenerIDFichaInsertada(fichaNutricional);
            }
        }

        return ultimo;
    }

    [WebMethod]
    public static bool actualizarFichaAnterior(string id_ficha, string peso, string talla, string cintura, string imc, string alcohol,
        string tabaco, string tipoConsulta, string anamnesis, string diagnostico, string indicaciones)
    {
        bool resultado = true;
        MetodosTabFichaNutricional metodosFichaNutricional = new MetodosTabFichaNutricional();
        Tab_fichaNutricional fichaNutricional = new Tab_fichaNutricional();

        fichaNutricional.Id = Convert.ToInt32(id_ficha);
        fichaNutricional.Peso = Convert.ToSingle(peso.Replace(".", ","));
        fichaNutricional.Talla = Convert.ToSingle(talla.Replace(".", ","));
        fichaNutricional.Cintura = Convert.ToSingle(cintura.Replace(".", ","));
        fichaNutricional.IMC = Convert.ToSingle(imc.Replace(".", ","));
        fichaNutricional.Alcohol = Convert.ToInt32(alcohol);
        fichaNutricional.Tabaco = Convert.ToInt32(tabaco);
        fichaNutricional.IdTipoConsulta = Convert.ToInt32(tipoConsulta);
        fichaNutricional.Anamnesis = anamnesis;
        fichaNutricional.Diagnostico = diagnostico;
        fichaNutricional.FechaRegistro = DateTime.Now;
        fichaNutricional.Indicaciones = indicaciones;

        resultado = metodosFichaNutricional.updateFicha(fichaNutricional);

        return resultado;
    }

    [WebMethod]
    public static ArrayList cargarTablaFichaResumenPacientes(string id_paciente)
    {
        ArrayList mensajes = new ArrayList();

        obtenerResumenFichaPacientes(mensajes, id_paciente);

        return mensajes;
    }

    private static void obtenerResumenFichaPacientes(ArrayList mensajes, string id_paciente)
    {
        DataSet ds = new DataSet();
        MetodosTabFichaNutricional fichaNutricional = new MetodosTabFichaNutricional();
        Tab_pacientes pacientes = new Tab_pacientes();
        pacientes.Id_paciente = Convert.ToInt32(id_paciente);

        ds = fichaNutricional.obtenerFichasPorIDPaciente(pacientes);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                string id = item["id"].ToString();
                int idPaciente = Convert.ToInt32(item["id_paciente"]);
                double peso = Convert.ToDouble(item["peso"]);
                double imc = Convert.ToDouble(item["imc"]);

                DateTime fechaExtraida = Convert.ToDateTime(item["fechaRegistro"]);
                string fecha = fechaExtraida.ToString("yyyy/MM/dd");

                mensajes.Add(new { ID = id, Fecha = fecha, Peso = peso, IMC = imc });
            }
        }
    }

    [WebMethod]
    public static int diagnostico()
    {
        int resultado = 0;

        return resultado;
    }

    [WebMethod]
    public static ArrayList cargarFichaResumen(string id_Ficha)
    {
        ArrayList mensajes = new ArrayList();

        procesaFichaResumen(mensajes, id_Ficha);

        return mensajes;
    }

    private static void procesaFichaResumen(ArrayList mensajes, string id_ficha)
    {
        DataSet ds = new DataSet();

        MetodosTabFichaNutricional metodosFichaNutricional = new MetodosTabFichaNutricional();
        Tab_fichaNutricional fichaNutricional = new Tab_fichaNutricional();

        fichaNutricional.Id = Convert.ToInt32(id_ficha);

        ds = metodosFichaNutricional.obtenerFichasPorIDFicha(fichaNutricional);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string fechaRegistro = item["fechaRegistro"].ToString();
                string peso = item["peso"].ToString().Replace(",",".");
                string talla = item["talla"].ToString().Replace(",", ".");
                string cintura = item["cintura"].ToString().Replace(",", ".");
                string imc = item["imc"].ToString();
                string alcohol = item["alcohol"].ToString();
                string tabaco = item["tabaco"].ToString();
                string idTipoConsulta = item["idTipoConsulta"].ToString();
                string anamnesis = item["anamnesis"].ToString();
                string diagnostico = item["diagnostico"].ToString();
                string indicaciones = item["indicaciones"].ToString();

                mensajes.Add(new
                {
                    id = id,
                    fechaRegistro = fechaRegistro,
                    peso = peso,
                    talla = talla,
                    cintura = cintura,
                    imc = imc,
                    alcohol = alcohol,
                    tabaco = tabaco,
                    idTipoConsulta = idTipoConsulta,
                    anamnesis = anamnesis,
                    diagnostico = diagnostico,
                    indicaciones = indicaciones
                });
            }
        }
    }

    [WebMethod]
    public static ArrayList cargarTipoConsulta()
    {
        ArrayList tipoConsulta = new ArrayList();

        procesaTipoConsulta(tipoConsulta);
        return tipoConsulta;
    }

    public static void procesaTipoConsulta(ArrayList tipoConsulta)
    {
        MetodosTabTipoConsulta metodosTipoConsulta = new MetodosTabTipoConsulta();
        DataSet ds = new DataSet();

        ds = metodosTipoConsulta.obtenerTipoConsulta();

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string nombre = item["nombre"].ToString();

                tipoConsulta.Add(new { id = id, nombre = nombre });
            }
        }
    }

    [WebMethod]
    public static ArrayList cargarDatosHistoricos(string id_paciente)
    {
        ArrayList Datos = new ArrayList();
        DataSet ds = new DataSet();

        MetodosTabFichaNutricional metodosFichaNutricional = new MetodosTabFichaNutricional();
        Tab_pacientes pacientes = new Tab_pacientes();

        pacientes.Id_paciente = Convert.ToInt32(id_paciente);

        ds = metodosFichaNutricional.obtenerFichasPorIDPaciente(pacientes);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                string fecha = item["fechaRegistro"].ToString();
                decimal peso = Convert.ToDecimal(item["peso"]);
                string peso2 = peso.ToString("N2");

                decimal talla = Convert.ToDecimal(item["talla"]);
                string talla2 = talla.ToString("N2");

                decimal cintura = Convert.ToDecimal(item["cintura"]);
                string cintura2 = cintura.ToString("N2");

                decimal imc = Convert.ToDecimal(item["imc"]);
                string imc2 = imc.ToString("N2");

                Datos.Add(new { fecha = fecha, peso = peso2, talla = talla2, cintura = cintura2, imc = imc2 });
            }
        }

        return Datos;
    }
}