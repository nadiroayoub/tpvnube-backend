
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Empleado_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class EmpleadoCEN
{
public string Login (string p_email, string p_pass)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Empleado_login) ENABLED START*/
        string result = null;

        IList<EmpleadoEN> list = _IEmpleadoCAD.DamePorEmail (p_email);
        if (list.Count > 0) {
                EmpleadoEN emp = list [0];
                if (emp.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass))) {
                        result = this.GetToken (emp.Id);
                }
        }
        return result == null ? "" : result;

        /*PROTECTED REGION END*/
}
}
}
