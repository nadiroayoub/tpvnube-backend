
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
public class ComandaRESTCAD : ComandaCAD
{
public ComandaRESTCAD()
        : base ()
{
}

public ComandaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public FacturaEN Factura (int id)
{
        FacturaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Factura FROM ComandaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<FacturaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public MesaEN MesaOfComanda (int id)
{
        MesaEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Mesa FROM ComandaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<MesaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<LineaComandaEN> AllLineaComandaOfComanda (int id)
{
        IList<LineaComandaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaComandaEN self inner join self.Comanda as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaComandaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
