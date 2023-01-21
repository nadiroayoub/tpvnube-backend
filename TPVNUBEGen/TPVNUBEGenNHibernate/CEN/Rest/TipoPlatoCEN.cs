

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
 *      Definition of the class TipoPlatoCEN
 *
 */
public partial class TipoPlatoCEN
{
private ITipoPlatoCAD _ITipoPlatoCAD;

public TipoPlatoCEN()
{
        this._ITipoPlatoCAD = new TipoPlatoCAD ();
}

public TipoPlatoCEN(ITipoPlatoCAD _ITipoPlatoCAD)
{
        this._ITipoPlatoCAD = _ITipoPlatoCAD;
}

public ITipoPlatoCAD get_ITipoPlatoCAD ()
{
        return this._ITipoPlatoCAD;
}

public int Nuevo (string p_nombre)
{
        TipoPlatoEN tipoPlatoEN = null;
        int oid;

        //Initialized TipoPlatoEN
        tipoPlatoEN = new TipoPlatoEN ();
        tipoPlatoEN.Nombre = p_nombre;

        //Call to TipoPlatoCAD

        oid = _ITipoPlatoCAD.Nuevo (tipoPlatoEN);
        return oid;
}

public void Modificar (int p_TipoPlato_OID, string p_nombre)
{
        TipoPlatoEN tipoPlatoEN = null;

        //Initialized TipoPlatoEN
        tipoPlatoEN = new TipoPlatoEN ();
        tipoPlatoEN.Id = p_TipoPlato_OID;
        tipoPlatoEN.Nombre = p_nombre;
        //Call to TipoPlatoCAD

        _ITipoPlatoCAD.Modificar (tipoPlatoEN);
}

public void Eliminar (int id
                      )
{
        _ITipoPlatoCAD.Eliminar (id);
}
}
}
