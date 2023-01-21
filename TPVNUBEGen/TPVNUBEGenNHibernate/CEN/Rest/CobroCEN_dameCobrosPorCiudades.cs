
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Cobro_dameCobrosPorCiudades) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class CobroCEN
{
public System.Collections.Generic.IList<int> DameCobrosPorCiudades (System.Collections.Generic.IList<string> p_ciudades)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Cobro_dameCobrosPorCiudades) ENABLED START*/


        // get cobros
        CobroCAD cobroCAD = new CobroCAD ();

        IList<string> ciudades = new List<string>(){
        };
        IList<CobroEN> cobros = cobroCAD.ReadAll (-1, 0);
        foreach (var cobro in cobros) {
                CajaCAD cajaCAD = new CajaCAD ();
                NegocioCAD negocioCAD = new NegocioCAD ();
                CajaEN cajaEN = cajaCAD.ReadOID (cobro.Caja.Id);
                NegocioEN negocioEN = negocioCAD.ReadOID (cajaEN.Negocio.Id);
                ciudades.Add (negocioEN.Ciudad);
        }
        ciudades = ciudades.ToList ();

        // have ciudades
        var q = from x in ciudades
                group x by x into g
                let count = g.Count ()
                            orderby count descending
                            select new { Value = g.Key, Count = count };
        List<int> ciudadNumeroCobros = new List<int>();
        foreach (var x in q) {
                Console.WriteLine ("Value: " + x.Value + " Count: " + x.Count);
                foreach (var ciudad in p_ciudades) {
                        if (x.Value == ciudad) {
                                ciudadNumeroCobros.Add (x.Count);
                        }
                }
        }
        return ciudadNumeroCobros;
        /*PROTECTED REGION END*/
}
}
}
