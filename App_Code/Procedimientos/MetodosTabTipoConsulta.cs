using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MetodosTabTipoConsulta
/// </summary>
public class MetodosTabTipoConsulta
{
    public MetodosTabTipoConsulta()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataSet obtenerTipoConsulta()
    {
        DataSet ds = new DataSet();

        ds = SqlQuery.ObtieneDataSet("SP_TipoConsultaObtenerTodos", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }
}