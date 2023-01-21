
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
 * Clase TipoPlato:
 *
 */

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial class TipoPlatoCAD : BasicCAD, ITipoPlatoCAD
{
public TipoPlatoCAD() : base ()
{
}

public TipoPlatoCAD(ISession sessionAux) : base (sessionAux)
{
}



public TipoPlatoEN ReadOIDDefault (int id
                                   )
{
        TipoPlatoEN tipoPlatoEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipoPlatoEN = (TipoPlatoEN)session.Get (typeof(TipoPlatoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in TipoPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoPlatoEN;
}

public System.Collections.Generic.IList<TipoPlatoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TipoPlatoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TipoPlatoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TipoPlatoEN>();
                        else
                                result = session.CreateCriteria (typeof(TipoPlatoEN)).List<TipoPlatoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in TipoPlatoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TipoPlatoEN tipoPlato)
{
        try
        {
                SessionInitializeTransaction ();
                TipoPlatoEN tipoPlatoEN = (TipoPlatoEN)session.Load (typeof(TipoPlatoEN), tipoPlato.Id);

                tipoPlatoEN.Nombre = tipoPlato.Nombre;


                session.Update (tipoPlatoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in TipoPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (TipoPlatoEN tipoPlato)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tipoPlato);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in TipoPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipoPlato.Id;
}

public void Modificar (TipoPlatoEN tipoPlato)
{
        try
        {
                SessionInitializeTransaction ();
                TipoPlatoEN tipoPlatoEN = (TipoPlatoEN)session.Load (typeof(TipoPlatoEN), tipoPlato.Id);

                tipoPlatoEN.Nombre = tipoPlato.Nombre;

                session.Update (tipoPlatoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in TipoPlatoCAD.", ex);
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
                TipoPlatoEN tipoPlatoEN = (TipoPlatoEN)session.Load (typeof(TipoPlatoEN), id);
                session.Delete (tipoPlatoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in TipoPlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
