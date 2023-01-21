
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface IEmpleadoCAD
{
EmpleadoEN ReadOIDDefault (int id
                           );

void ModifyDefault (EmpleadoEN empleado);

System.Collections.Generic.IList<EmpleadoEN> ReadAllDefault (int first, int size);



int Nuevo (EmpleadoEN empleado);

void ModificarSinPass (EmpleadoEN empleado);


void Eliminar (int id
               );


EmpleadoEN ReadOID (int id
                    );


System.Collections.Generic.IList<EmpleadoEN> ReadAll (int first, int size);



System.Collections.Generic.IList<TPVNUBEGenNHibernate.EN.Rest.EmpleadoEN> DamePorEmail (string p_email);


void Modificar (EmpleadoEN empleado);
}
}
