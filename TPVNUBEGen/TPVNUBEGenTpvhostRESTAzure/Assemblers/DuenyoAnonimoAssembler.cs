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
public static class DuenyoAnonimoAssembler
{
public static DuenyoAnonimoDTOA Convert (DuenyoEN en, NHibernate.ISession session = null)
{
        DuenyoAnonimoDTOA dto = null;
        DuenyoAnonimoRESTCAD duenyoAnonimoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoCP duenyoCP = null;

        if (en != null) {
                dto = new DuenyoAnonimoDTOA ();
                duenyoAnonimoRESTCAD = new DuenyoAnonimoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoAnonimoRESTCAD);
                duenyoCP = new DuenyoCP (session);





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
