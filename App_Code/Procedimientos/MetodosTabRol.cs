using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Tab_rol_metodos
/// </summary>
public class MetodosTabRol
{
    public MetodosTabRol()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataSet obtenerPerfiles()
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaPerfiles", ConfigurationManager.AppSettings["Sistema"]);
        
        return ds;
    }
}