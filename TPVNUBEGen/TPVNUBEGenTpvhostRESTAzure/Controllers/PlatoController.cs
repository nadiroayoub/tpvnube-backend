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


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_PlatoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Http.Cors;
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Plato")]
public class PlatoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Plato/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;

        List<PlatoEN> platoEN = null;
        List<PlatoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                // Data
                // TODO: paginación

                platoEN = platoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (platoEN != null) {
                        returnValue = new List<PlatoDTOA>();
                        foreach (PlatoEN entry in platoEN)
                                returnValue.Add (PlatoAssembler.Convert (entry, session));
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
// [Route("{idPlato}", Name="GetOIDPlato")]

[Route ("~/api/Plato/{idPlato}")]

public HttpResponseMessage ReadOID (int idPlato)
{
        // CAD, CEN, EN, returnValue
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;
        PlatoEN platoEN = null;
        PlatoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                // Data
                platoEN = platoCEN.ReadOID (idPlato);

                // Convert return
                if (platoEN != null) {
                        returnValue = PlatoAssembler.Convert (platoEN, session);
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


[Route ("~/api/Plato/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] PlatoDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;
        PlatoDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                // Create
                returnOID = platoCEN.Nuevo (
                        dto.Nombre                                                                               //Atributo Primitivo: p_nombre
                        , dto.Precio                                                                                                                                                     //Atributo Primitivo: p_precio
                        , LineaPlatoAssemblerDTO.ConvertList (dto.LineaPlato)
                        //Atributo Object: p_lineaPlato
                        , dto.Foto                                                                                                                                                       //Atributo Primitivo: p_foto
                        ,
                        //Atributo OID: p_tipoPlato
                        // attr.estaRelacionado: true
                        dto.TipoPlato_oid                 // association role

                        ,
                        //Atributo OID: p_negocio
                        // attr.estaRelacionado: true
                        dto.Negocio_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = PlatoAssembler.Convert (platoRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDPlato", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Plato/Modificar")]

public HttpResponseMessage Modificar (int idPlato, [FromBody] PlatoDTO dto)
{
        // CAD, CEN, returnValue
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;
        PlatoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                // Modify
                platoCEN.Modificar (idPlato,
                        dto.Nombre
                        ,
                        dto.Precio
                        ,
                        dto.Foto
                        );

                // Return modified object
                returnValue = PlatoAssembler.Convert (platoRESTCAD.ReadOIDDefault (idPlato), session);

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


[Route ("~/api/Plato/Eliminar")]

public HttpResponseMessage Eliminar (int p_plato_oid)
{
        // CAD, CEN
        PlatoRESTCAD platoRESTCAD = null;
        PlatoCEN platoCEN = null;

        try
        {
                SessionInitializeTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);
                platoCEN = new PlatoCEN (platoRESTCAD);

                platoCEN.Eliminar (p_plato_oid);
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









/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_PlatoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
[HttpPost]
[Route ("~/api/Plato/UploadImage")]
public async Task<HttpResponseMessage> UploadImage (int p_oid, string p_pass)
{
        PlatoCEN platoCEN = new PlatoCEN ();
        PlatoEN plato = null;

        Dictionary<string, object> dict = new Dictionary<string, object>();
        try
        {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files) {
                        HttpResponseMessage response = Request.CreateResponse (HttpStatusCode.Created);

                        var postedFile = httpRequest.Files [file];
                        if (postedFile != null && postedFile.ContentLength > 0) {
                                int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB

                                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".jpeg", ".png" };
                                var ext = postedFile.FileName.Substring (postedFile.FileName.LastIndexOf ('.'));
                                var extension = ext.ToLower ();
                                if (!AllowedFileExtensions.Contains (extension)) {
                                        var message = string.Format ("Please Upload image of type .jpg,.gif,.png.");

                                        dict.Add ("error", message);
                                        return Request.CreateResponse (HttpStatusCode.BadRequest, dict);
                                }
                                else if (postedFile.ContentLength > MaxContentLength) {
                                        var message = string.Format ("Please Upload a file upto 1 mb.");

                                        dict.Add ("error", message);
                                        return Request.CreateResponse (HttpStatusCode.BadRequest, dict);
                                }
                                else{
                                        string imageName = p_oid + Path.GetExtension (postedFile.FileName);

                                        var filePath = "C:\\Users\\nadir\\Documents\\Master\\TFM\\Movil\\TPVHost\\src\\assets\\images\\PlatosImages";
                                        bool exists = System.IO.Directory.Exists (filePath);
                                        if (!exists)
                                                System.IO.Directory.CreateDirectory (filePath);

                                        var final_path = filePath + "/" + imageName;
                                        postedFile.SaveAs (final_path);
                                        plato = platoCEN.ReadOID (p_oid);
                                        //platoCEN.Modificar(p_oid, plato.Dni, plato.Nombre, plato.Apellidos, plato.Telefono, p_pass, plato.Email, final_path);
                                        platoCEN.Modificar (p_oid, plato.Nombre, plato.Precio, final_path);
                                }
                        }

                        var message1 = string.Format ("Image Updated Successfully.");
                        return Request.CreateErrorResponse (HttpStatusCode.Created, message1);;
                }
                var res = string.Format ("Please Upload a image.");
                dict.Add ("error", res);
                return Request.CreateResponse (HttpStatusCode.NotFound, dict);
        }
        catch (Exception ex)
        {
                var res = string.Format ("some Message");
                dict.Add ("error", res);
                return Request.CreateResponse (HttpStatusCode.NotFound, dict);
        }
}



[HttpGet]
[Route ("~/api/Plato/GetImage")]
public Byte[] GetImage (int id)
{
        PlatoCEN platoCEN = new PlatoCEN ();
        PlatoEN plato = platoCEN.ReadOID (id);

        // string tempName = id + imageName;

        if (!plato.Foto.StartsWith ("http")) {
                var filePath = HttpContext.Current.Server.MapPath ("~/PlatosImages");
                bool exists = System.IO.Directory.Exists (filePath);
                if (!exists) return null;
                exists = System.IO.File.Exists (plato.Foto);
                if (!exists) return null;
                Byte[] image = File.ReadAllBytes (plato.Foto);
                return image;
        }
        else{
                using (var webClient = new WebClient ())
                {
                        try
                        {
                                Byte[] image = webClient.DownloadData (plato.Foto);
                                return image;
                        }
                        catch (Exception e)
                        {
                                return null;
                        }
                }
        }
}
/*PROTECTED REGION END*/
}
}
