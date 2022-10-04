using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? IdFabricante { get; set; }

        public virtual Fabricante? IdFabricanteNavigation { get; set; }
    }
}
