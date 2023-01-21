using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class ServicioAssemblerDTO {
public static IList<ServicioEN> ConvertList (IList<ServicioDTO> lista)
{
        IList<ServicioEN> result = new List<ServicioEN>();
        foreach (ServicioDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ServicioEN Convert (ServicioDTO dto)
{
        ServicioEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ServicioEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Negocio_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TPVNUBEGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
                        }
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Costo = dto.Costo;

                        if (dto.LineaProveedor != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ILineaCompraProveedorCAD lineaCompraProveedorCAD = new TPVNUBEGenNHibernate.CAD.Rest.LineaCompraProveedorCAD ();

                                newinstance.LineaProveedor = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaCompraProveedorEN>();
                                foreach (LineaCompraProveedorDTO entry in dto.LineaProveedor) {
                                        newinstance.LineaProveedor.Add (LineaCompraProveedorAssemblerDTO.Convert (entry));
                                }
                        }
                        newinstance.CodigoContrato = dto.CodigoContrato;
                        if (dto.CategoriaServicio_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICategoriaServicioCAD categoriaServicioCAD = new TPVNUBEGenNHibernate.CAD.Rest.CategoriaServicioCAD ();

                                newinstance.CategoriaServicio = categoriaServicioCAD.ReadOIDDefault (dto.CategoriaServicio_oid);
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
