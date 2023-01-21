

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
 *      Definition of the class EmpresaCEN
 *
 */
public partial class EmpresaCEN
{
private IEmpresaCAD _IEmpresaCAD;

public EmpresaCEN()
{
        this._IEmpresaCAD = new EmpresaCAD ();
}

public EmpresaCEN(IEmpresaCAD _IEmpresaCAD)
{
        this._IEmpresaCAD = _IEmpresaCAD;
}

public IEmpresaCAD get_IEmpresaCAD ()
{
        return this._IEmpresaCAD;
}

public int Nuevo (string p_nombre, string p_direccion, int p_duenyo, string p_cif, string p_email, Nullable<DateTime> p_fechaconstitucion, string p_telefono, string p_provincia, string p_ciudad, string p_pais, string p_cp)
{
        EmpresaEN empresaEN = null;
        int oid;

        //Initialized EmpresaEN
        empresaEN = new EmpresaEN ();
        empresaEN.Nombre = p_nombre;

        empresaEN.Direccion = p_direccion;


        if (p_duenyo != -1) {
                // El argumento p_duenyo -> Property duenyo es oid = false
                // Lista de oids id
                empresaEN.Duenyo = new TPVNUBEGenNHibernate.EN.Rest.DuenyoEN ();
                empresaEN.Duenyo.Id = p_duenyo;
        }

        empresaEN.Cif = p_cif;

        empresaEN.Email = p_email;

        empresaEN.Fechaconstitucion = p_fechaconstitucion;

        empresaEN.Telefono = p_telefono;

        empresaEN.Provincia = p_provincia;

        empresaEN.Ciudad = p_ciudad;

        empresaEN.Pais = p_pais;

        empresaEN.Cp = p_cp;

        //Call to EmpresaCAD

        oid = _IEmpresaCAD.Nuevo (empresaEN);
        return oid;
}

public void Modificar (int p_Empresa_OID, string p_nombre, string p_direccion, string p_cif, string p_email, Nullable<DateTime> p_fechaconstitucion, string p_telefono, string p_provincia, string p_ciudad, string p_pais, string p_cp)
{
        EmpresaEN empresaEN = null;

        //Initialized EmpresaEN
        empresaEN = new EmpresaEN ();
        empresaEN.Id = p_Empresa_OID;
        empresaEN.Nombre = p_nombre;
        empresaEN.Direccion = p_direccion;
        empresaEN.Cif = p_cif;
        empresaEN.Email = p_email;
        empresaEN.Fechaconstitucion = p_fechaconstitucion;
        empresaEN.Telefono = p_telefono;
        empresaEN.Provincia = p_provincia;
        empresaEN.Ciudad = p_ciudad;
        empresaEN.Pais = p_pais;
        empresaEN.Cp = p_cp;
        //Call to EmpresaCAD

        _IEmpresaCAD.Modificar (empresaEN);
}

public void Eliminar (int id
                      )
{
        _IEmpresaCAD.Eliminar (id);
}

public EmpresaEN ReadOID (int id
                          )
{
        EmpresaEN empresaEN = null;

        empresaEN = _IEmpresaCAD.ReadOID (id);
        return empresaEN;
}

public System.Collections.Generic.IList<EmpresaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EmpresaEN> list = null;

        list = _IEmpresaCAD.ReadAll (first, size);
        return list;
}
}
}
