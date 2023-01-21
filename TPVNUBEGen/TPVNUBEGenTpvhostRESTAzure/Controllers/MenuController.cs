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


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_MenuControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Http.Cors;
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Menu")]
public class MenuController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Menu/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;

        List<MenuEN> menuEN = null;
        List<MenuDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                // Data
                // TODO: paginación

                menuEN = menuCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (menuEN != null) {
                        returnValue = new List<MenuDTOA>();
                        foreach (MenuEN entry in menuEN)
                                returnValue.Add (MenuAssembler.Convert (entry, session));
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
// [Route("{idMenu}", Name="GetOIDMenu")]

[Route ("~/api/Menu/{idMenu}")]

public HttpResponseMessage ReadOID (int idMenu)
{
        // CAD, CEN, EN, returnValue
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;
        MenuEN menuEN = null;
        MenuDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                // Data
                menuEN = menuCEN.ReadOID (idMenu);

                // Convert return
                if (menuEN != null) {
                        returnValue = MenuAssembler.Convert (menuEN, session);
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


[Route ("~/api/Menu/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] MenuDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;
        MenuDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                // Create
                returnOID = menuCEN.Nuevo (
                        dto.Nombre                                                                               //Atributo Primitivo: p_nombre
                        , LineaMenuAssemblerDTO.ConvertList (dto.LineaMenu)
                        //Atributo Object: p_lineaMenu
                        , dto.Foto                                                                                                                                                       //Atributo Primitivo: p_foto
                        , dto.Precio                                                                                                                                                     //Atributo Primitivo: p_precio
                        ,
                        //Atributo OID: p_negocio
                        // attr.estaRelacionado: true
                        dto.Negocio_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = MenuAssembler.Convert (menuRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDMenu", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}






[HttpPut]


[Route ("~/api/Menu/Modificar")]

public HttpResponseMessage Modificar (int idMenu, [FromBody] MenuDTO dto)
{
        // CAD, CEN, returnValue
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;
        MenuDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                // Modify
                menuCEN.Modificar (idMenu,
                        dto.Nombre
                        ,
                        dto.Foto
                        ,
                        dto.Precio
                        );

                // Return modified object
                returnValue = MenuAssembler.Convert (menuRESTCAD.ReadOIDDefault (idMenu), session);

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


[Route ("~/api/Menu/Eliminar")]

public HttpResponseMessage Eliminar (int p_menu_oid)
{
        // CAD, CEN
        MenuRESTCAD menuRESTCAD = null;
        MenuCEN menuCEN = null;

        try
        {
                SessionInitializeTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);
                menuCEN = new MenuCEN (menuRESTCAD);

                menuCEN.Eliminar (p_menu_oid);
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









/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_MenuControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs

[HttpPost]
[Route ("~/api/Menu/UploadImage")]
public async Task<HttpResponseMessage> UploadImage (int p_oid, string p_pass)
{
        MenuCEN menuCEN = new MenuCEN ();
        MenuEN menu = null;

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

                                        var filePath = "C:\\Users\\nadir\\Documents\\Master\\TFM\\Movil\\TPVHost\\src\\assets\\images\\MenusImages";
                                        bool exists = System.IO.Directory.Exists (filePath);
                                        if (!exists)
                                                System.IO.Directory.CreateDirectory (filePath);

                                        var final_path = filePath + "/" + imageName;
                                        postedFile.SaveAs (final_path);
                                        menu = menuCEN.ReadOID (p_oid);
                                        //menuCEN.Modificar(p_oid, menu.Dni, menu.Nombre, menu.Apellidos, menu.Telefono, p_pass, menu.Email, final_path);
                                        menuCEN.Modificar (p_oid, menu.Nombre, final_path, menu.Precio);
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
[Route ("~/api/Menu/GetImage")]
public Byte[] GetImage (int id)
{
        MenuCEN menuCEN = new MenuCEN ();
        MenuEN menu = menuCEN.ReadOID (id);

        // string tempName = id + imageName;

        if (!menu.Foto.StartsWith ("http")) {
                var filePath = HttpContext.Current.Server.MapPath ("~/MenusImages");
                bool exists = System.IO.Directory.Exists (filePath);
                if (!exists) return null;
                exists = System.IO.File.Exists (menu.Foto);
                if (!exists) return null;
                Byte[] image = File.ReadAllBytes (menu.Foto);
                return image;
        }
        else{
                using (var webClient = new WebClient ())
                {
                        try
                        {
                                Byte[] image = webClient.DownloadData (menu.Foto);
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
