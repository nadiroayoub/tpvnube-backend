
using System;
// Definición clase MesaEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class MesaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comanda
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> comanda;



/**
 *	Atributo estado
 */
private TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum estado;



/**
 *	Atributo numero
 */
private int numero;



/**
 *	Atributo negocio
 */
private TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> Comanda {
        get { return comanda; } set { comanda = value;  }
}



public virtual TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual int Numero {
        get { return numero; } set { numero = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}





public MesaEN()
{
        comanda = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ComandaEN>();
}



public MesaEN(int id, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> comanda, TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum estado, int numero, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio
              )
{
        this.init (Id, comanda, estado, numero, negocio);
}


public MesaEN(MesaEN mesa)
{
        this.init (Id, mesa.Comanda, mesa.Estado, mesa.Numero, mesa.Negocio);
}

private void init (int id
                   , System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> comanda, TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum estado, int numero, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio)
{
        this.Id = id;


        this.Comanda = comanda;

        this.Estado = estado;

        this.Numero = numero;

        this.Negocio = negocio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MesaEN t = obj as MesaEN;
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
