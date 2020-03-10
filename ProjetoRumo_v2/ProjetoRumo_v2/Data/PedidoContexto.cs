using ProjetoRumo_v2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRumo_v2.Data
{
    public class PedidoContexto : DbContext
    {
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Copa> Copa { get; set; } 
        public DbSet<Cozinha> Cozinha { get; set; }
        public DbSet<PedidoCopa> PedidoCopa { get; set; }
        public DbSet<PedidoCozinha> PedidoCozinha { get; set; }

    }
}
