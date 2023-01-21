using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class RolAssemblerDTO {
public static IList<RolEN> ConvertList (IList<RolDTO> lista)
{
        IList<RolEN> result = new List<RolEN>();
        foreach (RolDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static RolEN Convert (RolDTO dto)
{
        RolEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new RolEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Cajero_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICajeroCAD cajeroCAD = new TPVNUBEGenNHibernate.CAD.Rest.CajeroCAD ();

                                newinstance.Cajero = cajeroCAD.ReadOIDDefault (dto.Cajero_oid);
                        }
                        if (dto.Camarero_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICamareroCAD camareroCAD = new TPVNUBEGenNHibernate.CAD.Rest.CamareroCAD ();

                                newinstance.Camarero = camareroCAD.ReadOIDDefault (dto.Camarero_oid);
                        }
                        newinstance.Empleo = dto.Empleo;
                        if (dto.Empleado_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IEmpleadoCAD empleadoCAD = new TPVNUBEGenNHibernate.CAD.Rest.EmpleadoCAD ();

                                newinstance.Empleado = empleadoCAD.ReadOIDDefault (dto.Empleado_oid);
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
