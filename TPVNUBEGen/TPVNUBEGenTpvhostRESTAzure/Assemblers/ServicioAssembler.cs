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
public static class ServicioAssembler
{
public static ServicioDTOA Convert (ServicioEN en, NHibernate.ISession session = null)
{
        ServicioDTOA dto = null;
        ServicioRESTCAD servicioRESTCAD = null;
        ServicioCEN servicioCEN = null;
        ServicioCP servicioCP = null;

        if (en != null) {
                dto = new ServicioDTOA ();
                servicioRESTCAD = new ServicioRESTCAD (session);
                servicioCEN = new ServicioCEN (servicioRESTCAD);
                servicioCP = new ServicioCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Costo = en.Costo;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
