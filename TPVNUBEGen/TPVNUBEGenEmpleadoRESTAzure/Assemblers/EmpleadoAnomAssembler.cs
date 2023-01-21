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
public static class EmpleadoAnomAssembler
{
public static EmpleadoAnomDTOA Convert (EmpleadoEN en, NHibernate.ISession session = null)
{
        EmpleadoAnomDTOA dto = null;
        EmpleadoAnomRESTCAD empleadoAnomRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCP empleadoCP = null;

        if (en != null) {
                dto = new EmpleadoAnomDTOA ();
                empleadoAnomRESTCAD = new EmpleadoAnomRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoAnomRESTCAD);
                empleadoCP = new EmpleadoCP (session);





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
