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
public static class ComandaAssembler
{
public static ComandaDTOA Convert (ComandaEN en, NHibernate.ISession session = null)
{
        ComandaDTOA dto = null;
        ComandaRESTCAD comandaRESTCAD = null;
        ComandaCEN comandaCEN = null;
        ComandaCP comandaCP = null;

        if (en != null) {
                dto = new ComandaDTOA ();
                comandaRESTCAD = new ComandaRESTCAD (session);
                comandaCEN = new ComandaCEN (comandaRESTCAD);
                comandaCP = new ComandaCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Fecha = en.Fecha;


                dto.Total = en.Total;


                dto.EstadoComanda = en.EstadoComanda;


                dto.Pdf = en.Pdf;


                //
                // TravesalLink

                /* Rol: Comanda o--> Factura */
                dto.Factura = FacturaAssembler.Convert ((FacturaEN)en.Factura, session);

                /* Rol: Comanda o--> Mesa */
                dto.MesaOfComanda = MesaAssembler.Convert ((MesaEN)en.Mesa, session);

                /* Rol: Comanda o--> LineaComanda */
                dto.AllLineaComandaOfComanda = null;
                List<LineaComandaEN> AllLineaComandaOfComanda = comandaRESTCAD.AllLineaComandaOfComanda (en.Id).ToList ();
                if (AllLineaComandaOfComanda != null) {
                        dto.AllLineaComandaOfComanda = new List<LineaComandaDTOA>();
                        foreach (LineaComandaEN entry in AllLineaComandaOfComanda)
                                dto.AllLineaComandaOfComanda.Add (LineaComandaAssembler.Convert (entry, session));
                }


                //
                // Service
        }

        return dto;
}
}
}
