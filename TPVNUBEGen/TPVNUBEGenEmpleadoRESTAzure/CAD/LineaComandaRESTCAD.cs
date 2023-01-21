
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
public class LineaComandaRESTCAD : LineaComandaCAD
{
public LineaComandaRESTCAD()
        : base ()
{
}

public LineaComandaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public PlatoEN PlatoOfLineaComanda (int id)
{
        PlatoEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Plato FROM LineaComandaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<PlatoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public MenuEN MenuOfLineaComanda (int id)
{
        MenuEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Menu FROM LineaComandaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<MenuEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in LineaComandaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
