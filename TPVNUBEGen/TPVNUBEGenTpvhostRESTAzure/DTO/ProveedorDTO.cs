using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenTpvhostRESTAzure.DTO
{
public partial class ProveedorDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}


private System.Collections.Generic.IList<int> compraProveedor_oid;
public System.Collections.Generic.IList<int> CompraProveedor_oid {
        get { return compraProveedor_oid; } set { compraProveedor_oid = value;  }
}

private string email;
public string Email {
        get { return email; } set { email = value;  }
}
private string telefono;
public string Telefono {
        get { return telefono; } set { telefono = value;  }
}
}
}
