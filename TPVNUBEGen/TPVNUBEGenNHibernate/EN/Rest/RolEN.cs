
using System;
// Definición clase RolEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class RolEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cajero
 */
private TPVNUBEGenNHibernate.EN.Rest.CajeroEN cajero;



/**
 *	Atributo camarero
 */
private TPVNUBEGenNHibernate.EN.Rest.CamareroEN camarero;



/**
 *	Atributo empleo
 */
private TPVNUBEGenNHibernate.Enumerated.Rest.EmpleoEnum empleo;



/**
 *	Atributo empleado
 */
private TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN empleado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.CajeroEN Cajero {
        get { return cajero; } set { cajero = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.CamareroEN Camarero {
        get { return camarero; } set { camarero = value;  }
}



public virtual TPVNUBEGenNHibernate.Enumerated.Rest.EmpleoEnum Empleo {
        get { return empleo; } set { empleo = value;  }
}



public virtual TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN Empleado {
        get { return empleado; } set { empleado = value;  }
}





public RolEN()
{
}



public RolEN(int id, TPVNUBEGenNHibernate.EN.Rest.CajeroEN cajero, TPVNUBEGenNHibernate.EN.Rest.CamareroEN camarero, TPVNUBEGenNHibernate.Enumerated.Rest.EmpleoEnum empleo, TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN empleado
             )
{
        this.init (Id, cajero, camarero, empleo, empleado);
}


public RolEN(RolEN rol)
{
        this.init (Id, rol.Cajero, rol.Camarero, rol.Empleo, rol.Empleado);
}

private void init (int id
                   , TPVNUBEGenNHibernate.EN.Rest.CajeroEN cajero, TPVNUBEGenNHibernate.EN.Rest.CamareroEN camarero, TPVNUBEGenNHibernate.Enumerated.Rest.EmpleoEnum empleo, TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN empleado)
{
        this.Id = id;


        this.Cajero = cajero;

        this.Camarero = camarero;

        this.Empleo = empleo;

        this.Empleado = empleado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RolEN t = obj as RolEN;
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
