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


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_DuenyoAnonimoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/DuenyoAnonimo")]
public class DuenyoAnonimoController : BasicController
{
// Voy a generar el readAll















[HttpPost]

[Route ("~/api/DuenyoAnonimo/Login")]


public HttpResponseMessage Login ( [FromBody] DuenyoDTO dto)
{
        // CAD, CEN, returnValue
        DuenyoAnonimoRESTCAD duenyoAnonimoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        string token = null;

        try
        {
                SessionInitializeTransaction ();
                duenyoAnonimoRESTCAD = new DuenyoAnonimoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoAnonimoRESTCAD);


                // Operation
                token = duenyoCEN.Login (
                        dto.Email
                        , dto.Pass
                        );

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
        if (token != null)
                return this.Request.CreateResponse (HttpStatusCode.OK, token);
        else
                return this.Request.CreateResponse (HttpStatusCode.Unauthorized, "");
}




[HttpPost]


[Route ("~/api/DuenyoAnonimo/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] DuenyoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        DuenyoAnonimoRESTCAD duenyoAnonimoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoAnonimoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                duenyoAnonimoRESTCAD = new DuenyoAnonimoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoAnonimoRESTCAD);

                // Create
                returnOID = duenyoCEN.Nuevo (
                        dto.Dni                                                                          //Atributo Primitivo: p_dni
                        , dto.Nombre                                                                                                                                                     //Atributo Primitivo: p_nombre
                        , dto.Apellidos                                                                                                                                                  //Atributo Primitivo: p_apellidos
                        , dto.Telefono                                                                                                                                                   //Atributo Primitivo: p_telefono
                        , dto.Pass                                                                                                                                                       //Atributo Primitivo: p_pass
                        , dto.Email                                                                                                                                                      //Atributo Primitivo: p_email
                        , dto.Foto                                                                                                                                                       //Atributo Primitivo: p_foto
                        );
                SessionCommit ();

                // Convert return
                returnValue = DuenyoAnonimoAssembler.Convert (duenyoAnonimoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDDuenyoAnonimo", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}
















/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_DuenyoAnonimoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
