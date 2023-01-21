using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class EmpresaAssemblerDTO {
public static IList<EmpresaEN> ConvertList (IList<EmpresaDTO> lista)
{
        IList<EmpresaEN> result = new List<EmpresaEN>();
        foreach (EmpresaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static EmpresaEN Convert (EmpresaDTO dto)
{
        EmpresaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new EmpresaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Direccion = dto.Direccion;
                        if (dto.Duenyo_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IDuenyoCAD duenyoCAD = new TPVNUBEGenNHibernate.CAD.Rest.DuenyoCAD ();

                                newinstance.Duenyo = duenyoCAD.ReadOIDDefault (dto.Duenyo_oid);
                        }
                        if (dto.Negocio_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TPVNUBEGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.NegocioEN>();
                                foreach (int entry in dto.Negocio_oid) {
                                        newinstance.Negocio.Add (negocioCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Cif = dto.Cif;
                        newinstance.Email = dto.Email;
                        newinstance.Fechaconstitucion = dto.Fechaconstitucion;
                        newinstance.Telefono = dto.Telefono;
                        newinstance.Provincia = dto.Provincia;
                        newinstance.Ciudad = dto.Ciudad;
                        newinstance.Pais = dto.Pais;
                        newinstance.Cp = dto.Cp;
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
