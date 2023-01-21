
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TPVNUBEGenNHibernate.Exceptions;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Comanda_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
public partial class ComandaCEN
{
public int Nuevo (TPVNUBEGenNHibernate.Enumerated.Rest.EstadoComandaEnum p_estadoComanda, int p_mesa, int p_empleado)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Comanda_nuevo_customized) ENABLED START*/

        ComandaEN comandaEN = null;

        int oid;

        //Initialized ComandaEN
        comandaEN = new ComandaEN ();
        comandaEN.EstadoComanda = p_estadoComanda;
        comandaEN.Fecha = DateTime.Now;
        comandaEN.Pdf = "";
        if (p_mesa != -1) {
                comandaEN.Mesa = new TPVNUBEGenNHibernate.EN.Rest.MesaEN ();
                comandaEN.Mesa.Id = p_mesa;
        }


        if (p_empleado != -1) {
                comandaEN.Empleado = new TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN ();
                comandaEN.Empleado.Id = p_empleado;
        }

        //Call to ComandaCAD

        oid = _IComandaCAD.Nuevo (comandaEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
