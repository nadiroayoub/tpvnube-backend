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


/*PROTECTED REGION ID(usingTPVNUBEGenTpvhostRESTAzure_CobroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenTpvhostRESTAzure.Controllers
{
[RoutePrefix ("~/api/Cobro")]
public class CobroController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Cobro/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        CobroRESTCAD cobroRESTCAD = null;
        CobroCEN cobroCEN = null;

        List<CobroEN> cobroEN = null;
        List<CobroDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cobroRESTCAD = new CobroRESTCAD (session);
                cobroCEN = new CobroCEN (cobroRESTCAD);

                // Data
                // TODO: paginación

                cobroEN = cobroCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (cobroEN != null) {
                        returnValue = new List<CobroDTOA>();
                        foreach (CobroEN entry in cobroEN)
                                returnValue.Add (CobroAssembler.Convert (entry, session));
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





[Route ("~/api/Cobro/GetAllCobroOfCaja")]

public HttpResponseMessage GetAllCobroOfCaja (int idCaja)
{
        // CAD, EN
        CajaRESTCAD cajaRESTCAD = null;
        CajaEN cajaEN = null;

        // returnValue
        List<CobroEN> en = null;
        List<CobroDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cajaRESTCAD = new CajaRESTCAD (session);

                // Exists Caja
                cajaEN = cajaRESTCAD.ReadOIDDefault (idCaja);
                if (cajaEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Caja#" + idCaja + " not found"));

                // Rol
                // TODO: paginación


                en = cajaRESTCAD.GetAllCobroOfCaja (idCaja).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<CobroDTOA>();
                        foreach (CobroEN entry in en)
                                returnValue.Add (CobroAssembler.Convert (entry, session));
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
// [Route("{idCobro}", Name="GetOIDCobro")]

[Route ("~/api/Cobro/{idCobro}")]

public HttpResponseMessage ReadOID (int idCobro)
{
        // CAD, CEN, EN, returnValue
        CobroRESTCAD cobroRESTCAD = null;
        CobroCEN cobroCEN = null;
        CobroEN cobroEN = null;
        CobroDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cobroRESTCAD = new CobroRESTCAD (session);
                cobroCEN = new CobroCEN (cobroRESTCAD);

                // Data
                cobroEN = cobroCEN.ReadOID (idCobro);

                // Convert return
                if (cobroEN != null) {
                        returnValue = CobroAssembler.Convert (cobroEN, session);
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



// No pasa el slEnables: dameCobroPorNegocio

[HttpGet]

[Route ("~/api/Cobro/DameCobroPorNegocio")]

public HttpResponseMessage DameCobroPorNegocio (int p_negocio)
{
        // CAD, CEN, EN, returnValue

        CobroRESTCAD cobroRESTCAD = null;
        CobroCEN cobroCEN = null;


        System.Collections.Generic.List<CobroEN> en;

        System.Collections.Generic.List<CobroDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                cobroRESTCAD = new CobroRESTCAD (session);
                cobroCEN = new CobroCEN (cobroRESTCAD);

                // CEN return



                en = cobroCEN.DameCobroPorNegocio (p_negocio).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<CobroDTOA>();
                        foreach (CobroEN entry in en)
                                returnValue.Add (CobroAssembler.Convert (entry, session));
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




















/*PROTECTED REGION ID(TPVNUBEGenTpvhostRESTAzure_CobroControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
