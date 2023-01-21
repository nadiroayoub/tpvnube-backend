using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class CategoriaServicioAssemblerDTO {
public static IList<CategoriaServicioEN> ConvertList (IList<CategoriaServicioDTO> lista)
{
        IList<CategoriaServicioEN> result = new List<CategoriaServicioEN>();
        foreach (CategoriaServicioDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CategoriaServicioEN Convert (CategoriaServicioDTO dto)
{
        CategoriaServicioEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CategoriaServicioEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Servicio_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IServicioCAD servicioCAD = new TPVNUBEGenNHibernate.CAD.Rest.ServicioCAD ();

                                newinstance.Servicio = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ServicioEN>();
                                foreach (int entry in dto.Servicio_oid) {
                                        newinstance.Servicio.Add (servicioCAD.ReadOIDDefault (entry));
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
