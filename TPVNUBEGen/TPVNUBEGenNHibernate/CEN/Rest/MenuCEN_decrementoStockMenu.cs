
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Menu_decrementoStockMenu) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class MenuCEN
{
public void DecrementoStockMenu (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Menu_decrementoStockMenu) ENABLED START*/

        // Write here your custom code...

        MenuCAD menuCAD = new MenuCAD ();
        MenuEN menuEN = menuCAD.ReadOID (p_oid);

        menuEN.Stock = menuEN.Stock - p_cantidad;

        menuCAD.Modificar (menuEN);

        /*PROTECTED REGION END*/
}
}
}
