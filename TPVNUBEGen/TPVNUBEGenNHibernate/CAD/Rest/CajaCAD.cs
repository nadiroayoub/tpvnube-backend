
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
 * Clase Caja:
 *
 */

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial class CajaCAD : BasicCAD, ICajaCAD
{
public CajaCAD() : base ()
{
}

public CajaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CajaEN ReadOIDDefault (int id
                              )
{
        CajaEN cajaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cajaEN = (CajaEN)session.Get (typeof(CajaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajaEN;
}

public System.Collections.Generic.IList<CajaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CajaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CajaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CajaEN>();
                        else
                                result = session.CreateCriteria (typeof(CajaEN)).List<CajaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CajaEN caja)
{
        try
        {
                SessionInitializeTransaction ();
                CajaEN cajaEN = (CajaEN)session.Load (typeof(CajaEN), caja.Id);



                cajaEN.Saldo = caja.Saldo;



                cajaEN.Descripcion = caja.Descripcion;



                cajaEN.Fondo = caja.Fondo;


                cajaEN.Fecha = caja.Fecha;

                session.Update (cajaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modificar (CajaEN caja)
{
        try
        {
                SessionInitializeTransaction ();
                CajaEN cajaEN = (CajaEN)session.Load (typeof(CajaEN), caja.Id);

                cajaEN.Descripcion = caja.Descripcion;


                cajaEN.Fondo = caja.Fondo;


                cajaEN.Fecha = caja.Fecha;

                session.Update (cajaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
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
                CajaEN cajaEN = (CajaEN)session.Load (typeof(CajaEN), id);
                session.Delete (cajaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CajaEN
public CajaEN ReadOID (int id
                       )
{
        CajaEN cajaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cajaEN = (CajaEN)session.Get (typeof(CajaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajaEN;
}

public System.Collections.Generic.IList<CajaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CajaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CajaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CajaEN>();
                else
                        result = session.CreateCriteria (typeof(CajaEN)).List<CajaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> DameCajaPorNegocio (int ? p_negocio)
{
        System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CajaEN self where FROM CajaEN caja where caja.Negocio.Id = :p_negocio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CajaENdameCajaPorNegocioHQL");
                query.SetParameter ("p_negocio", p_negocio);

                result = query.List<TPVNUBEGenNHibernate.EN.Rest.CajaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int Nuevo (CajaEN caja)
{
        try
        {
                SessionInitializeTransaction ();
                if (caja.Negocio != null) {
                        // Argumento OID y no colección.
                        caja.Negocio = (TPVNUBEGenNHibernate.EN.Rest.NegocioEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.NegocioEN), caja.Negocio.Id);

                        caja.Negocio.Caja
                        .Add (caja);
                }
                if (caja.Duenyo != null) {
                        // Argumento OID y no colección.
                        caja.Duenyo = (TPVNUBEGenNHibernate.EN.Rest.DuenyoEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.DuenyoEN), caja.Duenyo.Id);

                        caja.Duenyo.Caja
                        .Add (caja);
                }

                session.Save (caja);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return caja.Id;
}
}
}
