using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Tab_tipoConsulta
/// </summary>
public class Tab_tipoConsulta
{
    private int id = 0;
    private string nombre = "";

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public Tab_tipoConsulta() { }
}