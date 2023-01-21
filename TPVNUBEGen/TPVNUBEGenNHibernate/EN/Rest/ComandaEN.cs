
using System;
// Definición clase ComandaEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class ComandaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estadoComanda
 */
private TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoComanda;



/**
 *	Atributo lineaComanda
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda;



/**
 *	Atributo pago
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> pago;



/**
 *	Atributo mesa
 */
private TPVNUBEGenNHibernate.EN.Rest.MesaEN mesa;



/**
 *	Atributo factura
 */
private TPVNUBEGenNHibernate.EN.Rest.FacturaEN factura;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo empleado
 */
private TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN empleado;



/**
 *	Atributo total
 */
private double total;



/**
 *	Atributo pdf
 */
private string pdf;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum EstadoComanda {
        get { return estadoComanda; } set { estadoComanda = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> LineaComanda {
        get { return lineaComanda; } set { lineaComanda = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> Pago {
        get { return pago; } set { pago = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.MesaEN Mesa {
        get { return mesa; } set { mesa = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN Empleado {
        get { return empleado; } set { empleado = value;  }
}



public virtual double Total {
        get { return total; } set { total = value;  }
}



public virtual string Pdf {
        get { return pdf; } set { pdf = value;  }
}





public ComandaEN()
{
        lineaComanda = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN>();
        pago = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
}



public ComandaEN(int id, TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoComanda, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> pago, TPVNUBEGenNHibernate.EN.Rest.MesaEN mesa, TPVNUBEGenNHibernate.EN.Rest.FacturaEN factura, Nullable<DateTime> fecha, TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN empleado, double total, string pdf
                 )
{
        this.init (Id, estadoComanda, lineaComanda, pago, mesa, factura, fecha, empleado, total, pdf);
}


public ComandaEN(ComandaEN comanda)
{
        this.init (Id, comanda.EstadoComanda, comanda.LineaComanda, comanda.Pago, comanda.Mesa, comanda.Factura, comanda.Fecha, comanda.Empleado, comanda.Total, comanda.Pdf);
}

private void init (int id
                   , TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoComanda, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> pago, TPVNUBEGenNHibernate.EN.Rest.MesaEN mesa, TPVNUBEGenNHibernate.EN.Rest.FacturaEN factura, Nullable<DateTime> fecha, TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN empleado, double total, string pdf)
{
        this.Id = id;


        this.EstadoComanda = estadoComanda;

        this.LineaComanda = lineaComanda;

        this.Pago = pago;

        this.Mesa = mesa;

        this.Factura = factura;

        this.Fecha = fecha;

        this.Empleado = empleado;

        this.Total = total;

        this.Pdf = pdf;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComandaEN t = obj as ComandaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
