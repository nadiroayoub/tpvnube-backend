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


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_MesaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Mesa")]
public class MesaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Mesa/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        MesaRESTCAD mesaRESTCAD = null;
        MesaCEN mesaCEN = null;

        List<MesaEN> mesaEN = null;
        List<MesaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                mesaRESTCAD = new MesaRESTCAD (session);
                mesaCEN = new MesaCEN (mesaRESTCAD);

                // Data
                // TODO: paginación

                mesaEN = mesaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (mesaEN != null) {
                        returnValue = new List<MesaDTOA>();
                        foreach (MesaEN entry in mesaEN)
                                returnValue.Add (MesaAssembler.Convert (entry, session));
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





[Route ("~/api/Mesa/GetAllMesaOfNegocio")]

public HttpResponseMessage GetAllMesaOfNegocio (int idNegocio)
{
        // CAD, EN
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioEN negocioEN = null;

        // returnValue
        List<MesaEN> en = null;
        List<MesaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);

                // Exists Negocio
                negocioEN = negocioRESTCAD.ReadOIDDefault (idNegocio);
                if (negocioEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Negocio#" + idNegocio + " not found"));

                // Rol
                // TODO: paginación


                en = negocioRESTCAD.GetAllMesaOfNegocio (idNegocio).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<MesaDTOA>();
                        foreach (MesaEN entry in en)
                                returnValue.Add (MesaAssembler.Convert (entry, session));
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
// [Route("{idMesa}", Name="GetOIDMesa")]

[Route ("~/api/Mesa/{idMesa}")]

public HttpResponseMessage ReadOID (int idMesa)
{
        // CAD, CEN, EN, returnValue
        MesaRESTCAD mesaRESTCAD = null;
        MesaCEN mesaCEN = null;
        MesaEN mesaEN = null;
        MesaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                mesaRESTCAD = new MesaRESTCAD (session);
                mesaCEN = new MesaCEN (mesaRESTCAD);

                // Data
                mesaEN = mesaCEN.ReadOID (idMesa);

                // Convert return
                if (mesaEN != null) {
                        returnValue = MesaAssembler.Convert (mesaEN, session);
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


[Route ("~/api/Mesa/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] MesaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        MesaRESTCAD mesaRESTCAD = null;
        MesaCEN mesaCEN = null;
        MesaDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                mesaRESTCAD = new MesaRESTCAD (session);
                mesaCEN = new MesaCEN (mesaRESTCAD);

                // Create
                returnOID = mesaCEN.Nuevo (
                        dto.Estado                                                                               //Atributo Primitivo: p_estado
                        , dto.Numero                                                                                                                                                     //Atributo Primitivo: p_numero
                        ,
                        //Atributo OID: p_negocio
                        // attr.estaRelacionado: true
                        dto.Negocio_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = MesaAssembler.Convert (mesaRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDMesa", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Mesa/Modificar")]

public HttpResponseMessage Modificar (int idMesa, [FromBody] MesaDTO dto)
{
        // CAD, CEN, returnValue
        MesaRESTCAD mesaRESTCAD = null;
        MesaCEN mesaCEN = null;
        MesaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                mesaRESTCAD = new MesaRESTCAD (session);
                mesaCEN = new MesaCEN (mesaRESTCAD);

                // Modify
                mesaCEN.Modificar (idMesa,
                        dto.Estado
                        ,
                        dto.Numero
                        );

                // Return modified object
                returnValue = MesaAssembler.Convert (mesaRESTCAD.ReadOIDDefault (idMesa), session);

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


[Route ("~/api/Mesa/Eliminar")]

public HttpResponseMessage Eliminar (int p_mesa_oid)
{
        // CAD, CEN
        MesaRESTCAD mesaRESTCAD = null;
        MesaCEN mesaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                mesaRESTCAD = new MesaRESTCAD (session);
                mesaCEN = new MesaCEN (mesaRESTCAD);

                mesaCEN.Eliminar (p_mesa_oid);
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









/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_MesaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
