

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
 *      Definition of the class CajaFechaCEN
 *
 */
public partial class CajaFechaCEN
{
private ICajaFechaCAD _ICajaFechaCAD;

public CajaFechaCEN()
{
        this._ICajaFechaCAD = new CajaFechaCAD ();
}

public CajaFechaCEN(ICajaFechaCAD _ICajaFechaCAD)
{
        this._ICajaFechaCAD = _ICajaFechaCAD;
}

public ICajaFechaCAD get_ICajaFechaCAD ()
{
        return this._ICajaFechaCAD;
}

public int New_ (Nullable<DateTime> p_fecha, string p_idCaja, string p_total, System.Collections.Generic.IList<int> p_caja)
{
        CajaFechaEN cajaFechaEN = null;
        int oid;

        //Initialized CajaFechaEN
        cajaFechaEN = new CajaFechaEN ();
        cajaFechaEN.Fecha = p_fecha;

        cajaFechaEN.IdCaja = p_idCaja;

        cajaFechaEN.Total = p_total;


        cajaFechaEN.Caja = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CajaEN>();
        if (p_caja != null) {
                foreach (int item in p_caja) {
                        TPVNUBEGenNHibernate.EN.Rest.CajaEN en = new TPVNUBEGenNHibernate.EN.Rest.CajaEN ();
                        en.Id = item;
                        cajaFechaEN.Caja.Add (en);
                }
        }

        else{
                cajaFechaEN.Caja = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CajaEN>();
        }

        //Call to CajaFechaCAD

        oid = _ICajaFechaCAD.New_ (cajaFechaEN);
        return oid;
}

public void Modify (int p_CajaFecha_OID, Nullable<DateTime> p_fecha, string p_idCaja, string p_total)
{
        CajaFechaEN cajaFechaEN = null;

        //Initialized CajaFechaEN
        cajaFechaEN = new CajaFechaEN ();
        cajaFechaEN.Id = p_CajaFecha_OID;
        cajaFechaEN.Fecha = p_fecha;
        cajaFechaEN.IdCaja = p_idCaja;
        cajaFechaEN.Total = p_total;
        //Call to CajaFechaCAD

        _ICajaFechaCAD.Modify (cajaFechaEN);
}

public void Destroy (int id
                     )
{
        _ICajaFechaCAD.Destroy (id);
}

public CajaFechaEN ReadOID (int id
                            )
{
        CajaFechaEN cajaFechaEN = null;

        cajaFechaEN = _ICajaFechaCAD.ReadOID (id);
        return cajaFechaEN;
}

public System.Collections.Generic.IList<CajaFechaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CajaFechaEN> list = null;

        list = _ICajaFechaCAD.ReadAll (first, size);
        return list;
}
}
}
