using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class ClienteAssemblerDTO {
public static IList<ClienteEN> ConvertList (IList<ClienteDTO> lista)
{
        IList<ClienteEN> result = new List<ClienteEN>();
        foreach (ClienteDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ClienteEN Convert (ClienteDTO dto)
{
        ClienteEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ClienteEN ();



                        newinstance.Dni = dto.Dni;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Apellidos = dto.Apellidos;
                        if (dto.Factura_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IFacturaCAD facturaCAD = new TPVNUBEGenNHibernate.CAD.Rest.FacturaCAD ();

                                newinstance.Factura = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.FacturaEN>();
                                foreach (int entry in dto.Factura_oid) {
                                        newinstance.Factura.Add (facturaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Cobro_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICobroCAD cobroCAD = new TPVNUBEGenNHibernate.CAD.Rest.CobroCAD ();

                                newinstance.Cobro = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
                                foreach (int entry in dto.Cobro_oid) {
                                        newinstance.Cobro.Add (cobroCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Id = dto.Id;
                        if (dto.Negocio_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TPVNUBEGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
                        }
                        newinstance.Email = dto.Email;
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
