using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenEmpleadoRESTAzure.DTO
{
public partial class EmpresaDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string direccion;
public string Direccion {
        get { return direccion; } set { direccion = value;  }
}


private int duenyo_oid;
public int Duenyo_oid {
        get { return duenyo_oid; } set { duenyo_oid = value;  }
}



private System.Collections.Generic.IList<int> negocio_oid;
public System.Collections.Generic.IList<int> Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}

private string cif;
public string Cif {
        get { return cif; } set { cif = value;  }
}
private string email;
public string Email {
        get { return email; } set { email = value;  }
}
private Nullable<DateTime> fechaconstitucion;
public Nullable<DateTime> Fechaconstitucion {
        get { return fechaconstitucion; } set { fechaconstitucion = value;  }
}
private string telefono;
public string Telefono {
        get { return telefono; } set { telefono = value;  }
}
private string provincia;
public string Provincia {
        get { return provincia; } set { provincia = value;  }
}
private string ciudad;
public string Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}
private string pais;
public string Pais {
        get { return pais; } set { pais = value;  }
}
private string cp;
public string Cp {
        get { return cp; } set { cp = value;  }
}
}
}
