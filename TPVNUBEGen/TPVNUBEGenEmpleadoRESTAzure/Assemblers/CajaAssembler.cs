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
public static class CajaAssembler
{
public static CajaDTOA Convert (CajaEN en, NHibernate.ISession session = null)
{
        CajaDTOA dto = null;
        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;
        CajaCP cajaCP = null;

        if (en != null) {
                dto = new CajaDTOA ();
                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);
                cajaCP = new CajaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Fondo = en.Fondo;


                //
                // TravesalLink

                /* Rol: Caja o--> Pago */
                dto.Cobros = null;
                List<CobroEN> Cobros = cajaRESTCAD.Cobros (en.Id).ToList ();
                if (Cobros != null) {
                        dto.Cobros = new List<PagoDTOA>();
                        foreach (CobroEN entry in Cobros)
                                dto.Cobros.Add (PagoAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
