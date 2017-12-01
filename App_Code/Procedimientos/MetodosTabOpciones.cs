using System;
using System.Data.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Data;
using System.Web.Configuration;

/// <summary>
/// Descripción breve de MetodosTabOpciones
/// </summary>
public class MetodosTabOpciones
{
    public MetodosTabOpciones()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataSet obtenerOpciones(Tab_opciones opciones)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@id_usuario", DbType.Int32, opciones.Id_usuario));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_Opciones_ObtenerTodo", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }
}