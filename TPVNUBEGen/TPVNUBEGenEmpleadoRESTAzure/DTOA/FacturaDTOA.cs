using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class FacturaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string numero;
public string Numero
{
        get { return numero; }
        set { numero = value; }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}

private double precio;
public double Precio
{
        get { return precio; }
        set { precio = value; }
}

private string descripcion;
public string Descripcion
{
        get { return descripcion; }
        set { descripcion = value; }
}
}
}
