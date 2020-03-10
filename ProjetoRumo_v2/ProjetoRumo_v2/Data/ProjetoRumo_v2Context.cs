using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoRumo_v2.Models;

namespace ProjetoRumo_v2.Data
{
    public class ProjetoRumo_v2Context : DbContext
    {
        public ProjetoRumo_v2Context (DbContextOptions<ProjetoRumo_v2Context> options)
            : base(options)
        {
        }

        public DbSet<ProjetoRumo_v2.Models.Pedido> Pedido { get; set; }

        public DbSet<ProjetoRumo_v2.Models.Copa> Copa { get; set; }

        public DbSet<ProjetoRumo_v2.Models.Cozinha> Cozinha { get; set; }
    }
}
