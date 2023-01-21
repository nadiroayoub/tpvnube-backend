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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_LineaPedidoControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
    [RoutePrefix("~/api/LineaPedido")]
    public class LineaPedidoController : BasicController
    {
        // Voy a generar el readAll



        // ReadAll Generado a partir del NavigationalOperation
        [HttpGet]

        [Route("~/api/LineaPedido/ReadAll")]
        public HttpResponseMessage ReadAll()
        {
            // CAD, CEN, EN, returnValue
            LineaPedidoRESTCAD lineaPedidoRESTCAD = null;
            LineaComandaCEN lineaComandaCEN = null;

            List<LineaComandaEN> lineaComandaEN = null;
            List<LineaPedidoDTOA> returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();


                lineaPedidoRESTCAD = new LineaPedidoRESTCAD(session);
                lineaComandaCEN = new LineaComandaCEN(lineaPedidoRESTCAD);

                // Data
                // TODO: paginación

                lineaComandaEN = lineaComandaCEN.ReadAll(0, -1).ToList();

                // Convert return
                if (lineaComandaEN != null)
                {
                    returnValue = new List<LineaPedidoDTOA>();
                    foreach (LineaComandaEN entry in lineaComandaEN)
                        returnValue.Add(LineaPedidoAssembler.Convert(entry, session));
                }
            }

            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 204 - Empty
            if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            // Return 200 - OK
            else return this.Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }











        [HttpGet]
        // [Route("{idLineaPedido}", Name="GetOIDLineaPedido")]

        [Route("~/api/LineaPedido/{idLineaPedido}")]

        public HttpResponseMessage ReadOID(int idLineaPedido)
        {
            // CAD, CEN, EN, returnValue
            LineaPedidoRESTCAD lineaPedidoRESTCAD = null;
            LineaComandaCEN lineaComandaCEN = null;
            LineaComandaEN lineaComandaEN = null;
            LineaPedidoDTOA returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();


                lineaPedidoRESTCAD = new LineaPedidoRESTCAD(session);
                lineaComandaCEN = new LineaComandaCEN(lineaPedidoRESTCAD);

                // Data
                lineaComandaEN = lineaComandaCEN.ReadOID(idLineaPedido);

                // Convert return
                if (lineaComandaEN != null)
                {
                    returnValue = LineaPedidoAssembler.Convert(lineaComandaEN, session);
                }
            }

            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 404 - Not found
            if (returnValue == null)
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            // Return 200 - OK
            else return this.Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }







        [HttpPost]


        [Route("~/api/LineaPedido/NuevaLineaPlato")]



        public HttpResponseMessage NuevaLineaPlato([FromBody] LineaComandaDTO dto)
        {
            // CAD, CEN, returnValue, returnOID
            LineaComandaCP lineaComandaCP = null;
            LineaPedidoDTOA returnValue = null;
            LineaComandaEN returnOID = null;

            // HTTP response
            HttpResponseMessage response = null;
            string uri = null;

            try
            {
                SessionInitializeTransaction();


                lineaComandaCP = new LineaComandaCP(session);

                // Create
                returnOID = lineaComandaCP.NuevaLineaPlato(
                        dto.Id
                        , dto.Cantidad
                        , dto.Plato_oid
                        );
                SessionCommit();

                // Convert return
                returnValue = LineaPedidoAssembler.Convert(returnOID, session);
            }

            catch (Exception e)
            {
                SessionRollBack();

                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 201 - Created
            response = this.Request.CreateResponse(HttpStatusCode.Created, returnValue);

            // Location Header
            /*
             * Dictionary<string, object> routeValues = new Dictionary<string, object>();
             *
             * // TODO: y rolPaths
             * routeValues.Add("id", returnOID);
             *
             * uri = Url.Link("GetOIDLineaPedido", routeValues);
             * response.Headers.Location = new Uri(uri);
             */

            return response;
        }

        [HttpPost]


        [Route("~/api/LineaPedido/NuevaLineaMenu")]



        public HttpResponseMessage NuevaLineaMenu([FromBody] LineaComandaDTO dto)
        {
            // CAD, CEN, returnValue, returnOID
            LineaComandaCP lineaComandaCP = null;
            LineaPedidoDTOA returnValue = null;
            LineaComandaEN returnOID = null;

            // HTTP response
            HttpResponseMessage response = null;
            string uri = null;

            try
            {
                SessionInitializeTransaction();


                lineaComandaCP = new LineaComandaCP(session);

                // Create
                returnOID = lineaComandaCP.NuevaLineaMenu(
                        dto.Id
                        , dto.Cantidad
                        , dto.Menu_oid
                        );
                SessionCommit();

                // Convert return
                returnValue = LineaPedidoAssembler.Convert(returnOID, session);
            }

            catch (Exception e)
            {
                SessionRollBack();

                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(TPVNUBEGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 201 - Created
            response = this.Request.CreateResponse(HttpStatusCode.Created, returnValue);

            // Location Header
            /*
             * Dictionary<string, object> routeValues = new Dictionary<string, object>();
             *
             * // TODO: y rolPaths
             * routeValues.Add("id", returnOID);
             *
             * uri = Url.Link("GetOIDLineaPedido", routeValues);
             * response.Headers.Location = new Uri(uri);
             */

            return response;
        }















        /*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_LineaPedidoControllerAzure) ENABLED START*/
        // Meter las operaciones que invoquen a las CPs
        /*PROTECTED REGION END*/
    }
}
