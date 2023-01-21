
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Pago_actualizarSaldoCompraProv) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class PagoCEN
{
public void ActualizarSaldoCompraProv (TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN p_pedidoProveedor, double monto)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Pago_actualizarSaldoCompraProv) ENABLED START*/

        // Write here your custom code...

        p_pedidoProveedor.EstadoCompra = Enumerated.Rest.EstadoCompraProveedorEnum.pagado;

        /*PROTECTED REGION END*/
}
}
}
