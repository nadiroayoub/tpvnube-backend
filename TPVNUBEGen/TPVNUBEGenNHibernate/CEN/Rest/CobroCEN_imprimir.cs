
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Cobro_imprimir) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class CobroCEN
{
public void Imprimir (int p_oid, int p_comanda)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Cobro_imprimir) ENABLED START*/

        // Write here your custom code...
        ComandaCAD comandaCAD = new ComandaCAD ();
        ComandaEN comandaEN = comandaCAD.ReadOID (p_comanda);

        IList<LineaComandaEN> lineaComanda = comandaEN.LineaComanda;

        CobroCAD cobroCAD = new CobroCAD ();
        CobroEN cobroEN = cobroCAD.ReadOID (p_oid);
        float precioTotal = cobroEN.Monto; // precio total del pedido

        // llamar la libreria para imprimir los datos obtenidos

        /*PROTECTED REGION END*/
}
}
}
