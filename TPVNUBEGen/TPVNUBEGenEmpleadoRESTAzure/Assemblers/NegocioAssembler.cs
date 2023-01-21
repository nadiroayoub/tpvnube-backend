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

                /* Rol: Negocio o--> Caja */
                dto.CajaOfNegocio = null;
                List<CajaEN> CajaOfNegocio = negocioRESTCAD.CajaOfNegocio (en.Id).ToList ();
                if (CajaOfNegocio != null) {
                        dto.CajaOfNegocio = new List<CajaDTOA>();
                        foreach (CajaEN entry in CajaOfNegocio)
                                dto.CajaOfNegocio.Add (CajaAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
