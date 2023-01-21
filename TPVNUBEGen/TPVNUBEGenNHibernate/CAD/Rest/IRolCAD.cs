
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface IRolCAD
{
RolEN ReadOIDDefault (int id
                      );

void ModifyDefault (RolEN rol);

System.Collections.Generic.IList<RolEN> ReadAllDefault (int first, int size);



int NuevoCajero (RolEN rol);

void Modificar (RolEN rol);


void Eliminar (int id
               );



int NuevoCamarero (RolEN rol);


RolEN ReadOID (int id
               );


System.Collections.Generic.IList<RolEN> ReadAll (int first, int size);
}
}
