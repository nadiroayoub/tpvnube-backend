using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class CajaFechaAssemblerDTO {
public static IList<CajaFechaEN> ConvertList (IList<CajaFechaDTO> lista)
{
        IList<CajaFechaEN> result = new List<CajaFechaEN>();
        foreach (CajaFechaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CajaFechaEN Convert (CajaFechaDTO dto)
{
        CajaFechaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CajaFechaEN ();



                        newinstance.Fecha = dto.Fecha;
                        newinstance.Id = dto.Id;
                        newinstance.IdCaja = dto.IdCaja;
                        newinstance.Total = dto.Total;
                        if (dto.Caja_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICajaCAD cajaCAD = new TPVNUBEGenNHibernate.CAD.Rest.CajaCAD ();

                                newinstance.Caja = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CajaEN>();
                                foreach (int entry in dto.Caja_oid) {
                                        newinstance.Caja.Add (cajaCAD.ReadOIDDefault (entry));
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
