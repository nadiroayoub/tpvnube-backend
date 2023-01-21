using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class TipoPagoAssemblerDTO {
public static IList<TipoPagoEN> ConvertList (IList<TipoPagoDTO> lista)
{
        IList<TipoPagoEN> result = new List<TipoPagoEN>();
        foreach (TipoPagoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static TipoPagoEN Convert (TipoPagoDTO dto)
{
        TipoPagoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new TipoPagoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Descripcion = dto.Descripcion;
                        if (dto.Pago_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IPagoCAD pagoCAD = new TPVNUBEGenNHibernate.CAD.Rest.PagoCAD ();

                                newinstance.Pago = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.PagoEN>();
                                foreach (int entry in dto.Pago_oid) {
                                        newinstance.Pago.Add (pagoCAD.ReadOIDDefault (entry));
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
