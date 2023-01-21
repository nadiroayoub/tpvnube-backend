
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
public class MenuRESTCAD : MenuCAD
{
public MenuRESTCAD()
        : base ()
{
}

public MenuRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<LineaMenuEN> LineasMenu (int id)
{
        IList<LineaMenuEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaMenuEN self inner join self.Menu as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaMenuEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in MenuRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<LineaMenuEN> GetAllLineaMenuByMenu (int id)
{
        IList<LineaMenuEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaMenuEN self inner join self.Menu as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaMenuEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in MenuRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<LineaComandaEN> GetAllLineaComandaOfMenu (int id)
{
        IList<LineaComandaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaComandaEN self inner join self.Menu as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaComandaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in MenuRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public NegocioEN NegocioMenu (int id)
{
        NegocioEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Negocio FROM MenuEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<NegocioEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in MenuRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
