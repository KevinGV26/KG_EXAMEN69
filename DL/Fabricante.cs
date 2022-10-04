using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Fabricante
    {
        public Fabricante()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdFabricante { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
