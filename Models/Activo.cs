using System;
using System.Collections.Generic;

namespace EstebanVasquez_Parcial2_API.Models
{
    public partial class Activo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public string Area { get; set; } = null!;
        public decimal Costo { get; set; }
    }
}
