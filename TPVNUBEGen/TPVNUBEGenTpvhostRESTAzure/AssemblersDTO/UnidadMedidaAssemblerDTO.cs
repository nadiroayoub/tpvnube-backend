using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class UnidadMedidaAssemblerDTO {
public static IList<UnidadMedidaEN> ConvertList (IList<UnidadMedidaDTO> lista)
{
        IList<UnidadMedidaEN> result = new List<UnidadMedidaEN>();
        foreach (UnidadMedidaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static UnidadMedidaEN Convert (UnidadMedidaDTO dto)
{
        UnidadMedidaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new UnidadMedidaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Descripcion = dto.Descripcion;
                        if (dto.Producto_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IProductoCAD productoCAD = new TPVNUBEGenNHibernate.CAD.Rest.ProductoCAD ();

                                newinstance.Producto = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ProductoEN>();
                                foreach (int entry in dto.Producto_oid) {
                                        newinstance.Producto.Add (productoCAD.ReadOIDDefault (entry));
                                }
                        }
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
