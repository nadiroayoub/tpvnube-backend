

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
 *      Definition of the class MesaCEN
 *
 */
public partial class MesaCEN
{
private IMesaCAD _IMesaCAD;

public MesaCEN()
{
        this._IMesaCAD = new MesaCAD ();
}

public MesaCEN(IMesaCAD _IMesaCAD)
{
        this._IMesaCAD = _IMesaCAD;
}

public IMesaCAD get_IMesaCAD ()
{
        return this._IMesaCAD;
}

public int Nuevo (TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum p_estado, int p_numero, int p_negocio)
{
        MesaEN mesaEN = null;
        int oid;

        //Initialized MesaEN
        mesaEN = new MesaEN ();
        mesaEN.Estado = p_estado;

        mesaEN.Numero = p_numero;


        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                mesaEN.Negocio = new TPVNUBEGenNHibernate.EN.Rest.NegocioEN ();
                mesaEN.Negocio.Id = p_negocio;
        }

        //Call to MesaCAD

        oid = _IMesaCAD.Nuevo (mesaEN);
        return oid;
}

public void Modificar (int p_Mesa_OID, TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum p_estado, int p_numero)
{
        MesaEN mesaEN = null;

        //Initialized MesaEN
        mesaEN = new MesaEN ();
        mesaEN.Id = p_Mesa_OID;
        mesaEN.Estado = p_estado;
        mesaEN.Numero = p_numero;
        //Call to MesaCAD

        _IMesaCAD.Modificar (mesaEN);
}

public void Eliminar (int id
                      )
{
        _IMesaCAD.Eliminar (id);
}

public MesaEN ReadOID (int id
                       )
{
        MesaEN mesaEN = null;

        mesaEN = _IMesaCAD.ReadOID (id);
        return mesaEN;
}

public System.Collections.Generic.IList<MesaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MesaEN> list = null;

        list = _IMesaCAD.ReadAll (first, size);
        return list;
}
}
}
