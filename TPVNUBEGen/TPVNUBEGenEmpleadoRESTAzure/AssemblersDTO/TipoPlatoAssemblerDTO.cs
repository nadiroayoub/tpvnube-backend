using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class TipoPlatoAssemblerDTO {
public static IList<TipoPlatoEN> ConvertList (IList<TipoPlatoDTO> lista)
{
        IList<TipoPlatoEN> result = new List<TipoPlatoEN>();
        foreach (TipoPlatoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static TipoPlatoEN Convert (TipoPlatoDTO dto)
{
        TipoPlatoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new TipoPlatoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        if (dto.Plato_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IPlatoCAD platoCAD = new TPVNUBEGenNHibernate.CAD.Rest.PlatoCAD ();

                                newinstance.Plato = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.PlatoEN>();
                                foreach (int entry in dto.Plato_oid) {
                                        newinstance.Plato.Add (platoCAD.ReadOIDDefault (entry));
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
