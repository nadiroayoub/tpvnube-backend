
using System;
// Definición clase ServicioEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class ServicioEN
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
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo costo
 */
private double costo;



/**
 *	Atributo lineaProveedor
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaCompraProveedorEN> lineaProveedor;



/**
 *	Atributo codigoContrato
 */
private string codigoContrato;



/**
 *	Atributo categoriaServicio
 */
private TPVNUBEGenNHibernate.EN.Rest.CategoriaServicioEN categoriaServicio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual double Costo {
        get { return costo; } set { costo = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaCompraProveedorEN> LineaProveedor {
        get { return lineaProveedor; } set { lineaProveedor = value;  }
}



public virtual string CodigoContrato {
        get { return codigoContrato; } set { codigoContrato = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.CategoriaServicioEN CategoriaServicio {
        get { return categoriaServicio; } set { categoriaServicio = value;  }
}





public ServicioEN()
{
        lineaProveedor = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaCompraProveedorEN>();
}



public ServicioEN(int id, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio, string nombre, double costo, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaCompraProveedorEN> lineaProveedor, string codigoContrato, TPVNUBEGenNHibernate.EN.Rest.CategoriaServicioEN categoriaServicio
                  )
{
        this.init (Id, negocio, nombre, costo, lineaProveedor, codigoContrato, categoriaServicio);
}


public ServicioEN(ServicioEN servicio)
{
        this.init (Id, servicio.Negocio, servicio.Nombre, servicio.Costo, servicio.LineaProveedor, servicio.CodigoContrato, servicio.CategoriaServicio);
}

private void init (int id
                   , TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio, string nombre, double costo, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaCompraProveedorEN> lineaProveedor, string codigoContrato, TPVNUBEGenNHibernate.EN.Rest.CategoriaServicioEN categoriaServicio)
{
        this.Id = id;


        this.Negocio = negocio;

        this.Nombre = nombre;

        this.Costo = costo;

        this.LineaProveedor = lineaProveedor;

        this.CodigoContrato = codigoContrato;

        this.CategoriaServicio = categoriaServicio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ServicioEN t = obj as ServicioEN;
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
