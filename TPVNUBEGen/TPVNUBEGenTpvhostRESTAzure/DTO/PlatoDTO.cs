using System;
using System.Runtime.Serialization;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenTpvhostRESTAzure.DTO
{
public partial class PlatoDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string nombre;
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private double stock;
public double Stock {
        get { return stock; } set { stock = value;  }
}
private double precio;
public double Precio {
        get { return precio; } set { precio = value;  }
}
private System.Collections.Generic.IList<LineaPlatoDTO> lineaPlato;
public System.Collections.Generic.IList<LineaPlatoDTO> LineaPlato {
        get { return lineaPlato; } set { lineaPlato = value;  }
}
private System.Collections.Generic.IList<LineaMenuDTO> lineaMenu;
public System.Collections.Generic.IList<LineaMenuDTO> LineaMenu {
        get { return lineaMenu; } set { lineaMenu = value;  }
}
private string foto;
public string Foto {
        get { return foto; } set { foto = value;  }
}


private int tipoPlato_oid;
public int TipoPlato_oid {
        get { return tipoPlato_oid; } set { tipoPlato_oid = value;  }
}



private System.Collections.Generic.IList<int> lineaComanda_oid;
public System.Collections.Generic.IList<int> LineaComanda_oid {
        get { return lineaComanda_oid; } set { lineaComanda_oid = value;  }
}



private int negocio_oid;
public int Negocio_oid {
        get { return negocio_oid; } set { negocio_oid = value;  }
}
}
}
