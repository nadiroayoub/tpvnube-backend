using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class CobroAssemblerDTO {
public static IList<CobroEN> ConvertList (IList<CobroDTO> lista)
{
        IList<CobroEN> result = new List<CobroEN>();
        foreach (CobroDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CobroEN Convert (CobroDTO dto)
{
        CobroEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CobroEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Monto = dto.Monto;
                        if (dto.Comanda_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IComandaCAD comandaCAD = new TPVNUBEGenNHibernate.CAD.Rest.ComandaCAD ();

                                newinstance.Comanda = comandaCAD.ReadOIDDefault (dto.Comanda_oid);
                        }
                        if (dto.Cliente_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IClienteCAD clienteCAD = new TPVNUBEGenNHibernate.CAD.Rest.ClienteCAD ();

                                newinstance.Cliente = clienteCAD.ReadOIDDefault (dto.Cliente_oid);
                        }
                        if (dto.TipoCobro_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.ITipoCobroCAD tipoCobroCAD = new TPVNUBEGenNHibernate.CAD.Rest.TipoCobroCAD ();

                                newinstance.TipoCobro = tipoCobroCAD.ReadOIDDefault (dto.TipoCobro_oid);
                        }
                        if (dto.Caja_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICajaCAD cajaCAD = new TPVNUBEGenNHibernate.CAD.Rest.CajaCAD ();

                                newinstance.Caja = cajaCAD.ReadOIDDefault (dto.Caja_oid);
                        }
                        newinstance.Fecha = dto.Fecha;
                        if (dto.Empleado_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IEmpleadoCAD empleadoCAD = new TPVNUBEGenNHibernate.CAD.Rest.EmpleadoCAD ();

                                newinstance.Empleado = empleadoCAD.ReadOIDDefault (dto.Empleado_oid);
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
