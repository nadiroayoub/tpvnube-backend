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
public static class LineaCompraProveedorAssembler
{
public static LineaCompraProveedorDTOA Convert (LineaCompraProveedorEN en, NHibernate.ISession session = null)
{
        LineaCompraProveedorDTOA dto = null;
        LineaCompraProveedorRESTCAD lineaCompraProveedorRESTCAD = null;
        LineaCompraProveedorCEN lineaCompraProveedorCEN = null;
        LineaCompraProveedorCP lineaCompraProveedorCP = null;

        if (en != null) {
                dto = new LineaCompraProveedorDTOA ();
                lineaCompraProveedorRESTCAD = new LineaCompraProveedorRESTCAD (session);
                lineaCompraProveedorCEN = new LineaCompraProveedorCEN (lineaCompraProveedorRESTCAD);
                lineaCompraProveedorCP = new LineaCompraProveedorCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Cantidad = en.Cantidad;


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
