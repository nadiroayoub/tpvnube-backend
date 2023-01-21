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

                dto.Fecha = en.Fecha;


                dto.EstadoPedido = en.EstadoPedido;


                dto.Total = en.Total;


                //
                // TravesalLink

                /* Rol: Pedido o--> LineaPedido */
                dto.Lineas = null;
                List<LineaComandaEN> Lineas = pedidoRESTCAD.Lineas (en.Id).ToList ();
                if (Lineas != null) {
                        dto.Lineas = new List<LineaPedidoDTOA>();
                        foreach (LineaComandaEN entry in Lineas)
                                dto.Lineas.Add (LineaPedidoAssembler.Convert (entry, session));
                }

                /* Rol: Pedido o--> Factura */
                dto.Factura = FacturaAssembler.Convert ((FacturaEN)en.Factura, session);

                /* Rol: Pedido o--> Mesa */
                dto.MesaComanda = MesaAssembler.Convert ((MesaEN)en.Mesa, session);


                //
                // Service
        }

        return dto;
}
}
}
