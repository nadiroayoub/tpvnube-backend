
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



/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CP.Rest_Caja_dameCajaPorDiaYNegocio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CP.Rest
{
public partial class CajaCP : BasicCP
{
public TPVNUBEGenNHibernate.EN.Rest.CajaEN DameCajaPorDiaYNegocio (int p_negocio, Nullable<DateTime> p_fecha)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CP.Rest_Caja_dameCajaPorDiaYNegocio) ENABLED START*/

        ICajaCAD cajaCAD = null;
        CajaCEN cajaCEN = null;

        TPVNUBEGenNHibernate.EN.Rest.CajaEN result = null;


        try
        {
                SessionInitializeTransaction ();
                cajaCAD = new CajaCAD (session);
                cajaCEN = new  CajaCEN (cajaCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method DameCajaPorDiaYNegocio() not yet implemented.");



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
