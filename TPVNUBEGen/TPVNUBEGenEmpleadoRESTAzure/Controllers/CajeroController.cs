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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_CajeroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Cajero")]
public class CajeroController : BasicController
{
// Voy a generar el readAll












[HttpGet]
// [Route("{idCajero}", Name="GetOIDCajero")]

[Route ("~/api/Cajero/{idCajero}")]

public HttpResponseMessage ReadOID (int idCajero)
{
        // CAD, CEN, EN, returnValue
        CajeroRESTCAD cajeroRESTCAD = null;
        CajeroCEN cajeroCEN = null;
        CajeroEN cajeroEN = null;
        CajeroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cajeroRESTCAD = new CajeroRESTCAD (session);
                cajeroCEN = new CajeroCEN (cajeroRESTCAD);

                // Data
                cajeroEN = cajeroCEN.ReadOID (idCajero);

                // Convert return
                if (cajeroEN != null) {
                        returnValue = CajeroAssembler.Convert (cajeroEN, session);
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





















/*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_CajeroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
