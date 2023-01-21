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
public static class LineaComandaAssembler
{
public static LineaComandaDTOA Convert (LineaComandaEN en, NHibernate.ISession session = null)
{
        LineaComandaDTOA dto = null;
        LineaComandaRESTCAD lineaComandaRESTCAD = null;
        LineaComandaCEN lineaComandaCEN = null;
        LineaComandaCP lineaComandaCP = null;

        if (en != null) {
                dto = new LineaComandaDTOA ();
                lineaComandaRESTCAD = new LineaComandaRESTCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaComandaRESTCAD);
                lineaComandaCP = new LineaComandaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Cantidad = en.Cantidad;


                //
                // TravesalLink

                /* Rol: LineaComanda o--> Plato */
                dto.PlatoOfLineaComanda = PlatoAssembler.Convert ((PlatoEN)en.Plato, session);

                /* Rol: LineaComanda o--> Menu */
                dto.MenuOfLineaComanda = MenuAssembler.Convert ((MenuEN)en.Menu, session);


                //
                // Service
        }

        return dto;
}
}
}
