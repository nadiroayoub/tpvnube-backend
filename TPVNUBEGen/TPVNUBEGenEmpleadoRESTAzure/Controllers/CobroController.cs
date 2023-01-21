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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_CobroControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using TPVNUBEGenEmpleadoRESTAzureREST.DTO;

/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
    [RoutePrefix("~/api/Cobro")]
    public class CobroController : BasicController
    {
        // Voy a generar el readAll



        // ReadAll Generado a partir del NavigationalOperation
        [HttpGet]

        [Route("~/api/Cobro/ReadAll")]
        public HttpResponseMessage ReadAll()
        {
            // CAD, CEN, EN, returnValue
            CobroRESTCAD cobroRESTCAD = null;
            CobroCEN cobroCEN = null;

            List<CobroEN> cobroEN = null;
            List<CobroDTOA> returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();


                cobroRESTCAD = new CobroRESTCAD(session);
                cobroCEN = new CobroCEN(cobroRESTCAD);

                // Data
                // TODO: paginación

                cobroEN = cobroCEN.ReadAll(0, -1).ToList();

                // Convert return
                if (cobroEN != null)
                {
                    returnValue = new List<CobroDTOA>();
                    foreach (CobroEN entry in cobroEN)
                        returnValue.Add(CobroAssembler.Convert(entry, session));
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





        [Route("~/api/Cobro/GetAllCobroOfEmpleado")]

        public HttpResponseMessage GetAllCobroOfEmpleado(int idEmpleado)
        {
            // CAD, EN
            EmpleadoRESTCAD empleadoRESTCAD = null;
            EmpleadoEN empleadoEN = null;

            // returnValue
            List<CobroEN> en = null;
            List<CobroDTOA> returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();


                empleadoRESTCAD = new EmpleadoRESTCAD(session);

                // Exists Empleado
                empleadoEN = empleadoRESTCAD.ReadOIDDefault(idEmpleado);
                if (empleadoEN == null) throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound, "Empleado#" + idEmpleado + " not found"));

                // Rol
                // TODO: paginación


                en = empleadoRESTCAD.GetAllCobroOfEmpleado(idEmpleado).ToList();



                // Convert return
                if (en != null)
                {
                    returnValue = new List<CobroDTOA>();
                    foreach (CobroEN entry in en)
                        returnValue.Add(CobroAssembler.Convert(entry, session));
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
        // [Route("{idCobro}", Name="GetOIDCobro")]

        [Route("~/api/Cobro/{idCobro}")]

        public HttpResponseMessage ReadOID(int idCobro)
        {
            // CAD, CEN, EN, returnValue
            CobroRESTCAD cobroRESTCAD = null;
            CobroCEN cobroCEN = null;
            CobroEN cobroEN = null;
            CobroDTOA returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();


                cobroRESTCAD = new CobroRESTCAD(session);
                cobroCEN = new CobroCEN(cobroRESTCAD);

                // Data
                cobroEN = cobroCEN.ReadOID(idCobro);

                // Convert return
                if (cobroEN != null)
                {
                    returnValue = CobroAssembler.Convert(cobroEN, session);
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

        [Route("~/api/Cobro/ImprimirCuenta")]


        public HttpResponseMessage ImprimirCuenta(int p_oid, int p_comanda)
        {
            // CAD, CEN, returnValue
            CobroRESTCAD cobroRESTCAD = null;
            CobroCEN cobroCEN = null;

            try
            {
                SessionInitializeTransaction();


                cobroRESTCAD = new CobroRESTCAD(session);
                cobroCEN = new CobroCEN(cobroRESTCAD);


                // Operation
                cobroCEN.ImprimirCuenta(p_oid, p_comanda);
                SessionCommit();
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

            // Return 200 - OK
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }




        [HttpPost]

        [Route("~/api/Cobro/Nuevo")]

        public HttpResponseMessage Nuevo(float p_monto, int p_comanda, int p_tipocobro, int p_caja, int p_empleado, int p_negocio)
        {
            // CP, returnValue
            CobroCP cobroCP = null;

            CobroDTOA returnValue;
            CobroEN en;

            try
            {
                SessionInitializeTransaction();




                cobroCP = new CobroCP(session);

                // Operation
                en = cobroCP.Nuevo(p_monto, p_comanda, p_tipocobro, p_caja, p_empleado, p_negocio);
                SessionCommit();

                // Convert return
                returnValue = CobroAssembler.Convert(en, session);
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

            // Return 200 - OK
            return this.Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }





        /*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_CobroControllerAzure) ENABLED START*/
        // Meter las operaciones que invoquen a las CPs

        [HttpPost]
        [Route("~/api/Cobro/CreateCuenta")]
        public async Task<HttpResponseMessage> CreateCuenta([FromBody] CuentaDTO[] dto, double total, int negocioId)
        {
            var returnValue = "";

            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                // File Path
                var myUniqueFileName = $@"{Guid.NewGuid()}.pdf";
                var filePath = "C:\\Users\\nadir\\Documents\\Master\\TFM\\Movil\\TPVHost\\src\\assets\\pdfs\\CuentaPdfs";
                NegocioEN negocioEN = new NegocioCEN().ReadOID(negocioId);
                using (System.IO.FileStream fs = new FileStream(filePath + "\\" + myUniqueFileName, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    document.AddAuthor("Ayoub Nadir");

                    document.Open();

                    PdfPTable table = new PdfPTable(4);
                    table.DefaultCell.Border = Rectangle.NO_BORDER;
                    table.DefaultCell.FixedHeight = 40f;

                    PdfPCell cell = new PdfPCell(new Phrase("Nombre del negocio: " + negocioEN.Nombre, FontFactory.GetFont("Helvetica", 16, Font.NORMAL)));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.Colspan = 2;
                    cell.FixedHeight = 40f;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Fecha: " + DateTime.Now.ToShortDateString(), FontFactory.GetFont("Helvetica", 16, Font.NORMAL)));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.Colspan = 2;
                    cell.FixedHeight = 40f;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("--------------------------------------------------------------", FontFactory.GetFont("Helvetica", 20, Font.BOLD)));
                    cell.Colspan = 4;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Border = Rectangle.NO_BORDER;
                    cell.FixedHeight = 40f;
                    table.AddCell(cell);

                    foreach (var comanda in dto)
                    {
                        foreach (var item in comanda.Items)
                        {
                            cell = new PdfPCell(new Phrase("x" + item.Cantidad.ToString(), FontFactory.GetFont("Helvetica", 18, Font.NORMAL)));
                            cell.Border = Rectangle.NO_BORDER;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(item.Nombre.ToString(), FontFactory.GetFont("Helvetica", 18, Font.NORMAL)));
                            cell.Border = Rectangle.NO_BORDER;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase(item.Precio.ToString() + "€", FontFactory.GetFont("Helvetica", 18, Font.NORMAL)));
                            cell.Border = Rectangle.NO_BORDER;
                            table.AddCell(cell);
                            cell = new PdfPCell(new Phrase((item.Precio * item.Cantidad).ToString() + "€", FontFactory.GetFont("Helvetica", 18, Font.NORMAL)));
                            cell.Border = Rectangle.NO_BORDER;
                            table.AddCell(cell);
                        }
                    }

                    cell.FixedHeight = 60f;
                    cell = new PdfPCell(new Phrase(("Total").ToString(), FontFactory.GetFont("Helvetica", 20, Font.BOLD)));
                    cell.Colspan = 4;
                    cell.Border = Rectangle.NO_BORDER;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase((total + "€").ToString(), FontFactory.GetFont("Helvetica", 20, Font.BOLD, new BaseColor(50, 183, 104))));
                    cell.Colspan = 4;
                    cell.Border = Rectangle.NO_BORDER;
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell);

                    document.Add(table);
                    document.Close();
                    writer.Close();
                    fs.Close();
                };

                //var res = string.Format("Please Upload a image.");
                //dict.Add("error", res);
                //return Request.CreateResponse(HttpStatusCode.NotFound, dict);

                if (myUniqueFileName != "")
                {
                    returnValue = myUniqueFileName;
                }
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            // Return 404 - Not found
            if (returnValue == "")
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            // Return 200 - OK
            else return this.Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }
        /*PROTECTED REGION END*/
    }
}
