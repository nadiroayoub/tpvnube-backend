

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
 *      Definition of the class PlatoCEN
 *
 */
public partial class PlatoCEN
{
private IPlatoCAD _IPlatoCAD;

public PlatoCEN()
{
        this._IPlatoCAD = new PlatoCAD ();
}

public PlatoCEN(IPlatoCAD _IPlatoCAD)
{
        this._IPlatoCAD = _IPlatoCAD;
}

public IPlatoCAD get_IPlatoCAD ()
{
        return this._IPlatoCAD;
}

public int Nuevo (string p_nombre, double p_precio, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaPlatoEN> p_lineaPlato, string p_foto, int p_tipoPlato, int p_negocio)
{
        PlatoEN platoEN = null;
        int oid;

        //Initialized PlatoEN
        platoEN = new PlatoEN ();
        platoEN.Nombre = p_nombre;

        platoEN.Precio = p_precio;

        platoEN.LineaPlato = p_lineaPlato;

        platoEN.Foto = p_foto;


        if (p_tipoPlato != -1) {
                // El argumento p_tipoPlato -> Property tipoPlato es oid = false
                // Lista de oids id
                platoEN.TipoPlato = new TPVNUBEGenNHibernate.EN.Rest.TipoPlatoEN ();
                platoEN.TipoPlato.Id = p_tipoPlato;
        }


        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                platoEN.Negocio = new TPVNUBEGenNHibernate.EN.Rest.NegocioEN ();
                platoEN.Negocio.Id = p_negocio;
        }

        //Call to PlatoCAD

        oid = _IPlatoCAD.Nuevo (platoEN);
        return oid;
}

public void Modificar (int p_Plato_OID, string p_nombre, double p_precio, string p_foto)
{
        PlatoEN platoEN = null;

        //Initialized PlatoEN
        platoEN = new PlatoEN ();
        platoEN.Id = p_Plato_OID;
        platoEN.Nombre = p_nombre;
        platoEN.Precio = p_precio;
        platoEN.Foto = p_foto;
        //Call to PlatoCAD

        _IPlatoCAD.Modificar (platoEN);
}

public void Eliminar (int id
                      )
{
        _IPlatoCAD.Eliminar (id);
}

public PlatoEN ReadOID (int id
                        )
{
        PlatoEN platoEN = null;

        platoEN = _IPlatoCAD.ReadOID (id);
        return platoEN;
}

public System.Collections.Generic.IList<PlatoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PlatoEN> list = null;

        list = _IPlatoCAD.ReadAll (first, size);
        return list;
}
}
}
