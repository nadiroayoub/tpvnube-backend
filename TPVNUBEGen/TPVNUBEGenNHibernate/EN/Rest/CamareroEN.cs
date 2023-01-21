
using System;
// Definición clase CamareroEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class CamareroEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo rol
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.RolEN> rol;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> pedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.RolEN> Rol {
        get { return rol; } set { rol = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}





public CamareroEN()
{
        rol = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.RolEN>();
        pedido = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ComandaEN>();
}



public CamareroEN(int id, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.RolEN> rol, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> pedido
                  )
{
        this.init (Id, rol, pedido);
}


public CamareroEN(CamareroEN camarero)
{
        this.init (Id, camarero.Rol, camarero.Pedido);
}

private void init (int id
                   , System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.RolEN> rol, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> pedido)
{
        this.Id = id;


        this.Rol = rol;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CamareroEN t = obj as CamareroEN;
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
