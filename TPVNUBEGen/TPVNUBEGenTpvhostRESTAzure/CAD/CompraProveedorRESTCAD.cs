
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
public class CompraProveedorRESTCAD : CompraProveedorCAD
{
public CompraProveedorRESTCAD()
        : base ()
{
}

public CompraProveedorRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public IList<LineaCompraProveedorEN> LineasCompraProveedor (int id)
{
        IList<LineaCompraProveedorEN> result = null;

        try
        {
                SessionInitializeTransaction ();

                String sql = @"select self FROM LineaCompraProveedorEN self inner join self.CompraProveedor as target with target.Id=:p_Id";
                IQuery query = session.CreateQuery (sql).SetParameter ("p_Id", id);




                result = query.List<LineaCompraProveedorEN>();

                SessionCommit ();
        }

        catch (Exception ex)
        {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException) throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorRESTCAD.", ex);
        }

        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
