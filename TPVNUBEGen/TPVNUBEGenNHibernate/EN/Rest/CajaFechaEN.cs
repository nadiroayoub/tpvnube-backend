
using System;
// Definición clase CajaFechaEN
namespace TPVNUBEGenNHibernate.EN.Rest
{
public partial class CajaFechaEN
{
/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo idCaja
 */
private string idCaja;



/**
 *	Atributo total
 */
private string total;



/**
 *	Atributo caja
 */
private System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> caja;






public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string IdCaja {
        get { return idCaja; } set { idCaja = value;  }
}



public virtual string Total {
        get { return total; } set { total = value;  }
}



public virtual System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> Caja {
        get { return caja; } set { caja = value;  }
}





public CajaFechaEN()
{
        caja = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CajaEN>();
}



public CajaFechaEN(int id, Nullable<DateTime> fecha, string idCaja, string total, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> caja
                   )
{
        this.init (Id, fecha, idCaja, total, caja);
}


public CajaFechaEN(CajaFechaEN cajaFecha)
{
        this.init (Id, cajaFecha.Fecha, cajaFecha.IdCaja, cajaFecha.Total, cajaFecha.Caja);
}

private void init (int id
                   , Nullable<DateTime> fecha, string idCaja, string total, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> caja)
{
        this.Id = id;


        this.Fecha = fecha;

        this.IdCaja = idCaja;

        this.Total = total;

        this.Caja = caja;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CajaFechaEN t = obj as CajaFechaEN;
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
