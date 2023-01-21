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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_ComandaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
[RoutePrefix ("~/api/Comanda")]
public class ComandaController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Comanda/ReadAll")]
public HttpResponseMessage ReadAll ()
{
        // CAD, CEN, EN, returnValue
        ComandaRESTCAD comandaRESTCAD = null;
        ComandaCEN comandaCEN = null;

        List<ComandaEN> comandaEN = null;
        List<ComandaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                comandaRESTCAD = new ComandaRESTCAD (session);
                comandaCEN = new ComandaCEN (comandaRESTCAD);

                // Data
                // TODO: paginación

                comandaEN = comandaCEN.ReadAll (0, -1).ToList ();

                // Convert return
                if (comandaEN != null) {
                        returnValue = new List<ComandaDTOA>();
                        foreach (ComandaEN entry in comandaEN)
                                returnValue.Add (ComandaAssembler.Convert (entry, session));
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





[Route ("~/api/Comanda/DameComandaPorPago")]

public HttpResponseMessage DameComandaPorPago (int idPago)
{
        // CAD, EN
        PagoRESTCAD pagoRESTCAD = null;
        CobroEN cobroEN = null;

        // returnValue
        ComandaEN en = null;
        ComandaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                pagoRESTCAD = new PagoRESTCAD (session);

                // Exists Pago
                cobroEN = pagoRESTCAD.ReadOIDDefault (idPago);
                if (cobroEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Pago#" + idPago + " not found"));

                // Rol
                // TODO: paginación


                en = pagoRESTCAD.DameComandaPorPago (idPago);



                // Convert return
                if (en != null) {
                        returnValue = ComandaAssembler.Convert (en, session);
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





[Route ("~/api/Comanda/DameComandasEmpleado")]

public HttpResponseMessage DameComandasEmpleado (int idEmpleado)
{
        // CAD, EN
        EmpleadoRESTCAD empleadoRESTCAD = null;
        EmpleadoEN empleadoEN = null;

        // returnValue
        List<ComandaEN> en = null;
        List<ComandaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                empleadoRESTCAD = new EmpleadoRESTCAD (session);

                // Exists Empleado
                empleadoEN = empleadoRESTCAD.ReadOIDDefault (idEmpleado);
                if (empleadoEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Empleado#" + idEmpleado + " not found"));

                // Rol
                // TODO: paginación


                en = empleadoRESTCAD.DameComandasEmpleado (idEmpleado).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<ComandaDTOA>();
                        foreach (ComandaEN entry in en)
                                returnValue.Add (ComandaAssembler.Convert (entry, session));
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





[Route ("~/api/Comanda/GetComandaOfCobro")]

public HttpResponseMessage GetComandaOfCobro (int idCobro)
{
        // CAD, EN
        CobroRESTCAD cobroRESTCAD = null;
        CobroEN cobroEN = null;

        // returnValue
        ComandaEN en = null;
        ComandaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                cobroRESTCAD = new CobroRESTCAD (session);

                // Exists Cobro
                cobroEN = cobroRESTCAD.ReadOIDDefault (idCobro);
                if (cobroEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Cobro#" + idCobro + " not found"));

                // Rol
                // TODO: paginación


                en = cobroRESTCAD.GetComandaOfCobro (idCobro);



                // Convert return
                if (en != null) {
                        returnValue = ComandaAssembler.Convert (en, session);
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





[Route ("~/api/Comanda/GetAllComandaOfMesa")]

public HttpResponseMessage GetAllComandaOfMesa (int idMesa)
{
        // CAD, EN
        MesaRESTCAD mesaRESTCAD = null;
        MesaEN mesaEN = null;

        // returnValue
        List<ComandaEN> en = null;
        List<ComandaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                mesaRESTCAD = new MesaRESTCAD (session);

                // Exists Mesa
                mesaEN = mesaRESTCAD.ReadOIDDefault (idMesa);
                if (mesaEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Mesa#" + idMesa + " not found"));

                // Rol
                // TODO: paginación


                en = mesaRESTCAD.GetAllComandaOfMesa (idMesa).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<ComandaDTOA>();
                        foreach (ComandaEN entry in en)
                                returnValue.Add (ComandaAssembler.Convert (entry, session));
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
// [Route("{idComanda}", Name="GetOIDComanda")]

[Route ("~/api/Comanda/{idComanda}")]

public HttpResponseMessage ReadOID (int idComanda)
{
        // CAD, CEN, EN, returnValue
        ComandaRESTCAD comandaRESTCAD = null;
        ComandaCEN comandaCEN = null;
        ComandaEN comandaEN = null;
        ComandaDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();


                comandaRESTCAD = new ComandaRESTCAD (session);
                comandaCEN = new ComandaCEN (comandaRESTCAD);

                // Data
                comandaEN = comandaCEN.ReadOID (idComanda);

                // Convert return
                if (comandaEN != null) {
                        returnValue = ComandaAssembler.Convert (comandaEN, session);
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



// No pasa el slEnables: dameComandasPorMesa

[HttpGet]

[Route ("~/api/Comanda/DameComandasPorMesa")]

public HttpResponseMessage DameComandasPorMesa (int p_mesa)
{
        // CAD, CEN, EN, returnValue

        ComandaRESTCAD comandaRESTCAD = null;
        ComandaCEN comandaCEN = null;


        System.Collections.Generic.List<ComandaEN> en;

        System.Collections.Generic.List<ComandaDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();



                comandaRESTCAD = new ComandaRESTCAD (session);
                comandaCEN = new ComandaCEN (comandaRESTCAD);

                // CEN return



                en = comandaCEN.DameComandasPorMesa (p_mesa).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<ComandaDTOA>();
                        foreach (ComandaEN entry in en)
                                returnValue.Add (ComandaAssembler.Convert (entry, session));
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


[Route ("~/api/Comanda/Nuevo")]




public HttpResponseMessage Nuevo ( [FromBody] ComandaDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        ComandaRESTCAD comandaRESTCAD = null;
        ComandaCEN comandaCEN = null;
        ComandaDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                comandaRESTCAD = new ComandaRESTCAD (session);
                comandaCEN = new ComandaCEN (comandaRESTCAD);

                // Create
                returnOID = comandaCEN.Nuevo (
                        dto.EstadoComanda                                                                                //Atributo Primitivo: p_estadoComanda
                        ,
                        //Atributo OID: p_mesa
                        // attr.estaRelacionado: true
                        dto.Mesa_oid                 // association role

                        ,
                        //Atributo OID: p_empleado
                        // attr.estaRelacionado: true
                        dto.Empleado_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = ComandaAssembler.Convert (comandaRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDComanda", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}




[HttpPut]


[Route ("~/api/Comanda/Modificar")]

public HttpResponseMessage Modificar (int idComanda, [FromBody] ComandaDTO dto)
{
        // CAD, CEN, returnValue
        ComandaRESTCAD comandaRESTCAD = null;
        ComandaCEN comandaCEN = null;
        ComandaDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();


                comandaRESTCAD = new ComandaRESTCAD (session);
                comandaCEN = new ComandaCEN (comandaRESTCAD);

                // Modify
                comandaCEN.Modificar (idComanda,
                        dto.EstadoComanda
                        ,
                        dto.Fecha
                        ,
                        dto.Total
                        ,
                        dto.Pdf
                        );

                // Return modified object
                returnValue = ComandaAssembler.Convert (comandaRESTCAD.ReadOIDDefault (idComanda), session);

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










[HttpPost]

[Route ("~/api/Comanda/DamePedidoPlato")]


public HttpResponseMessage DamePedidoPlato (int p_plato, int p_comanda)
{
        // CAD, CEN, returnValue
        ComandaRESTCAD comandaRESTCAD = null;
        ComandaCEN comandaCEN = null;

        System.Collections.Generic.List<ComandaDTOA> returnValue = null;
        System.Collections.Generic.List<ComandaEN> en;

        try
        {
                SessionInitializeTransaction ();


                comandaRESTCAD = new ComandaRESTCAD (session);
                comandaCEN = new ComandaCEN (comandaRESTCAD);


                // Operation
                en = comandaCEN.DameComandaPlato (p_plato, p_comanda).ToList ();
                SessionCommit ();

                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<ComandaDTOA>();
                        foreach (ComandaEN entry in en)
                                returnValue.Add (ComandaAssembler.Convert (entry, session));
                }
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






/*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_ComandaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
