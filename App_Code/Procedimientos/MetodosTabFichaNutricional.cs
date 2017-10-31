using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MetodosTabFichaNutricional
/// </summary>
public class MetodosTabFichaNutricional
{
    public MetodosTabFichaNutricional()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public bool insertarFicha(Tab_fichaNutricional fichaNutricional)
    {
        bool resultado = false;
        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_FichaNutricionalInsertar", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ID_Paciente", SqlDbType.Int);
        cmd.Parameters["@ID_Paciente"].Value = fichaNutricional.Id_paciente;
        cmd.Parameters.Add("@FechaRegistro", SqlDbType.Date);
        cmd.Parameters["@FechaRegistro"].Value = fichaNutricional.FechaRegistro.ToShortDateString();
        cmd.Parameters.Add("@Peso", SqlDbType.Float);
        cmd.Parameters["@Peso"].Value = fichaNutricional.Peso;
        cmd.Parameters.Add("@Talla", SqlDbType.Float);
        cmd.Parameters["@Talla"].Value = fichaNutricional.Talla;
        cmd.Parameters.Add("@Cintura", SqlDbType.Float);
        cmd.Parameters["@Cintura"].Value = fichaNutricional.Cintura;
        cmd.Parameters.Add("@Alcohol", SqlDbType.Int);
        cmd.Parameters["@Alcohol"].Value = fichaNutricional.Alcohol;
        cmd.Parameters.Add("@Tabaco", SqlDbType.Int);
        cmd.Parameters["@Tabaco"].Value = fichaNutricional.Tabaco;
        cmd.Parameters.Add("@Anamnesis", SqlDbType.VarChar);
        cmd.Parameters["@Anamnesis"].Value = fichaNutricional.Anamnesis;
        cmd.Parameters.Add("@Diagnostico", SqlDbType.VarChar);
        cmd.Parameters["@Diagnostico"].Value = fichaNutricional.Diagnostico;
        cmd.Parameters.Add("@TipoConsulta", SqlDbType.Int);
        cmd.Parameters["@TipoConsulta"].Value = fichaNutricional.IdTipoConsulta;
        cmd.Parameters.Add("@IMC", SqlDbType.Float);
        cmd.Parameters["@IMC"].Value = fichaNutricional.IMC;
        cmd.Parameters.Add("@Indicaciones", SqlDbType.VarChar);
        cmd.Parameters["@Indicaciones"].Value = fichaNutricional.Indicaciones;

        cnn.Open();
        int cantidad = Convert.ToInt32(cmd.ExecuteNonQuery());
        cnn.Close();

        if (cantidad >= 1)
        {
            resultado = true;
        }

        return resultado;
    }

    public int obtenerIDFichaInsertada(Tab_fichaNutricional fichaNutricional)
    {
        DataSet ds = new DataSet();
        int ultimo = 0;
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@id_paciente", DbType.Int32, fichaNutricional.Id_paciente));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_FICHANUTRICIONAL_ULTIMAPORID", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ultimo = Convert.ToInt32(item["id"]);
            }
        }
        return ultimo;
    }

    public bool updateFicha(Tab_fichaNutricional fichaNutricional)
    {
        bool resultado = false;
        SqlConnection cnn = null;
        SqlCommand cmd = null;

        cnn = new SqlConnection(ConfigurationManager.AppSettings["Sistema"]);
        cmd = new SqlCommand("SP_FichaNutricionalUpdate", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ID", SqlDbType.Int);
        cmd.Parameters["@Id"].Value = fichaNutricional.Id;
        cmd.Parameters.Add("@Peso", SqlDbType.Float);
        cmd.Parameters["@Peso"].Value = fichaNutricional.Peso;
        cmd.Parameters.Add("@Talla", SqlDbType.Float);
        cmd.Parameters["@Talla"].Value = fichaNutricional.Talla;
        cmd.Parameters.Add("@Cintura", SqlDbType.Float);
        cmd.Parameters["@Cintura"].Value = fichaNutricional.Cintura;
        cmd.Parameters.Add("@Alcohol", SqlDbType.Int);
        cmd.Parameters["@Alcohol"].Value = fichaNutricional.Alcohol;
        cmd.Parameters.Add("@Tabaco", SqlDbType.Int);
        cmd.Parameters["@Tabaco"].Value = fichaNutricional.Tabaco;
        cmd.Parameters.Add("@Anamnesis", SqlDbType.VarChar);
        cmd.Parameters["@Anamnesis"].Value = fichaNutricional.Anamnesis;
        cmd.Parameters.Add("@Diagnostico", SqlDbType.VarChar);
        cmd.Parameters["@Diagnostico"].Value = fichaNutricional.Diagnostico;
        cmd.Parameters.Add("@TipoConsulta", SqlDbType.Int);
        cmd.Parameters["@TipoConsulta"].Value = fichaNutricional.IdTipoConsulta;
        cmd.Parameters.Add("@IMC", SqlDbType.Float);
        cmd.Parameters["@IMC"].Value = fichaNutricional.IMC;
        cmd.Parameters.Add("@Indicaciones", SqlDbType.VarChar);
        cmd.Parameters["@Indicaciones"].Value = fichaNutricional.Indicaciones;

        cnn.Open();
        int cantidad = Convert.ToInt32(cmd.ExecuteNonQuery());
        cnn.Close();

        if (cantidad >= 1)
        {
            resultado = true;
        }

        return resultado;
    }


    public DataSet obtenerFichasPorIDPaciente(Tab_pacientes pacientes)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_Paciente", DbType.Int32, pacientes.Id_paciente));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_FichaNutricionalObtenerPorIDPaciente", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet obtenerFichasPorIDFicha(Tab_fichaNutricional ficha)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_Ficha", DbType.Int32, ficha.Id));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_FichaNutricionalObtenerPorIDFicha", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }
}