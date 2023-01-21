
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
public class ProductoRESTCAD : ProductoCAD
{
public ProductoRESTCAD()
        : base ()
{
}

public ProductoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public UnidadMedidaEN GetUnidadMedidaByProducto (int id)
{
        UnidadMedidaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.UnidadMedida FROM ProductoEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<UnidadMedidaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ProductoRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
