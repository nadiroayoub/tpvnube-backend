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
public static class TipoPagoAssembler
{
public static TipoPagoDTOA Convert (TipoPagoEN en, NHibernate.ISession session = null)
{
        TipoPagoDTOA dto = null;
        TipoPagoRESTCAD tipoPagoRESTCAD = null;
        TipoPagoCEN tipoPagoCEN = null;
        TipoPagoCP tipoPagoCP = null;

        if (en != null) {
                dto = new TipoPagoDTOA ();
                tipoPagoRESTCAD = new TipoPagoRESTCAD (session);
                tipoPagoCEN = new TipoPagoCEN (tipoPagoRESTCAD);
                tipoPagoCP = new TipoPagoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Descripcion = en.Descripcion;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
