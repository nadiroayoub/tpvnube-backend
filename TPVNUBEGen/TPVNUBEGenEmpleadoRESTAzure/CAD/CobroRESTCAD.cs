
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



public ComandaEN DameComandaPorPago (int id)
{
        ComandaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Comanda FROM CobroEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<ComandaEN>();

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

public ClienteEN Cliente (int id)
{
        ClienteEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Cliente FROM CobroEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<ClienteEN>();

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

public ComandaEN GetComandaOfCobro (int id)
{
        ComandaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Comanda FROM CobroEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<ComandaEN>();

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
