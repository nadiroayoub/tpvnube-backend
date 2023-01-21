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
public static class DuenyoRegistradoAssembler
{
public static DuenyoRegistradoDTOA Convert (DuenyoEN en, NHibernate.ISession session = null)
{
        DuenyoRegistradoDTOA dto = null;
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoCP duenyoCP = null;

        if (en != null) {
                dto = new DuenyoRegistradoDTOA ();
                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);
                duenyoCP = new DuenyoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Telefono = en.Telefono;


                dto.Email = en.Email;


                dto.Dni = en.Dni;


                dto.Pass = en.Pass;


                dto.Foto = en.Foto;


                dto.Apellidos = en.Apellidos;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
