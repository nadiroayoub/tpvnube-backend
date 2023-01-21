using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class TipoCobroAssemblerDTO {
public static IList<TipoCobroEN> ConvertList (IList<TipoCobroDTO> lista)
{
        IList<TipoCobroEN> result = new List<TipoCobroEN>();
        foreach (TipoCobroDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static TipoCobroEN Convert (TipoCobroDTO dto)
{
        TipoCobroEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new TipoCobroEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Cobro_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICobroCAD cobroCAD = new TPVNUBEGenNHibernate.CAD.Rest.CobroCAD ();

                                newinstance.Cobro = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
                                foreach (int entry in dto.Cobro_oid) {
                                        newinstance.Cobro.Add (cobroCAD.ReadOIDDefault (entry));
                                }
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
