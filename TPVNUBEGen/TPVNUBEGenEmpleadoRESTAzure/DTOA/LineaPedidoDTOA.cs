using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class LineaPedidoDTOA
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


/* GetAll: Plato */
private IList<PlatoDTOA> platos;
public IList<PlatoDTOA> Platos
{
        get { return platos; }
        set { platos = value; }
}

/* Rol: LineaPedido o--> Menu */
private MenuDTOA menus;
public MenuDTOA Menus
{
        get { return menus; }
        set { menus = value; }
}
}
}
