

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
 *      Definition of the class CobroCEN
 *
 */
public partial class CobroCEN
{
private ICobroCAD _ICobroCAD;

public CobroCEN()
{
        this._ICobroCAD = new CobroCAD ();
}

public CobroCEN(ICobroCAD _ICobroCAD)
{
        this._ICobroCAD = _ICobroCAD;
}

public ICobroCAD get_ICobroCAD ()
{
        return this._ICobroCAD;
}

public void Modificar (int p_Cobro_OID, float p_monto, Nullable<DateTime> p_fecha)
{
        CobroEN cobroEN = null;

        //Initialized CobroEN
        cobroEN = new CobroEN ();
        cobroEN.Id = p_Cobro_OID;
        cobroEN.Monto = p_monto;
        cobroEN.Fecha = p_fecha;
        //Call to CobroCAD

        _ICobroCAD.Modificar (cobroEN);
}

public void Eliminar (int id
                      )
{
        _ICobroCAD.Eliminar (id);
}

public CobroEN ReadOID (int id
                        )
{
        CobroEN cobroEN = null;

        cobroEN = _ICobroCAD.ReadOID (id);
        return cobroEN;
}

public System.Collections.Generic.IList<CobroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CobroEN> list = null;

        list = _ICobroCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> DameCobroPorNegocio (int p_negocio)
{
        return _ICobroCAD.DameCobroPorNegocio (p_negocio);
}
public int New_ (float p_monto, int p_comanda, int p_tipoCobro, int p_caja, Nullable<DateTime> p_fecha, int p_empleado, int p_negocio)
{
        CobroEN cobroEN = null;
        int oid;

        //Initialized CobroEN
        cobroEN = new CobroEN ();
        cobroEN.Monto = p_monto;


        if (p_comanda != -1) {
                // El argumento p_comanda -> Property comanda es oid = false
                // Lista de oids id
                cobroEN.Comanda = new TPVNUBEGenNHibernate.EN.Rest.ComandaEN ();
                cobroEN.Comanda.Id = p_comanda;
        }


        if (p_tipoCobro != -1) {
                // El argumento p_tipoCobro -> Property tipoCobro es oid = false
                // Lista de oids id
                cobroEN.TipoCobro = new TPVNUBEGenNHibernate.EN.Rest.TipoCobroEN ();
                cobroEN.TipoCobro.Id = p_tipoCobro;
        }


        if (p_caja != -1) {
                // El argumento p_caja -> Property caja es oid = false
                // Lista de oids id
                cobroEN.Caja = new TPVNUBEGenNHibernate.EN.Rest.CajaEN ();
                cobroEN.Caja.Id = p_caja;
        }

        cobroEN.Fecha = p_fecha;


        if (p_empleado != -1) {
                // El argumento p_empleado -> Property empleado es oid = false
                // Lista de oids id
                cobroEN.Empleado = new TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN ();
                cobroEN.Empleado.Id = p_empleado;
        }


        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                cobroEN.Negocio = new TPVNUBEGenNHibernate.EN.Rest.NegocioEN ();
                cobroEN.Negocio.Id = p_negocio;
        }

        //Call to CobroCAD

        oid = _ICobroCAD.New_ (cobroEN);
        return oid;
}
}
}
