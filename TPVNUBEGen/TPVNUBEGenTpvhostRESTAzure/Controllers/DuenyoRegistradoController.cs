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


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_DuenyoRegistradoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Http.Cors;
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/DuenyoRegistrado")]
public class DuenyoRegistradoController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/DuenyoRegistrado/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;

        List<DuenyoEN> duenyoEN = null;
        List<DuenyoRegistradoDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new DuenyoCEN ().CheckToken (token);



                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);

                // Data
                // TODO: paginación

                duenyoEN = duenyoCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (duenyoEN != null) {
                        returnValue = new List<DuenyoRegistradoDTOA>();
                        foreach (DuenyoEN entry in duenyoEN)
                                returnValue.Add (DuenyoRegistradoAssembler.Convert (entry, session));
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





[Route ("~/api/DuenyoRegistrado/GetDuenyoOfEmpresa")]

public HttpResponseMessage GetDuenyoOfEmpresa (int idEmpresa)
{
        // CAD, EN
        EmpresaRESTCAD empresaRESTCAD = null;
        EmpresaEN empresaEN = null;

        // returnValue
        DuenyoEN en = null;
        DuenyoRegistradoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                new DuenyoCEN ().CheckToken (token);


                empresaRESTCAD = new EmpresaRESTCAD (session);

                // Exists Empresa
                empresaEN = empresaRESTCAD.ReadOIDDefault (idEmpresa);
                if (empresaEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Empresa#" + idEmpresa + " not found"));

                // Rol
                // TODO: paginación


                en = empresaRESTCAD.GetDuenyoOfEmpresa (idEmpresa);



                // Convert return
                if (en != null) {
                        returnValue = DuenyoRegistradoAssembler.Convert (en, session);
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
// [Route("{idDuenyoRegistrado}", Name="GetOIDDuenyoRegistrado")]

[Route ("~/api/DuenyoRegistrado")]

public HttpResponseMessage ReadOID ()
{
        // CAD, CEN, EN, returnValue
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoEN duenyoEN = null;
        DuenyoRegistradoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new DuenyoCEN ().CheckToken (token);



                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);

                // Data
                duenyoEN = duenyoCEN.ReadOID (id);

                // Convert return
                if (duenyoEN != null) {
                        returnValue = DuenyoRegistradoAssembler.Convert (duenyoEN, session);
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


[Route ("~/api/DuenyoRegistrado/Modificar")]

public HttpResponseMessage Modificar ( [FromBody] DuenyoDTO dto)
{
        // CAD, CEN, returnValue
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;
        DuenyoRegistradoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new DuenyoCEN ().CheckToken (token);



                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);

                // Modify
                duenyoCEN.Modificar (id,
                        dto.Dni
                        ,
                        dto.Nombre
                        ,
                        dto.Apellidos
                        ,
                        dto.Telefono
                        ,
                        dto.Pass
                        ,
                        dto.Email
                        ,
                        dto.Foto
                        );

                // Return modified object
                returnValue = DuenyoRegistradoAssembler.Convert (duenyoRegistradoRESTCAD.ReadOIDDefault (id), session);

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


[Route ("~/api/DuenyoRegistrado/Eliminar")]

public HttpResponseMessage Eliminar (      )
{
        // CAD, CEN
        DuenyoRegistradoRESTCAD duenyoRegistradoRESTCAD = null;
        DuenyoCEN duenyoCEN = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new DuenyoCEN ().CheckToken (token);



                duenyoRegistradoRESTCAD = new DuenyoRegistradoRESTCAD (session);
                duenyoCEN = new DuenyoCEN (duenyoRegistradoRESTCAD);

                duenyoCEN.Eliminar (id);
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









/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_DuenyoRegistradoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs

[HttpPost]
[Route ("~/api/DuenyoRegistrado/UploadImage")]
public async Task<HttpResponseMessage> UploadImage (int p_oid, string p_pass)
{
        DuenyoCEN duenyoCEN = new DuenyoCEN ();
        DuenyoEN duenyo = null;

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

                                        var filePath = HttpContext.Current.Server.MapPath ("~/DuenyosImages");
                                        bool exists = System.IO.Directory.Exists (filePath);
                                        if (!exists)
                                                System.IO.Directory.CreateDirectory (filePath);

                                        var final_path = filePath + "/" + imageName;
                                        postedFile.SaveAs (final_path);
                                        duenyo = duenyoCEN.ReadOID (p_oid);
                                        duenyoCEN.Modificar (p_oid, duenyo.Dni, duenyo.Nombre, duenyo.Apellidos, duenyo.Telefono, p_pass, duenyo.Email, final_path);
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
[Route ("~/api/DuenyoRegistrado/GetImage")]
public Byte[] GetImage (int id)
{
        DuenyoCEN duenyoCEN = new DuenyoCEN ();
        DuenyoEN duenyo = duenyoCEN.ReadOID (id);

        // string tempName = id + imageName;

        if (!duenyo.Foto.StartsWith ("http")) {
                var filePath = HttpContext.Current.Server.MapPath ("~/DuenyosImages");
                bool exists = System.IO.Directory.Exists (filePath);
                if (!exists) return null;
                exists = System.IO.File.Exists (duenyo.Foto);
                if (!exists) return null;
                Byte[] image = File.ReadAllBytes (duenyo.Foto);
                return image;
        }
        else{
                using (var webClient = new WebClient ())
                {
                        try
                        {
                                Byte[] image = webClient.DownloadData (duenyo.Foto);
                                return image;
                        }
                        catch (Exception e)
                        {
                                return null;
                        }
                }
        }
}

[HttpPost]
[Route ("~/api/Duenyo/RemoveImage")]
public bool RemoveImage (int id, string imageName)
{
        DuenyoCEN duenyoCEN = new DuenyoCEN ();
        DuenyoEN duenyo = duenyoCEN.ReadOID (id);
        var filePath = HttpContext.Current.Server.MapPath ("~/DuenyosImages");
        bool exists = System.IO.Directory.Exists (filePath);

        if (!exists) return false;

        if (!duenyo.Foto.StartsWith ("http")) {
                exists = System.IO.File.Exists (duenyo.Foto);
                if (!exists) return false;
                File.Delete (duenyo.Foto);
                return true;
        }
        return false;
}

[HttpGet]
[Route ("~/api/Duenyo/DuenyoCount")]
public int NivelCount ()
{
        return new DuenyoCEN ().ReadAll (0, -1).Count ();
}


/*PROTECTED REGION END*/
}
}
