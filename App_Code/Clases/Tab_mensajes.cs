using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_mensajes
{
	private int id_Mensaje;
	private string mensaje = "";
	private int activo = 1;

	public int Id_Mensaje
	{
		get { return id_Mensaje; }
		set { id_Mensaje = value; }
	}
	public string Mensaje
	{
		get { return mensaje; }
		set { mensaje = value; }
	}
	public int Activo
	{
		get { return activo; }
		set { activo = value; }
	}

	public Tab_mensajes(){ }

}
