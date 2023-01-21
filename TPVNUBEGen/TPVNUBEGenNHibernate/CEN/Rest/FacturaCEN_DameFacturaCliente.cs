
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Factura_DameFacturaCliente) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class FacturaCEN
{
public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.FacturaEN> DameFacturaCliente (int p_idFactura, int p_comanda, int p_cliente)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Factura_DameFacturaCliente) ENABLED START*/

        // Write here your custom code...
        // Return all facturas of a Client

        FacturaCAD facturaCAD = new FacturaCAD ();

        // we have all facturas
        IList<FacturaEN> facturaAll = facturaCAD.ReadAll (0, 10);
        List<FacturaEN> facturasCliente = new List<FacturaEN>();

        foreach (var factura in facturaAll) {
                if (factura.Cliente.Id == p_cliente) {
                        facturasCliente.Add (factura);
                }
        }

        return facturasCliente;

        /*PROTECTED REGION END*/
}
}
}
