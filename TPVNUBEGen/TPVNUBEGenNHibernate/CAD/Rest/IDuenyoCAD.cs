
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface IDuenyoCAD
{
DuenyoEN ReadOIDDefault (int id
                         );

void ModifyDefault (DuenyoEN duenyo);

System.Collections.Generic.IList<DuenyoEN> ReadAllDefault (int first, int size);



int Nuevo (DuenyoEN duenyo);

void Modificar (DuenyoEN duenyo);


void Eliminar (int id
               );



DuenyoEN ReadOID (int id
                  );


System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.DuenyoEN> DamePorEmail (string p_email);


System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.DuenyoEN> DamePorDni (string p_dni);


System.Collections.Generic.IList<DuenyoEN> ReadAll (int first, int size);
}
}
