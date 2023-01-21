
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface ICajaFechaCAD
{
CajaFechaEN ReadOIDDefault (int id
                            );

void ModifyDefault (CajaFechaEN cajaFecha);

System.Collections.Generic.IList<CajaFechaEN> ReadAllDefault (int first, int size);



int New_ (CajaFechaEN cajaFecha);

void Modify (CajaFechaEN cajaFecha);


void Destroy (int id
              );


CajaFechaEN ReadOID (int id
                     );


System.Collections.Generic.IList<CajaFechaEN> ReadAll (int first, int size);
}
}
