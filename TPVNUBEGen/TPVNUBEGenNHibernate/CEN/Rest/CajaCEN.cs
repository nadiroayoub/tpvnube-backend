

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
 *      Definition of the class CajaCEN
 *
 */
public partial class CajaCEN
{
private ICajaCAD _ICajaCAD;

public CajaCEN()
{
        this._ICajaCAD = new CajaCAD ();
}

public CajaCEN(ICajaCAD _ICajaCAD)
{
        this._ICajaCAD = _ICajaCAD;
}

public ICajaCAD get_ICajaCAD ()
{
        return this._ICajaCAD;
}

public void Modificar (int p_Caja_OID, string p_descripcion, double p_fondo, Nullable<DateTime> p_fecha)
{
        CajaEN cajaEN = null;

        //Initialized CajaEN
        cajaEN = new CajaEN ();
        cajaEN.Id = p_Caja_OID;
        cajaEN.Descripcion = p_descripcion;
        cajaEN.Fondo = p_fondo;
        cajaEN.Fecha = p_fecha;
        //Call to CajaCAD

        _ICajaCAD.Modificar (cajaEN);
}

public void Eliminar (int id
                      )
{
        _ICajaCAD.Eliminar (id);
}

public CajaEN ReadOID (int id
                       )
{
        CajaEN cajaEN = null;

        cajaEN = _ICajaCAD.ReadOID (id);
        return cajaEN;
}

public System.Collections.Generic.IList<CajaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CajaEN> list = null;

        list = _ICajaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> DameCajaPorNegocio (int ? p_negocio)
{
        return _ICajaCAD.DameCajaPorNegocio (p_negocio);
}
public int Nuevo (int p_negocio, string p_descripcion, int p_duenyo, double p_fondo, Nullable<DateTime> p_fecha)
{
        CajaEN cajaEN = null;
        int oid;

        //Initialized CajaEN
        cajaEN = new CajaEN ();

        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                cajaEN.Negocio = new TPVNUBEGenNHibernate.EN.Rest.NegocioEN ();
                cajaEN.Negocio.Id = p_negocio;
        }

        cajaEN.Descripcion = p_descripcion;


        if (p_duenyo != -1) {
                // El argumento p_duenyo -> Property duenyo es oid = false
                // Lista de oids id
                cajaEN.Duenyo = new TPVNUBEGenNHibernate.EN.Rest.DuenyoEN ();
                cajaEN.Duenyo.Id = p_duenyo;
        }

        cajaEN.Fondo = p_fondo;

        cajaEN.Fecha = p_fecha;

        //Call to CajaCAD

        oid = _ICajaCAD.Nuevo (cajaEN);
        return oid;
}
}
}
