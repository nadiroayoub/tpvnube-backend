using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class CajeroAssemblerDTO {
public static IList<CajeroEN> ConvertList (IList<CajeroDTO> lista)
{
        IList<CajeroEN> result = new List<CajeroEN>();
        foreach (CajeroDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CajeroEN Convert (CajeroDTO dto)
{
        CajeroEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CajeroEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Rol_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IRolCAD rolCAD = new TPVNUBEGenNHibernate.CAD.Rest.RolCAD ();

                                newinstance.Rol = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.RolEN>();
                                foreach (int entry in dto.Rol_oid) {
                                        newinstance.Rol.Add (rolCAD.ReadOIDDefault (entry));
                                }
                        }
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
