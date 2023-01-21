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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_LineaComandaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/LineaComanda")]
public class LineaComandaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/LineaComanda/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        LineaComandaRESTCAD lineaComandaRESTCAD = null;
        LineaComandaCEN lineaComandaCEN = null;

        List<LineaComandaEN> lineaComandaEN = null;
        List<LineaComandaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaComandaRESTCAD = new LineaComandaRESTCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaComandaRESTCAD);

                // Data
                // TODO: paginación

                lineaComandaEN = lineaComandaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (lineaComandaEN != null) {
                        returnValue = new List<LineaComandaDTOA>();
                        foreach (LineaComandaEN entry in lineaComandaEN)
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
// [Route("{idLineaComanda}", Name="GetOIDLineaComanda")]

[Route ("~/api/LineaComanda/{idLineaComanda}")]

public HttpResponseMessage ReadOID (int idLineaComanda)
{
        // CAD, CEN, EN, returnValue
        LineaComandaRESTCAD lineaComandaRESTCAD = null;
        LineaComandaCEN lineaComandaCEN = null;
        LineaComandaEN lineaComandaEN = null;
        LineaComandaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                lineaComandaRESTCAD = new LineaComandaRESTCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaComandaRESTCAD);

                // Data
                lineaComandaEN = lineaComandaCEN.ReadOID (idLineaComanda);

                // Convert return
                if (lineaComandaEN != null) {
                        returnValue = LineaComandaAssembler.Convert (lineaComandaEN, session);
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


[Route ("~/api/LineaComanda/Modificar")]

public HttpResponseMessage Modificar (int idLineaComanda, [FromBody] LineaComandaDTO dto)
{
        // CAD, CEN, returnValue
        LineaComandaRESTCAD lineaComandaRESTCAD = null;
        LineaComandaCEN lineaComandaCEN = null;
        LineaComandaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                lineaComandaRESTCAD = new LineaComandaRESTCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaComandaRESTCAD);

                // Modify
                lineaComandaCEN.Modificar (idLineaComanda,
                        dto.Cantidad
                        );

                // Return modified object
                returnValue = LineaComandaAssembler.Convert (lineaComandaRESTCAD.ReadOIDDefault (idLineaComanda), session);

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


[Route ("~/api/LineaComanda/Eliminar")]

public HttpResponseMessage Eliminar (int p_lineacomanda_oid)
{
        // CAD, CEN
        LineaComandaRESTCAD lineaComandaRESTCAD = null;
        LineaComandaCEN lineaComandaCEN = null;

        try
        {
                SessionInitializeTransaction ();


                lineaComandaRESTCAD = new LineaComandaRESTCAD (session);
                lineaComandaCEN = new LineaComandaCEN (lineaComandaRESTCAD);

                lineaComandaCEN.Eliminar (p_lineacomanda_oid);
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







[HttpPost]

[Route ("~/api/LineaComanda/NuevaLineaPlato")]

public HttpResponseMessage NuevaLineaPlato (int p_comanda, int p_cantidad, int p_plato)
{
        // CP, returnValue
        LineaComandaCP lineaComandaCP = null;

        LineaComandaDTOA returnValue;
        LineaComandaEN en;

        try
        {
                SessionInitializeTransaction ();




                lineaComandaCP = new LineaComandaCP (session);

                // Operation
                en = lineaComandaCP.NuevaLineaPlato (p_comanda, p_cantidad, p_plato);
                SessionCommit ();

                // Convert return
                returnValue = LineaComandaAssembler.Convert (en, session);
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
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}



[HttpPost]

[Route ("~/api/LineaComanda/NuevaLineaMenu")]

public HttpResponseMessage NuevaLineaMenu (int p_comanda, int p_cantidad, int p_menu)
{
        // CP, returnValue
        LineaComandaCP lineaComandaCP = null;

        LineaComandaDTOA returnValue;
        LineaComandaEN en;

        try
        {
                SessionInitializeTransaction ();




                lineaComandaCP = new LineaComandaCP (session);

                // Operation
                en = lineaComandaCP.NuevaLineaMenu (p_comanda, p_cantidad, p_menu);
                SessionCommit ();

                // Convert return
                returnValue = LineaComandaAssembler.Convert (en, session);
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
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}





/*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_LineaComandaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
