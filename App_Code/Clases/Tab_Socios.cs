using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_socios
{
    private int id_socio = 0;
    private string rut = "";
    private string nombre = "";
    private string apellidoPaterno = "";
    private string apellidoMaterno = "";
    private DateTime fechaNacimiento = DateTime.Now;
    private int sexo = 0;
    private int fono = 0;
    private string email = "";

    public int Id_socio
    {
        get { return id_socio; }
        set { id_socio = value; }
    }
    public string Rut
    {
        get { return rut; }
        set { rut = value; }
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
    public DateTime FechaNacimiento
    {
        get { return fechaNacimiento; }
        set { fechaNacimiento = value; }
    }
    public int Sexo
    {
        get { return sexo; }
        set { sexo = value; }
    }
    public int Fono
    {
        get { return fono; }
        set { fono = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public Tab_socios() { }

}
