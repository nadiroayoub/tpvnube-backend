using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenTpvhostRESTAzure.DTO
{
public partial class CajaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}



private System.Collections.Generic.IList<int> pago_oid;
public System.Collections.Generic.IList<int> Pago_oid {
        get { return pago_oid; } set { pago_oid = value;  }
}

private double saldo;
public double Saldo {
        get { return saldo; } set { saldo = value;  }
}


private System.Collections.Generic.IList<int> cobro_oid;
public System.Collections.Generic.IList<int> Cobro_oid {
        get { return cobro_oid; } set { cobro_oid = value;  }
}

private string descripcion;
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


private int duenyo_oid;
public int Duenyo_oid {
        get { return duenyo_oid; } set { duenyo_oid = value;  }
}

private double fondo;
public double Fondo {
        get { return fondo; } set { fondo = value;  }
}
private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
}
}
