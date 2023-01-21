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
public static class CategoriaServicioAssembler
{
public static CategoriaServicioDTOA Convert (CategoriaServicioEN en, NHibernate.ISession session = null)
{
        CategoriaServicioDTOA dto = null;
        CategoriaServicioRESTCAD categoriaServicioRESTCAD = null;
        CategoriaServicioCEN categoriaServicioCEN = null;
        CategoriaServicioCP categoriaServicioCP = null;

        if (en != null) {
                dto = new CategoriaServicioDTOA ();
                categoriaServicioRESTCAD = new CategoriaServicioRESTCAD (session);
                categoriaServicioCEN = new CategoriaServicioCEN (categoriaServicioRESTCAD);
                categoriaServicioCP = new CategoriaServicioCP (session);





                //
                // Attributes

                dto.Id = en.Id;

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
