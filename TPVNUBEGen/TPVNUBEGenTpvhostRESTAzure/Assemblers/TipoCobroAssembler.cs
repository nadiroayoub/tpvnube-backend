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
public static class TipoCobroAssembler
{
public static TipoCobroDTOA Convert (TipoCobroEN en, NHibernate.ISession session = null)
{
        TipoCobroDTOA dto = null;
        TipoCobroRESTCAD tipoCobroRESTCAD = null;
        TipoCobroCEN tipoCobroCEN = null;
        TipoCobroCP tipoCobroCP = null;

        if (en != null) {
                dto = new TipoCobroDTOA ();
                tipoCobroRESTCAD = new TipoCobroRESTCAD (session);
                tipoCobroCEN = new TipoCobroCEN (tipoCobroRESTCAD);
                tipoCobroCP = new TipoCobroCP (session);





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
