using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Perfiles : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region metodos

    [WebMethod]
    public static ArrayList cargarVentanas()
    {
        ArrayList perfiles = new ArrayList();

        procesaCargarVentanas(perfiles);
        return perfiles;
    }

    [WebMethod]
    public static ArrayList cargarTablaPerfiles()
    {
        ArrayList perfiles = new ArrayList();

        procesaPerfiles(perfiles);
        return perfiles;
    }

    public static void procesaCargarVentanas(ArrayList perfiles)
    {
        MetodosTabPagina metodosPaginas = new MetodosTabPagina();
        DataSet ds = new DataSet();

        ds = metodosPaginas.obtenerEspecifico();
        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string pagina = item["pagina"].ToString();

                perfiles.Add(new { id = id, pagina = pagina });
            }
        }
    }

    public static void procesaPerfiles(ArrayList perfiles)
    {
        MetodosTabPagina metodosPaginas = new MetodosTabPagina();
        DataSet ds = new DataSet();

        ds = metodosPaginas.consultaPerfiles();

        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string nombre = item["nombre"].ToString();
                string descripcion = item["descripcion"].ToString();

                perfiles.Add(new { id = id, nombre = nombre, descripcion = descripcion });
            }
        }
    }

    [WebMethod]
    public static ArrayList cargarEditarPerfiles(string id_perfil)
    {
        ArrayList perfiles = new ArrayList();

        extraeDatosPerfil(perfiles, id_perfil);
        return perfiles;
    }

    public static void extraeDatosPerfil(ArrayList perfiles, string id_perfil)
    {
        MetodosTabRolPagina metodosRolPagina = new MetodosTabRolPagina();
        Tab_rol rol = new Tab_rol();

        rol.Id_rol = Convert.ToInt32(id_perfil);

        DataSet ds = new DataSet();

        ds = metodosRolPagina.obtenerTodoPorID_Perfil(rol);


        if (ds != null)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                int id = Convert.ToInt32(item["id_rol"]);
                string nombre = item["nombre"].ToString();
                string descripcion = item["descripcion"].ToString();
                int estado = Convert.ToInt32(item["activo"]);
                string paginas = item["id_pagina"].ToString();

                perfiles.Add(new { id = id, nombre = nombre, descripcion = descripcion, estado = estado, paginas = paginas });
            }
        }
    }

    [WebMethod]
    public static bool actualizarPerfil(string id, string nombre, string descripcion, string estado, string paginas)
    {
        bool resultado = true;

        MetodosTabRol metodosRol = new MetodosTabRol();
        Tab_rol rol = new Tab_rol();

        DataSet ds = new DataSet();

        rol.Id_rol = Convert.ToInt32(id);
        rol.Nombre = nombre;
        rol.Descripcion = descripcion;
        rol.Activo = Convert.ToInt32(estado);

        resultado = metodosRol.updateRol(rol, paginas);

        return resultado;
    }

    [WebMethod]
    public static bool nuevoPerfil(string nombre, string descripcion, string paginas)
    {
        bool resultado = true;

        MetodosTabRol metodosRol = new MetodosTabRol();
        Tab_rol rol = new Tab_rol();

        DataSet ds = new DataSet();

        rol.Nombre = nombre;
        rol.Descripcion = descripcion;

        resultado = metodosRol.nuevoPerfil(rol, paginas);

        return resultado;
    }
    #endregion
}