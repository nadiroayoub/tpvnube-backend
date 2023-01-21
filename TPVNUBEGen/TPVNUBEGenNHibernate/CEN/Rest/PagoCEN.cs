

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TPVNUBEGenNHibernate.Exceptions;

using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;


namespace TPVNUBEGenNHibernate.CEN.Rest
{
/*
 *      Definition of the class PagoCEN
 *
 */
public partial class PagoCEN
{
private IPagoCAD _IPagoCAD;

public PagoCEN()
{
        this._IPagoCAD = new PagoCAD ();
}

public PagoCEN(IPagoCAD _IPagoCAD)
{
        this._IPagoCAD = _IPagoCAD;
}

public IPagoCAD get_IPagoCAD ()
{
        return this._IPagoCAD;
}

public void Modificar (int p_Pago_OID, double p_monto, Nullable<DateTime> p_fechaPago, int p_numeroDocumento)
{
        PagoEN pagoEN = null;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.Id = p_Pago_OID;
        pagoEN.Monto = p_monto;
        pagoEN.FechaPago = p_fechaPago;
        pagoEN.NumeroDocumento = p_numeroDocumento;
        //Call to PagoCAD

        _IPagoCAD.Modificar (pagoEN);
}

public void Eliminar (int id
                      )
{
        _IPagoCAD.Eliminar (id);
}

public PagoEN ReadOID (int id
                       )
{
        PagoEN pagoEN = null;

        pagoEN = _IPagoCAD.ReadOID (id);
        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> list = null;

        list = _IPagoCAD.ReadAll (first, size);
        return list;
}
}
}
