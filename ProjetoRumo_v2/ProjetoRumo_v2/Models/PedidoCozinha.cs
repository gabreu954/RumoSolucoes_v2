using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRumo_v2.Models
{
    public class PedidoCozinha
    {
        public int PedidoCozinhaId { get; set; }
        public Pedido Pedido { get; set; }
        public Cozinha Cozinha { get; set; }
    }
}
