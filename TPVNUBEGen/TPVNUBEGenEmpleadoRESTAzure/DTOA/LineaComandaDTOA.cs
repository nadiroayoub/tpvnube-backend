using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class LineaComandaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private int cantidad;
public int Cantidad
{
        get { return cantidad; }
        set { cantidad = value; }
}


/* Rol: LineaComanda o--> Plato */
private PlatoDTOA platoOfLineaComanda;
public PlatoDTOA PlatoOfLineaComanda
{
        get { return platoOfLineaComanda; }
        set { platoOfLineaComanda = value; }
}

/* Rol: LineaComanda o--> Menu */
private MenuDTOA menuOfLineaComanda;
public MenuDTOA MenuOfLineaComanda
{
        get { return menuOfLineaComanda; }
        set { menuOfLineaComanda = value; }
}
}
}
