
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface ILineaComandaCAD
{
LineaComandaEN ReadOIDDefault (int id
                               );

void ModifyDefault (LineaComandaEN lineaComanda);

System.Collections.Generic.IList<LineaComandaEN> ReadAllDefault (int first, int size);



void Modificar (LineaComandaEN lineaComanda);


void Eliminar (int id
               );



LineaComandaEN ReadOID (int id
                        );


System.Collections.Generic.IList<LineaComandaEN> ReadAll (int first, int size);



int New_ (LineaComandaEN lineaComanda);
}
}
