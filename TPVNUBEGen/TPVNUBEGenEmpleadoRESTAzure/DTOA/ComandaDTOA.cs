using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class ComandaDTOA
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

private double total;
public double Total
{
        get { return total; }
        set { total = value; }
}

private TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoComanda;
public TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum EstadoComanda
{
        get { return estadoComanda; }
        set { estadoComanda = value; }
}

private string pdf;
public string Pdf
{
        get { return pdf; }
        set { pdf = value; }
}


/* Rol: Comanda o--> Factura */
private FacturaDTOA factura;
public FacturaDTOA Factura
{
        get { return factura; }
        set { factura = value; }
}

/* Rol: Comanda o--> Mesa */
private MesaDTOA mesaOfComanda;
public MesaDTOA MesaOfComanda
{
        get { return mesaOfComanda; }
        set { mesaOfComanda = value; }
}

/* Rol: Comanda o--> LineaComanda */
private IList<LineaComandaDTOA> allLineaComandaOfComanda;
public IList<LineaComandaDTOA> AllLineaComandaOfComanda
{
        get { return allLineaComandaOfComanda; }
        set { allLineaComandaOfComanda = value; }
}
}
}
