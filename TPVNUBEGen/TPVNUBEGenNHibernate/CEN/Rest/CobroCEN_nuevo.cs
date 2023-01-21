
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


/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CEN.Rest_Cobro_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CEN.Rest
{
    public partial class CobroCEN
    {
        public int Nuevo(float p_monto, int p_comanda, string p_tipoDeCobro, int p_tipoCobro, int p_caja, string p_numeroTransaccion)
        {
            /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CEN.Rest_Cobro_nuevo_customized) ENABLED START*/

            CobroEN cobroEN = null;

            int oid;

            //Initialized CobroEN
            cobroEN = new CobroEN();
            cobroEN.Monto = p_monto;
            cobroEN.Fecha = DateTime.Now;

            if (p_comanda != -1)
            {
                cobroEN.Comanda = new TPVNUBEGenNHibernate.EN.Rest.ComandaEN();
                cobroEN.Comanda.Id = p_comanda;
            }

            cobroEN.TipoDeCobro = p_tipoDeCobro;


            if (p_tipoCobro != -1)
            {
                cobroEN.TipoCobro = new TPVNUBEGenNHibernate.EN.Rest.TipoCobroEN();
                cobroEN.TipoCobro.Id = p_tipoCobro;
            }


            if (p_caja != -1)
            {
                cobroEN.Caja = new TPVNUBEGenNHibernate.EN.Rest.CajaEN();
                cobroEN.Caja.Id = p_caja;
            }

            cobroEN.NumeroTransaccion = p_numeroTransaccion;

            //Call to CobroCAD

            oid = _ICobroCAD.Nuevo(cobroEN);
            return oid;
            /*PROTECTED REGION END*/
        }
    }
}
