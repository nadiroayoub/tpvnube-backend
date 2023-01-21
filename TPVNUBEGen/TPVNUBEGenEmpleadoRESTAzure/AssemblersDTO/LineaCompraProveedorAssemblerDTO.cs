using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class LineaCompraProveedorAssemblerDTO {
public static IList<LineaCompraProveedorEN> ConvertList (IList<LineaCompraProveedorDTO> lista)
{
        IList<LineaCompraProveedorEN> result = new List<LineaCompraProveedorEN>();
        foreach (LineaCompraProveedorDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static LineaCompraProveedorEN Convert (LineaCompraProveedorDTO dto)
{
        LineaCompraProveedorEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new LineaCompraProveedorEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Cantidad = dto.Cantidad;
                        if (dto.Servicio_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IServicioCAD servicioCAD = new TPVNUBEGenNHibernate.CAD.Rest.ServicioCAD ();

                                newinstance.Servicio = servicioCAD.ReadOIDDefault (dto.Servicio_oid);
                        }
                        if (dto.CompraProveedor_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICompraProveedorCAD compraProveedorCAD = new TPVNUBEGenNHibernate.CAD.Rest.CompraProveedorCAD ();

                                newinstance.CompraProveedor = compraProveedorCAD.ReadOIDDefault (dto.CompraProveedor_oid);
                        }
                        if (dto.Producto_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IProductoCAD productoCAD = new TPVNUBEGenNHibernate.CAD.Rest.ProductoCAD ();

                                newinstance.Producto = productoCAD.ReadOIDDefault (dto.Producto_oid);
                        }
                        newinstance.Costo = dto.Costo;
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
