using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenEmpleadoRESTAzure.DTO
{
public partial class RolDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int cajero_oid;
public int Cajero_oid {
        get { return cajero_oid; } set { cajero_oid = value;  }
}



private int camarero_oid;
public int Camarero_oid {
        get { return camarero_oid; } set { camarero_oid = value;  }
}

private TPVNUBEGenNHibernate.Enumerated.Rest.EmpleoEnum empleo;
public TPVNUBEGenNHibernate.Enumerated.Rest.EmpleoEnum Empleo {
        get { return empleo; } set { empleo = value;  }
}


private int empleado_oid;
public int Empleado_oid {
        get { return empleado_oid; } set { empleado_oid = value;  }
}
}
}
