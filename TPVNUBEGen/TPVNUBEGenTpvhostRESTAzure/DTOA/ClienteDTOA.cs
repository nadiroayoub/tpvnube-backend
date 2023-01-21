using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenTpvhostRESTAzure.DTOA
{
public class ClienteDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string nombre;
public string Nombre
{
        get { return nombre; }
        set { nombre = value; }
}

private string apellidos;
public string Apellidos
{
        get { return apellidos; }
        set { apellidos = value; }
}

private string dni;
public string Dni
{
        get { return dni; }
        set { dni = value; }
}

private string email;
public string Email
{
        get { return email; }
        set { email = value; }
}


/* Rol: Cliente o--> Negocio */
private NegocioDTOA negocio;
public NegocioDTOA Negocio
{
        get { return negocio; }
        set { negocio = value; }
}
}
}
