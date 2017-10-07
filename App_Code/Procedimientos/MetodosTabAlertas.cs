using System;
using System.Data.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Data;
using System.Web.Configuration;
/// <summary>
/// Descripción breve de MetodosTabAlertas
/// </summary>
public class MetodosTabAlertas
{
    public MetodosTabAlertas()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public DataSet obtenerAlertaPorID(Tab_alertas alertas)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@numeroError", DbType.Int32, alertas.Id_alerta));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_MensajesError", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }
}