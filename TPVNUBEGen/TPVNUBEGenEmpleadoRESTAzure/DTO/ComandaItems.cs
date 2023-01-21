using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPVNUBEGenEmpleadoRESTAzureREST.DTO
{
    public partial class ComandaItems
    {

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private double precio;
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private string foto;
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}