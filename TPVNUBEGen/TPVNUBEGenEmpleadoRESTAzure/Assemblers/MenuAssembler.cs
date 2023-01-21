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
public static class MenuAssembler
{
public static MenuDTOA Convert (MenuEN en, NHibernate.ISession session = null)
{
        MenuDTOA dto = null;
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;
        MenuCP menuCP = null;

        if (en != null) {
                dto = new MenuDTOA ();
                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);
                menuCP = new MenuCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Foto = en.Foto;


                dto.Precio = en.Precio;


                dto.Stock = en.Stock;


                //
                // TravesalLink

                /* Rol: Menu o--> Negocio */
                dto.NegocioMenu = NegocioAssembler.Convert ((NegocioEN)en.Negocio, session);


                //
                // Service
        }

        return dto;
}
}
}
