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
public static class NegocioAssembler
{
public static NegocioDTOA Convert (NegocioEN en, NHibernate.ISession session = null)
{
        NegocioDTOA dto = null;
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioCEN negocioCEN = null;
        NegocioCP negocioCP = null;

        if (en != null) {
                dto = new NegocioDTOA ();
                negocioRESTCAD = new NegocioRESTCAD (session);
                negocioCEN = new NegocioCEN (negocioRESTCAD);
                negocioCP = new NegocioCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Direccion = en.Direccion;


                dto.Ciudad = en.Ciudad;


                dto.Cp = en.Cp;


                dto.Provincia = en.Provincia;


                dto.Pais = en.Pais;


                //
                // TravesalLink

                /* Rol: Negocio o--> Empresa */
                dto.Empresa = EmpresaAssembler.Convert ((EmpresaEN)en.Empresa, session);


                //
                // Service
        }

        return dto;
}
}
}
