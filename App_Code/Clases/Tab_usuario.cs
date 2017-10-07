using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_usuario
{
    private int id_usuario;
    private string rut = "";
    private string email = "";
    private string nombre = "";
    private string apellidoPaterno = "";
    private string apellidoMaterno = "";
    private string contrasena = "";
    private string direccion = "";
    private int fono = 0;
    private int activo = 1;
    private int id_rol;

    public int Id_usuario
    {
        get { return id_usuario; }
        set { id_usuario = value; }
    }
    public string Rut
    {
        get { return rut; }
        set { rut = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    public string ApellidoPaterno
    {
        get { return apellidoPaterno; }
        set { apellidoPaterno = value; }
    }
    public string ApellidoMaterno
    {
        get { return apellidoMaterno; }
        set { apellidoMaterno = value; }
    }
    public string Contrasena
    {
        get { return contrasena; }
        set { contrasena = value; }
    }
    public string Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }
    public int Fono
    {
        get { return fono; }
        set { fono = value; }
    }
    public int Activo
    {
        get { return activo; }
        set { activo = value; }
    }
    public int Id_rol
    {
        get { return id_rol; }
        set { id_rol = value; }
    }

    public Tab_usuario() { }

}
