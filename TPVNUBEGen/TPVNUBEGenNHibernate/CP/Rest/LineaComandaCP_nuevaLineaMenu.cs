
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



/*PROTECTED REGION ID(usingTPVNUBEGenNHibernate.CP.Rest_LineaComanda_nuevaLineaMenu) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace TPVNUBEGenNHibernate.CP.Rest
{
public partial class LineaComandaCP : BasicCP
{
public TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN NuevaLineaMenu (int p_comanda, int p_cantidad, int p_menu)
{
        /*PROTECTED REGION ID(TPVNUBEGenNHibernate.CP.Rest_LineaComanda_nuevaLineaMenu) ENABLED START*/

        ILineaComandaCAD lineaComandaCAD = null;
        LineaComandaCEN lineaComandaCEN = null;

        TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN result = null;


        try
        {
                SessionInitializeTransaction ();
                lineaComandaCAD = new LineaComandaCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaComandaCAD);
                MenuCAD menuCAD = new MenuCAD (session);
                ComandaCAD comandaCAD = new ComandaCAD (session);
                ComandaCEN comandaCEN = new ComandaCEN (comandaCAD);

                int oid;
                //Initialized LineaComandaEN
                LineaComandaEN lineaComandaEN;
                lineaComandaEN = new LineaComandaEN ();

                if (p_comanda != -1) {
                        lineaComandaEN.Comanda = new TPVNUBEGenNHibernate.EN.Rest.ComandaEN ();
                        lineaComandaEN.Comanda.Id = p_comanda;
                }

                lineaComandaEN.Cantidad = p_cantidad;

                lineaComandaEN.Menu = menuCAD.ReadOIDDefault (p_menu);

                //Call to LineaComandaCAD

                oid = lineaComandaCAD.New_ (lineaComandaEN);
                result = lineaComandaCAD.ReadOIDDefault (oid);
                ComandaEN comanda = lineaComandaEN.Comanda;
                comanda.Total += lineaComandaEN.Menu.Precio * p_cantidad;
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
