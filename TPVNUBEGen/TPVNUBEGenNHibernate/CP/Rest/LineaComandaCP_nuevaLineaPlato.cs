
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;
using TPVNUBEGenNHibernate.CEN.Rest;



/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CP.Rest_LineaComanda_nuevaLineaPlato) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CP.Rest
{
public partial class LineaComandaCP : BasicCP
{
public TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN NuevaLineaPlato (int p_comanda, int p_cantidad, int p_plato)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CP.Rest_LineaComanda_nuevaLineaPlato) ENABLED START*/

        ILineaComandaCAD lineaComandaCAD = null;
        LineaComandaCEN lineaComandaCEN = null;

        TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN result = null;


        try
        {
                SessionInitializeTransaction ();
                lineaComandaCAD = new LineaComandaCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaComandaCAD);
                PlatoCAD platoCAD = new PlatoCAD (session);
                ComandaCAD comandaCAD = new ComandaCAD (session);


                int oid;
                //Initialized LineaComandaEN
                LineaComandaEN lineaComandaEN;
                lineaComandaEN = new LineaComandaEN ();

                if (p_comanda != -1) {
                        lineaComandaEN.Comanda = new TPVNUBEGenNHibernate.EN.Rest.ComandaEN ();
                        lineaComandaEN.Comanda.Id = p_comanda;
                }

                lineaComandaEN.Cantidad = p_cantidad;


                lineaComandaEN.Plato = platoCAD.ReadOIDDefault (p_plato);

                //Call to LineaComandaCAD

                oid = lineaComandaCAD.New_ (lineaComandaEN);
                result = lineaComandaCAD.ReadOIDDefault (oid);
                ComandaEN comanda = lineaComandaEN.Comanda;
                comanda.Total += lineaComandaEN.Plato.Precio * p_cantidad;
                comandaCAD.Modificar (comanda);


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
