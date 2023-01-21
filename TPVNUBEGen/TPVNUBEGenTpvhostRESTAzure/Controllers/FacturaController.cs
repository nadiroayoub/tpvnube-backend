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


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_FacturaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Factura")]
public class FacturaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Factura/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        FacturaRESTCAD facturaRESTCAD = null;
        FacturaCEN facturaCEN = null;

        List<FacturaEN> facturaEN = null;
        List<FacturaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                facturaRESTCAD = new FacturaRESTCAD (session);
                facturaCEN = new FacturaCEN (facturaRESTCAD);

                // Data
                // TODO: paginación

                facturaEN = facturaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (facturaEN != null) {
                        returnValue = new List<FacturaDTOA>();
                        foreach (FacturaEN entry in facturaEN)
                                returnValue.Add (FacturaAssembler.Convert (entry, session));
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





[Route ("~/api/Factura/GetAllFacturaOfCliente")]

public HttpResponseMessage GetAllFacturaOfCliente (int idCliente)
{
        // CAD, EN
        ClienteRESTCAD clienteRESTCAD = null;
        ClienteEN clienteEN = null;

        // returnValue
        List<FacturaEN> en = null;
        List<FacturaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                clienteRESTCAD = new ClienteRESTCAD (session);

                // Exists Cliente
                clienteEN = clienteRESTCAD.ReadOIDDefault (idCliente);
                if (clienteEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Cliente#" + idCliente + " not found"));

                // Rol
                // TODO: paginación


                en = clienteRESTCAD.GetAllFacturaOfCliente (idCliente).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<FacturaDTOA>();
                        foreach (FacturaEN entry in en)
                                returnValue.Add (FacturaAssembler.Convert (entry, session));
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
// [Route("{idFactura}", Name="GetOIDFactura")]

[Route ("~/api/Factura/{idFactura}")]

public HttpResponseMessage ReadOID (int idFactura)
{
        // CAD, CEN, EN, returnValue
        FacturaRESTCAD facturaRESTCAD = null;
        FacturaCEN facturaCEN = null;
        FacturaEN facturaEN = null;
        FacturaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                facturaRESTCAD = new FacturaRESTCAD (session);
                facturaCEN = new FacturaCEN (facturaRESTCAD);

                // Data
                facturaEN = facturaCEN.ReadOID (idFactura);

                // Convert return
                if (facturaEN != null) {
                        returnValue = FacturaAssembler.Convert (facturaEN, session);
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


[Route ("~/api/Factura/Modificar")]

public HttpResponseMessage Modificar (int idFactura, [FromBody] FacturaDTO dto)
{
        // CAD, CEN, returnValue
        FacturaRESTCAD facturaRESTCAD = null;
        FacturaCEN facturaCEN = null;
        FacturaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                facturaRESTCAD = new FacturaRESTCAD (session);
                facturaCEN = new FacturaCEN (facturaRESTCAD);

                // Modify
                facturaCEN.Modificar (idFactura,
                        dto.Numero
                        ,
                        dto.Fecha
                        ,
                        dto.Precio
                        ,
                        dto.Descripcion
                        );

                // Return modified object
                returnValue = FacturaAssembler.Convert (facturaRESTCAD.ReadOIDDefault (idFactura), session);

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


[Route ("~/api/Factura/Eliminar")]

public HttpResponseMessage Eliminar (int p_factura_oid)
{
        // CAD, CEN
        FacturaRESTCAD facturaRESTCAD = null;
        FacturaCEN facturaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                facturaRESTCAD = new FacturaRESTCAD (session);
                facturaCEN = new FacturaCEN (facturaRESTCAD);

                facturaCEN.Eliminar (p_factura_oid);
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









/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_FacturaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
