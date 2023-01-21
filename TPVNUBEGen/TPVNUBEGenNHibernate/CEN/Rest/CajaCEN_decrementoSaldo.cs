
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Caja_decrementoSaldo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class CajaCEN
{
public void DecrementoSaldo (int p_oid, double p_monto)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Caja_decrementoSaldo) ENABLED START*/

        // Write here your custom code...
        CajaCAD cajaCAD = new CajaCAD ();
        CajaEN cajaEN = cajaCAD.ReadOID (p_oid);

        cajaEN.Saldo = cajaEN.Saldo - p_monto;

        cajaCAD.Modificar (cajaEN);

        /*PROTECTED REGION END*/
}
}
}
