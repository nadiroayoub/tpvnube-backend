
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
public class FacturaRESTCAD : FacturaCAD
{
public FacturaRESTCAD()
        : base ()
{
}

public FacturaRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
