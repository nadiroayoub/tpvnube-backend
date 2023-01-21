
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

namespace TPVNUBEGenEmpleadoRESTAzure.CAD
{
public class MesaRESTCAD : MesaCAD
{
public MesaRESTCAD()
        : base ()
{
}

public MesaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<ComandaEN> GetAllComandaOfMesa (int id)
{
        IList<ComandaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ComandaEN self inner join self.Mesa as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<ComandaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in MesaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
