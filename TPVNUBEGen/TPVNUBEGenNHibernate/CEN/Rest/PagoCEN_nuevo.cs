
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Pago_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class PagoCEN
{
public int Nuevo (double p_monto, Nullable<DateTime> p_fechaPago, int p_tipoPago, int p_numeroDocumento, int p_caja)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Pago_nuevo_customized) START*/

        PagoEN pagoEN = null;

        int oid;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.Monto = p_monto;

        pagoEN.FechaPago = p_fechaPago;


        if (p_tipoPago != -1) {
                pagoEN.TipoPago = new TPVNUBEGenNHibernate.EN.Rest.TipoPagoEN ();
                pagoEN.TipoPago.Id = p_tipoPago;
        }

        pagoEN.NumeroDocumento = p_numeroDocumento;


        if (p_caja != -1) {
                pagoEN.Caja = new TPVNUBEGenNHibernate.EN.Rest.CajaEN ();
                pagoEN.Caja.Id = p_caja;
        }

        //Call to PagoCAD

        oid = _IPagoCAD.Nuevo (pagoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
