using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class ComandaAssemblerDTO {
public static IList<ComandaEN> ConvertList (IList<ComandaDTO> lista)
{
        IList<ComandaEN> result = new List<ComandaEN>();
        foreach (ComandaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ComandaEN Convert (ComandaDTO dto)
{
        ComandaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ComandaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.EstadoComanda = dto.EstadoComanda;

                        if (dto.LineaComanda != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ILineaComandaCAD lineaComandaCAD = new TPVNUBEGenNHibernate.CAD.Rest.LineaComandaCAD ();

                                newinstance.LineaComanda = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.LineaComandaEN>();
                                foreach (LineaComandaDTO entry in dto.LineaComanda) {
                                        newinstance.LineaComanda.Add (LineaComandaAssemblerDTO.Convert (entry));
                                }
                        }
                        if (dto.Pago_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICobroCAD cobroCAD = new TPVNUBEGenNHibernate.CAD.Rest.CobroCAD ();

                                newinstance.Pago = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
                                foreach (int entry in dto.Pago_oid) {
                                        newinstance.Pago.Add (cobroCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Mesa_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IMesaCAD mesaCAD = new TPVNUBEGenNHibernate.CAD.Rest.MesaCAD ();

                                newinstance.Mesa = mesaCAD.ReadOIDDefault (dto.Mesa_oid);
                        }
                        if (dto.Factura_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IFacturaCAD facturaCAD = new TPVNUBEGenNHibernate.CAD.Rest.FacturaCAD ();

                                newinstance.Factura = facturaCAD.ReadOIDDefault (dto.Factura_oid);
                        }
                        newinstance.Fecha = dto.Fecha;
                        if (dto.Empleado_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IEmpleadoCAD empleadoCAD = new TPVNUBEGenNHibernate.CAD.Rest.EmpleadoCAD ();

                                newinstance.Empleado = empleadoCAD.ReadOIDDefault (dto.Empleado_oid);
                        }
                        newinstance.Total = dto.Total;
                        newinstance.Pdf = dto.Pdf;
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
