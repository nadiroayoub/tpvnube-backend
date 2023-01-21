
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
 * Clase Plato:
 *
 */

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial class PlatoCAD : BasicCAD, IPlatoCAD
{
public PlatoCAD() : base ()
{
}

public PlatoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PlatoEN ReadOIDDefault (int id
                               )
{
        PlatoEN platoEN = null;

        try
        {
                SessionInitializeTransaction ();
                platoEN = (PlatoEN)session.Get (typeof(PlatoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in PlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return platoEN;
}

public System.Collections.Generic.IList<PlatoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PlatoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PlatoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PlatoEN>();
                        else
                                result = session.CreateCriteria (typeof(PlatoEN)).List<PlatoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in PlatoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PlatoEN plato)
{
        try
        {
                SessionInitializeTransaction ();
                PlatoEN platoEN = (PlatoEN)session.Load (typeof(PlatoEN), plato.Id);

                platoEN.Nombre = plato.Nombre;


                platoEN.Stock = plato.Stock;


                platoEN.Precio = plato.Precio;




                platoEN.Foto = plato.Foto;




                session.Update (platoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in PlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (PlatoEN plato)
{
        try
        {
                SessionInitializeTransaction ();
                if (plato.LineaPlato != null) {
                        foreach (TPVNUBEGenNHibernate.EN.Rest.LineaPlatoEN item in plato.LineaPlato) {
                                item.Plato = plato;
                                session.Save (item);
                        }
                }
                if (plato.TipoPlato != null) {
                        // Argumento OID y no colección.
                        plato.TipoPlato = (TPVNUBEGenNHibernate.EN.Rest.TipoPlatoEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.TipoPlatoEN), plato.TipoPlato.Id);

                        plato.TipoPlato.Plato
                        .Add (plato);
                }
                if (plato.Negocio != null) {
                        // Argumento OID y no colección.
                        plato.Negocio = (TPVNUBEGenNHibernate.EN.Rest.NegocioEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.NegocioEN), plato.Negocio.Id);

                        plato.Negocio.Plato
                        .Add (plato);
                }

                session.Save (plato);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in PlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return plato.Id;
}

public void Modificar (PlatoEN plato)
{
        try
        {
                SessionInitializeTransaction ();
                PlatoEN platoEN = (PlatoEN)session.Load (typeof(PlatoEN), plato.Id);

                platoEN.Nombre = plato.Nombre;


                platoEN.Precio = plato.Precio;


                platoEN.Foto = plato.Foto;

                session.Update (platoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in PlatoCAD.", ex);
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
                PlatoEN platoEN = (PlatoEN)session.Load (typeof(PlatoEN), id);
                session.Delete (platoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in PlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PlatoEN
public PlatoEN ReadOID (int id
                        )
{
        PlatoEN platoEN = null;

        try
        {
                SessionInitializeTransaction ();
                platoEN = (PlatoEN)session.Get (typeof(PlatoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in PlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return platoEN;
}

public System.Collections.Generic.IList<PlatoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PlatoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PlatoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PlatoEN>();
                else
                        result = session.CreateCriteria (typeof(PlatoEN)).List<PlatoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in PlatoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
