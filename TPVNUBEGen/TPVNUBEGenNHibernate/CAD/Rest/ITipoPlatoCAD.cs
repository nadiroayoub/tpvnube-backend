
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface ITipoPlatoCAD
{
TipoPlatoEN ReadOIDDefault (int id
                            );

void ModifyDefault (TipoPlatoEN tipoPlato);

System.Collections.Generic.IList<TipoPlatoEN> ReadAllDefault (int first, int size);



int Nuevo (TipoPlatoEN tipoPlato);

void Modificar (TipoPlatoEN tipoPlato);


void Eliminar (int id
               );
}
}
