
using System;
// Definición clase ProveedorEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class ProveedorEN
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
 *	Atributo compraProveedor
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo telefono
 */
private string telefono;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN> CompraProveedor {
        get { return compraProveedor; } set { compraProveedor = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}





public ProveedorEN()
{
        compraProveedor = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN>();
}



public ProveedorEN(int id, string nombre, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, string email, string telefono
                   )
{
        this.init (Id, nombre, compraProveedor, email, telefono);
}


public ProveedorEN(ProveedorEN proveedor)
{
        this.init (Id, proveedor.Nombre, proveedor.CompraProveedor, proveedor.Email, proveedor.Telefono);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, string email, string telefono)
{
        this.Id = id;


        this.Nombre = nombre;

        this.CompraProveedor = compraProveedor;

        this.Email = email;

        this.Telefono = telefono;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProveedorEN t = obj as ProveedorEN;
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
