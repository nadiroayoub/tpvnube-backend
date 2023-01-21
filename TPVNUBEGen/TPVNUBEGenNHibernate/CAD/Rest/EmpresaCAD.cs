
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
 * Clase Empresa:
 *
 */

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial class EmpresaCAD : BasicCAD, IEmpresaCAD
{
public EmpresaCAD() : base ()
{
}

public EmpresaCAD(ISession sessionAux) : base (sessionAux)
{
}



public EmpresaEN ReadOIDDefault (int id
                                 )
{
        EmpresaEN empresaEN = null;

        try
        {
                SessionInitializeTransaction ();
                empresaEN = (EmpresaEN)session.Get (typeof(EmpresaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return empresaEN;
}

public System.Collections.Generic.IList<EmpresaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EmpresaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EmpresaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EmpresaEN>();
                        else
                                result = session.CreateCriteria (typeof(EmpresaEN)).List<EmpresaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EmpresaEN empresa)
{
        try
        {
                SessionInitializeTransaction ();
                EmpresaEN empresaEN = (EmpresaEN)session.Load (typeof(EmpresaEN), empresa.Id);

                empresaEN.Nombre = empresa.Nombre;


                empresaEN.Direccion = empresa.Direccion;




                empresaEN.Cif = empresa.Cif;


                empresaEN.Email = empresa.Email;


                empresaEN.Fechaconstitucion = empresa.Fechaconstitucion;


                empresaEN.Telefono = empresa.Telefono;


                empresaEN.Provincia = empresa.Provincia;


                empresaEN.Ciudad = empresa.Ciudad;


                empresaEN.Pais = empresa.Pais;


                empresaEN.Cp = empresa.Cp;

                session.Update (empresaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (EmpresaEN empresa)
{
        try
        {
                SessionInitializeTransaction ();
                if (empresa.Duenyo != null) {
                        // Argumento OID y no colección.
                        empresa.Duenyo = (TPVNUBEGenNHibernate.EN.Rest.DuenyoEN)session.Load (typeof(TPVNUBEGenNHibernate.EN.Rest.DuenyoEN), empresa.Duenyo.Id);

                        empresa.Duenyo.Empresa
                        .Add (empresa);
                }

                session.Save (empresa);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return empresa.Id;
}

public void Modificar (EmpresaEN empresa)
{
        try
        {
                SessionInitializeTransaction ();
                EmpresaEN empresaEN = (EmpresaEN)session.Load (typeof(EmpresaEN), empresa.Id);

                empresaEN.Nombre = empresa.Nombre;


                empresaEN.Direccion = empresa.Direccion;


                empresaEN.Cif = empresa.Cif;


                empresaEN.Email = empresa.Email;


                empresaEN.Fechaconstitucion = empresa.Fechaconstitucion;


                empresaEN.Telefono = empresa.Telefono;


                empresaEN.Provincia = empresa.Provincia;


                empresaEN.Ciudad = empresa.Ciudad;


                empresaEN.Pais = empresa.Pais;


                empresaEN.Cp = empresa.Cp;

                session.Update (empresaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaCAD.", ex);
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
                EmpresaEN empresaEN = (EmpresaEN)session.Load (typeof(EmpresaEN), id);
                session.Delete (empresaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: EmpresaEN
public EmpresaEN ReadOID (int id
                          )
{
        EmpresaEN empresaEN = null;

        try
        {
                SessionInitializeTransaction ();
                empresaEN = (EmpresaEN)session.Get (typeof(EmpresaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return empresaEN;
}

public System.Collections.Generic.IList<EmpresaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EmpresaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EmpresaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EmpresaEN>();
                else
                        result = session.CreateCriteria (typeof(EmpresaEN)).List<EmpresaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is TPVNUBEGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new TPVNUBEGenNHibernate.Exceptions.DataLayerException ("Error in EmpresaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
