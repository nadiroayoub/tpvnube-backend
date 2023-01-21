
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Comanda_dameComandasPorFecha) ENABLED START*/

//  references to other libraries
using System.Linq;
using System.Web;


/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class ComandaCEN
{
public System.Collections.Generic.IList<int> DameComandasPorFecha ()
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Comanda_dameComandasPorFecha) ENABLED START*/

        ComandaCAD comandaCAD = new ComandaCAD ();

        List<DateTime> dateTimes = new List<DateTime>() {
                DateTime.Now.AddDays (-1),
                DateTime.Now.AddDays (-2), DateTime.Now.AddDays (-3), DateTime.Now.AddDays (-4), DateTime.Now.AddDays (-5),
                DateTime.Now.AddDays (-6)
        };

        IList<ComandaEN> comandas = comandaCAD.ReadAll (0, -1);
        List<int> totalComandas = new List<int>();
        foreach (var fecha in dateTimes) {
                var totalComanda = 0;
                foreach (var comanda in comandas.Where (x => x.Fecha.Value.Day == fecha.Day)) {
                        totalComanda++;
                }
                totalComandas.Add (totalComanda);
        }
        return totalComandas;
        /*PROTECTED REGION END*/
}
}
}
