
using System;
// Definición clase MenuEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class MenuEN
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
 *	Atributo stock
 */
private double stock;



/**
 *	Atributo lineaComanda
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda;



/**
 *	Atributo lineaMenu
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo negocio
 */
private TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual double Stock {
        get { return stock; } set { stock = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> LineaComanda {
        get { return lineaComanda; } set { lineaComanda = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN> LineaMenu {
        get { return lineaMenu; } set { lineaMenu = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}





public MenuEN()
{
        lineaComanda = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN>();
        lineaMenu = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN>();
}



public MenuEN(int id, string nombre, double stock, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu, string foto, double precio, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio
              )
{
        this.init (Id, nombre, stock, lineaComanda, lineaMenu, foto, precio, negocio);
}


public MenuEN(MenuEN menu)
{
        this.init (Id, menu.Nombre, menu.Stock, menu.LineaComanda, menu.LineaMenu, menu.Foto, menu.Precio, menu.Negocio);
}

private void init (int id
                   , string nombre, double stock, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu, string foto, double precio, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Stock = stock;

        this.LineaComanda = lineaComanda;

        this.LineaMenu = lineaMenu;

        this.Foto = foto;

        this.Precio = precio;

        this.Negocio = negocio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MenuEN t = obj as MenuEN;
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
