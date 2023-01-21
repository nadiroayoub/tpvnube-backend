
using System;
using System.Text;
using TPVNUBEGenNHibernate.CEN.Rest;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.Exceptions;


/*
 * Clase CompraProveedor:
 *
 */

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial class CompraProveedorCAD : BasicCAD, ICompraProveedorCAD
{
public CompraProveedorCAD() : base ()
{
}

public CompraProveedorCAD(ISession sessionAux) : base (sessionAux)
{
}



public CompraProveedorEN ReadOIDDefault (int id
                                         )
{
        CompraProveedorEN compraProveedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                compraProveedorEN = (CompraProveedorEN)session.Get (typeof(CompraProveedorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compraProveedorEN;
}

public System.Collections.Generic.IList<CompraProveedorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CompraProveedorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CompraProveedorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CompraProveedorEN>();
                        else
                                result = session.CreateCriteria (typeof(CompraProveedorEN)).List<CompraProveedorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CompraProveedorEN compraProveedor)
{
        try
        {
                SessionInitializeTransaction ();
                CompraProveedorEN compraProveedorEN = (CompraProveedorEN)session.Load (typeof(CompraProveedorEN), compraProveedor.Id);





                compraProveedorEN.EstadoCompra = compraProveedor.EstadoCompra;


                compraProveedorEN.Fecha = compraProveedor.Fecha;


                compraProveedorEN.Total = compraProveedor.Total;

                session.Update (compraProveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (CompraProveedorEN compraProveedor)
{
        try
        {
                SessionInitializeTransaction ();
                if (compraProveedor.LineaCompraProveedor != null) {
                        foreach (TPVNUBEGenNHibernate.EN.Rest.LineaCompraProveedorEN item in compraProveedor.LineaCompraProveedor) {
                                item.CompraProveedor = compraProveedor;
                                session.Save (item);
                        }
                }
                if (compraProveedor.Proveedor != null) {
                        // Argumento OID y no colección.
                        compraProveedor.Proveedor = (TPVNUBEGenNHibernate.EN.Rest.ProveedorEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.ProveedorEN), compraProveedor.Proveedor.Id);

                        compraProveedor.Proveedor.CompraProveedor
                        .Add (compraProveedor);
                }
                if (compraProveedor.Negocio != null) {
                        // Argumento OID y no colección.
                        compraProveedor.Negocio = (TPVNUBEGenNHibernate.EN.Rest.NegocioEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.NegocioEN), compraProveedor.Negocio.Id);

                        compraProveedor.Negocio.CompraProveedor
                        .Add (compraProveedor);
                }

                session.Save (compraProveedor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compraProveedor.Id;
}

public void Modificar (CompraProveedorEN compraProveedor)
{
        try
        {
                SessionInitializeTransaction ();
                CompraProveedorEN compraProveedorEN = (CompraProveedorEN)session.Load (typeof(CompraProveedorEN), compraProveedor.Id);

                compraProveedorEN.EstadoCompra = compraProveedor.EstadoCompra;


                compraProveedorEN.Fecha = compraProveedor.Fecha;

                session.Update (compraProveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (int id
                      )
{
        try
        {
                SessionInitializeTransaction ();
                CompraProveedorEN compraProveedorEN = (CompraProveedorEN)session.Load (typeof(CompraProveedorEN), id);
                session.Delete (compraProveedorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CompraProveedorEN
public CompraProveedorEN ReadOID (int id
                                  )
{
        CompraProveedorEN compraProveedorEN = null;

        try
        {
                SessionInitializeTransaction ();
                compraProveedorEN = (CompraProveedorEN)session.Get (typeof(CompraProveedorEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return compraProveedorEN;
}

public System.Collections.Generic.IList<CompraProveedorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CompraProveedorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CompraProveedorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CompraProveedorEN>();
                else
                        result = session.CreateCriteria (typeof(CompraProveedorEN)).List<CompraProveedorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CompraProveedorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
