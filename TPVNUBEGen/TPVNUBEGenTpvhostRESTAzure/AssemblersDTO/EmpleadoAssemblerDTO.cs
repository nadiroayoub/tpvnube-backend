using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class EmpleadoAssemblerDTO {
public static IList<EmpleadoEN> ConvertList (IList<EmpleadoDTO> lista)
{
        IList<EmpleadoEN> result = new List<EmpleadoEN>();
        foreach (EmpleadoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static EmpleadoEN Convert (EmpleadoDTO dto)
{
        EmpleadoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new EmpleadoEN ();



                        if (dto.Negocio_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TPVNUBEGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
                        }
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Apellidos = dto.Apellidos;
                        newinstance.Pass = dto.Pass;
                        newinstance.Foto = dto.Foto;
                        if (dto.Comanda_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IComandaCAD comandaCAD = new TPVNUBEGenNHibernate.CAD.Rest.ComandaCAD ();

                                newinstance.Comanda = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ComandaEN>();
                                foreach (int entry in dto.Comanda_oid) {
                                        newinstance.Comanda.Add (comandaCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Id = dto.Id;
                        newinstance.Dni = dto.Dni;
                        newinstance.Email = dto.Email;
                        newinstance.Telefono = dto.Telefono;
                        if (dto.Cobro_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICobroCAD cobroCAD = new TPVNUBEGenNHibernate.CAD.Rest.CobroCAD ();

                                newinstance.Cobro = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
                                foreach (int entry in dto.Cobro_oid) {
                                        newinstance.Cobro.Add (cobroCAD.ReadOIDDefault (entry));
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
