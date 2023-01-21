using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenTpvhostRESTAzure.DTOA
{
public class PedidoDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoPedido;
public TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum EstadoPedido
{
        get { return estadoPedido; }
        set { estadoPedido = value; }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}
}
}
