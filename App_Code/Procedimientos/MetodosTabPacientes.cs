using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class MetodosTabPacientes
{
    public MetodosTabPacientes()
    {

    }

    public DataSet obtenerTodos()
    {
        DataSet ds = new DataSet();

        ds = SqlQuery.ObtieneDataSet("SP_ObtenerTodosPacientes", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet obtenerPorID(Tab_pacientes pacientes)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID", DbType.Int32, pacientes.Id_paciente));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ObtenerPacientePorID", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public bool crearPaciente(Tab_pacientes pacientes)
    {
        bool resultado = false;
        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_InsertarNuevoPaciente", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@Rut", SqlDbType.VarChar);
        cmd.Parameters["@Rut"].Value = pacientes.Rut;
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
        cmd.Parameters["@Nombre"].Value = pacientes.Nombre;
        cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar);
        cmd.Parameters["@ApellidoPaterno"].Value = pacientes.ApellidoPaterno;
        cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar);
        cmd.Parameters["@ApellidoMaterno"].Value = pacientes.ApellidoMaterno;
        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
        cmd.Parameters["@FechaNacimiento"].Value = pacientes.FechaNacimiento;
        cmd.Parameters.Add("@Sexo", SqlDbType.Bit);
        cmd.Parameters["@Sexo"].Value = pacientes.Sexo;
        cmd.Parameters.Add("@Fono", SqlDbType.Int);
        cmd.Parameters["@Fono"].Value = pacientes.Fono;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar);
        cmd.Parameters["@Email"].Value = pacientes.Email;

        cnn.Open();
        int cantidad = Convert.ToInt32(cmd.ExecuteNonQuery());
        cnn.Close();

        if (cantidad >= 1)
        {
            resultado = true;
        }

        return resultado;
    }

    public bool actualizarSocio(Tab_pacientes pacientes)
    {
        bool resultado = false;
        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_ActualizarPaciente", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ID", SqlDbType.Int);
        cmd.Parameters["@ID"].Value = pacientes.Id_paciente;
        cmd.Parameters.Add("@Rut", SqlDbType.VarChar);
        cmd.Parameters["@Rut"].Value = pacientes.Rut;
        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar);
        cmd.Parameters["@Nombre"].Value = pacientes.Nombre;
        cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar);
        cmd.Parameters["@ApellidoPaterno"].Value = pacientes.ApellidoPaterno;
        cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar);
        cmd.Parameters["@ApellidoMaterno"].Value = pacientes.ApellidoMaterno;
        cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
        cmd.Parameters["@FechaNacimiento"].Value = pacientes.FechaNacimiento;
        cmd.Parameters.Add("@Sexo", SqlDbType.Bit);
        cmd.Parameters["@Sexo"].Value = pacientes.Sexo;
        cmd.Parameters.Add("@Fono", SqlDbType.Int);
        cmd.Parameters["@Fono"].Value = pacientes.Fono;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar);
        cmd.Parameters["@Email"].Value = pacientes.Email;

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