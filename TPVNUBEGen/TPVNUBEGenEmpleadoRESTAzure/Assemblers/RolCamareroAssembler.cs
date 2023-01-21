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
public static class RolCamareroAssembler
{
public static RolCamareroDTOA Convert (RolEN en, NHibernate.ISession session = null)
{
        RolCamareroDTOA dto = null;
        RolCamareroRESTCAD rolCamareroRESTCAD = null;
        RolCEN rolCEN = null;
        RolCP rolCP = null;

        if (en != null) {
                dto = new RolCamareroDTOA ();
                rolCamareroRESTCAD = new RolCamareroRESTCAD (session);
                rolCEN = new RolCEN (rolCamareroRESTCAD);
                rolCP = new RolCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink

                /* Rol: RolCamarero o--> Camarero */
                dto.Camarero = CamareroAssembler.Convert ((CamareroEN)en.Camarero, session);


                //
                // Service
        }

        return dto;
}
}
}
