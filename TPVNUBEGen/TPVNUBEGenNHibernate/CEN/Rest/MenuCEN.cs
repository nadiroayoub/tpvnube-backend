

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TPVNUBEGenNHibernate.Exceptions;

using TPVNUBEGenNHibernate.EN.Rest;
using TPVNUBEGenNHibernate.CAD.Rest;


namespace TPVNUBEGenNHibernate.CEN.Rest
{
/*
 *      Definition of the class MenuCEN
 *
 */
public partial class MenuCEN
{
private IMenuCAD _IMenuCAD;

public MenuCEN()
{
        this._IMenuCAD = new MenuCAD ();
}

public MenuCEN(IMenuCAD _IMenuCAD)
{
        this._IMenuCAD = _IMenuCAD;
}

public IMenuCAD get_IMenuCAD ()
{
        return this._IMenuCAD;
}

public int Nuevo (string p_nombre, System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.LineaMenuEN> p_lineaMenu, string p_foto, double p_precio, int p_negocio)
{
        MenuEN menuEN = null;
        int oid;

        //Initialized MenuEN
        menuEN = new MenuEN ();
        menuEN.Nombre = p_nombre;

        menuEN.LineaMenu = p_lineaMenu;

        menuEN.Foto = p_foto;

        menuEN.Precio = p_precio;


        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                menuEN.Negocio = new TPVNUBEGenNHibernate.EN.Rest.NegocioEN ();
                menuEN.Negocio.Id = p_negocio;
        }

        //Call to MenuCAD

        oid = _IMenuCAD.Nuevo (menuEN);
        return oid;
}

public void Modificar (int p_Menu_OID, string p_nombre, string p_foto, double p_precio)
{
        MenuEN menuEN = null;

        //Initialized MenuEN
        menuEN = new MenuEN ();
        menuEN.Id = p_Menu_OID;
        menuEN.Nombre = p_nombre;
        menuEN.Foto = p_foto;
        menuEN.Precio = p_precio;
        //Call to MenuCAD

        _IMenuCAD.Modificar (menuEN);
}

public void Eliminar (int id
                      )
{
        _IMenuCAD.Eliminar (id);
}

public MenuEN ReadOID (int id
                       )
{
        MenuEN menuEN = null;

        menuEN = _IMenuCAD.ReadOID (id);
        return menuEN;
}

public System.Collections.Generic.IList<MenuEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MenuEN> list = null;

        list = _IMenuCAD.ReadAll (first, size);
        return list;
}
}
}
