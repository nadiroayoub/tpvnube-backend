

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
 *      Definition of the class ComandaCEN
 *
 */
public partial class ComandaCEN
{
private IComandaCAD _IComandaCAD;

public ComandaCEN()
{
        this._IComandaCAD = new ComandaCAD ();
}

public ComandaCEN(IComandaCAD _IComandaCAD)
{
        this._IComandaCAD = _IComandaCAD;
}

public IComandaCAD get_IComandaCAD ()
{
        return this._IComandaCAD;
}

public void Modificar (int p_Comanda_OID, TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum p_estadoComanda, Nullable<DateTime> p_fecha, double p_total, string p_pdf)
{
        ComandaEN comandaEN = null;

        //Initialized ComandaEN
        comandaEN = new ComandaEN ();
        comandaEN.Id = p_Comanda_OID;
        comandaEN.EstadoComanda = p_estadoComanda;
        comandaEN.Fecha = p_fecha;
        comandaEN.Total = p_total;
        comandaEN.Pdf = p_pdf;
        //Call to ComandaCAD

        _IComandaCAD.Modificar (comandaEN);
}

public void Eliminar (int id
                      )
{
        _IComandaCAD.Eliminar (id);
}

public ComandaEN ReadOID (int id
                          )
{
        ComandaEN comandaEN = null;

        comandaEN = _IComandaCAD.ReadOID (id);
        return comandaEN;
}

public System.Collections.Generic.IList<ComandaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComandaEN> list = null;

        list = _IComandaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> DameComandasPorMesa (int p_mesa)
{
        return _IComandaCAD.DameComandasPorMesa (p_mesa);
}
}
}
