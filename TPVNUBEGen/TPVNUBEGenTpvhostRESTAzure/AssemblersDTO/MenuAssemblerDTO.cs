using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class MenuAssemblerDTO {
public static IList<MenuEN> ConvertList (IList<MenuDTO> lista)
{
        IList<MenuEN> result = new List<MenuEN>();
        foreach (MenuDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static MenuEN Convert (MenuDTO dto)
{
        MenuEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new MenuEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Stock = dto.Stock;
                        if (dto.LineaComanda_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ILineaComandaCAD lineaComandaCAD = new TPVNUBEGenNHibernate.CAD.Rest.LineaComandaCAD ();

                                newinstance.LineaComanda = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN>();
                                foreach (int entry in dto.LineaComanda_oid) {
                                        newinstance.LineaComanda.Add (lineaComandaCAD.ReadOIDDefault (entry));
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
                        newinstance.Precio = dto.Precio;
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
