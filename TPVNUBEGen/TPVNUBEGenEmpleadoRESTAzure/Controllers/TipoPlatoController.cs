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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_TipoPlatoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/TipoPlato")]
public class TipoPlatoController : BasicController
{
// Voy a generar el readAll







[HttpGet]





[Route ("~/api/TipoPlato/GetTipoPlatoOfPlato")]

public HttpResponseMessage GetTipoPlatoOfPlato (int idPlato)
{
        // CAD, EN
        PlatoRESTCAD platoRESTCAD = null;
        PlatoEN platoEN = null;

        // returnValue
        TipoPlatoEN en = null;
        TipoPlatoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);

                // Exists Plato
                platoEN = platoRESTCAD.ReadOIDDefault (idPlato);
                if (platoEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Plato#" + idPlato + " not found"));

                // Rol
                // TODO: paginación


                en = platoRESTCAD.GetTipoPlatoOfPlato (idPlato);



                // Convert return
                if (en != null) {
                        returnValue = TipoPlatoAssembler.Convert (en, session);
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










[HttpPost]


[Route ("~/api/TipoPlato/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] TipoPlatoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        TipoPlatoRESTCAD tipoPlatoRESTCAD = null;
        TipoPlatoCEN tipoPlatoCEN = null;
        TipoPlatoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                tipoPlatoRESTCAD = new TipoPlatoRESTCAD (session);
                tipoPlatoCEN = new TipoPlatoCEN (tipoPlatoRESTCAD);

                // Create
                returnOID = tipoPlatoCEN.Nuevo (
                        dto.Nombre                                                                               //Atributo Primitivo: p_nombre
                        );
                SessionCommit ();

                // Convert return
                returnValue = TipoPlatoAssembler.Convert (tipoPlatoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDTipoPlato", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/TipoPlato/Modificar")]

public HttpResponseMessage Modificar (int idTipoPlato, [FromBody] TipoPlatoDTO dto)
{
        // CAD, CEN, returnValue
        TipoPlatoRESTCAD tipoPlatoRESTCAD = null;
        TipoPlatoCEN tipoPlatoCEN = null;
        TipoPlatoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                tipoPlatoRESTCAD = new TipoPlatoRESTCAD (session);
                tipoPlatoCEN = new TipoPlatoCEN (tipoPlatoRESTCAD);

                // Modify
                tipoPlatoCEN.Modificar (idTipoPlato,
                        dto.Nombre
                        );

                // Return modified object
                returnValue = TipoPlatoAssembler.Convert (tipoPlatoRESTCAD.ReadOIDDefault (idTipoPlato), session);

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


[Route ("~/api/TipoPlato/Eliminar")]

public HttpResponseMessage Eliminar (int p_tipoplato_oid)
{
        // CAD, CEN
        TipoPlatoRESTCAD tipoPlatoRESTCAD = null;
        TipoPlatoCEN tipoPlatoCEN = null;

        try
        {
                SessionInitializeTransaction ();


                tipoPlatoRESTCAD = new TipoPlatoRESTCAD (session);
                tipoPlatoCEN = new TipoPlatoCEN (tipoPlatoRESTCAD);

                tipoPlatoCEN.Eliminar (p_tipoplato_oid);
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









/*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_TipoPlatoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
