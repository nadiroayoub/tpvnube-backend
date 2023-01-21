
using System;
// Definición clase DuenyoEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class DuenyoEN
{
/**
 *	Atributo dni
 */
private string dni;



/**
 *	Atributo empresa
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpresaEN> empresa;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo caja
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> caja;



/**
 *	Atributo foto
 */
private string foto;






public virtual string Dni {
        get { return dni; } set { dni = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpresaEN> Empresa {
        get { return empresa; } set { empresa = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> Caja {
        get { return caja; } set { caja = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}





public DuenyoEN()
{
        empresa = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.EmpresaEN>();
        caja = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CajaEN>();
}



public DuenyoEN(int id, string dni, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpresaEN> empresa, string nombre, string apellidos, string telefono, String pass, string email, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> caja, string foto
                )
{
        this.init (Id, dni, empresa, nombre, apellidos, telefono, pass, email, caja, foto);
}


public DuenyoEN(DuenyoEN duenyo)
{
        this.init (Id, duenyo.Dni, duenyo.Empresa, duenyo.Nombre, duenyo.Apellidos, duenyo.Telefono, duenyo.Pass, duenyo.Email, duenyo.Caja, duenyo.Foto);
}

private void init (int id
                   , string dni, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpresaEN> empresa, string nombre, string apellidos, string telefono, String pass, string email, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> caja, string foto)
{
        this.Id = id;


        this.Dni = dni;

        this.Empresa = empresa;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Telefono = telefono;

        this.Pass = pass;

        this.Email = email;

        this.Caja = caja;

        this.Foto = foto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DuenyoEN t = obj as DuenyoEN;
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
