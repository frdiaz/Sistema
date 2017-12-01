using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

    public bool updateRol(Tab_rol rol, string paginas)
    {
        bool resultado = false;
        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_RolPaginaUpdate", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@id_rol", SqlDbType.Int);
        cmd.Parameters["@id_rol"].Value = rol.Id_rol;
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters["@nombre"].Value = rol.Nombre;
        cmd.Parameters.Add("@activo", SqlDbType.Int);
        cmd.Parameters["@activo"].Value = rol.Activo;
        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);
        cmd.Parameters["@descripcion"].Value = rol.Descripcion;
        cmd.Parameters.Add("@paginas", SqlDbType.VarChar);
        cmd.Parameters["@paginas"].Value = paginas;

        cnn.Open();
        int cantidad = Convert.ToInt32(cmd.ExecuteNonQuery());
        cnn.Close();

        if (cantidad >= 1)
        {
            resultado = true;
        }

        return resultado;
    }

    public bool nuevoPerfil(Tab_rol rol, string paginas)
    {
        bool resultado = false;
        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_RolPaginaNuevo", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
        cmd.Parameters["@nombre"].Value = rol.Nombre;
        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);
        cmd.Parameters["@descripcion"].Value = rol.Descripcion;
        cmd.Parameters.Add("@paginas", SqlDbType.VarChar);
        cmd.Parameters["@paginas"].Value = paginas;

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