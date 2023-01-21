
using System;
// Definición clase LineaMenuEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class LineaMenuEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo plato
 */
private TPVNUBEGenNHibernate.EN.Rest.PlatoEN plato;



/**
 *	Atributo menu
 */
private TPVNUBEGenNHibernate.EN.Rest.MenuEN menu;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.PlatoEN Plato {
        get { return plato; } set { plato = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.MenuEN Menu {
        get { return menu; } set { menu = value;  }
}





public LineaMenuEN()
{
}



public LineaMenuEN(int id, int cantidad, TPVNUBEGenNHibernate.EN.Rest.PlatoEN plato, TPVNUBEGenNHibernate.EN.Rest.MenuEN menu
                   )
{
        this.init (Id, cantidad, plato, menu);
}


public LineaMenuEN(LineaMenuEN lineaMenu)
{
        this.init (Id, lineaMenu.Cantidad, lineaMenu.Plato, lineaMenu.Menu);
}

private void init (int id
                   , int cantidad, TPVNUBEGenNHibernate.EN.Rest.PlatoEN plato, TPVNUBEGenNHibernate.EN.Rest.MenuEN menu)
{
        this.Id = id;


        this.Cantidad = cantidad;

        this.Plato = plato;

        this.Menu = menu;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaMenuEN t = obj as LineaMenuEN;
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
