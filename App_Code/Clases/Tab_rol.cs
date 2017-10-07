using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_rol
{
	private int id_rol;
	private string nombre = "";
	private int activo = 1;
	private string descripcion = "";

	public int Id_rol
	{
		get { return id_rol; }
		set { id_rol = value; }
	}
	public string Nombre
	{
		get { return nombre; }
		set { nombre = value; }
	}
	public int Activo
	{
		get { return activo; }
		set { activo = value; }
	}
	public string Descripcion
	{
		get { return descripcion; }
		set { descripcion = value; }
	}

	public Tab_rol(){ }

}
