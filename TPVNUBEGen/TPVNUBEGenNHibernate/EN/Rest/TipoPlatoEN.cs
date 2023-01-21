
using System;
// Definición clase TipoPlatoEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class TipoPlatoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo plato
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PlatoEN> plato;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PlatoEN> Plato {
        get { return plato; } set { plato = value;  }
}





public TipoPlatoEN()
{
        plato = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.PlatoEN>();
}



public TipoPlatoEN(int id, string nombre, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PlatoEN> plato
                   )
{
        this.init (Id, nombre, plato);
}


public TipoPlatoEN(TipoPlatoEN tipoPlato)
{
        this.init (Id, tipoPlato.Nombre, tipoPlato.Plato);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PlatoEN> plato)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Plato = plato;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TipoPlatoEN t = obj as TipoPlatoEN;
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
