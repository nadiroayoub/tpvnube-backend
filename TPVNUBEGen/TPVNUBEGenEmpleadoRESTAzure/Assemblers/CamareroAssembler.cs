using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using TPVNUBEGenEmpleadoRESTAzure.DTOA;
using TPVNUBEGenEmpleadoRESTAzure.CAD;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CEN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;
using TPVNUBEGenNHibernate.CP.Rest;

namespace TPVNUBEGenEmpleadoRESTAzure.Assemblers
{
public static class CamareroAssembler
{
public static CamareroDTOA Convert (CamareroEN en, NHibernate.ISession session = null)
{
        CamareroDTOA dto = null;
        CamareroRESTCAD camareroRESTCAD = null;
        CamareroCEN camareroCEN = null;
        CamareroCP camareroCP = null;

        if (en != null) {
                dto = new CamareroDTOA ();
                camareroRESTCAD = new CamareroRESTCAD (session);
                camareroCEN = new CamareroCEN (camareroRESTCAD);
                camareroCP = new CamareroCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink

                /* Rol: Camarero o--> Pedido */
                dto.Pedidos = null;
                List<ComandaEN> Pedidos = camareroRESTCAD.Pedidos (en.Id).ToList ();
                if (Pedidos != null) {
                        dto.Pedidos = new List<PedidoDTOA>();
                        foreach (ComandaEN entry in Pedidos)
                                dto.Pedidos.Add (PedidoAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
