
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
public class LineaPedidoRESTCAD : LineaComandaCAD
{
public LineaPedidoRESTCAD()
        : base ()
{
}

public LineaPedidoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}



public MenuEN Menus (int id)
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
