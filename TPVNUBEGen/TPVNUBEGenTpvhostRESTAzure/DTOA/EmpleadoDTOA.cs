using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenTpvhostRESTAzure.DTOA
{
public class EmpleadoDTOA
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

private String pass;
public String Pass
{
        get { return pass; }
        set { pass = value; }
}

private string foto;
public string Foto
{
        get { return foto; }
        set { foto = value; }
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


/* Rol: Empleado o--> Pedido */
private IList<PedidoDTOA> comandas;
public IList<PedidoDTOA> Comandas
{
        get { return comandas; }
        set { comandas = value; }
}

/* Rol: Empleado o--> Negocio */
private NegocioDTOA negocioEmpleado;
public NegocioDTOA NegocioEmpleado
{
        get { return negocioEmpleado; }
        set { negocioEmpleado = value; }
}
}
}
