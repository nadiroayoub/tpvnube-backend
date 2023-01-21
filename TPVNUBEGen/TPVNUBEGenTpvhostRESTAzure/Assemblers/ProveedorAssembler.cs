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
public static class ProveedorAssembler
{
public static ProveedorDTOA Convert (ProveedorEN en, NHibernate.ISession session = null)
{
        ProveedorDTOA dto = null;
        ProveedorRESTCAD proveedorRESTCAD = null;
        ProveedorCEN proveedorCEN = null;
        ProveedorCP proveedorCP = null;

        if (en != null) {
                dto = new ProveedorDTOA ();
                proveedorRESTCAD = new ProveedorRESTCAD (session);
                proveedorCEN = new ProveedorCEN (proveedorRESTCAD);
                proveedorCP = new ProveedorCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Email = en.Email;


                dto.Telefono = en.Telefono;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
