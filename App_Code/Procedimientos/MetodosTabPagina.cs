using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MetodosTabPagina
/// </summary>
public class MetodosTabPagina
{
    public MetodosTabPagina()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataSet obtenerEspecifico()
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_CONSULTAPAGINAS", ConfigurationManager.AppSettings["Sistema"]);
        return ds;
    }

    public DataSet consultaPerfiles()
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));

        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaPerfiles", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

}