
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
 * Clase Cobro:
 *
 */

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial class CobroCAD : BasicCAD, ICobroCAD
{
public CobroCAD() : base ()
{
}

public CobroCAD(ISession sessionAux) : base (sessionAux)
{
}



public CobroEN ReadOIDDefault (int id
                               )
{
        CobroEN cobroEN = null;

        try
        {
                SessionInitializeTransaction ();
                cobroEN = (CobroEN)session.Get (typeof(CobroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cobroEN;
}

public System.Collections.Generic.IList<CobroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CobroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CobroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CobroEN>();
                        else
                                result = session.CreateCriteria (typeof(CobroEN)).List<CobroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CobroEN cobro)
{
        try
        {
                SessionInitializeTransaction ();
                CobroEN cobroEN = (CobroEN)session.Load (typeof(CobroEN), cobro.Id);

                cobroEN.Monto = cobro.Monto;






                cobroEN.Fecha = cobro.Fecha;



                session.Update (cobroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modificar (CobroEN cobro)
{
        try
        {
                SessionInitializeTransaction ();
                CobroEN cobroEN = (CobroEN)session.Load (typeof(CobroEN), cobro.Id);

                cobroEN.Monto = cobro.Monto;


                cobroEN.Fecha = cobro.Fecha;

                session.Update (cobroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
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
                CobroEN cobroEN = (CobroEN)session.Load (typeof(CobroEN), id);
                session.Delete (cobroEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CobroEN
public CobroEN ReadOID (int id
                        )
{
        CobroEN cobroEN = null;

        try
        {
                SessionInitializeTransaction ();
                cobroEN = (CobroEN)session.Get (typeof(CobroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cobroEN;
}

public System.Collections.Generic.IList<CobroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CobroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CobroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CobroEN>();
                else
                        result = session.CreateCriteria (typeof(CobroEN)).List<CobroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> DameCobroPorNegocio (int p_negocio)
{
        System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CobroEN self where FROM CobroEN cobro where cobro.Negocio.Id = :p_negocio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CobroENdameCobroPorNegocioHQL");
                query.SetParameter ("p_negocio", p_negocio);

                result = query.List<TPVNUBEGenNHibernate.EN.Rest.CobroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int New_ (CobroEN cobro)
{
        try
        {
                SessionInitializeTransaction ();
                if (cobro.Comanda != null) {
                        // Argumento OID y no colección.
                        cobro.Comanda = (TPVNUBEGenNHibernate.EN.Rest.ComandaEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.ComandaEN), cobro.Comanda.Id);

                        cobro.Comanda.Pago
                        .Add (cobro);
                }
                if (cobro.TipoCobro != null) {
                        // Argumento OID y no colección.
                        cobro.TipoCobro = (TPVNUBEGenNHibernate.EN.Rest.TipoCobroEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.TipoCobroEN), cobro.TipoCobro.Id);

                        cobro.TipoCobro.Cobro
                        .Add (cobro);
                }
                if (cobro.Caja != null) {
                        // Argumento OID y no colección.
                        cobro.Caja = (TPVNUBEGenNHibernate.EN.Rest.CajaEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.CajaEN), cobro.Caja.Id);

                        cobro.Caja.Cobro
                        .Add (cobro);
                }
                if (cobro.Empleado != null) {
                        // Argumento OID y no colección.
                        cobro.Empleado = (TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN), cobro.Empleado.Id);

                        cobro.Empleado.Cobro
                        .Add (cobro);
                }
                if (cobro.Negocio != null) {
                        // Argumento OID y no colección.
                        cobro.Negocio = (TPVNUBEGenNHibernate.EN.Rest.NegocioEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.NegocioEN), cobro.Negocio.Id);

                        cobro.Negocio.Cobro
                        .Add (cobro);
                }

                session.Save (cobro);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in CobroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cobro.Id;
}
}
}
