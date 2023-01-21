
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
public class EmpleadoRESTCAD : EmpleadoCAD
{
public EmpleadoRESTCAD()
        : base ()
{
}

public EmpleadoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<ComandaEN> Comandas (int id)
{
        IList<ComandaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM ComandaEN self inner join self.Empleado as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<ComandaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpleadoRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public NegocioEN NegocioEmpleado (int id)
{
        NegocioEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Negocio FROM EmpleadoEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<NegocioEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpleadoRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
