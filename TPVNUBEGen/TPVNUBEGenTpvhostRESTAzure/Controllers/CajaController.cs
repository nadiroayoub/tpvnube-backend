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


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_CajaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Caja")]
public class CajaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Caja/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;

        List<CajaEN> cajaEN = null;
        List<CajaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);

                // Data
                // TODO: paginación

                cajaEN = cajaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (cajaEN != null) {
                        returnValue = new List<CajaDTOA>();
                        foreach (CajaEN entry in cajaEN)
                                returnValue.Add (CajaAssembler.Convert (entry, session));
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





[Route ("~/api/Caja/GetCajaOfNegocio")]

public HttpResponseMessage GetCajaOfNegocio (int idNegocio)
{
        // CAD, EN
        NegocioRESTCAD negocioRESTCAD = null;
        NegocioEN negocioEN = null;

        // returnValue
        List<CajaEN> en = null;
        List<CajaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                negocioRESTCAD = new NegocioRESTCAD (session);

                // Exists Negocio
                negocioEN = negocioRESTCAD.ReadOIDDefault (idNegocio);
                if (negocioEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Negocio#" + idNegocio + " not found"));

                // Rol
                // TODO: paginación


                en = negocioRESTCAD.GetCajaOfNegocio (idNegocio).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<CajaDTOA>();
                        foreach (CajaEN entry in en)
                                returnValue.Add (CajaAssembler.Convert (entry, session));
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
// [Route("{idCaja}", Name="GetOIDCaja")]

[Route ("~/api/Caja/{idCaja}")]

public HttpResponseMessage ReadOID (int idCaja)
{
        // CAD, CEN, EN, returnValue
        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;
        CajaEN cajaEN = null;
        CajaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);

                // Data
                cajaEN = cajaCEN.ReadOID (idCaja);

                // Convert return
                if (cajaEN != null) {
                        returnValue = CajaAssembler.Convert (cajaEN, session);
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



// No pasa el slEnables: dameCajaPorNegocio

[HttpGet]

[Route ("~/api/Caja/DameCajaPorNegocio")]

public HttpResponseMessage DameCajaPorNegocio (int ? p_negocio)
{
        // CAD, CEN, EN, returnValue

        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;


        System.Collections.Generic.List<CajaEN> en;

        System.Collections.Generic.List<CajaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);

                // CEN return



                en = cajaCEN.DameCajaPorNegocio (p_negocio).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<CajaDTOA>();
                        foreach (CajaEN entry in en)
                                returnValue.Add (CajaAssembler.Convert (entry, session));
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



[HttpPost]


[Route ("~/api/Caja/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] CajaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;
        CajaDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);

                // Create
                returnOID = cajaCEN.Nuevo (

                        //Atributo OID: p_negocio
                        // attr.estaRelacionado: true
                        dto.Negocio_oid                 // association role

                        , dto.Descripcion                                                                                                                                                //Atributo Primitivo: p_descripcion
                        ,
                        //Atributo OID: p_duenyo
                        // attr.estaRelacionado: true
                        dto.Duenyo_oid                 // association role

                        , dto.Fondo                                                                                                                                                      //Atributo Primitivo: p_fondo
                        , dto.Fecha                                                                                                                                                      //Atributo Primitivo: p_fecha
                        );
                SessionCommit ();

                // Convert return
                returnValue = CajaAssembler.Convert (cajaRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDCaja", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Caja/Modificar")]

public HttpResponseMessage Modificar (int idCaja, [FromBody] CajaDTO dto)
{
        // CAD, CEN, returnValue
        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;
        CajaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);

                // Modify
                cajaCEN.Modificar (idCaja,
                        dto.Descripcion
                        ,
                        dto.Fondo
                        ,
                        dto.Fecha
                        );

                // Return modified object
                returnValue = CajaAssembler.Convert (cajaRESTCAD.ReadOIDDefault (idCaja), session);

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


[Route ("~/api/Caja/Eliminar")]

public HttpResponseMessage Eliminar (int p_caja_oid)
{
        // CAD, CEN
        CajaRESTCAD cajaRESTCAD = null;
        CajaCEN cajaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                cajaRESTCAD = new CajaRESTCAD (session);
                cajaCEN = new CajaCEN (cajaRESTCAD);

                cajaCEN.Eliminar (p_caja_oid);
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









/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_CajaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
