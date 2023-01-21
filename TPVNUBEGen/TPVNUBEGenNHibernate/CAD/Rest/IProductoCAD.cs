
using System;
using TPVNUBEGenNHibernate.EN.Rest;

namespace TPVNUBEGenNHibernate.CAD.Rest
{
public partial interface IProductoCAD
{
ProductoEN ReadOIDDefault (int id
                           );

void ModifyDefault (ProductoEN producto);

System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size);



int Nuevo (ProductoEN producto);

void Modificar (ProductoEN producto);


void Eliminar (int id
               );




ProductoEN ReadOID (int id
                    );


System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size);
}
}
