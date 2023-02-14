using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationPrueba
{
    public class Producto
    {
        private long id;
        private string descripciones;
        private double costo;
        private double precioVenta;
        private int stock;
        private long idUsuario;

        public long Id { get => id; set => id = value; }
        public string Descripciones { get => descripciones; set => descripciones = value; }
        public double Costo { get => costo; set => costo = value; }
        public double PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }
        
    }
}
