
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Caja_incrementoSaldo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class CajaCEN
{
public void IncrementoSaldo (int p_oid, double p_monto)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Caja_incrementoSaldo) ENABLED START*/

        // Write here your custom code...

        CajaEN cajaEN = _ICajaCAD.ReadOID (p_oid);

        cajaEN.Saldo = cajaEN.Saldo + p_monto;

        _ICajaCAD.Modificar (cajaEN);

        /*PROTECTED REGION END*/
}
}
}
