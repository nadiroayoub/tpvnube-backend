
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Pago_actualizaBanco) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class PagoCEN
{
public void ActualizaBanco (int p_oid)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Pago_actualizaBanco) ENABLED START*/

        PagoCAD pagoCAD = new PagoCAD ();
        PagoEN pagoEN = pagoCAD.ReadOID (p_oid);

        // TODO: Library for bank account


        /*PROTECTED REGION END*/
}
}
}
