using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenTpvhostRESTAzure.DTO;

namespace TPVNUBEGenTpvhostRESTAzure.AssemblersDTO
{
public class LineaComandaAssemblerDTO {
public static IList<LineaComandaEN> ConvertList (IList<LineaComandaDTO> lista)
{
        IList<LineaComandaEN> result = new List<LineaComandaEN>();
        foreach (LineaComandaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static LineaComandaEN Convert (LineaComandaDTO dto)
{
        LineaComandaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new LineaComandaEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Comanda_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IComandaCAD comandaCAD = new TPVNUBEGenNHibernate.CAD.Rest.ComandaCAD ();

                                newinstance.Comanda = comandaCAD.ReadOIDDefault (dto.Comanda_oid);
                        }
                        newinstance.Cantidad = dto.Cantidad;
                        if (dto.Menu_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IMenuCAD menuCAD = new TPVNUBEGenNHibernate.CAD.Rest.MenuCAD ();

                                newinstance.Menu = menuCAD.ReadOIDDefault (dto.Menu_oid);
                        }
                        if (dto.Plato_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IPlatoCAD platoCAD = new TPVNUBEGenNHibernate.CAD.Rest.PlatoCAD ();

                                newinstance.Plato = platoCAD.ReadOIDDefault (dto.Plato_oid);
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
