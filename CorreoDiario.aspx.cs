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
using System.Collections;
using System.Web.Script.Services;
using System.Web;

public partial class pages_CorreoDiario : System.Web.UI.Page
{
    private static object httpContext;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod]
    public static bool nuevoMensaje(string mensaje)
    {
        bool resultado = false;
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_ACCION", DbType.String, 1));
        Parametros.Add(new Parametro("@MENSAJE", DbType.String, mensaje));

        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_EditarMensajesDiarios", ConfigurationManager.AppSettings["Sistema"]);

        if(ds != null)
        {
            foreach(DataRow item in ds.Tables[0].Rows)
            {
                if(Convert.ToInt32(item["RESULTADO"]) == 1)
                {
                    resultado = true;
                }
            }
        }
        return resultado;
    }

    [WebMethod]
    public static int mensajesDisponibles()
    {
        int resultado = 0;

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 2));
        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaMensajes", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                resultado = Convert.ToInt32(item["activo"]);
            }
        }
        return resultado;
    }

    [WebMethod]
    public static int mensajesEnviados()
    {
        int resultado = 0;
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 3));
        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaMensajes", ConfigurationManager.AppSettings["Sistema"]);

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                resultado = Convert.ToInt32(item["enviado"]);
            }
        }
        return resultado;
    }

    [WebMethod]
    public static bool enviarMensaje()
    {
        bool resultado = true;
        try
        {
            List<Parametro> Parametros = new List<Parametro>();
            Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));

            DataSet ds = new DataSet();
            ds = SqlQuery.ObtieneDataSet(Parametros, "SP_EnviarMensajeDiario", ConfigurationManager.AppSettings["Sistema"]);

            if (ds != null)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp-mail.outlook.com");
                    mail.From = new MailAddress("f.diaz@live.com", "Francisco Diaz", Encoding.UTF8);
                    mail.Subject = "Mensaje";
                    mail.To.Add("bess.salazar@gmail.com");
                    mail.Body = item["MENSAJE"].ToString() + "\n\nFrancisco Diaz (Tu Enamorado).";
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("f.diaz@live.com", "Outlook1256");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
            }
        }
        catch (Exception)
        {
            resultado = false;
        }
        return resultado;
    }

    [WebMethod]
    public static ArrayList listaMensajesEnviados()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Fecha", typeof(string));
        dt.Columns.Add("Hora", typeof(string));
        dt.Columns.Add("Mensaje", typeof(string));

        ArrayList mensajes = new ArrayList();

        procesaMensajes(mensajes, dt);

        HttpContext.Current.Session["Datatable"] = dt;

        return mensajes;
    }

    private static void procesaMensajes(ArrayList mensajes,  DataTable dt)
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 1));//1=con fechas en el sp
        DataSet ds = new DataSet();
        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ConsultaMensajes", ConfigurationManager.AppSettings["Sistema"]);

        if(ds != null)
        {
            foreach(DataRow item in ds.Tables[0].Rows)
            {
                DateTime fechaExtraida = Convert.ToDateTime(item["fecha"]);
                //string fecha = item["fecha"].ToString();
                string fecha = fechaExtraida.ToString("yyyy/MM/dd");
                string hora = item["hora"].ToString();
                string mensaje = item["mensaje"].ToString();

                dt.Rows.Add(fecha, hora, mensaje);
                mensajes.Add(new { fecha = fecha, hora = hora, mensaje = mensaje });
            }
        }
    }

}