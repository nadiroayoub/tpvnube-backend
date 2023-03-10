

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
 *      Definition of the class RolCEN
 *
 */
public partial class RolCEN
{
private IRolCAD _IRolCAD;

public RolCEN()
{
        this._IRolCAD = new RolCAD ();
}

public RolCEN(IRolCAD _IRolCAD)
{
        this._IRolCAD = _IRolCAD;
}

public IRolCAD get_IRolCAD ()
{
        return this._IRolCAD;
}

public int NuevoCajero (TPVNUBEGenNHibernate.Enumerated.Rest.EmpleoEnum p_empleo, int p_empleado)
{
        RolEN rolEN = null;
        int oid;

        //Initialized RolEN
        rolEN = new RolEN ();
        rolEN.Empleo = p_empleo;


        if (p_empleado != -1) {
                // El argumento p_empleado -> Property empleado es oid = false
                // Lista de oids id
                rolEN.Empleado = new TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN ();
                rolEN.Empleado.DNI = p_empleado;
        }

        //Call to RolCAD

        oid = _IRolCAD.NuevoCajero (rolEN);
        return oid;
}

public void Modificar (int p_Rol_OID, TPVNUBEGenNHibernate.Enumerated.Rest.EmpleoEnum p_empleo)
{
        RolEN rolEN = null;

        //Initialized RolEN
        rolEN = new RolEN ();
        rolEN.Id = p_Rol_OID;
        rolEN.Empleo = p_empleo;
        //Call to RolCAD

        _IRolCAD.Modificar (rolEN);
}

public void Eliminar (int id
                      )
{
        _IRolCAD.Eliminar (id);
}

public int NuevoCamarero (TPVNUBEGenNHibernate.Enumerated.Rest.EmpleoEnum p_empleo, int p_empleado)
{
        RolEN rolEN = null;
        int oid;

        //Initialized RolEN
        rolEN = new RolEN ();
        rolEN.Empleo = p_empleo;


        if (p_empleado != -1) {
                // El argumento p_empleado -> Property empleado es oid = false
                // Lista de oids id
                rolEN.Empleado = new TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN ();
                rolEN.Empleado.DNI = p_empleado;
        }

        //Call to RolCAD

        oid = _IRolCAD.NuevoCamarero (rolEN);
        return oid;
}

public RolEN ReadOID (int id
                      )
{
        RolEN rolEN = null;

        rolEN = _IRolCAD.ReadOID (id);
        return rolEN;
}

public System.Collections.Generic.IList<RolEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RolEN> list = null;

        list = _IRolCAD.ReadAll (first, size);
        return list;
}
}
}
