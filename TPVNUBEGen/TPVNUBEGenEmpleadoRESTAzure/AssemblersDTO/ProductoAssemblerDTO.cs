using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class ProductoAssemblerDTO {
public static IList<ProductoEN> ConvertList (IList<ProductoDTO> lista)
{
        IList<ProductoEN> result = new List<ProductoEN>();
        foreach (ProductoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ProductoEN Convert (ProductoDTO dto)
{
        ProductoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ProductoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Stock = dto.Stock;
                        if (dto.UnidadMedida_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IUnidadMedidaCAD unidadMedidaCAD = new TPVNUBEGenNHibernate.CAD.Rest.UnidadMedidaCAD ();

                                newinstance.UnidadMedida = unidadMedidaCAD.ReadOIDDefault (dto.UnidadMedida_oid);
                        }

                        if (dto.LineaCompraProveedor != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ILineaCompraProveedorCAD lineaCompraProveedorCAD = new TPVNUBEGenNHibernate.CAD.Rest.LineaCompraProveedorCAD ();

                                newinstance.LineaCompraProveedor = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaCompraProveedorEN>();
                                foreach (LineaCompraProveedorDTO entry in dto.LineaCompraProveedor) {
                                        newinstance.LineaCompraProveedor.Add (LineaCompraProveedorAssemblerDTO.Convert (entry));
                                }
                        }
                        if (dto.LineaPlato_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ILineaPlatoCAD lineaPlatoCAD = new TPVNUBEGenNHibernate.CAD.Rest.LineaPlatoCAD ();

                                newinstance.LineaPlato = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaPlatoEN>();
                                foreach (int entry in dto.LineaPlato_oid) {
                                        newinstance.LineaPlato.Add (lineaPlatoCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Negocio_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TPVNUBEGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
                        }
                        newinstance.Descripcion = dto.Descripcion;
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
