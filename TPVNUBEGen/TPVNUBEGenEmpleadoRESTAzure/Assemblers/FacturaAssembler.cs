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
public static class FacturaAssembler
{
public static FacturaDTOA Convert (FacturaEN en, NHibernate.ISession session = null)
{
        FacturaDTOA dto = null;
        FacturaRESTCAD facturaRESTCAD = null;
        FacturaCEN facturaCEN = null;
        FacturaCP facturaCP = null;

        if (en != null) {
                dto = new FacturaDTOA ();
                facturaRESTCAD = new FacturaRESTCAD (session);
                facturaCEN = new FacturaCEN (facturaRESTCAD);
                facturaCP = new FacturaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Numero = en.Numero;


                dto.Fecha = en.Fecha;


                dto.Precio = en.Precio;


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
