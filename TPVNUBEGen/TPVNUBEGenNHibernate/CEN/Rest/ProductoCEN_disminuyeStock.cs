
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Producto_disminuyeStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class ProductoCEN
{
public void DisminuyeStock (int p_oid, double p_cantidad)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Producto_disminuyeStock) ENABLED START*/

        ProductoCAD productoCAD = new ProductoCAD ();
        ProductoEN productoEN = productoCAD.ReadOID (p_oid);

        productoEN.Stock = productoEN.Stock - p_cantidad;

        productoCAD.Modificar (productoEN);

        /*PROTECTED REGION END*/
}
}
}
