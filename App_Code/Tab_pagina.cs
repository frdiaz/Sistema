using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class Tab_pagina
{
	private int id_pagina;
	private string menu;
	private string url;
	private int activo;
	private string class;
	private string submenu;

	public int Id_pagina
	{
		get { return id_pagina; }
		set { id_pagina = value; }
	}
	public string Menu
	{
		get { return menu; }
		set { menu = value; }
	}
	public string Url
	{
		get { return url; }
		set { url = value; }
	}
	public int Activo
	{
		get { return activo; }
		set { activo = value; }
	}
	public string Class
	{
		get { return class; }
		set { class = value; }
	}
	public string Submenu
	{
		get { return submenu; }
		set { submenu = value; }
	}

	public Tab_pagina(){ }

}