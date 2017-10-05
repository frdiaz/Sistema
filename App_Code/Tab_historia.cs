using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_historia
{
	private int id_Historial;
	private DateTime Fecha;
	private int id_Mensaje;

	public int Id_Historial
	{
		get { return id_Historial; }
		set { id_Historial = value; }
	}
	public DateTime Fecha
	{
		get { return Fecha; }
		set { Fecha = value; }
	}
	public int Id_Mensaje
	{
		get { return id_Mensaje; }
		set { id_Mensaje = value; }
	}

	public Tab_historia(){ }

}
