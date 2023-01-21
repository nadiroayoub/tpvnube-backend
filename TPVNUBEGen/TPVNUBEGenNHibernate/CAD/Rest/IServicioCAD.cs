
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface IServicioCAD
{
ServicioEN ReadOIDDefault (int id
                           );

void ModifyDefault (ServicioEN servicio);

System.Collections.Generic.IList<ServicioEN> ReadAllDefault (int first, int size);



int Nuevo (ServicioEN servicio);

void Modificar (ServicioEN servicio);


void Eliminar (int id
               );


ServicioEN ReadOID (int id
                    );


System.Collections.Generic.IList<ServicioEN> ReadAll (int first, int size);
}
}
