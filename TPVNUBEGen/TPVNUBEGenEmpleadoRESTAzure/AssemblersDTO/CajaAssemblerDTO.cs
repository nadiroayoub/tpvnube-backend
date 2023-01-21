using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class CajaAssemblerDTO {
public static IList<CajaEN> ConvertList (IList<CajaDTO> lista)
{
        IList<CajaEN> result = new List<CajaEN>();
        foreach (CajaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static CajaEN Convert (CajaDTO dto)
{
        CajaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CajaEN ();



                        newinstance.Id = dto.Id;
                        if (dto.Negocio_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.INegocioCAD negocioCAD = new TPVNUBEGenNHibernate.CAD.Rest.NegocioCAD ();

                                newinstance.Negocio = negocioCAD.ReadOIDDefault (dto.Negocio_oid);
                        }
                        if (dto.Pago_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IPagoCAD pagoCAD = new TPVNUBEGenNHibernate.CAD.Rest.PagoCAD ();

                                newinstance.Pago = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.PagoEN>();
                                foreach (int entry in dto.Pago_oid) {
                                        newinstance.Pago.Add (pagoCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Saldo = dto.Saldo;
                        if (dto.Cobro_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICobroCAD cobroCAD = new TPVNUBEGenNHibernate.CAD.Rest.CobroCAD ();

                                newinstance.Cobro = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
                                foreach (int entry in dto.Cobro_oid) {
                                        newinstance.Cobro.Add (cobroCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Descripcion = dto.Descripcion;
                        if (dto.Duenyo_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IDuenyoCAD duenyoCAD = new TPVNUBEGenNHibernate.CAD.Rest.DuenyoCAD ();

                                newinstance.Duenyo = duenyoCAD.ReadOIDDefault (dto.Duenyo_oid);
                        }
                        newinstance.Fondo = dto.Fondo;
                        newinstance.Fecha = dto.Fecha;
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
