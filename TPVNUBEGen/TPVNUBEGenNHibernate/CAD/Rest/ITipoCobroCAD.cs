
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface ITipoCobroCAD
{
TipoCobroEN ReadOIDDefault (int id
                            );

void ModifyDefault (TipoCobroEN tipoCobro);

System.Collections.Generic.IList<TipoCobroEN> ReadAllDefault (int first, int size);



int Nuevo (TipoCobroEN tipoCobro);

void Modificar (TipoCobroEN tipoCobro);


void Eliminar (int id
               );


TipoCobroEN ReadOID (int id
                     );


System.Collections.Generic.IList<TipoCobroEN> ReadAll (int first, int size);
}
}
