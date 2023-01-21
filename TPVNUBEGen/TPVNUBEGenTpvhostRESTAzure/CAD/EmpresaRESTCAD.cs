
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
public class EmpresaRESTCAD : EmpresaCAD
{
public EmpresaRESTCAD()
        : base ()
{
}

public EmpresaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<NegocioEN> GetAllNegocioByEmpresa (int id)
{
        IList<NegocioEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM NegocioEN self inner join self.Empresa as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<NegocioEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}

public DuenyoEN GetDuenyoOfEmpresa (int id)
{
        DuenyoEN result = null;

        try
        {
                SessionInitializeTransaction ();


                String sql = @"select self.Duenyo FROM EmpresaEN self " +
                             "where self.Id = :p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.UniqueResult<DuenyoEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
