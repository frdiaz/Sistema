using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MetodosTabRolPagina
/// </summary>
public class MetodosTabRolPagina
{
    public MetodosTabRolPagina()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataSet obtenerTodoPorID_Perfil(Tab_rol rol)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@id_rol", DbType.Int32, rol.Id_rol));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaPerfilesPorIDRol", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet actualizarPerfil(Tab_rolpagina rolPagina)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@id_rolPagina", DbType.Int32, rolPagina.Id_rolPagina));
        Parametros.Add(new Parametro("@id_rol", DbType.Int32, rolPagina.Id_rol));
        Parametros.Add(new Parametro("@id_pagina", DbType.String, rolPagina.Id_pagina));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ACTUALIZARDATOSUSUARIO", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    //public bool actualizarPerfil(Tab_rol rol)
    //{
    //    bool resultado = false;
    //    SqlConnection cnn = null;
    //    SqlCommand cmd = null;

    //    cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
    //    cmd = new SqlCommand("SP_actualizarPerfil", cnn);
    //    cmd.CommandType = CommandType.StoredProcedure;

    //    cmd.Parameters.Add("@id_rolPagina", SqlDbType.VarChar);
    //    cmd.Parameters["@id_rolPagina"].Value = ;
        
    //    cnn.Open();
    //    int cantidad = Convert.ToInt32(cmd.ExecuteNonQuery());
    //    cnn.Close();

    //    if (cantidad >= 1)
    //    {
    //        resultado = true;
    //    }

    //    return resultado;
    //}
}