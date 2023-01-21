using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class PlatoDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string nombre;
public string Nombre
{
        get { return nombre; }
        set { nombre = value; }
}

private double stock;
public double Stock
{
        get { return stock; }
        set { stock = value; }
}

private double precio;
public double Precio
{
        get { return precio; }
        set { precio = value; }
}

private string foto;
public string Foto
{
        get { return foto; }
        set { foto = value; }
}


/* Rol: Plato o--> Negocio */
private NegocioDTOA negocioPlato;
public NegocioDTOA NegocioPlato
{
        get { return negocioPlato; }
        set { negocioPlato = value; }
}
}
}
