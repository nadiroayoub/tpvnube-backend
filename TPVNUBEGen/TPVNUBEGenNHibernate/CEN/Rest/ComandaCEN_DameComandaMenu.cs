
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Comanda_DameComandaMenu) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class ComandaCEN
{
public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> DameComandaMenu (int p_menu, int p_comanda, int p_mesa, int p_lineaMenu)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Comanda_DameComandaMenu) ENABLED START*/

        ComandaCAD comandaCAD = new ComandaCAD ();
        ComandaEN comandaEN = comandaCAD.ReadOID (p_comanda);

        IList<MenuEN> menus = new List<MenuEN>();
        IList<ComandaEN> comandaENs = new List<ComandaEN>();
        IList<LineaComandaEN> lineaComandaENs = comandaEN.LineaComanda;
        foreach (var item in lineaComandaENs) {
                menus.Add (item.Menu);
        }

        return comandaENs;
        /*PROTECTED REGION END*/
}
}
}
