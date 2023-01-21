

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
 *      Definition of the class DuenyoCEN
 *
 */
public partial class DuenyoCEN
{
private IDuenyoCAD _IDuenyoCAD;

public DuenyoCEN()
{
        this._IDuenyoCAD = new DuenyoCAD ();
}

public DuenyoCEN(IDuenyoCAD _IDuenyoCAD)
{
        this._IDuenyoCAD = _IDuenyoCAD;
}

public IDuenyoCAD get_IDuenyoCAD ()
{
        return this._IDuenyoCAD;
}

public void Modificar (int p_Duenyo_OID, string p_dni, string p_nombre, string p_apellidos, string p_telefono, String p_pass, string p_email, string p_foto)
{
        DuenyoEN duenyoEN = null;

        //Initialized DuenyoEN
        duenyoEN = new DuenyoEN ();
        duenyoEN.Id = p_Duenyo_OID;
        duenyoEN.Dni = p_dni;
        duenyoEN.Nombre = p_nombre;
        duenyoEN.Apellidos = p_apellidos;
        duenyoEN.Telefono = p_telefono;
        duenyoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        duenyoEN.Email = p_email;
        duenyoEN.Foto = p_foto;
        //Call to DuenyoCAD

        _IDuenyoCAD.Modificar (duenyoEN);
}

public void Eliminar (int id
                      )
{
        _IDuenyoCAD.Eliminar (id);
}

public DuenyoEN ReadOID (int id
                         )
{
        DuenyoEN duenyoEN = null;

        duenyoEN = _IDuenyoCAD.ReadOID (id);
        return duenyoEN;
}

public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.DuenyoEN> DamePorEmail (string p_email)
{
        return _IDuenyoCAD.DamePorEmail (p_email);
}
public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.DuenyoEN> DamePorDni (string p_dni)
{
        return _IDuenyoCAD.DamePorDni (p_dni);
}
public System.Collections.Generic.IList<DuenyoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<DuenyoEN> list = null;

        list = _IDuenyoCAD.ReadAll (first, size);
        return list;
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
        DuenyoEN en = _IDuenyoCAD.ReadOIDDefault (id);
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

                DuenyoEN en = _IDuenyoCAD.ReadOIDDefault (id);

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
