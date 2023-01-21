
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;
using TPVNUBEGenNHibernate.CEN.Rest;



/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CP.Rest_Cobro_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CP.Rest
{
public partial class CobroCP : BasicCP
{
public TPVNUBEGenNHibernate.EN.Rest.CobroEN Nuevo (float p_monto, int p_comanda, int p_tipoCobro, int p_caja, int p_empleado, int p_negocio)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CP.Rest_Cobro_nuevo) ENABLED START*/

        ICobroCAD cobroCAD = null;
        CobroCEN cobroCEN = null;

        TPVNUBEGenNHibernate.EN.Rest.CobroEN result = null;


        try
        {
                SessionInitializeTransaction ();
                cobroCAD = new CobroCAD (session);
                cobroCEN = new CobroCEN (cobroCAD);

                CajaCAD cajaCAD = new CajaCAD (session);
                CajaCEN cajaCEN = new CajaCEN (cajaCAD);


                int oid;
                //Initialized CobroEN
                CobroEN cobroEN;
                cobroEN = new CobroEN ();
                cobroEN.Monto = p_monto;
                cobroEN.Fecha = DateTime.Now;

                if (p_comanda != -1) {
                        cobroEN.Comanda = new TPVNUBEGenNHibernate.EN.Rest.ComandaEN ();
                        cobroEN.Comanda.Id = p_comanda;
                }



                if (p_tipoCobro != -1) {
                        cobroEN.TipoCobro = new TPVNUBEGenNHibernate.EN.Rest.TipoCobroEN ();
                        cobroEN.TipoCobro.Id = p_tipoCobro;
                }


                if (p_caja != -1) {
                        cobroEN.Caja = new TPVNUBEGenNHibernate.EN.Rest.CajaEN ();
                        cobroEN.Caja.Id = p_caja;
                }

                if (p_empleado != -1) {
                        cobroEN.Empleado = new TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN ();
                        cobroEN.Empleado.Id = p_empleado;
                }

                if (p_negocio != -1) {
                        cobroEN.Negocio = new TPVNUBEGenNHibernate.EN.Rest.NegocioEN ();
                        cobroEN.Negocio.Id = p_negocio;
                }


                //Call to CobroCAD

                oid = cobroCAD.New_ (cobroEN);
                result = cobroCAD.ReadOIDDefault (oid);
                //Comprobar que Total del pedido es igual o superior al monto del cobro. Anyadir la cantidad cobrada en el pedido.

                cajaCEN.IncrementoSaldo (p_caja, cobroEN.Monto);

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
