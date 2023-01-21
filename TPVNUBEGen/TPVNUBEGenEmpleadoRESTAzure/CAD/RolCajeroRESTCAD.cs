
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
public class RolCajeroRESTCAD : RolCAD
{
public RolCajeroRESTCAD()
        : base ()
{
}

public RolCajeroRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public CamareroEN Camarero (int id)
{
        CamareroEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Camarero FROM RolEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<CamareroEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in RolRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public CajeroEN Cajero (int id)
{
        CajeroEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Cajero FROM RolEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<CajeroEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in RolRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
