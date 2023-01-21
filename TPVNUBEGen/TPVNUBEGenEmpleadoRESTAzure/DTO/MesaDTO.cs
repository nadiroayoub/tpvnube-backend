using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenEmpleadoRESTAzure.DTO
{
public partial class MesaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private System.Collections.Generic.IList<int> comanda_oid;
public System.Collections.Generic.IList<int> Comanda_oid {
        get { return comanda_oid; } set { comanda_oid = value;  }
}

private TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum estado;
public TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum Estado {
        get { return estado; } set { estado = value;  }
}
private int numero;
public int Numero {
        get { return numero; } set { numero = value;  }
}


private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}
}
}
