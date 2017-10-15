using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

    public bool crearSocio(Tab_socios socios)
    {
        bool resultado = false;
        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_InsertarNuevoSocio", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@Rut", SqlDbType.VarChar);
        cmd.Parameters["@Rut"].Value = socios.Rut;
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
        cmd.Parameters["@Nombre"].Value = socios.Nombre;
        cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar);
        cmd.Parameters["@ApellidoPaterno"].Value = socios.ApellidoPaterno;
        cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar);
        cmd.Parameters["@ApellidoMaterno"].Value = socios.ApellidoMaterno;
        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
        cmd.Parameters["@FechaNacimiento"].Value = socios.FechaNacimiento;
        cmd.Parameters.Add("@Sexo", SqlDbType.Bit);
        cmd.Parameters["@Sexo"].Value = socios.Sexo;
        cmd.Parameters.Add("@Fono", SqlDbType.Int);
        cmd.Parameters["@Fono"].Value = socios.Fono;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar);
        cmd.Parameters["@Email"].Value = socios.Email;

        cnn.Open();
        int cantidad = Convert.ToInt32(cmd.ExecuteNonQuery());
        cnn.Close();

        if (cantidad >= 1)
        {
            resultado = true;
        }

        return resultado;
    }

    public bool actualizarSocio(Tab_socios socios)
    {
        bool resultado = false;
        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_ActualizarSocio", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ID", SqlDbType.Int);
        cmd.Parameters["@ID"].Value = socios.Id_socio;
        cmd.Parameters.Add("@Rut", SqlDbType.VarChar);
        cmd.Parameters["@Rut"].Value = socios.Rut;
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
        cmd.Parameters["@Nombre"].Value = socios.Nombre;
        cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar);
        cmd.Parameters["@ApellidoPaterno"].Value = socios.ApellidoPaterno;
        cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar);
        cmd.Parameters["@ApellidoMaterno"].Value = socios.ApellidoMaterno;
        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
        cmd.Parameters["@FechaNacimiento"].Value = socios.FechaNacimiento;
        cmd.Parameters.Add("@Sexo", SqlDbType.Bit);
        cmd.Parameters["@Sexo"].Value = socios.Sexo;
        cmd.Parameters.Add("@Fono", SqlDbType.Int);
        cmd.Parameters["@Fono"].Value = socios.Fono;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar);
        cmd.Parameters["@Email"].Value = socios.Email;

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


//public static bool insertar()
//{
//    bool resultado = false;
//    SqlConnection cnn = null;
//    SqlCommand cmd = null;

//    cnn = new SqlConnection(ConfigurationManager.AppSettings["prueba"]);
//    cmd = new SqlCommand("insertar", cnn);
//    cmd.CommandType = CommandType.StoredProcedure;

//    cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
//    cmd.Parameters["@nombre"].Value = "FrancisaDAdco";

//    cnn.Open();
//    int cantidad = Convert.ToInt32(cmd.ExecuteNonQuery());
//    cnn.Close();

//    if (cantidad >= 1)
//    {
//        resultado = true;
//    }

//    return resultado;
//}