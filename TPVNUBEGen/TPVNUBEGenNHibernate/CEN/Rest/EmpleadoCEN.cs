

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
 *      Definition of the class EmpleadoCEN
 *
 */
public partial class EmpleadoCEN
{
private IEmpleadoCAD _IEmpleadoCAD;

public EmpleadoCEN()
{
        this._IEmpleadoCAD = new EmpleadoCAD ();
}

public EmpleadoCEN(IEmpleadoCAD _IEmpleadoCAD)
{
        this._IEmpleadoCAD = _IEmpleadoCAD;
}

public IEmpleadoCAD get_IEmpleadoCAD ()
{
        return this._IEmpleadoCAD;
}

public int Nuevo (int p_negocio, string p_nombre, string p_apellidos, String p_pass, string p_foto, string p_dni, string p_email, string p_telefono)
{
        EmpleadoEN empleadoEN = null;
        int oid;

        //Initialized EmpleadoEN
        empleadoEN = new EmpleadoEN ();

        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                empleadoEN.Negocio = new TPVNUBEGenNHibernate.EN.Rest.NegocioEN ();
                empleadoEN.Negocio.Id = p_negocio;
        }

        empleadoEN.Nombre = p_nombre;

        empleadoEN.Apellidos = p_apellidos;

        empleadoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        empleadoEN.Foto = p_foto;

        empleadoEN.Dni = p_dni;

        empleadoEN.Email = p_email;

        empleadoEN.Telefono = p_telefono;

        //Call to EmpleadoCAD

        oid = _IEmpleadoCAD.Nuevo (empleadoEN);
        return oid;
}

public void Eliminar (int id
                      )
{
        _IEmpleadoCAD.Eliminar (id);
}

public EmpleadoEN ReadOID (int id
                           )
{
        EmpleadoEN empleadoEN = null;

        empleadoEN = _IEmpleadoCAD.ReadOID (id);
        return empleadoEN;
}

public System.Collections.Generic.IList<EmpleadoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EmpleadoEN> list = null;

        list = _IEmpleadoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN> DamePorEmail (string p_email)
{
        return _IEmpleadoCAD.DamePorEmail (p_email);
}
public void Modificar (int p_Empleado_OID, string p_nombre, string p_apellidos, String p_pass, string p_foto, string p_dni, string p_email, string p_telefono)
{
        EmpleadoEN empleadoEN = null;

        //Initialized EmpleadoEN
        empleadoEN = new EmpleadoEN ();
        empleadoEN.Id = p_Empleado_OID;
        empleadoEN.Nombre = p_nombre;
        empleadoEN.Apellidos = p_apellidos;
        empleadoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        empleadoEN.Foto = p_foto;
        empleadoEN.Dni = p_dni;
        empleadoEN.Email = p_email;
        empleadoEN.Telefono = p_telefono;
        //Call to EmpleadoCAD

        _IEmpleadoCAD.Modificar (empleadoEN);
}




private string Encode (int id)
{
        var payload = new Dictionary<string, object>(){
                { "id", id }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int id)
{
        EmpleadoEN en = _IEmpleadoCAD.ReadOIDDefault (id);
        string token = Encode (en.Id);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerID (decodedToken);

                EmpleadoEN en = _IEmpleadoCAD.ReadOIDDefault (id);

                if (en != null && ((long)en.Id).Equals (ObtenerID (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public long ObtenerID (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long id = (long)results ["id"];
                return id;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
