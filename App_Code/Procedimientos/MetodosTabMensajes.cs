using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

/// <summary>
/// Descripción breve de MetodosTabMensajes
/// </summary>
public class MetodosTabMensajes
{
    public MetodosTabMensajes()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataSet nuevoMensaje(Tab_mensajes mensaje)
    {
        DataSet ds = new DataSet();

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_ACCION", DbType.String, 1));
        Parametros.Add(new Parametro("@MENSAJE", DbType.String, mensaje.Mensaje));
        
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_EditarMensajesDiarios", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet mensajesDisponibles()
    {
        DataSet ds = new DataSet();

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 2));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaMensajes", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet mensajesEnviados()
    {
        DataSet ds = new DataSet();

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 3));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaMensajes", ConfigurationManager.AppSettings["Sistema"]);
        return ds;
    }

    public DataSet obtenerMensajeAleatorio()
    {
        DataSet ds = new DataSet();

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_EnviarMensajeDiario", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet obtener20UltimosMensajesEnviados()
    {
        DataSet ds = new DataSet();

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));//1=con fechas en el sp
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaMensajes", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }
}