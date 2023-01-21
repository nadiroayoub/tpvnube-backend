
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Pago_actualizarCaja) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class PagoCEN
{
public void ActualizarCaja (int p_oid, int p_caja)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Pago_actualizarCaja) ENABLED START*/
        // p_oid  : id de pago
        // p_caja : id de caja
        // Write here your custom code...

        PagoCAD pagoCAD = new PagoCAD ();
        PagoEN pagoEN = pagoCAD.ReadOID (p_oid);

        CajaCAD cajaCAD = new CajaCAD ();
        CajaEN cajaEN = cajaCAD.ReadOID (p_caja);

        cajaEN.Saldo = cajaEN.Saldo - pagoEN.Monto;

        cajaCAD.Modificar (cajaEN);

        /*PROTECTED REGION END*/
}
}
}
