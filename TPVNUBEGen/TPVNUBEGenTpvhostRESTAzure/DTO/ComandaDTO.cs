using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenTpvhostRESTAzure.DTO
{
public partial class ComandaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum estadoComanda;
public TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum EstadoComanda {
        get { return estadoComanda; } set { estadoComanda = value;  }
}
private System.Collections.Generic.IList<LineaComandaDTO> lineaComanda;
public System.Collections.Generic.IList<LineaComandaDTO> LineaComanda {
        get { return lineaComanda; } set { lineaComanda = value;  }
}


private System.Collections.Generic.IList<int> pago_oid;
public System.Collections.Generic.IList<int> Pago_oid {
        get { return pago_oid; } set { pago_oid = value;  }
}



private int mesa_oid;
public int Mesa_oid {
        get { return mesa_oid; } set { mesa_oid = value;  }
}



private int factura_oid;
public int Factura_oid {
        get { return factura_oid; } set { factura_oid = value;  }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}


private int empleado_oid;
public int Empleado_oid {
        get { return empleado_oid; } set { empleado_oid = value;  }
}

private double total;
public double Total {
        get { return total; } set { total = value;  }
}
}
}
