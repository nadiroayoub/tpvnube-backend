using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenTpvhostRESTAzure.DTO
{
public partial class CajaFechaDTO
{
private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string idCaja;
public string IdCaja {
        get { return idCaja; } set { idCaja = value;  }
}
private string total;
public string Total {
        get { return total; } set { total = value;  }
}


private System.Collections.Generic.IList<int> caja_oid;
public System.Collections.Generic.IList<int> Caja_oid {
        get { return caja_oid; } set { caja_oid = value;  }
}
}
}
