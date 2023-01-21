
using System;
// Definición clase LineaComandaEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class LineaComandaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comanda
 */
private TPVNUBEGenNHibernate.EN.Rest.ComandaEN comanda;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo menu
 */
private TPVNUBEGenNHibernate.EN.Rest.MenuEN menu;



/**
 *	Atributo plato
 */
private TPVNUBEGenNHibernate.EN.Rest.PlatoEN plato;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.ComandaEN Comanda {
        get { return comanda; } set { comanda = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.MenuEN Menu {
        get { return menu; } set { menu = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.PlatoEN Plato {
        get { return plato; } set { plato = value;  }
}





public LineaComandaEN()
{
}



public LineaComandaEN(int id, TPVNUBEGenNHibernate.EN.Rest.ComandaEN comanda, int cantidad, TPVNUBEGenNHibernate.EN.Rest.MenuEN menu, TPVNUBEGenNHibernate.EN.Rest.PlatoEN plato
                      )
{
        this.init (Id, comanda, cantidad, menu, plato);
}


public LineaComandaEN(LineaComandaEN lineaComanda)
{
        this.init (Id, lineaComanda.Comanda, lineaComanda.Cantidad, lineaComanda.Menu, lineaComanda.Plato);
}

private void init (int id
                   , TPVNUBEGenNHibernate.EN.Rest.ComandaEN comanda, int cantidad, TPVNUBEGenNHibernate.EN.Rest.MenuEN menu, TPVNUBEGenNHibernate.EN.Rest.PlatoEN plato)
{
        this.Id = id;


        this.Comanda = comanda;

        this.Cantidad = cantidad;

        this.Menu = menu;

        this.Plato = plato;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaComandaEN t = obj as LineaComandaEN;
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
