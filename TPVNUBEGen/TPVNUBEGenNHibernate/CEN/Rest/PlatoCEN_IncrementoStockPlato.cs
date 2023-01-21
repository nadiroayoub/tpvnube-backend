
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Plato_IncrementoStockPlato) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class PlatoCEN
{
public void IncrementoStockPlato (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Plato_IncrementoStockPlato) ENABLED START*/

        // Write here your custom code...
        PlatoCAD platoCAD = new PlatoCAD ();
        PlatoEN platoEN = platoCAD.ReadOID (p_oid);

        // tomate + zanahoria
        foreach (var lineaPlato in platoEN.LineaPlato) {
                lineaPlato.Cantidad = platoEN.LineaPlato [0].Cantidad + p_cantidad;
        }

        platoCAD.Modificar (platoEN);
        /*PROTECTED REGION END*/
}
}
}
