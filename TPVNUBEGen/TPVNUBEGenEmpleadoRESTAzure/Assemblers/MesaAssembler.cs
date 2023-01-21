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
public static class MesaAssembler
{
public static MesaDTOA Convert (MesaEN en, NHibernate.ISession session = null)
{
        MesaDTOA dto = null;
        MesaRESTCAD mesaRESTCAD = null;
        MesaCEN mesaCEN = null;
        MesaCP mesaCP = null;

        if (en != null) {
                dto = new MesaDTOA ();
                mesaRESTCAD = new MesaRESTCAD (session);
                mesaCEN = new MesaCEN (mesaRESTCAD);
                mesaCP = new MesaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Estado = en.Estado;


                dto.Numero = en.Numero;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
