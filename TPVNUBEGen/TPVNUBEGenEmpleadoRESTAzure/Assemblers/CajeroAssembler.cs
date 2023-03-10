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
public static class CajeroAssembler
{
public static CajeroDTOA Convert (CajeroEN en, NHibernate.ISession session = null)
{
        CajeroDTOA dto = null;
        CajeroRESTCAD cajeroRESTCAD = null;
        CajeroCEN cajeroCEN = null;
        CajeroCP cajeroCP = null;

        if (en != null) {
                dto = new CajeroDTOA ();
                cajeroRESTCAD = new CajeroRESTCAD (session);
                cajeroCEN = new CajeroCEN (cajeroRESTCAD);
                cajeroCP = new CajeroCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                //
                // TravesalLink

                /* Rol: Cajero o--> Caja */
                dto.Cajas = null;
                List<CajaEN> Cajas = cajeroRESTCAD.Cajas (en.Id).ToList ();
                if (Cajas != null) {
                        dto.Cajas = new List<CajaDTOA>();
                        foreach (CajaEN entry in Cajas)
                                dto.Cajas.Add (CajaAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
