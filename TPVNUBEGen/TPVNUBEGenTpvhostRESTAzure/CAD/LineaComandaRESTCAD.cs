
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
}
}
