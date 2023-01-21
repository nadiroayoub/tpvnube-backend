using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class CamareroDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}



/* Rol: Camarero o--> Pedido */
private IList<PedidoDTOA> pedidos;
public IList<PedidoDTOA> Pedidos
{
        get { return pedidos; }
        set { pedidos = value; }
}
}
}
