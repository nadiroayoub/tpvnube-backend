
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Caja_dameCajaPorDiaYNegocio) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class CajaCEN
{
public System.Collections.Generic.IList<double> DameCajaPorDiaYNegocio (int p_cajaId)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Caja_dameCajaPorDiaYNegocio) ENABLED START*/

        // Write here your custom code...
        // get negocios

        //LAST 7 DAYS
        List<DateTime> dateTimes = new List<DateTime>() {
                DateTime.Now.AddDays (-1),
                DateTime.Now.AddDays (-2), DateTime.Now.AddDays (-3), DateTime.Now.AddDays (-4), DateTime.Now.AddDays (-5),
                DateTime.Now.AddDays (-6)
        };

        // Lista de cajas
        List<CajaEN> cajasENs = new List<CajaEN>();
        Dictionary<DateTime, Double> sumaCobrosFechaPrice = new Dictionary<DateTime, Double>();
        // lista de cobros de un negocio
        // get cobros
        CajaCAD cajaCAD = new CajaCAD ();
        //CajaEN cajaEN = cajaCAD.ReadOID (14);
        CajaCEN cajaCEN = new CajaCEN ();
        CobroCEN cobroCEN = new CobroCEN ();
        CobroCAD cobroCAD = new CobroCAD ();
        //foreach (var idCaja in p_cajas)
        //{
        //    = cajaCEN.ReadOID(idCaja);
        //}
        // get cajas
        //IList<CajaEN> p_cajas = cajaCEN.ReadAll(0, -1);
        IList<CobroEN> cobroENAll = cobroCEN.ReadAll (0, -1);

        // list of cobros
        List<double> listaCobrosDeCaja = new List<double>();
        // get cobros of every caja
        //foreach (var cajaId in p_cajas) {
        CajaEN cajaEN = cajaCEN.ReadOID (p_cajaId);
        var sumaCobrosPorCaja = cajaEN.Fondo;

        // loop through dates
        // in every date should check if cobro have this date
        // Por fecha
        foreach (var date in dateTimes) {
                // 1 de enero
                foreach (var cobro in cobroENAll.Where (x => (x.Caja.Id == p_cajaId))) {
                        // cobros no existen
                        if (date.Day == cobro.Fecha.Value.Day) {
                                sumaCobrosPorCaja += cobro.Monto;
                        }
                        // suma de los cobros
                }
                listaCobrosDeCaja.Add (sumaCobrosPorCaja);
        }
        // add la suma de los cobros
        //listaCobrosDeCaja.Add (sumaCobrosPorCaja);
        //}

        return listaCobrosDeCaja;
        /*PROTECTED REGION END*/
}
}
}
