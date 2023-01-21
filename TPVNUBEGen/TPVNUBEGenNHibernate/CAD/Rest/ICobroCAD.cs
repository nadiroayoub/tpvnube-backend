
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface ICobroCAD
{
CobroEN ReadOIDDefault (int id
                        );

void ModifyDefault (CobroEN cobro);

System.Collections.Generic.IList<CobroEN> ReadAllDefault (int first, int size);



void Modificar (CobroEN cobro);


void Eliminar (int id
               );


CobroEN ReadOID (int id
                 );


System.Collections.Generic.IList<CobroEN> ReadAll (int first, int size);




System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CobroEN> DameCobroPorNegocio (int p_negocio);


int New_ (CobroEN cobro);
}
}
