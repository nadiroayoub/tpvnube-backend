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


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_LineaComandaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/LineaComanda")]
public class LineaComandaController : BasicController
{
// Voy a generar el readAll







[HttpGet]





[Route ("~/api/LineaComanda/GetAllLineaComandaOfMenu")]

public HttpResponseMessage GetAllLineaComandaOfMenu (int idMenu)
{
        // CAD, EN
        MenuRESTCAD menuRESTCAD = null;
        MenuEN menuEN = null;

        // returnValue
        List<LineaComandaEN> en = null;
        List<LineaComandaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                menuRESTCAD = new MenuRESTCAD (session);

                // Exists Menu
                menuEN = menuRESTCAD.ReadOIDDefault (idMenu);
                if (menuEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Menu#" + idMenu + " not found"));

                // Rol
                // TODO: paginación


                en = menuRESTCAD.GetAllLineaComandaOfMenu (idMenu).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<LineaComandaDTOA>();
                        foreach (LineaComandaEN entry in en)
                                returnValue.Add (LineaComandaAssembler.Convert (entry, session));
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





[Route ("~/api/LineaComanda/GetAllLineaComandaOfPlato")]

public HttpResponseMessage GetAllLineaComandaOfPlato (int idPlato)
{
        // CAD, EN
        PlatoRESTCAD platoRESTCAD = null;
        PlatoEN platoEN = null;

        // returnValue
        List<LineaComandaEN> en = null;
        List<LineaComandaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                platoRESTCAD = new PlatoRESTCAD (session);

                // Exists Plato
                platoEN = platoRESTCAD.ReadOIDDefault (idPlato);
                if (platoEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Plato#" + idPlato + " not found"));

                // Rol
                // TODO: paginación


                en = platoRESTCAD.GetAllLineaComandaOfPlato (idPlato).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<LineaComandaDTOA>();
                        foreach (LineaComandaEN entry in en)
                                returnValue.Add (LineaComandaAssembler.Convert (entry, session));
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



























/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_LineaComandaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
