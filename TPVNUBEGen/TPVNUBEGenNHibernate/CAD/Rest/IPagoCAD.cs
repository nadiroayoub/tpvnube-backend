
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface IPagoCAD
{
PagoEN ReadOIDDefault (int id
                       );

void ModifyDefault (PagoEN pago);

System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size);



int Nuevo (PagoEN pago);

void Modificar (PagoEN pago);


void Eliminar (int id
               );





PagoEN ReadOID (int id
                );


System.Collections.Generic.IList<PagoEN> ReadAll (int first, int size);
}
}
