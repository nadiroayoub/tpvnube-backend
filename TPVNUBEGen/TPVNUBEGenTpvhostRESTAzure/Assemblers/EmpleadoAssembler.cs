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
public static class EmpleadoAssembler
{
public static EmpleadoDTOA Convert (EmpleadoEN en, NHibernate.ISession session = null)
{
        EmpleadoDTOA dto = null;
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoCP empleadoCP = null;

        if (en != null) {
                dto = new EmpleadoDTOA ();
                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);
                empleadoCP = new EmpleadoCP (session);





                //
                // Attributes

                dto.Id = en.Id;

                dto.Nombre = en.Nombre;


                dto.Apellidos = en.Apellidos;


                dto.Pass = en.Pass;


                dto.Foto = en.Foto;


                dto.Dni = en.Dni;


                dto.Email = en.Email;


                //
                // TravesalLink

                /* Rol: Empleado o--> Pedido */
                dto.Comandas = null;
                List<ComandaEN> Comandas = empleadoRESTCAD.Comandas (en.Id).ToList ();
                if (Comandas != null) {
                        dto.Comandas = new List<PedidoDTOA>();
                        foreach (ComandaEN entry in Comandas)
                                dto.Comandas.Add (PedidoAssembler.Convert (entry, session));
                }

                /* Rol: Empleado o--> Negocio */
                dto.NegocioEmpleado = NegocioAssembler.Convert ((NegocioEN)en.Negocio, session);


                //
                // Service
        }

        return dto;
}
}
}
