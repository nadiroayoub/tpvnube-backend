
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using TPVNUBEGenNHibernate.Exceptions;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;
using TPVNUBEGenNHibernate.CEN.Rest;



namespace TPVNUBEGenNHibernate.CP.Rest
{
public partial class TipoPagoCP : BasicCP
{
public TipoPagoCP() : base ()
{
}

public TipoPagoCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
