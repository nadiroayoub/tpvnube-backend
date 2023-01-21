
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
 * Clase CajaFecha:
 *
 */

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial class CajaFechaCAD : BasicCAD, ICajaFechaCAD
{
public CajaFechaCAD() : base ()
{
}

public CajaFechaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CajaFechaEN ReadOIDDefault (int id
                                   )
{
        CajaFechaEN cajaFechaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cajaFechaEN = (CajaFechaEN)session.Get (typeof(CajaFechaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaFechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajaFechaEN;
}

public System.Collections.Generic.IList<CajaFechaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CajaFechaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CajaFechaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CajaFechaEN>();
                        else
                                result = session.CreateCriteria (typeof(CajaFechaEN)).List<CajaFechaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaFechaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CajaFechaEN cajaFecha)
{
        try
        {
                SessionInitializeTransaction ();
                CajaFechaEN cajaFechaEN = (CajaFechaEN)session.Load (typeof(CajaFechaEN), cajaFecha.Id);

                cajaFechaEN.Fecha = cajaFecha.Fecha;


                cajaFechaEN.IdCaja = cajaFecha.IdCaja;


                cajaFechaEN.Total = cajaFecha.Total;


                session.Update (cajaFechaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaFechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CajaFechaEN cajaFecha)
{
        try
        {
                SessionInitializeTransaction ();
                if (cajaFecha.Caja != null) {
                        for (int i = 0; i < cajaFecha.Caja.Count; i++) {
                                cajaFecha.Caja [i] = (TPVNUBEGenNHibernate.EN.Rest.CajaEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.CajaEN), cajaFecha.Caja [i].Id);
                                cajaFecha.Caja [i].CajaFecha.Add (cajaFecha);
                        }
                }

                session.Save (cajaFecha);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaFechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajaFecha.Id;
}

public void Modify (CajaFechaEN cajaFecha)
{
        try
        {
                SessionInitializeTransaction ();
                CajaFechaEN cajaFechaEN = (CajaFechaEN)session.Load (typeof(CajaFechaEN), cajaFecha.Id);

                cajaFechaEN.Fecha = cajaFecha.Fecha;


                cajaFechaEN.IdCaja = cajaFecha.IdCaja;


                cajaFechaEN.Total = cajaFecha.Total;

                session.Update (cajaFechaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaFechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                CajaFechaEN cajaFechaEN = (CajaFechaEN)session.Load (typeof(CajaFechaEN), id);
                session.Delete (cajaFechaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaFechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CajaFechaEN
public CajaFechaEN ReadOID (int id
                            )
{
        CajaFechaEN cajaFechaEN = null;

        try
        {
                SessionInitializeTransaction ();
                cajaFechaEN = (CajaFechaEN)session.Get (typeof(CajaFechaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaFechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cajaFechaEN;
}

public System.Collections.Generic.IList<CajaFechaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CajaFechaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CajaFechaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CajaFechaEN>();
                else
                        result = session.CreateCriteria (typeof(CajaFechaEN)).List<CajaFechaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CajaFechaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
