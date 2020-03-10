using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRumo_v2.Models
{
    public class PedidoCopa
    {
        public int PedidoCopaId { get; set; }
        public Pedido Pedido { get; set; }
        public Copa Copa { get; set; }
    }
}
