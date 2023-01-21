using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class CajaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private double fondo;
public double Fondo
{
        get { return fondo; }
        set { fondo = value; }
}


/* Rol: Caja o--> Pago */
private IList<PagoDTOA> cobros;
public IList<PagoDTOA> Cobros
{
        get { return cobros; }
        set { cobros = value; }
}
}
}
