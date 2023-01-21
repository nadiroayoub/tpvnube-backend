
using System;
// Definición clase CajaEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class CajaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo negocio
 */
private TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio;



/**
 *	Atributo pago
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PagoEN> pago;



/**
 *	Atributo saldo
 */
private double saldo;



/**
 *	Atributo cobro
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> cobro;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo duenyo
 */
private TPVNUBEGenNHibernate.EN.Rest.DuenyoEN duenyo;



/**
 *	Atributo fondo
 */
private double fondo;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PagoEN> Pago {
        get { return pago; } set { pago = value;  }
}



public virtual double Saldo {
        get { return saldo; } set { saldo = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> Cobro {
        get { return cobro; } set { cobro = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.DuenyoEN Duenyo {
        get { return duenyo; } set { duenyo = value;  }
}



public virtual double Fondo {
        get { return fondo; } set { fondo = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public CajaEN()
{
        pago = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.PagoEN>();
        cobro = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
}



public CajaEN(int id, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PagoEN> pago, double saldo, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> cobro, string descripcion, TPVNUBEGenNHibernate.EN.Rest.DuenyoEN duenyo, double fondo, Nullable<DateTime> fecha
              )
{
        this.init (Id, negocio, pago, saldo, cobro, descripcion, duenyo, fondo, fecha);
}


public CajaEN(CajaEN caja)
{
        this.init (Id, caja.Negocio, caja.Pago, caja.Saldo, caja.Cobro, caja.Descripcion, caja.Duenyo, caja.Fondo, caja.Fecha);
}

private void init (int id
                   , TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PagoEN> pago, double saldo, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> cobro, string descripcion, TPVNUBEGenNHibernate.EN.Rest.DuenyoEN duenyo, double fondo, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Negocio = negocio;

        this.Pago = pago;

        this.Saldo = saldo;

        this.Cobro = cobro;

        this.Descripcion = descripcion;

        this.Duenyo = duenyo;

        this.Fondo = fondo;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CajaEN t = obj as CajaEN;
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
