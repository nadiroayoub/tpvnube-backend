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
public static class LineaMenuAssembler
{
public static LineaMenuDTOA Convert (LineaMenuEN en, NHibernate.ISession session = null)
{
        LineaMenuDTOA dto = null;
        LineaMenuRESTCAD lineaMenuRESTCAD = null;
        LineaMenuCEN lineaMenuCEN = null;
        LineaMenuCP lineaMenuCP = null;

        if (en != null) {
                dto = new LineaMenuDTOA ();
                lineaMenuRESTCAD = new LineaMenuRESTCAD (session);
                lineaMenuCEN = new LineaMenuCEN (lineaMenuRESTCAD);
                lineaMenuCP = new LineaMenuCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Cantidad = en.Cantidad;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
