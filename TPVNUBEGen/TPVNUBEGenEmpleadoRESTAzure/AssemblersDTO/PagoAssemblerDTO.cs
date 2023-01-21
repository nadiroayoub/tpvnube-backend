using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class PagoAssemblerDTO {
public static IList<PagoEN> ConvertList (IList<PagoDTO> lista)
{
        IList<PagoEN> result = new List<PagoEN>();
        foreach (PagoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static PagoEN Convert (PagoDTO dto)
{
        PagoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PagoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.IdPedidoProveedor = dto.IdPedidoProveedor;
                        newinstance.Monto = dto.Monto;
                        if (dto.CompraProveedor_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICompraProveedorCAD compraProveedorCAD = new TPVNUBEGenNHibernate.CAD.Rest.CompraProveedorCAD ();

                                newinstance.CompraProveedor = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN>();
                                foreach (int entry in dto.CompraProveedor_oid) {
                                        newinstance.CompraProveedor.Add (compraProveedorCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.FechaPago = dto.FechaPago;
                        if (dto.TipoPago_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.ITipoPagoCAD tipoPagoCAD = new TPVNUBEGenNHibernate.CAD.Rest.TipoPagoCAD ();

                                newinstance.TipoPago = tipoPagoCAD.ReadOIDDefault (dto.TipoPago_oid);
                        }
                        newinstance.NumeroDocumento = dto.NumeroDocumento;
                        if (dto.Caja_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICajaCAD cajaCAD = new TPVNUBEGenNHibernate.CAD.Rest.CajaCAD ();

                                newinstance.Caja = cajaCAD.ReadOIDDefault (dto.Caja_oid);
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
