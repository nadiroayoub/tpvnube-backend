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
public static class TipoPlatoAssembler
{
public static TipoPlatoDTOA Convert (TipoPlatoEN en, NHibernate.ISession session = null)
{
        TipoPlatoDTOA dto = null;
        TipoPlatoRESTCAD tipoPlatoRESTCAD = null;
        TipoPlatoCEN tipoPlatoCEN = null;
        TipoPlatoCP tipoPlatoCP = null;

        if (en != null) {
                dto = new TipoPlatoDTOA ();
                tipoPlatoRESTCAD = new TipoPlatoRESTCAD (session);
                tipoPlatoCEN = new TipoPlatoCEN (tipoPlatoRESTCAD);
                tipoPlatoCP = new TipoPlatoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
