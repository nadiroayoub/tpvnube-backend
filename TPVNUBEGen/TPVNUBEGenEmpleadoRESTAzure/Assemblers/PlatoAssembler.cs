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
public static class PlatoAssembler
{
public static PlatoDTOA Convert (PlatoEN en, NHibernate.ISession session = null)
{
        PlatoDTOA dto = null;
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;
        PlatoCP platoCP = null;

        if (en != null) {
                dto = new PlatoDTOA ();
                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);
                platoCP = new PlatoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Stock = en.Stock;


                dto.Precio = en.Precio;


                dto.Foto = en.Foto;


                //
                // TravesalLink

                /* Rol: Plato o--> Negocio */
                dto.NegocioPlato = NegocioAssembler.Convert ((NegocioEN)en.Negocio, session);


                //
                // Service
        }

        return dto;
}
}
}
