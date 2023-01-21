
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
public class UnidadMedidaRESTCAD : UnidadMedidaCAD
{
public UnidadMedidaRESTCAD()
        : base ()
{
}

public UnidadMedidaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<ProductoEN> GetAllProductoOfUnidadMedida (int id)
{
        IList<ProductoEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ProductoEN self inner join self.UnidadMedida as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<ProductoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in UnidadMedidaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
