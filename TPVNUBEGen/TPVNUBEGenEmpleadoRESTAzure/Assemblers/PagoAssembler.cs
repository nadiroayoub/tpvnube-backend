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
public static class PagoAssembler
{
public static PagoDTOA Convert (CobroEN en, NHibernate.ISession session = null)
{
        PagoDTOA dto = null;
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;
        CobroCP cobroCP = null;

        if (en != null) {
                dto = new PagoDTOA ();
                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);
                cobroCP = new CobroCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Monto = en.Monto;


                //
                // TravesalLink

                /* Rol: Pago o--> Cliente */
                dto.Cliente = ClienteAssembler.Convert ((ClienteEN)en.Cliente, session);


                //
                // Service
        }

        return dto;
}
}
}
