using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MetodosTabUsuario
/// </summary>
public class MetodosTabUsuario
{
    public MetodosTabUsuario()
    {
        
    }

    public DataSet actualizarUsuario(Tab_usuario usuarios)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID", DbType.Int32, usuarios.Id_usuario));
        Parametros.Add(new Parametro("@RUT", DbType.String, usuarios.Rut));
        Parametros.Add(new Parametro("@EMAIL", DbType.String, usuarios.Email));
        Parametros.Add(new Parametro("@NOMBRE", DbType.String, usuarios.Nombre));
        Parametros.Add(new Parametro("@APELLIDOPATERNO", DbType.String, usuarios.ApellidoPaterno));
        Parametros.Add(new Parametro("@APELLIDOMATERNO", DbType.String, usuarios.ApellidoMaterno));
        Parametros.Add(new Parametro("@DIRECCION", DbType.String, usuarios.Direccion));
        Parametros.Add(new Parametro("@FONO", DbType.Int32, usuarios.Fono));
        Parametros.Add(new Parametro("@IDROL", DbType.Int32, usuarios.Id_rol));
        Parametros.Add(new Parametro("@ACTIVO", DbType.Int32, usuarios.Activo));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ACTUALIZARDATOSUSUARIO", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet resetearPassword(Tab_usuario usuarios)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.String, usuarios.Id_usuario));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_RESETEARPASSWORD", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet obtenerUsuario(Tab_usuario usuarios)
    {
        DataSet ds = new DataSet();

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, 3));//1=con fechas en el sp
        Parametros.Add(new Parametro("@ID", DbType.Int32, usuarios.Id_usuario));
        Parametros.Add(new Parametro("@RUT", DbType.String, usuarios.Rut));
        Parametros.Add(new Parametro("@EMAIL", DbType.String, usuarios.Email));
        Parametros.Add(new Parametro("@NOMBRE", DbType.String, usuarios.Nombre));
        Parametros.Add(new Parametro("@APELLIDOPATERNO", DbType.String, usuarios.ApellidoPaterno));
        Parametros.Add(new Parametro("@APELLIDOMATERNO", DbType.String, usuarios.ApellidoMaterno));
        Parametros.Add(new Parametro("@CONTRASENA", DbType.String, usuarios.Contrasena));
        Parametros.Add(new Parametro("@DIRECCION", DbType.String, usuarios.Direccion));
        Parametros.Add(new Parametro("@FONO", DbType.Int32, usuarios.Fono));
        Parametros.Add(new Parametro("@IDROL", DbType.Int32, usuarios.Id_rol));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_Usuario", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet obtenerUsuarios()
    {
        DataSet ds = new DataSet();

        ds = SqlQuery.ObtieneDataSet("obtenerUsuarios", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet nuevoUsuario(Tab_usuario usuarios)
    {
        DataSet ds = new DataSet();

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.String, 1));
        Parametros.Add(new Parametro("@ID", DbType.Int32, 0));
        Parametros.Add(new Parametro("@RUT", DbType.String, usuarios.Rut));
        Parametros.Add(new Parametro("@EMAIL", DbType.String, usuarios.Email));
        Parametros.Add(new Parametro("@NOMBRE", DbType.String, usuarios.Nombre));
        Parametros.Add(new Parametro("@APELLIDOPATERNO", DbType.String, usuarios.ApellidoPaterno));
        Parametros.Add(new Parametro("@APELLIDOMATERNO", DbType.String, usuarios.ApellidoMaterno));
        Parametros.Add(new Parametro("@CONTRASENA", DbType.String, usuarios.Contrasena));
        Parametros.Add(new Parametro("@DIRECCION", DbType.String, usuarios.Direccion));
        Parametros.Add(new Parametro("@FONO", DbType.String, usuarios.Fono));
        Parametros.Add(new Parametro("@IDROL", DbType.Int32, usuarios.Id_rol));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_Usuario", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet login(Tab_usuario usuario)
    {
        DataSet ds = new DataSet();

        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@email", DbType.String, usuario.Email));
        Parametros.Add(new Parametro("@password", DbType.String, usuario.Contrasena));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_Login", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet obtenerPaginasPorIDUsuario(Tab_usuario usuarios)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.Int32, usuarios.Id_usuario));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_CONSULTAMENU", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet obtenerDatosEspecificos(Tab_usuario usuarios, int tipoConsulta)
    {
        DataSet ds = new DataSet();
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.Int32, usuarios.Id_usuario));
        Parametros.Add(new Parametro("@TIPO_CONSULTA", DbType.Int32, tipoConsulta));

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_DatosPrincipales", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet actualizarPassword(Tab_usuario usuarios)
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.Int32, usuarios.Id_usuario));
        Parametros.Add(new Parametro("@PASSWORD", DbType.String, usuarios.Contrasena));
        DataSet ds = new DataSet();

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ACTUALIZARPASSWORD", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }

    public DataSet actualizarDatos(Tab_usuario usuarios)
    {
        List<Parametro> Parametros = new List<Parametro>();
        Parametros.Add(new Parametro("@ID_USUARIO", DbType.Int32, usuarios.Id_usuario));
        Parametros.Add(new Parametro("@EMAIL", DbType.String, usuarios.Email));
        Parametros.Add(new Parametro("@DIRECCION", DbType.String, usuarios.Direccion));
        Parametros.Add(new Parametro("@FONO", DbType.Int32, usuarios.Fono));
        DataSet ds = new DataSet();

        ds = SqlQuery.ObtieneDataSet(Parametros, "SP_ACTUALIZARDATOS", ConfigurationManager.AppSettings["Sistema"]);

        return ds;
    }
}