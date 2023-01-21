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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_NegocioControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Negocio")]
public class NegocioController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Negocio/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioCEN negocioCEN = null;

        List<NegocioEN> negocioEN = null;
        List<NegocioDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);
                negocioCEN = new NegocioCEN (negocioRESTCAD);

                // Data
                // TODO: paginación

                negocioEN = negocioCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (negocioEN != null) {
                        returnValue = new List<NegocioDTOA>();
                        foreach (NegocioEN entry in negocioEN)
                                returnValue.Add (NegocioAssembler.Convert (entry, session));
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
// [Route("{idNegocio}", Name="GetOIDNegocio")]

[Route ("~/api/Negocio/{idNegocio}")]

public HttpResponseMessage ReadOID (int idNegocio)
{
        // CAD, CEN, EN, returnValue
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioCEN negocioCEN = null;
        NegocioEN negocioEN = null;
        NegocioDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);
                negocioCEN = new NegocioCEN (negocioRESTCAD);

                // Data
                negocioEN = negocioCEN.ReadOID (idNegocio);

                // Convert return
                if (negocioEN != null) {
                        returnValue = NegocioAssembler.Convert (negocioEN, session);
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





















/*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_NegocioControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
