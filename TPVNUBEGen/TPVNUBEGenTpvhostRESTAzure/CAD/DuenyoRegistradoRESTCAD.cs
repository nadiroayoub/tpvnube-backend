
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
public class DuenyoRegistradoRESTCAD : DuenyoCAD
{
public DuenyoRegistradoRESTCAD()
        : base ()
{
}

public DuenyoRegistradoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<EmpresaEN> GetAllEmpresaOfDuenyo (int id)
{
        IList<EmpresaEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM EmpresaEN self inner join self.Duenyo as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<EmpresaEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in DuenyoRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
