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
public static class ClienteAssembler
{
public static ClienteDTOA Convert (ClienteEN en, NHibernate.ISession session = null)
{
        ClienteDTOA dto = null;
        ClienteRESTCAD clienteRESTCAD = null;
        ClienteCEN clienteCEN = null;
        ClienteCP clienteCP = null;

        if (en != null) {
                dto = new ClienteDTOA ();
                clienteRESTCAD = new ClienteRESTCAD (session);
                clienteCEN = new ClienteCEN (clienteRESTCAD);
                clienteCP = new ClienteCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Apellidos = en.Apellidos;


                dto.Dni = en.Dni;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
