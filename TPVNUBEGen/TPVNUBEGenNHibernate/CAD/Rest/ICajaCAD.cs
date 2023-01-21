
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface ICajaCAD
{
CajaEN ReadOIDDefault (int id
                       );

void ModifyDefault (CajaEN caja);

System.Collections.Generic.IList<CajaEN> ReadAllDefault (int first, int size);



void Modificar (CajaEN caja);


void Eliminar (int id
               );




CajaEN ReadOID (int id
                );


System.Collections.Generic.IList<CajaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.CajaEN> DameCajaPorNegocio (int ? p_negocio);


int Nuevo (CajaEN caja);
}
}
