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

                dto.Saldo = en.Saldo;


                dto.Descripcion = en.Descripcion;


                dto.Fondo = en.Fondo;


                //
                // TravesalLink

                /* Rol: Caja o--> DuenyoRegistrado */
                dto.Duenyo = DuenyoRegistradoAssembler.Convert ((DuenyoEN)en.Duenyo, session);

                /* Rol: Caja o--> Cobro */
                dto.Cobros = null;
                List<CobroEN> Cobros = cajaRESTCAD.Cobros (en.Id).ToList ();
                if (Cobros != null) {
                        dto.Cobros = new List<CobroDTOA>();
                        foreach (CobroEN entry in Cobros)
                                dto.Cobros.Add (CobroAssembler.Convert (entry, session));
                }

                /* Rol: Caja o--> Negocio */
                dto.NegocioCaja = NegocioAssembler.Convert ((NegocioEN)en.Negocio, session);


                //
                // Service
        }

        return dto;
}
}
}
