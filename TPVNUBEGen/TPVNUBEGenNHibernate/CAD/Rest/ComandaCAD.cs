
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
 * Clase Comanda:
 *
 */

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial class ComandaCAD : BasicCAD, IComandaCAD
{
public ComandaCAD() : base ()
{
}

public ComandaCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComandaEN ReadOIDDefault (int id
                                 )
{
        ComandaEN comandaEN = null;

        try
        {
                SessionInitializeTransaction ();
                comandaEN = (ComandaEN)session.Get (typeof(ComandaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comandaEN;
}

public System.Collections.Generic.IList<ComandaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComandaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComandaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComandaEN>();
                        else
                                result = session.CreateCriteria (typeof(ComandaEN)).List<ComandaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComandaEN comanda)
{
        try
        {
                SessionInitializeTransaction ();
                ComandaEN comandaEN = (ComandaEN)session.Load (typeof(ComandaEN), comanda.Id);

                comandaEN.EstadoComanda = comanda.EstadoComanda;






                comandaEN.Fecha = comanda.Fecha;



                comandaEN.Total = comanda.Total;


                comandaEN.Pdf = comanda.Pdf;

                session.Update (comandaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (ComandaEN comanda)
{
        try
        {
                SessionInitializeTransaction ();
                if (comanda.Mesa != null) {
                        // Argumento OID y no colección.
                        comanda.Mesa = (TPVNUBEGenNHibernate.EN.Rest.MesaEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.MesaEN), comanda.Mesa.Id);

                        comanda.Mesa.Comanda
                        .Add (comanda);
                }
                if (comanda.Empleado != null) {
                        // Argumento OID y no colección.
                        comanda.Empleado = (TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN), comanda.Empleado.Id);

                        comanda.Empleado.Comanda
                        .Add (comanda);
                }

                session.Save (comanda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comanda.Id;
}

public void Modificar (ComandaEN comanda)
{
        try
        {
                SessionInitializeTransaction ();
                ComandaEN comandaEN = (ComandaEN)session.Load (typeof(ComandaEN), comanda.Id);

                comandaEN.EstadoComanda = comanda.EstadoComanda;


                comandaEN.Fecha = comanda.Fecha;


                comandaEN.Total = comanda.Total;


                comandaEN.Pdf = comanda.Pdf;

                session.Update (comandaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
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
                ComandaEN comandaEN = (ComandaEN)session.Load (typeof(ComandaEN), id);
                session.Delete (comandaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComandaEN
public ComandaEN ReadOID (int id
                          )
{
        ComandaEN comandaEN = null;

        try
        {
                SessionInitializeTransaction ();
                comandaEN = (ComandaEN)session.Get (typeof(ComandaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comandaEN;
}

public System.Collections.Generic.IList<ComandaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComandaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComandaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComandaEN>();
                else
                        result = session.CreateCriteria (typeof(ComandaEN)).List<ComandaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> DameComandasPorMesa (int p_mesa)
{
        System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ComandaEN self where FROM ComandaEN comanda where comanda.Mesa.Id = :p_mesa";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ComandaENdameComandasPorMesaHQL");
                query.SetParameter ("p_mesa", p_mesa);

                result = query.List<TPVNUBEGenNHibernate.EN.Rest.ComandaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in ComandaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
