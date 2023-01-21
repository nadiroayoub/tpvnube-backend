
using System;
// Definición clase EmpleadoEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class EmpleadoEN
{
/**
 *	Atributo negocio
 */
private TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo comanda
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> comanda;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo dni
 */
private string dni;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo cobro
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> cobro;






public virtual TPVNUBEGenNHibernate.EN.Rest.NegocioEN Negocio {
        get { return negocio; } set { negocio = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> Comanda {
        get { return comanda; } set { comanda = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Dni {
        get { return dni; } set { dni = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> Cobro {
        get { return cobro; } set { cobro = value;  }
}





public EmpleadoEN()
{
        comanda = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ComandaEN>();
        cobro = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
}



public EmpleadoEN(int id, TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio, string nombre, string apellidos, String pass, string foto, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> comanda, string dni, string email, string telefono, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> cobro
                  )
{
        this.init (Id, negocio, nombre, apellidos, pass, foto, comanda, dni, email, telefono, cobro);
}


public EmpleadoEN(EmpleadoEN empleado)
{
        this.init (Id, empleado.Negocio, empleado.Nombre, empleado.Apellidos, empleado.Pass, empleado.Foto, empleado.Comanda, empleado.Dni, empleado.Email, empleado.Telefono, empleado.Cobro);
}

private void init (int id
                   , TPVNUBEGenNHibernate.EN.Rest.NegocioEN negocio, string nombre, string apellidos, String pass, string foto, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> comanda, string dni, string email, string telefono, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> cobro)
{
        this.Id = id;


        this.Negocio = negocio;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Pass = pass;

        this.Foto = foto;

        this.Comanda = comanda;

        this.Dni = dni;

        this.Email = email;

        this.Telefono = telefono;

        this.Cobro = cobro;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EmpleadoEN t = obj as EmpleadoEN;
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
