using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

using TPVNUBEGenTpvhostRESTAzure.DTOA;
using TPVNUBEGenTpvhostRESTAzure.CAD;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CEN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;
using TPVNUBEGenNHibernate.CP.Rest;

namespace TPVNUBEGenTpvhostRESTAzure.Assemblers
{
public static class PedidoAssembler
{
public static PedidoDTOA Convert (ComandaEN en, NHibernate.ISession session = null)
{
        PedidoDTOA dto = null;
        PedidoRESTCAD pedidoRESTCAD = null;
        ComandaCEN comandaCEN = null;
        ComandaCP comandaCP = null;

        if (en != null) {
                dto = new PedidoDTOA ();
                pedidoRESTCAD = new PedidoRESTCAD (session);
                comandaCEN = new ComandaCEN (pedidoRESTCAD);
                comandaCP = new ComandaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.EstadoPedido = en.EstadoComanda;


                dto.Fecha = en.Fecha;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
