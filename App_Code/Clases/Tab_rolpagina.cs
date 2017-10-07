using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_rolpagina
{
	private int id_rolPagina;
	private int id_rol;
	private int id_pagina;

	public int Id_rolPagina
	{
		get { return id_rolPagina; }
		set { id_rolPagina = value; }
	}
	public int Id_rol
	{
		get { return id_rol; }
		set { id_rol = value; }
	}
	public int Id_pagina
	{
		get { return id_pagina; }
		set { id_pagina = value; }
	}

	public Tab_rolpagina(){ }

}
