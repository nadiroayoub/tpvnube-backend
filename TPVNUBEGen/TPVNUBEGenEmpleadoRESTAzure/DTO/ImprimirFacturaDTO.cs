using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPVNUBEGenEmpleadoRESTAzureREST.DTO
{
    public class ImprimirFacturaDTO
    {
        private int cliente_oid;
        public int Cliente_oid
        {
            get { return cliente_oid; }
            set { cliente_oid = value; }
        }

        private int numero;
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }


        private System.Collections.Generic.IList<ComandaItems> items;
        public System.Collections.Generic.IList<ComandaItems> Items
        {
            get { return items; }
            set { items = value; }
        }

        private double total;
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}