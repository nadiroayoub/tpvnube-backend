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
public static class LineaPedidoAssembler
{
public static LineaPedidoDTOA Convert (LineaComandaEN en, NHibernate.ISession session = null)
{
        LineaPedidoDTOA dto = null;
        LineaPedidoRESTCAD lineaPedidoRESTCAD = null;
        LineaComandaCEN lineaComandaCEN = null;
        LineaComandaCP lineaComandaCP = null;

        if (en != null) {
                dto = new LineaPedidoDTOA ();
                lineaPedidoRESTCAD = new LineaPedidoRESTCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaPedidoRESTCAD);
                lineaComandaCP = new LineaComandaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Cantidad = en.Cantidad;


                //
                // TravesalLink

                /* GetAll: Plato */
                dto.Platos = null;
                List<PlatoEN> platos_list = new PlatoCAD (session).ReadAllDefault (0, -1).ToList ();
                if (platos_list != null) {
                        dto.Platos = new List<PlatoDTOA>();
                        foreach (PlatoEN entry in platos_list)
                                dto.Platos.Add (PlatoAssembler.Convert (entry, session));
                }

                /* Rol: LineaPedido o--> Menu */
                dto.Menus = MenuAssembler.Convert ((MenuEN)en.Menu, session);


                //
                // Service
        }

        return dto;
}
}
}
