using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class CobroDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private float monto;
public float Monto
{
        get { return monto; }
        set { monto = value; }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}
}
}
