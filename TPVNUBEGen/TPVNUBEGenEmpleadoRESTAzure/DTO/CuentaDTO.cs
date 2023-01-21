using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPVNUBEGenEmpleadoRESTAzureREST.DTO
{
    public partial class CuentaDTO
    {
        private int nombre;
        public int Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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