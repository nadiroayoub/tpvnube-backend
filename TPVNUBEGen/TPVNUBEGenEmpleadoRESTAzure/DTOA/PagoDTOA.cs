using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class PagoDTOA
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


/* Rol: Pago o--> Cliente */
private ClienteDTOA cliente;
public ClienteDTOA Cliente
{
        get { return cliente; }
        set { cliente = value; }
}
}
}
