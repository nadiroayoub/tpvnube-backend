
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Duenyo_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class DuenyoCEN
{
public string Login (string p_email, string p_pass)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Duenyo_login) ENABLED START*/
        string result = null;

        IList<DuenyoEN> list = _IDuenyoCAD.DamePorEmail (p_email);
        if (list.Count > 0) {
                DuenyoEN duenyo = list [0];
                if (duenyo.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass))) {
                        result = this.GetToken (duenyo.Id);
                }
        }
        return result;

        /*PROTECTED REGION END*/
}
}
}
