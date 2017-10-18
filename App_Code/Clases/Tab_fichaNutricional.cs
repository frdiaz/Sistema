using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_fichaNutricional
{
    private int id = 0;
    private int id_paciente = 0;
    private DateTime fechaRegistro = DateTime.Now;
    private float peso = 0;
    private float talla = 0;
    private float cintura = 0;
    private int alcohol = 0;
    private int tabaco = 0;
    private string anamnesis = "";
    private string diagnostico = "";
    private int idTipoConsulta = 1;
    private float imc = 0;
    private string indicaciones = "";

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public int Id_paciente
    {
        get { return id_paciente; }
        set { id_paciente = value; }
    }
    public DateTime FechaRegistro
    {
        get { return fechaRegistro; }
        set { fechaRegistro = value; }
    }
    public float Peso
    {
        get { return peso; }
        set { peso = value; }
    }
    public float Talla
    {
        get { return talla; }
        set { talla = value; }
    }
    public float Cintura
    {
        get { return cintura; }
        set { cintura = value; }
    }
    public int Alcohol
    {
        get { return alcohol; }
        set { alcohol = value; }
    }
    public int Tabaco
    {
        get { return tabaco; }
        set { tabaco = value; }
    }
    public string Anamnesis
    {
        get { return anamnesis; }
        set { anamnesis = value; }
    }
    public string Diagnostico
    {
        get { return diagnostico; }
        set { diagnostico = value; }
    }
    public int IdTipoConsulta
    {
        get { return idTipoConsulta; }
        set { idTipoConsulta = value; }
    }

    public float IMC
    {
        get { return imc; }
        set { imc = value; }
    }

    public string Indicaciones
    {
        get { return indicaciones; }
        set { indicaciones = value; }
    }
    public Tab_fichaNutricional() { }

}
