
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface IComandaCAD
{
ComandaEN ReadOIDDefault (int id
                          );

void ModifyDefault (ComandaEN comanda);

System.Collections.Generic.IList<ComandaEN> ReadAllDefault (int first, int size);



int Nuevo (ComandaEN comanda);

void Modificar (ComandaEN comanda);


void Eliminar (int id
               );





ComandaEN ReadOID (int id
                   );


System.Collections.Generic.IList<ComandaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.ComandaEN> DameComandasPorMesa (int p_mesa);
}
}
