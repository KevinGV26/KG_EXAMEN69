using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { set; get; }

        public string? Nombre { set; get; }
        public double Precio { set; get; }

        public ML.Fabricante? fabricante { set; get; }

        public List<object> productos { set; get; }
    }
}
