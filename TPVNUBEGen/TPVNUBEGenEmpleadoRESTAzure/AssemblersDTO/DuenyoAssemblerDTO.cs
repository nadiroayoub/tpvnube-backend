using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class DuenyoAssemblerDTO {
public static IList<DuenyoEN> ConvertList (IList<DuenyoDTO> lista)
{
        IList<DuenyoEN> result = new List<DuenyoEN>();
        foreach (DuenyoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static DuenyoEN Convert (DuenyoDTO dto)
{
        DuenyoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new DuenyoEN ();



                        newinstance.Dni = dto.Dni;
                        if (dto.Empresa_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IEmpresaCAD empresaCAD = new TPVNUBEGenNHibernate.CAD.Rest.EmpresaCAD ();

                                newinstance.Empresa = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.EmpresaEN>();
                                foreach (int entry in dto.Empresa_oid) {
                                        newinstance.Empresa.Add (empresaCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Apellidos = dto.Apellidos;
                        newinstance.Telefono = dto.Telefono;
                        newinstance.Pass = dto.Pass;
                        newinstance.Id = dto.Id;
                        newinstance.Email = dto.Email;
                        if (dto.Caja_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICajaCAD cajaCAD = new TPVNUBEGenNHibernate.CAD.Rest.CajaCAD ();

                                newinstance.Caja = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CajaEN>();
                                foreach (int entry in dto.Caja_oid) {
                                        newinstance.Caja.Add (cajaCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Foto = dto.Foto;
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
