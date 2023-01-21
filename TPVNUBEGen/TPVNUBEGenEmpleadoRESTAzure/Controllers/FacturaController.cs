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


/*PROTECTED REGION ID(usingTPVNUBEGenEmpleadoRESTAzure_FacturaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
using System.Threading.Tasks;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using TPVNUBEGenEmpleadoRESTAzureREST.DTO;
/*PROTECTED REGION END*/



namespace TPVNUBEGenEmpleadoRESTAzure.Controllers
{
    [RoutePrefix("~/api/Factura")]
    public class FacturaController : BasicController
    {
        // Voy a generar el readAll



        // ReadAll Generado a partir del NavigationalOperation
        [HttpGet]

        [Route("~/api/Factura/ReadAll")]
        public HttpResponseMessage ReadAll()
        {
            // CAD, CEN, EN, returnValue
            FacturaRESTCAD facturaRESTCAD = null;
            FacturaCEN facturaCEN = null;

            List<FacturaEN> facturaEN = null;
            List<FacturaDTOA> returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();


                facturaRESTCAD = new FacturaRESTCAD(session);
                facturaCEN = new FacturaCEN(facturaRESTCAD);

                // Data
                // TODO: paginación

                facturaEN = facturaCEN.ReadAll(0, -1).ToList();

                // Convert return
                if (facturaEN != null)
                {
                    returnValue = new List<FacturaDTOA>();
                    foreach (FacturaEN entry in facturaEN)
                        returnValue.Add(FacturaAssembler.Convert(entry, session));
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













        [HttpPost]


        [Route("~/api/Factura/Nuevo")]




        public HttpResponseMessage Nuevo([FromBody] FacturaDTO dto)
        {
            // CAD, CEN, returnValue, returnOID
            FacturaRESTCAD facturaRESTCAD = null;
            FacturaCEN facturaCEN = null;
            FacturaDTOA returnValue = null;
            int returnOID = -1;

            // HTTP response
            HttpResponseMessage response = null;
            string uri = null;

            try
            {
                SessionInitializeTransaction();


                facturaRESTCAD = new FacturaRESTCAD(session);
                facturaCEN = new FacturaCEN(facturaRESTCAD);

                // Create
                returnOID = facturaCEN.Nuevo(
                        dto.Numero                                                                               //Atributo Primitivo: p_numero
                        , dto.Fecha                                                                                                                                                      //Atributo Primitivo: p_fecha
                        , dto.Precio                                                                                                                                                     //Atributo Primitivo: p_precio
                        , dto.Descripcion                                                                                                                                                //Atributo Primitivo: p_descripcion
                        ,
                        //Atributo OID: p_comanda
                        // attr.estaRelacionado: true
                        dto.Comanda_oid                 // association role

                        ,
                        //Atributo OID: p_cliente
                        // attr.estaRelacionado: true
                        dto.Cliente_oid                 // association role

                        );
                SessionCommit();

                // Convert return
                returnValue = FacturaAssembler.Convert(facturaRESTCAD.ReadOIDDefault(returnOID), session);
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
             * uri = Url.Link("GetOIDFactura", routeValues);
             * response.Headers.Location = new Uri(uri);
             */

            return response;
        }















        [HttpPost]

        [Route("~/api/Factura/ImprimirFactura")]


        public HttpResponseMessage ImprimirFactura(int p_oid)
        {
            // CAD, CEN, returnValue
            FacturaRESTCAD facturaRESTCAD = null;
            FacturaCEN facturaCEN = null;

            try
            {
                SessionInitializeTransaction();


                facturaRESTCAD = new FacturaRESTCAD(session);
                facturaCEN = new FacturaCEN(facturaRESTCAD);


                // Operation
                facturaCEN.ImprimirFactura(p_oid);
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






        /*PROTECTED REGION ID(TPVNUBEGenEmpleadoRESTAzure_FacturaControllerAzure) ENABLED START*/
        // Meter las operaciones que invoquen a las CPs

        [HttpPost]
        [Route("~/api/Factura/CreateFactura")]
        public async Task<HttpResponseMessage> CreateFactura([FromBody] ImprimirFacturaDTO dto, double total)
        {
            var returnValue = "";

            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                // File Path
                var myUniqueFileName = $@"{Guid.NewGuid()}.pdf";
                var filePath = "C:\\Users\\nadir\\Documents\\Master\\TFM\\Movil\\TPVHost\\src\\assets\\pdfs\\FacturaPdfs";

                using (System.IO.FileStream fs = new FileStream(filePath + "\\" + myUniqueFileName, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    ClienteCEN clienteCEN = new ClienteCEN();
                    ClienteEN clienteEN = clienteCEN.ReadOID(dto.Cliente_oid);

                    document.AddAuthor("Ayoub Nadir");


                    document.Open();

                    PdfPTable table = new PdfPTable(4);
                    table.DefaultCell.Border = Rectangle.NO_BORDER;
                    table.DefaultCell.FixedHeight = 40f;

                    // Title
                    PdfPCell cellTitle = new PdfPCell(new Phrase("Factura", FontFactory.GetFont("Helvetica", 22, Font.BOLD)));
                    cellTitle.Colspan = 4;
                    cellTitle.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellTitle.Border = Rectangle.NO_BORDER;
                    cellTitle.FixedHeight = 40f;
                    table.AddCell(cellTitle);

                    #region Content of cliente and empresa
                    // Datos cliente
                    // Nombre
                    PdfPCell cellNombreCliente = new PdfPCell(new Phrase("Nombre completo: " + clienteEN.Nombre + " " + clienteEN.Apellidos, FontFactory.GetFont("Helvetica", 16, Font.NORMAL)));
                    cellNombreCliente.Colspan = 4;
                    cellNombreCliente.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellNombreCliente.Border = Rectangle.NO_BORDER;
                    cellNombreCliente.FixedHeight = 20f;
                    table.AddCell(cellNombreCliente);

                    // DNI
                    PdfPCell cellDNICliente = new PdfPCell(new Phrase("NIF/NIE: " + clienteEN.Dni, FontFactory.GetFont("Helvetica", 16, Font.NORMAL)));
                    cellDNICliente.Colspan = 4;
                    cellDNICliente.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellDNICliente.Border = Rectangle.NO_BORDER;
                    cellDNICliente.FixedHeight = 20f;
                    table.AddCell(cellDNICliente);

                    // Email
                    PdfPCell cellEmailCliente = new PdfPCell(new Phrase("Correo electrónico : " + clienteEN.Email, FontFactory.GetFont("Helvetica", 16, Font.NORMAL)));
                    cellEmailCliente.Colspan = 4;
                    cellEmailCliente.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellEmailCliente.Border = Rectangle.NO_BORDER;
                    cellEmailCliente.FixedHeight = 100f;
                    table.AddCell(cellEmailCliente);

                    // Datos de la empresa
                    //PdfPCell cellEmpresa = new PdfPCell(new Phrase("Factura", FontFactory.GetFont("Helvetica", 20, Font.BOLD)));
                    //cellEmpresa.Colspan = 2;
                    //cellEmpresa.HorizontalAlignment = Element.ALIGN_CENTER;
                    //cellEmpresa.Border = Rectangle.NO_BORDER;
                    //cellEmpresa.FixedHeight = 40f;
                    //table.AddCell(cellEmpresa);

                    #endregion
                    // Datos de las comandas
                    //PdfPCell cell = new PdfPCell(new Phrase("Factura", FontFactory.GetFont("Helvetica", 20, Font.BOLD)));
                    //cell.Colspan = 1;
                    //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    //cell.Border = Rectangle.NO_BORDER;
                    //cell.FixedHeight = 40f;
                    //table.AddCell(cell);
                    PdfPCell cell = new PdfPCell(new Phrase("Nº. " + dto.Numero, FontFactory.GetFont("Helvetica", 16, Font.NORMAL)));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.Colspan = 2;
                    cell.FixedHeight = 40f;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Fecha: " + DateTime.Now.ToShortDateString(), FontFactory.GetFont("Helvetica", 16, Font.NORMAL)));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.Colspan = 2;
                    cell.FixedHeight = 40f;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Descripcion", FontFactory.GetFont("Helvetica", 16, Font.BOLD)));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Precio", FontFactory.GetFont("Helvetica", 16, Font.BOLD)));
                    cell.Border = Rectangle.NO_BORDER;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    // TODO: should change this: lista de comandas
                    //ComandaEN comandaEN = new ComandaCEN().ReadOID(dto.Comanda_oid);

                    foreach (var item in dto.Items)
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

                    //cell = new PdfPCell(new Phrase(dto.Descripcion, FontFactory.GetFont("Helvetica", 16, Font.NORMAL)));
                    //cell.Border = Rectangle.NO_BORDER;
                    //cell.Colspan = 2;
                    //table.AddCell(cell);
                    //cell = new PdfPCell(new Phrase(dto.Precio + "€", FontFactory.GetFont("Helvetica", 16, Font.NORMAL)));
                    //cell.Border = Rectangle.NO_BORDER;
                    //cell.Colspan = 2;
                    //cell.FixedHeight = 40f;
                    //table.AddCell(cell);

                    //
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
