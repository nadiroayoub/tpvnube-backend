
using System;
// Definición clase PlatoEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class PlatoEN
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
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo lineaPlato
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaPlatoEN> lineaPlato;



/**
 *	Atributo lineaMenu
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo tipoPlato
 */
private TPVNUBEGenNHibernate.EN.Rest.TipoPlatoEN tipoPlato;



/**
 *	Atributo lineaComanda
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda;



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



public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaPlatoEN> LineaPlato {
        get { return lineaPlato; } set { lineaPlato = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN> LineaMenu {
        get { return lineaMenu; } set { lineaMenu = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.TipoPlatoEN TipoPlato {
        get { return tipoPlato; } set { tipoPlato = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> LineaComanda {
        get { return lineaComanda; } set { lineaComanda = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}





public PlatoEN()
{
        lineaPlato = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaPlatoEN>();
        lineaMenu = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN>();
        lineaComanda = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN>();
}



public PlatoEN(int id, string nombre, double stock, double precio, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaPlatoEN> lineaPlato, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu, string foto, TPVNUBEGenNHibernate.EN.Rest.TipoPlatoEN tipoPlato, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio
               )
{
        this.init (Id, nombre, stock, precio, lineaPlato, lineaMenu, foto, tipoPlato, lineaComanda, negocio);
}


public PlatoEN(PlatoEN plato)
{
        this.init (Id, plato.Nombre, plato.Stock, plato.Precio, plato.LineaPlato, plato.LineaMenu, plato.Foto, plato.TipoPlato, plato.LineaComanda, plato.Negocio);
}

private void init (int id
                   , string nombre, double stock, double precio, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaPlatoEN> lineaPlato, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN> lineaMenu, string foto, TPVNUBEGenNHibernate.EN.Rest.TipoPlatoEN tipoPlato, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN> lineaComanda, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Stock = stock;

        this.Precio = precio;

        this.LineaPlato = lineaPlato;

        this.LineaMenu = lineaMenu;

        this.Foto = foto;

        this.TipoPlato = tipoPlato;

        this.LineaComanda = lineaComanda;

        this.Negocio = negocio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PlatoEN t = obj as PlatoEN;
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
