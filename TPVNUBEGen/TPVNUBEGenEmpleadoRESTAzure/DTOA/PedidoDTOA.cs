using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class PedidoDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}

private TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoPedido;
public TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum EstadoPedido
{
        get { return estadoPedido; }
        set { estadoPedido = value; }
}

private double total;
public double Total
{
        get { return total; }
        set { total = value; }
}


/* Rol: Pedido o--> LineaPedido */
private IList<LineaPedidoDTOA> lineas;
public IList<LineaPedidoDTOA> Lineas
{
        get { return lineas; }
        set { lineas = value; }
}

/* Rol: Pedido o--> Factura */
private FacturaDTOA factura;
public FacturaDTOA Factura
{
        get { return factura; }
        set { factura = value; }
}

/* Rol: Pedido o--> Mesa */
private MesaDTOA mesaComanda;
public MesaDTOA MesaComanda
{
        get { return mesaComanda; }
        set { mesaComanda = value; }
}
}
}
