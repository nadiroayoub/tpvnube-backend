
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
public class NegocioRESTCAD : NegocioCAD
{
public NegocioRESTCAD()
        : base ()
{
}

public NegocioRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<MesaEN> GetAllMesaOfNegocio (int id)
{
        IList<MesaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM MesaEN self inner join self.Negocio as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<MesaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in NegocioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public IList<CajaEN> CajaOfNegocio (int id)
{
        IList<CajaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM CajaEN self inner join self.Negocio as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<CajaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in NegocioRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
