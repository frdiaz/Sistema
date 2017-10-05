using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_alertas
{
    private int id_alerta;
    private string mensaje;
    private string descripcion;

    public int Id_alerta
    {
        get { return id_alerta; }
        set { id_alerta = value; }
    }
    public string Mensaje
    {
        get { return mensaje; }
        set { mensaje = value; }
    }
    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public Tab_alertas() { }

}
