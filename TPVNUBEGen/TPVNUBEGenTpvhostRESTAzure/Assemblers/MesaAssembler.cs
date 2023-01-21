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

                /* Rol: Mesa o--> Negocio */
                dto.NegocioMesa = NegocioAssembler.Convert ((NegocioEN)en.Negocio, session);


                //
                // Service
        }

        return dto;
}
}
}
