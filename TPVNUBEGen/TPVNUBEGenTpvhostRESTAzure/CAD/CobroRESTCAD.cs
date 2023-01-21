
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

namespace TPVNUBEGenTpvhostRESTAzure.CAD
{
public class CobroRESTCAD : CobroCAD
{
public CobroRESTCAD()
        : base ()
{
}

public CobroRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public NegocioEN NegocioCobro (int id)
{
        NegocioEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Negocio FROM CobroEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<NegocioEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
