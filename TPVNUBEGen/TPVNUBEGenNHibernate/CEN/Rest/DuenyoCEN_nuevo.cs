
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Duenyo_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class DuenyoCEN
{
public int Nuevo (string p_dni, string p_nombre, string p_apellidos, string p_telefono, String p_pass, string p_email, string p_foto)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Duenyo_nuevo_customized) START*/

        DuenyoEN duenyoEN = null;

        int oid;

        //Initialized DuenyoEN
        duenyoEN = new DuenyoEN ();
        duenyoEN.Dni = p_dni;

        duenyoEN.Nombre = p_nombre;

        duenyoEN.Apellidos = p_apellidos;

        duenyoEN.Telefono = p_telefono;

        duenyoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        duenyoEN.Email = p_email;

        duenyoEN.Foto = p_foto;

        //Call to DuenyoCAD

        oid = _IDuenyoCAD.Nuevo (duenyoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
