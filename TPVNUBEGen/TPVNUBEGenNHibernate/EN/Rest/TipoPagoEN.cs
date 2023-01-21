
using System;
// Definición clase TipoPagoEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class TipoPagoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo pago
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PagoEN> pago;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PagoEN> Pago {
        get { return pago; } set { pago = value;  }
}





public TipoPagoEN()
{
        pago = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.PagoEN>();
}



public TipoPagoEN(int id, string descripcion, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PagoEN> pago
                  )
{
        this.init (Id, descripcion, pago);
}


public TipoPagoEN(TipoPagoEN tipoPago)
{
        this.init (Id, tipoPago.Descripcion, tipoPago.Pago);
}

private void init (int id
                   , string descripcion, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PagoEN> pago)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Pago = pago;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TipoPagoEN t = obj as TipoPagoEN;
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
