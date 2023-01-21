using System;
using System.Collections.Generic;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenEmpleadoRESTAzure.DTO;

namespace TPVNUBEGenEmpleadoRESTAzure.AssemblersDTO
{
public class NegocioAssemblerDTO {
public static IList<NegocioEN> ConvertList (IList<NegocioDTO> lista)
{
        IList<NegocioEN> result = new List<NegocioEN>();
        foreach (NegocioDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static NegocioEN Convert (NegocioDTO dto)
{
        NegocioEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new NegocioEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Direccion = dto.Direccion;
                        newinstance.Ciudad = dto.Ciudad;
                        newinstance.Cp = dto.Cp;
                        newinstance.Provincia = dto.Provincia;
                        newinstance.Pais = dto.Pais;
                        if (dto.Servicios_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IServicioCAD servicioCAD = new TPVNUBEGenNHibernate.CAD.Rest.ServicioCAD ();

                                newinstance.Servicios = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ServicioEN>();
                                foreach (int entry in dto.Servicios_oid) {
                                        newinstance.Servicios.Add (servicioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Empresa_oid != -1) {
                                TPVNUBEGenNHibernate.CAD.Rest.IEmpresaCAD empresaCAD = new TPVNUBEGenNHibernate.CAD.Rest.EmpresaCAD ();

                                newinstance.Empresa = empresaCAD.ReadOIDDefault (dto.Empresa_oid);
                        }
                        if (dto.Caja_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICajaCAD cajaCAD = new TPVNUBEGenNHibernate.CAD.Rest.CajaCAD ();

                                newinstance.Caja = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CajaEN>();
                                foreach (int entry in dto.Caja_oid) {
                                        newinstance.Caja.Add (cajaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.CompraProveedor_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.ICompraProveedorCAD compraProveedorCAD = new TPVNUBEGenNHibernate.CAD.Rest.CompraProveedorCAD ();

                                newinstance.CompraProveedor = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.CompraProveedorEN>();
                                foreach (int entry in dto.CompraProveedor_oid) {
                                        newinstance.CompraProveedor.Add (compraProveedorCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Producto_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IProductoCAD productoCAD = new TPVNUBEGenNHibernate.CAD.Rest.ProductoCAD ();

                                newinstance.Producto = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ProductoEN>();
                                foreach (int entry in dto.Producto_oid) {
                                        newinstance.Producto.Add (productoCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Empleado_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IEmpleadoCAD empleadoCAD = new TPVNUBEGenNHibernate.CAD.Rest.EmpleadoCAD ();

                                newinstance.Empleado = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN>();
                                foreach (int entry in dto.Empleado_oid) {
                                        newinstance.Empleado.Add (empleadoCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Cliente_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IClienteCAD clienteCAD = new TPVNUBEGenNHibernate.CAD.Rest.ClienteCAD ();

                                newinstance.Cliente = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.ClienteEN>();
                                foreach (int entry in dto.Cliente_oid) {
                                        newinstance.Cliente.Add (clienteCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Mesa_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IMesaCAD mesaCAD = new TPVNUBEGenNHibernate.CAD.Rest.MesaCAD ();

                                newinstance.Mesa = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.MesaEN>();
                                foreach (int entry in dto.Mesa_oid) {
                                        newinstance.Mesa.Add (mesaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Menu_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IMenuCAD menuCAD = new TPVNUBEGenNHibernate.CAD.Rest.MenuCAD ();

                                newinstance.Menu = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.MenuEN>();
                                foreach (int entry in dto.Menu_oid) {
                                        newinstance.Menu.Add (menuCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Plato_oid != null) {
                                TPVNUBEGenNHibernate.CAD.Rest.IPlatoCAD platoCAD = new TPVNUBEGenNHibernate.CAD.Rest.PlatoCAD ();

                                newinstance.Plato = new System.Collections.Generic.List<TPVNUBEGenNHibernate.EN.Rest.PlatoEN>();
                                foreach (int entry in dto.Plato_oid) {
                                        newinstance.Plato.Add (platoCAD.ReadOIDDefault (entry));
                                }
                        }
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
