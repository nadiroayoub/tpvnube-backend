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

                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
