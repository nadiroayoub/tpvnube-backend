
using System;
// Definición clase EmpresaEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class EmpresaEN
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
 *	Atributo duenyo
 */
private TPVNUBEGenNHibernate.EN.Rest.DuenyoEN duenyo;



/**
 *	Atributo negocio
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.NegocioEN> negocio;



/**
 *	Atributo cif
 */
private string cif;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo fechaconstitucion
 */
private Nullable<DateTime> fechaconstitucion;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo ciudad
 */
private string ciudad;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo cp
 */
private string cp;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.DuenyoEN Duenyo {
        get { return duenyo; } set { duenyo = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.NegocioEN> Negocio {
        get { return negocio; } set { negocio = value;  }
}



public virtual string Cif {
        get { return cif; } set { cif = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual Nullable<DateTime> Fechaconstitucion {
        get { return fechaconstitucion; } set { fechaconstitucion = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual string Cp {
        get { return cp; } set { cp = value;  }
}





public EmpresaEN()
{
        negocio = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.NegocioEN>();
}



public EmpresaEN(int id, string nombre, string direccion, TPVNUBEGenNHibernate.EN.Rest.DuenyoEN duenyo, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.NegocioEN> negocio, string cif, string email, Nullable<DateTime> fechaconstitucion, string telefono, string provincia, string ciudad, string pais, string cp
                 )
{
        this.init (Id, nombre, direccion, duenyo, negocio, cif, email, fechaconstitucion, telefono, provincia, ciudad, pais, cp);
}


public EmpresaEN(EmpresaEN empresa)
{
        this.init (Id, empresa.Nombre, empresa.Direccion, empresa.Duenyo, empresa.Negocio, empresa.Cif, empresa.Email, empresa.Fechaconstitucion, empresa.Telefono, empresa.Provincia, empresa.Ciudad, empresa.Pais, empresa.Cp);
}

private void init (int id
                   , string nombre, string direccion, TPVNUBEGenNHibernate.EN.Rest.DuenyoEN duenyo, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.NegocioEN> negocio, string cif, string email, Nullable<DateTime> fechaconstitucion, string telefono, string provincia, string ciudad, string pais, string cp)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Direccion = direccion;

        this.Duenyo = duenyo;

        this.Negocio = negocio;

        this.Cif = cif;

        this.Email = email;

        this.Fechaconstitucion = fechaconstitucion;

        this.Telefono = telefono;

        this.Provincia = provincia;

        this.Ciudad = ciudad;

        this.Pais = pais;

        this.Cp = cp;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EmpresaEN t = obj as EmpresaEN;
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
