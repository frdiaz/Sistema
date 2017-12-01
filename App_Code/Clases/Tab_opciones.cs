using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_opciones
{
    private int id = 0;
    private string valor = "";
    private int id_usuario = 0;
    private int id_tipoOpcion = 0;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Valor
    {
        get { return valor; }
        set { valor = value; }
    }
    public int Id_usuario
    {
        get { return id_usuario; }
        set { id_usuario = value; }
    }
    public int Id_tipoOpcion
    {
        get { return id_tipoOpcion; }
        set { id_tipoOpcion = value; }
    }

    public Tab_opciones() { }

}