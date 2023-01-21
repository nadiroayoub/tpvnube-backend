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

                dto.Apellidos = en.Apellidos;


                dto.Nombre = en.Nombre;


                dto.Foto = en.Foto;


                dto.Pass = en.Pass;


                dto.Dni = en.Dni;


                dto.Email = en.Email;


                dto.Telefono = en.Telefono;


                //
                // TravesalLink

                /* Rol: Empleado o--> Negocio */
                dto.Negocio = NegocioAssembler.Convert ((NegocioEN)en.Negocio, session);


                //
                // Service
        }

        return dto;
}
}
}
