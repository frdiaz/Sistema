using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MetodosTabSocios
/// </summary>
public class MetodosTabSocios
{
    public MetodosTabSocios()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataSet obtenerTodos()
    {
        DataSet ds = new DataSet();

        ds = SqlQuery.ObtieneDataSet("SP_ObtenerTodosSocios", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet obtenerPorID(Tab_socios socios)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID", DbType.Int32, socios.Id_socio));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ObtenerSocioPorID", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }
}