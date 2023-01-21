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
public static class EmpresaAssembler
{
public static EmpresaDTOA Convert (EmpresaEN en, NHibernate.ISession session = null)
{
        EmpresaDTOA dto = null;
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaCEN empresaCEN = null;
        EmpresaCP empresaCP = null;

        if (en != null) {
                dto = new EmpresaDTOA ();
                empresaRESTCAD = new EmpresaRESTCAD (session);
                empresaCEN = new EmpresaCEN (empresaRESTCAD);
                empresaCP = new EmpresaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Direccion = en.Direccion;


                dto.Cif = en.Cif;


                dto.Email = en.Email;


                dto.Fechaconstitucion = en.Fechaconstitucion;


                dto.Telefono = en.Telefono;


                dto.Ciudad = en.Ciudad;


                dto.Pais = en.Pais;


                dto.Cp = en.Cp;


                dto.Provincia = en.Provincia;


                //
                // TravesalLink


                //
                // Service
        }

        return dto;
}
}
}
