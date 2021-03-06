﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

    public DataSet obtenerTodos()
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 2));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_CONSULTAPAGINAS", ConfigurationManager.AppSettings["Sistema"]);
        return ds;
    }

    public DataSet obtenerTodoPorIDPagina(Tab_pagina pagina)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_PAGINA", DbType.Int32, pagina.Id_pagina));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_TAB_PAGINA_obtenerTodoPorIDPagina", ConfigurationManager.AppSettings["Sistema"]);
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

    public bool crearPagina(Tab_pagina pagina)
    {
        bool resultado = false;

        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_InsertarNuevaPagina", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@Menu", SqlDbType.VarChar);
        cmd.Parameters["@Menu"].Value = pagina.Menu;
        cmd.Parameters.Add("@URL", SqlDbType.VarChar);
        cmd.Parameters["@URL"].Value = pagina.Url;
        cmd.Parameters.Add("@Class", SqlDbType.VarChar);
        cmd.Parameters["@Class"].Value = pagina.Clases;
        cmd.Parameters.Add("@Submenu", SqlDbType.VarChar);
        cmd.Parameters["@Submenu"].Value = pagina.Submenu;

        cnn.Open();
        int cantidad = Convert.ToInt32(cmd.ExecuteNonQuery());
        cnn.Close();

        if (cantidad >= 1)
        {
            resultado = true;
        }

        return resultado;
    }

    public bool actualizarPagina(Tab_pagina pagina)
    {
        bool resultado = false;

        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_ActualizarPagina", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@id_pagina", SqlDbType.Int);
        cmd.Parameters["@id_pagina"].Value = pagina.Id_pagina;
        cmd.Parameters.Add("@Menu", SqlDbType.VarChar);
        cmd.Parameters["@Menu"].Value = pagina.Menu;
        cmd.Parameters.Add("@URL", SqlDbType.VarChar);
        cmd.Parameters["@URL"].Value = pagina.Url;
        cmd.Parameters.Add("@activo", SqlDbType.Int);
        cmd.Parameters["@activo"].Value = pagina.Activo;
        cmd.Parameters.Add("@Class", SqlDbType.VarChar);
        cmd.Parameters["@Class"].Value = pagina.Clases;
        cmd.Parameters.Add("@Submenu", SqlDbType.VarChar);
        cmd.Parameters["@Submenu"].Value = pagina.Submenu;

        cnn.Open();
        int cantidad = Convert.ToInt32(cmd.ExecuteNonQuery());
        cnn.Close();

        if (cantidad >= 1)
        {
            resultado = true;
        }

        return resultado;
    }
}