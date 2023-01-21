using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class ProveedorAssemblerDTO {
public static IList<ProveedorEN> ConvertList (IList<ProveedorDTO> lista)
{
        IList<ProveedorEN> result = new List<ProveedorEN>();
        foreach (ProveedorDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ProveedorEN Convert (ProveedorDTO dto)
{
        ProveedorEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ProveedorEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        if (dto.CompraProveedor_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICompraProveedorCAD compraProveedorCAD = new TPVNUBEGenNHibernate.CAD.Rest.CompraProveedorCAD ();

                                newinstance.CompraProveedor = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN>();
                                foreach (int entry in dto.CompraProveedor_oid) {
                                        newinstance.CompraProveedor.Add (compraProveedorCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Email = dto.Email;
                        newinstance.Telefono = dto.Telefono;
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
