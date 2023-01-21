using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace TPVNUBEGenTpvhostRESTAzure.DTOA
{
public class CajaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private double saldo;
public double Saldo
{
        get { return saldo; }
        set { saldo = value; }
}

private string descripcion;
public string Descripcion
{
        get { return descripcion; }
        set { descripcion = value; }
}

private double fondo;
public double Fondo
{
        get { return fondo; }
        set { fondo = value; }
}


/* Rol: Caja o--> DuenyoRegistrado */
private DuenyoRegistradoDTOA duenyo;
public DuenyoRegistradoDTOA Duenyo
{
        get { return duenyo; }
        set { duenyo = value; }
}

/* Rol: Caja o--> Cobro */
private IList<CobroDTOA> cobros;
public IList<CobroDTOA> Cobros
{
        get { return cobros; }
        set { cobros = value; }
}

/* Rol: Caja o--> Negocio */
private NegocioDTOA negocioCaja;
public NegocioDTOA NegocioCaja
{
        get { return negocioCaja; }
        set { negocioCaja = value; }
}
}
}
