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
public static class UnidadMedidaAssembler
{
public static UnidadMedidaDTOA Convert (UnidadMedidaEN en, NHibernate.ISession session = null)
{
        UnidadMedidaDTOA dto = null;
        UnidadMedidaRESTCAD unidadMedidaRESTCAD = null;
        UnidadMedidaCEN unidadMedidaCEN = null;
        UnidadMedidaCP unidadMedidaCP = null;

        if (en != null) {
                dto = new UnidadMedidaDTOA ();
                unidadMedidaRESTCAD = new UnidadMedidaRESTCAD (session);
                unidadMedidaCEN = new UnidadMedidaCEN (unidadMedidaRESTCAD);
                unidadMedidaCP = new UnidadMedidaCP (session);





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
