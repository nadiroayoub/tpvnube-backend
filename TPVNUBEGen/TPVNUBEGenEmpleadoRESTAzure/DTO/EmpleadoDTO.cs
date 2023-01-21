using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenEmpleadoRESTAzure.DTO
{
public partial class EmpleadoDTO
{
private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}

private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string apellidos;
public string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}
private String pass;
public String Pass {
        get { return pass; } set { pass = value;  }
}
private string foto;
public string Foto {
        get { return foto; } set { foto = value;  }
}


private System.Collections.Generic.IList<int> comanda_oid;
public System.Collections.Generic.IList<int> Comanda_oid {
        get { return comanda_oid; } set { comanda_oid = value;  }
}

private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string dni;
public string Dni {
        get { return dni; } set { dni = value;  }
}
private string email;
public string Email {
        get { return email; } set { email = value;  }
}
private string telefono;
public string Telefono {
        get { return telefono; } set { telefono = value;  }
}


private System.Collections.Generic.IList<int> cobro_oid;
public System.Collections.Generic.IList<int> Cobro_oid {
        get { return cobro_oid; } set { cobro_oid = value;  }
}
}
}
