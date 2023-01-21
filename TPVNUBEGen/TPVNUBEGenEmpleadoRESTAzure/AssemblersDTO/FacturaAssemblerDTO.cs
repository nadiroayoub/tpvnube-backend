using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class FacturaAssemblerDTO {
public static IList<FacturaEN> ConvertList (IList<FacturaDTO> lista)
{
        IList<FacturaEN> result = new List<FacturaEN>();
        foreach (FacturaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static FacturaEN Convert (FacturaDTO dto)
{
        FacturaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new FacturaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Numero = dto.Numero;
                        newinstance.Fecha = dto.Fecha;
                        newinstance.Precio = dto.Precio;
                        newinstance.Descripcion = dto.Descripcion;
                        if (dto.Comanda_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IComandaCAD comandaCAD = new TPVNUBEGenNHibernate.CAD.Rest.ComandaCAD ();

                                newinstance.Comanda = comandaCAD.ReadOIDDefault (dto.Comanda_oid);
                        }
                        if (dto.Cliente_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IClienteCAD clienteCAD = new TPVNUBEGenNHibernate.CAD.Rest.ClienteCAD ();

                                newinstance.Cliente = clienteCAD.ReadOIDDefault (dto.Cliente_oid);
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
