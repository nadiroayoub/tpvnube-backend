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
public static class CobroAssembler
{
public static CobroDTOA Convert (CobroEN en, NHibernate.ISession session = null)
{
        CobroDTOA dto = null;
        CobroRESTCAD cobroRESTCAD = null;
        CobroCEN cobroCEN = null;
        CobroCP cobroCP = null;

        if (en != null) {
                dto = new CobroDTOA ();
                cobroRESTCAD = new CobroRESTCAD (session);
                cobroCEN = new CobroCEN (cobroRESTCAD);
                cobroCP = new CobroCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Monto = en.Monto;


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
