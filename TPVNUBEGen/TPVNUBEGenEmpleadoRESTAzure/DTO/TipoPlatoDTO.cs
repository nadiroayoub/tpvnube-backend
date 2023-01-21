using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenEmpleadoRESTAzure.DTO
{
public partial class TipoPlatoDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}


private System.Collections.Generic.IList<int> plato_oid;
public System.Collections.Generic.IList<int> Plato_oid {
        get { return plato_oid; } set { plato_oid = value;  }
}
}
}
