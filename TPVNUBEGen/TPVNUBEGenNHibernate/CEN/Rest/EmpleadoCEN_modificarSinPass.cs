
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TPVNUBEGenNHibernate.Exceptions;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Empleado_modificarSinPass) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class EmpleadoCEN
{
public void ModificarSinPass (int p_Empleado_OID, string p_nombre, string p_apellidos, string p_foto, string p_dni, string p_email, string p_telefono)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Empleado_modificarSinPass_customized) START*/

        EmpleadoEN empleadoEN = null;

        //Initialized EmpleadoEN
        empleadoEN = new EmpleadoEN ();
        empleadoEN.Id = p_Empleado_OID;
        empleadoEN.Nombre = p_nombre;
        empleadoEN.Apellidos = p_apellidos;
        empleadoEN.Foto = p_foto;
        empleadoEN.Dni = p_dni;
        empleadoEN.Email = p_email;
        empleadoEN.Telefono = p_telefono;
        //Call to EmpleadoCAD

        _IEmpleadoCAD.ModificarSinPass (empleadoEN);

        /*PROTECTED REGION END*/
}
}
}
