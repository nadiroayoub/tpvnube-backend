using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class LineaMenuAssemblerDTO {
public static IList<LineaMenuEN> ConvertList (IList<LineaMenuDTO> lista)
{
        IList<LineaMenuEN> result = new List<LineaMenuEN>();
        foreach (LineaMenuDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static LineaMenuEN Convert (LineaMenuDTO dto)
{
        LineaMenuEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new LineaMenuEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Cantidad = dto.Cantidad;
                        if (dto.Plato_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IPlatoCAD platoCAD = new TPVNUBEGenNHibernate.CAD.Rest.PlatoCAD ();

                                newinstance.Plato = platoCAD.ReadOIDDefault (dto.Plato_oid);
                        }
                        if (dto.Menu_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IMenuCAD menuCAD = new TPVNUBEGenNHibernate.CAD.Rest.MenuCAD ();

                                newinstance.Menu = menuCAD.ReadOIDDefault (dto.Menu_oid);
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
