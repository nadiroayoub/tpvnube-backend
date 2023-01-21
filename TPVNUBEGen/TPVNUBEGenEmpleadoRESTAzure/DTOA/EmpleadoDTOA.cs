using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenEmpleadoRESTAzure.DTOA
{
public class EmpleadoDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string apellidos;
public string Apellidos
{
        get { return apellidos; }
        set { apellidos = value; }
}

private string nombre;
public string Nombre
{
        get { return nombre; }
        set { nombre = value; }
}

private string foto;
public string Foto
{
        get { return foto; }
        set { foto = value; }
}

private String pass;
public String Pass
{
        get { return pass; }
        set { pass = value; }
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

private string telefono;
public string Telefono
{
        get { return telefono; }
        set { telefono = value; }
}


/* Rol: Empleado o--> Negocio */
private NegocioDTOA negocio;
public NegocioDTOA Negocio
{
        get { return negocio; }
        set { negocio = value; }
}
}
}
