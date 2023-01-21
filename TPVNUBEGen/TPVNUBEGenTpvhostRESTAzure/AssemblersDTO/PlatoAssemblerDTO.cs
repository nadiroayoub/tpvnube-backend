using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class PlatoAssemblerDTO {
public static IList<PlatoEN> ConvertList (IList<PlatoDTO> lista)
{
        IList<PlatoEN> result = new List<PlatoEN>();
        foreach (PlatoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static PlatoEN Convert (PlatoDTO dto)
{
        PlatoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PlatoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Stock = dto.Stock;
                        newinstance.Precio = dto.Precio;

                        if (dto.LineaPlato != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ILineaPlatoCAD lineaPlatoCAD = new TPVNUBEGenNHibernate.CAD.Rest.LineaPlatoCAD ();

                                newinstance.LineaPlato = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaPlatoEN>();
                                foreach (LineaPlatoDTO entry in dto.LineaPlato) {
                                        newinstance.LineaPlato.Add (LineaPlatoAssemblerDTO.Convert (entry));
                                }
                        }

                        if (dto.LineaMenu != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ILineaMenuCAD lineaMenuCAD = new TPVNUBEGenNHibernate.CAD.Rest.LineaMenuCAD ();

                                newinstance.LineaMenu = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN>();
                                foreach (LineaMenuDTO entry in dto.LineaMenu) {
                                        newinstance.LineaMenu.Add (LineaMenuAssemblerDTO.Convert (entry));
                                }
                        }
                        newinstance.Foto = dto.Foto;
                        if (dto.TipoPlato_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.ITipoPlatoCAD tipoPlatoCAD = new TPVNUBEGenNHibernate.CAD.Rest.TipoPlatoCAD ();

                                newinstance.TipoPlato = tipoPlatoCAD.ReadOIDDefault (dto.TipoPlato_oid);
                        }
                        if (dto.LineaComanda_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ILineaComandaCAD lineaComandaCAD = new TPVNUBEGenNHibernate.CAD.Rest.LineaComandaCAD ();

                                newinstance.LineaComanda = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN>();
                                foreach (int entry in dto.LineaComanda_oid) {
                                        newinstance.LineaComanda.Add (lineaComandaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Negocio_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TPVNUBEGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
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
