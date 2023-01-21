
using System;
// Definición clase NegocioEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class NegocioEN
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
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo ciudad
 */
private string ciudad;



/**
 *	Atributo cp
 */
private string cp;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo servicios
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ServicioEN> servicios;



/**
 *	Atributo empresa
 */
private TPVNUBEGenNHibernate.EN.Rest.EmpresaEN empresa;



/**
 *	Atributo caja
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> caja;



/**
 *	Atributo compraProveedor
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor;



/**
 *	Atributo producto
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ProductoEN> producto;



/**
 *	Atributo empleado
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN> empleado;



/**
 *	Atributo cliente
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ClienteEN> cliente;



/**
 *	Atributo mesa
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.MesaEN> mesa;



/**
 *	Atributo menu
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.MenuEN> menu;



/**
 *	Atributo plato
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PlatoEN> plato;



/**
 *	Atributo cobro
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> cobro;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}



public virtual string Cp {
        get { return cp; } set { cp = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ServicioEN> Servicios {
        get { return servicios; } set { servicios = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.EmpresaEN Empresa {
        get { return empresa; } set { empresa = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> Caja {
        get { return caja; } set { caja = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN> CompraProveedor {
        get { return compraProveedor; } set { compraProveedor = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN> Empleado {
        get { return empleado; } set { empleado = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ClienteEN> Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.MesaEN> Mesa {
        get { return mesa; } set { mesa = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.MenuEN> Menu {
        get { return menu; } set { menu = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PlatoEN> Plato {
        get { return plato; } set { plato = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> Cobro {
        get { return cobro; } set { cobro = value;  }
}





public NegocioEN()
{
        servicios = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ServicioEN>();
        caja = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CajaEN>();
        compraProveedor = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN>();
        producto = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ProductoEN>();
        empleado = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN>();
        cliente = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ClienteEN>();
        mesa = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.MesaEN>();
        menu = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.MenuEN>();
        plato = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.PlatoEN>();
        cobro = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
}



public NegocioEN(int id, string nombre, string direccion, string ciudad, string cp, string provincia, string pais, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ServicioEN> servicios, TPVNUBEGenNHibernate.EN.Rest.EmpresaEN empresa, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> caja, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ProductoEN> producto, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN> empleado, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ClienteEN> cliente, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.MesaEN> mesa, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.MenuEN> menu, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PlatoEN> plato, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> cobro
                 )
{
        this.init (Id, nombre, direccion, ciudad, cp, provincia, pais, servicios, empresa, caja, compraProveedor, producto, empleado, cliente, mesa, menu, plato, cobro);
}


public NegocioEN(NegocioEN negocio)
{
        this.init (Id, negocio.Nombre, negocio.Direccion, negocio.Ciudad, negocio.Cp, negocio.Provincia, negocio.Pais, negocio.Servicios, negocio.Empresa, negocio.Caja, negocio.CompraProveedor, negocio.Producto, negocio.Empleado, negocio.Cliente, negocio.Mesa, negocio.Menu, negocio.Plato, negocio.Cobro);
}

private void init (int id
                   , string nombre, string direccion, string ciudad, string cp, string provincia, string pais, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ServicioEN> servicios, TPVNUBEGenNHibernate.EN.Rest.EmpresaEN empresa, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> caja, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN> compraProveedor, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ProductoEN> producto, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN> empleado, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ClienteEN> cliente, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.MesaEN> mesa, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.MenuEN> menu, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.PlatoEN> plato, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> cobro)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Direccion = direccion;

        this.Ciudad = ciudad;

        this.Cp = cp;

        this.Provincia = provincia;

        this.Pais = pais;

        this.Servicios = servicios;

        this.Empresa = empresa;

        this.Caja = caja;

        this.CompraProveedor = compraProveedor;

        this.Producto = producto;

        this.Empleado = empleado;

        this.Cliente = cliente;

        this.Mesa = mesa;

        this.Menu = menu;

        this.Plato = plato;

        this.Cobro = cobro;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NegocioEN t = obj as NegocioEN;
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
