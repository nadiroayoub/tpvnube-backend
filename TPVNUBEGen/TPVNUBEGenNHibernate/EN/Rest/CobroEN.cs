
using System;
// Definición clase CobroEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class CobroEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo monto
 */
private float monto;



/**
 *	Atributo comanda
 */
private TPVNUBEGenNHibernate.EN.Rest.ComandaEN comanda;



/**
 *	Atributo cliente
 */
private TPVNUBEGenNHibernate.EN.Rest.ClienteEN cliente;



/**
 *	Atributo tipoCobro
 */
private TPVNUBEGenNHibernate.EN.Rest.TipoCobroEN tipoCobro;



/**
 *	Atributo caja
 */
private TPVNUBEGenNHibernate.EN.Rest.CajaEN caja;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo empleado
 */
private TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN empleado;



/**
 *	Atributo negocio
 */
private TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual float Monto {
        get { return monto; } set { monto = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.ComandaEN Comanda {
        get { return comanda; } set { comanda = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.TipoCobroEN TipoCobro {
        get { return tipoCobro; } set { tipoCobro = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.CajaEN Caja {
        get { return caja; } set { caja = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN Empleado {
        get { return empleado; } set { empleado = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}





public CobroEN()
{
}



public CobroEN(int id, float monto, TPVNUBEGenNHibernate.EN.Rest.ComandaEN comanda, TPVNUBEGenNHibernate.EN.Rest.ClienteEN cliente, TPVNUBEGenNHibernate.EN.Rest.TipoCobroEN tipoCobro, TPVNUBEGenNHibernate.EN.Rest.CajaEN caja, Nullable<DateTime> fecha, TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN empleado, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio
               )
{
        this.init (Id, monto, comanda, cliente, tipoCobro, caja, fecha, empleado, negocio);
}


public CobroEN(CobroEN cobro)
{
        this.init (Id, cobro.Monto, cobro.Comanda, cobro.Cliente, cobro.TipoCobro, cobro.Caja, cobro.Fecha, cobro.Empleado, cobro.Negocio);
}

private void init (int id
                   , float monto, TPVNUBEGenNHibernate.EN.Rest.ComandaEN comanda, TPVNUBEGenNHibernate.EN.Rest.ClienteEN cliente, TPVNUBEGenNHibernate.EN.Rest.TipoCobroEN tipoCobro, TPVNUBEGenNHibernate.EN.Rest.CajaEN caja, Nullable<DateTime> fecha, TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN empleado, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio)
{
        this.Id = id;


        this.Monto = monto;

        this.Comanda = comanda;

        this.Cliente = cliente;

        this.TipoCobro = tipoCobro;

        this.Caja = caja;

        this.Fecha = fecha;

        this.Empleado = empleado;

        this.Negocio = negocio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CobroEN t = obj as CobroEN;
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
