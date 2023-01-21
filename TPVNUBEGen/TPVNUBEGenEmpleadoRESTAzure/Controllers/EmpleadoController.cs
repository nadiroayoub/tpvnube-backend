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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_EmpleadoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
using System.Threading.Tasks;
using System.Web;
using System.IO;
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Empleado")]
public class EmpleadoController : BasicController
{
// Voy a generar el readAll











[HttpGet]
// [Route("{idEmpleado}", Name="GetOIDEmpleado")]

[Route ("~/api/Empleado")]

public HttpResponseMessage ReadOID ()
{
        // CAD, CEN, EN, returnValue
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoEN empleadoEN = null;
        EmpleadoDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new EmpleadoCEN ().CheckToken (token);



                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);

                // Data
                empleadoEN = empleadoCEN.ReadOID (id);

                // Convert return
                if (empleadoEN != null) {
                        returnValue = EmpleadoAssembler.Convert (empleadoEN, session);
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


[Route ("~/api/Empleado/ModificarSinPass")]

public HttpResponseMessage ModificarSinPass ( [FromBody] EmpleadoDTO dto)
{
        // CAD, CEN, returnValue
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoCEN empleadoCEN = null;
        EmpleadoDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                string token = "";
                if (Request.Headers.Authorization != null)
                        token = Request.Headers.Authorization.ToString ();
                int id = new EmpleadoCEN ().CheckToken (token);



                empleadoRESTCAD = new EmpleadoRESTCAD (session);
                empleadoCEN = new EmpleadoCEN (empleadoRESTCAD);

                // Modify
                empleadoCEN.ModificarSinPass (id,
                        dto.Nombre
                        ,
                        dto.Apellidos
                        ,
                        dto.Foto
                        ,
                        dto.Dni
                        ,
                        dto.Email
                        ,
                        dto.Telefono
                        );

                // Return modified object
                returnValue = EmpleadoAssembler.Convert (empleadoRESTCAD.ReadOIDDefault (id), session);

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












/*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_EmpleadoControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs

[HttpPost]
[Route ("~/api/Empleado/UploadImage")]
public async Task<HttpResponseMessage> UploadImage (int p_oid)
{
        EmpleadoCEN empleadoCEN = new EmpleadoCEN ();
        EmpleadoEN empleado = null;

        Dictionary<string, object> dict = new Dictionary<string, object>();
        try
        {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files) {
                        HttpResponseMessage response = Request.CreateResponse (HttpStatusCode.Created);

                        var postedFile = httpRequest.Files [file];
                        if (postedFile != null) {
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

                                        //var filePath = HttpContext.Current.Server.MapPath ("~/EmpleadosImages");
                                        var filePath = "C:\\Users\\nadir\\Documents\\Master\\TFM\\Movil\\TPVHost\\src\\assets\\images\\EmpleadoImages";
                                        bool exists = System.IO.Directory.Exists (filePath);
                                        if (!exists)
                                                System.IO.Directory.CreateDirectory (filePath);

                                        var final_path = filePath + "/" + imageName;
                                        postedFile.SaveAs (final_path);
                                        empleado = empleadoCEN.ReadOID (p_oid);
                                        empleadoCEN.ModificarSinPass (p_oid, empleado.Nombre, empleado.Apellidos, final_path, empleado.Dni, empleado.Email, empleado.Telefono);
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
[Route ("~/api/Empleado/GetImage")]
public Byte[] GetImage (int id, string imageName)
{
        EmpleadoCEN empleadoCEN = new EmpleadoCEN ();
        EmpleadoEN empleado = empleadoCEN.ReadOID (id);

        // string tempName = id + imageName;

        if (!empleado.Foto.StartsWith ("http")) {
                var filePath = HttpContext.Current.Server.MapPath ("~/DuenyosImages");
                bool exists = System.IO.Directory.Exists (filePath);
                if (!exists) return null;
                exists = System.IO.File.Exists (empleado.Foto);
                if (!exists) return null;
                Byte[] image = File.ReadAllBytes (empleado.Foto);
                return image;
        }
        else{
                using (var webClient = new WebClient ())
                {
                        try
                        {
                                Byte[] image = webClient.DownloadData (empleado.Foto);
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
[Route ("~/api/Empleado/RemoveImage")]
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
[Route ("~/api/Empleado/EmpleadoCount")]
public int NivelCount ()
{
        return new DuenyoCEN ().ReadAll (0, -1).Count ();
}


/*PROTECTED REGION END*/
}
}
