
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
public class CategoriaServicioRESTCAD : CategoriaServicioCAD
{
public CategoriaServicioRESTCAD()
        : base ()
{
}

public CategoriaServicioRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<ServicioEN> GetAllServicioByCategoriaServicio (int id)
{
        IList<ServicioEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ServicioEN self inner join self.CategoriaServicio as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<ServicioEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaServicioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
