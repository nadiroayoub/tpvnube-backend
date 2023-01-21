using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class LineaPlatoAssemblerDTO {
public static IList<LineaPlatoEN> ConvertList (IList<LineaPlatoDTO> lista)
{
        IList<LineaPlatoEN> result = new List<LineaPlatoEN>();
        foreach (LineaPlatoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static LineaPlatoEN Convert (LineaPlatoDTO dto)
{
        LineaPlatoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new LineaPlatoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Cantidad = dto.Cantidad;
                        if (dto.Producto_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IProductoCAD productoCAD = new TPVNUBEGenNHibernate.CAD.Rest.ProductoCAD ();

                                newinstance.Producto = productoCAD.ReadOIDDefault (dto.Producto_oid);
                        }
                        if (dto.Plato_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IPlatoCAD platoCAD = new TPVNUBEGenNHibernate.CAD.Rest.PlatoCAD ();

                                newinstance.Plato = platoCAD.ReadOIDDefault (dto.Plato_oid);
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
