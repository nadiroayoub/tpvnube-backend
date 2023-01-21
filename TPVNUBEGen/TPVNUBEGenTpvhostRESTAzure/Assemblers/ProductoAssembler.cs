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
public static class ProductoAssembler
{
public static ProductoDTOA Convert (ProductoEN en, NHibernate.ISession session = null)
{
        ProductoDTOA dto = null;
        ProductoRESTCAD productoRESTCAD = null;
        ProductoCEN productoCEN = null;
        ProductoCP productoCP = null;

        if (en != null) {
                dto = new ProductoDTOA ();
                productoRESTCAD = new ProductoRESTCAD (session);
                productoCEN = new ProductoCEN (productoRESTCAD);
                productoCP = new ProductoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Stock = en.Stock;


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
