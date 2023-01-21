using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenTpvhostRESTAzure.DTOA
{
public class MesaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum estado;
public TPVNUBEGenNHibernate.Enumerated.Rest.EstadoMesaEnum Estado
{
        get { return estado; }
        set { estado = value; }
}

private int numero;
public int Numero
{
        get { return numero; }
        set { numero = value; }
}


/* Rol: Mesa o--> Negocio */
private NegocioDTOA negocioMesa;
public NegocioDTOA NegocioMesa
{
        get { return negocioMesa; }
        set { negocioMesa = value; }
}
}
}
