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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_PagoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Pago")]
public class PagoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Pago/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;

        List<CobroEN> cobroEN = null;
        List<PagoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);

                // Data
                // TODO: paginación

                cobroEN = cobroCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (cobroEN != null) {
                        returnValue = new List<PagoDTOA>();
                        foreach (CobroEN entry in cobroEN)
                                returnValue.Add (PagoAssembler.Convert (entry, session));
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
// [Route("{idPago}", Name="GetOIDPago")]

[Route ("~/api/Pago/{idPago}")]

public HttpResponseMessage ReadOID (int idPago)
{
        // CAD, CEN, EN, returnValue
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;
        CobroEN cobroEN = null;
        PagoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);

                // Data
                cobroEN = cobroCEN.ReadOID (idPago);

                // Convert return
                if (cobroEN != null) {
                        returnValue = PagoAssembler.Convert (cobroEN, session);
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









[HttpPut]


[Route ("~/api/Pago/Modificar")]

public HttpResponseMessage Modificar (int idPago, [FromBody] CobroDTO dto)
{
        // CAD, CEN, returnValue
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;
        PagoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);

                // Modify
                cobroCEN.Modificar (idPago,
                        dto.Monto
                        ,
                        dto.Fecha
                        );

                // Return modified object
                returnValue = PagoAssembler.Convert (pagoRESTCAD.ReadOIDDefault (idPago), session);

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

        // Return 404 - Not found
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NotFound);
        // Return 200 - OK
        else{
                response = this.Request.CreateResponse (HttpStatusCode.OK, returnValue);

                return response;
        }
}





[HttpDelete]


[Route ("~/api/Pago/Eliminar")]

public HttpResponseMessage Eliminar (int p_cobro_oid)
{
        // CAD, CEN
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;

        try
        {
                SessionInitializeTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);

                cobroCEN.Eliminar (p_cobro_oid);
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

        // Return 204 - No Content
        return this.Request.CreateResponse (HttpStatusCode.NoContent);
}






[HttpPost]

[Route ("~/api/Pago/Imprimir")]


public HttpResponseMessage Imprimir (int p_oid, int p_comanda)
{
        // CAD, CEN, returnValue
        PagoRESTCAD pagoRESTCAD = null;
        CobroCEN cobroCEN = null;

        try
        {
                SessionInitializeTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);
                cobroCEN = new CobroCEN (pagoRESTCAD);


                // Operation
                cobroCEN.ImprimirCuenta (p_oid, p_comanda);
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
        return this.Request.CreateResponse (HttpStatusCode.OK);
}




[HttpPost]

[Route ("~/api/Pago/Nuevo")]

public HttpResponseMessage Nuevo (float p_monto, int p_comanda, int p_tipocobro, int p_caja, int p_empleado, int p_negocio)
{
        // CP, returnValue
        CobroCP cobroCP = null;

        PagoDTOA returnValue;
        CobroEN en;

        try
        {
                SessionInitializeTransaction ();




                cobroCP = new CobroCP (session);

                // Operation
                en = cobroCP.Nuevo (p_monto, p_comanda, p_tipocobro, p_caja, p_empleado, p_negocio);
                SessionCommit ();

                // Convert return
                returnValue = PagoAssembler.Convert (en, session);
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





/*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_PagoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
