using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TPVNUBEGenEmpleadoRESTAzure.DTO;
using TPVNUBEGenEmpleadoRESTAzure.DTOA;
using TPVNUBEGenEmpleadoRESTAzure.CAD;
using TPVNUBEGenEmpleadoRESTAzure.Assemblers;
using TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CEN.Rest;
using TPVNUBEGenNHibernate.CP.Rest;


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_PedidoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
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





[Route ("~/api/Pedido/DamePedidoPorPago")]

public HttpResponseMessage DamePedidoPorPago (int idPago)
{
        // CAD, EN
        PagoRESTCAD pagoRESTCAD = null;
        CobroEN cobroEN = null;

        // returnValue
        ComandaEN en = null;
        PedidoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);

                // Exists Pago
                cobroEN = pagoRESTCAD.ReadOIDDefault (idPago);
                if (cobroEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Pago#" + idPago + " not found"));

                // Rol
                // TODO: paginación


                en = pagoRESTCAD.DamePedidoPorPago (idPago);



                // Convert return
                if (en != null) {
                        returnValue = PedidoAssembler.Convert (en, session);
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
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}



[HttpGet]





[Route ("~/api/Pedido/DamePedidosEmpleado")]

public HttpResponseMessage DamePedidosEmpleado (int idEmpleado)
{
        // CAD, EN
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoEN empleadoEN = null;

        // returnValue
        List<ComandaEN> en = null;
        List<PedidoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empleadoRESTCAD = new EmpleadoRESTCAD (session);

                // Exists Empleado
                empleadoEN = empleadoRESTCAD.ReadOIDDefault (idEmpleado);
                if (empleadoEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Empleado#" + idEmpleado + " not found"));

                // Rol
                // TODO: paginación


                en = empleadoRESTCAD.DamePedidosEmpleado (idEmpleado).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<PedidoDTOA>();
                        foreach (ComandaEN entry in en)
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





[Route ("~/api/Pedido/GetPedidoOfCobro")]

public HttpResponseMessage GetPedidoOfCobro (int idCobro)
{
        // CAD, EN
        CobroRESTCAD cobroRESTCAD = null;
        CobroEN cobroEN = null;

        // returnValue
        ComandaEN en = null;
        PedidoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cobroRESTCAD = new CobroRESTCAD (session);

                // Exists Cobro
                cobroEN = cobroRESTCAD.ReadOIDDefault (idCobro);
                if (cobroEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Cobro#" + idCobro + " not found"));

                // Rol
                // TODO: paginación


                en = cobroRESTCAD.GetPedidoOfCobro (idCobro);



                // Convert return
                if (en != null) {
                        returnValue = PedidoAssembler.Convert (en, session);
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
        if (returnValue == null)
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


[Route ("~/api/Pedido/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] ComandaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        PedidoRESTCAD pedidoRESTCAD = null;
        ComandaCEN comandaCEN = null;
        PedidoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                pedidoRESTCAD = new PedidoRESTCAD (session);
                comandaCEN = new ComandaCEN (pedidoRESTCAD);

                // Create
                returnOID = comandaCEN.Nuevo (
                        dto.EstadoPedido                                                                                 //Atributo Primitivo: p_estadoPedido
                        ,
                        //Atributo OID: p_mesa
                        // attr.estaRelacionado: true
                        dto.Mesa_oid                 // association role

                        ,
                        //Atributo OID: p_empleado
                        // attr.estaRelacionado: true
                        dto.Empleado_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = PedidoAssembler.Convert (pedidoRESTCAD.ReadOIDDefault (returnOID), session);
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

        // Return 201 - Created
        response = this.Request.CreateResponse (HttpStatusCode.Created, returnValue);

        // Location Header
        /*
         * Dictionary<string, object> routeValues = new Dictionary<string, object>();
         *
         * // TODO: y rolPaths
         * routeValues.Add("id", returnOID);
         *
         * uri = Url.Link("GetOIDPedido", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}













[HttpPost]

[Route ("~/api/Pedido/DamePedidoPlato")]


public HttpResponseMessage DamePedidoPlato (int p_plato, int p_comanda)
{
        // CAD, CEN, returnValue
        PedidoRESTCAD pedidoRESTCAD = null;
        ComandaCEN comandaCEN = null;

        System.Collections.Generic.List<PedidoDTOA> returnValue = null;
        System.Collections.Generic.List<ComandaEN> en;

        try
        {
                SessionInitializeTransaction ();


                pedidoRESTCAD = new PedidoRESTCAD (session);
                comandaCEN = new ComandaCEN (pedidoRESTCAD);


                // Operation
                en = comandaCEN.DameComandaPlato (p_plato, p_comanda).ToList ();
                SessionCommit ();

                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PedidoDTOA>();
                        foreach (ComandaEN entry in en)
                                returnValue.Add (PedidoAssembler.Convert (entry, session));
                }
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






/*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_PedidoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
