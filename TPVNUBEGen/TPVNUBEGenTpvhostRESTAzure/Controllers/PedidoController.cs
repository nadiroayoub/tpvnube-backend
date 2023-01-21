using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TPVNUBEGenTpvhostRESTAzure.DTO;
using TPVNUBEGenTpvhostRESTAzure.DTOA;
using TPVNUBEGenTpvhostRESTAzure.CAD;
using TPVNUBEGenTpvhostRESTAzure.Assemblers;
using TPVNUBEGenTpvhostRESTAzure.AssemblersDTO;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CEN.Rest;
using TPVNUBEGenNHibernate.CP.Rest;


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_PedidoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Pedido")]
public class PedidoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Pedido/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        PedidoRESTCAD pedidoRESTCAD = null;
        ComandaCEN comandaCEN = null;

        List<ComandaEN> comandaEN = null;
        List<PedidoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                pedidoRESTCAD = new PedidoRESTCAD (session);
                comandaCEN = new ComandaCEN (pedidoRESTCAD);

                // Data
                // TODO: paginación

                comandaEN = comandaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (comandaEN != null) {
                        returnValue = new List<PedidoDTOA>();
                        foreach (ComandaEN entry in comandaEN)
                                returnValue.Add (PedidoAssembler.Convert (entry, session));
                }
        }

        catch (Exception e)
        {
                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(TPVNUBEGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 204 - Empty
        if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}










[HttpGet]
// [Route("{idPedido}", Name="GetOIDPedido")]

[Route ("~/api/Pedido/{idPedido}")]

public HttpResponseMessage ReadOID (int idPedido)
{
        // CAD, CEN, EN, returnValue
        PedidoRESTCAD pedidoRESTCAD = null;
        ComandaCEN comandaCEN = null;
        ComandaEN comandaEN = null;
        PedidoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                pedidoRESTCAD = new PedidoRESTCAD (session);
                comandaCEN = new ComandaCEN (pedidoRESTCAD);

                // Data
                comandaEN = comandaCEN.ReadOID (idPedido);

                // Convert return
                if (comandaEN != null) {
                        returnValue = PedidoAssembler.Convert (comandaEN, session);
                }
        }

        catch (Exception e)
        {
                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(TPVNUBEGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 404 - Not found
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NotFound);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}


















[HttpPost]

[Route ("~/api/Pedido/DameComandasPorFecha")]


public HttpResponseMessage DameComandasPorFecha (          )
{
        // CAD, CEN, returnValue
        PedidoRESTCAD pedidoRESTCAD = null;
        ComandaCEN comandaCEN = null;

        System.Collections.Generic.List<int> returnValue = null;

        try
        {
                SessionInitializeTransaction ();


                pedidoRESTCAD = new PedidoRESTCAD (session);
                comandaCEN = new ComandaCEN (pedidoRESTCAD);


                // Operation
                returnValue = comandaCEN.DameComandasPorFecha (  ).ToList ();
                SessionCommit ();
        }

        catch (Exception e)
        {
                SessionRollBack ();

                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) throw new HttpResponseException (HttpStatusCode.Forbidden);
                else if (e.GetType () == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(TPVNUBEGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 200 - OK
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}






/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_PedidoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
