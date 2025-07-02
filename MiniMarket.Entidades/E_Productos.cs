using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMarket.Entidades
{
    public class E_Productos
    {
        public int Codigo_pr { get; set; }
        public string Descripcion_pr { get; set; }
        public int Codigo_ma { get; set; }
        public int Codigo_um { get; set; }
        public int Codigo_ca { get; set; }
        public decimal Stock_min { get; set; }
        public decimal Stock_max { get; set; }


    }
}
