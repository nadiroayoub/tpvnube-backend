
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
public class PedidoRESTCAD : ComandaCAD
{
public PedidoRESTCAD()
        : base ()
{
}

public PedidoRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
