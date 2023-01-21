using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenEmpleadoRESTAzure.DTO
{
public partial class CobroDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private float monto;
public float Monto {
        get { return monto; } set { monto = value;  }
}


private int comanda_oid;
public int Comanda_oid {
        get { return comanda_oid; } set { comanda_oid = value;  }
}



private int cliente_oid;
public int Cliente_oid {
        get { return cliente_oid; } set { cliente_oid = value;  }
}



private int tipoCobro_oid;
public int TipoCobro_oid {
        get { return tipoCobro_oid; } set { tipoCobro_oid = value;  }
}



private int caja_oid;
public int Caja_oid {
        get { return caja_oid; } set { caja_oid = value;  }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}


private int empleado_oid;
public int Empleado_oid {
        get { return empleado_oid; } set { empleado_oid = value;  }
}



private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}
}
}
