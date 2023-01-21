
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Comanda_DameComandaPlato) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class ComandaCEN
{
public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> DameComandaPlato (int p_plato, int p_comanda)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Comanda_DameComandaPlato) ENABLED START*/

        // Write here your custom code...
        ComandaCAD comandaCAD = new ComandaCAD ();
        ComandaEN comandaEN = comandaCAD.ReadOID (p_comanda);

        IList<PlatoEN> platos = new List<PlatoEN>();
        IList<ComandaEN> comandaList = new List<ComandaEN>();
        IList<LineaComandaEN> lineaComandaENs = comandaEN.LineaComanda;
        foreach (var item in lineaComandaENs) {
                platos.Add (item.Plato);
        }


        return comandaList;

        /*PROTECTED REGION END*/
}
}
}
