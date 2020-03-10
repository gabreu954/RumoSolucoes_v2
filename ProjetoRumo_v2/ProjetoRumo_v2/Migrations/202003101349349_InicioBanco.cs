namespace ProjetoRumo_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicioBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Copas",
                c => new
                    {
                        CopaId = c.Int(nullable: false, identity: true),
                        Bebida = c.String(),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CopaId);
            
            CreateTable(
                "dbo.Cozinhas",
                c => new
                    {
                        CozinhaId = c.Int(nullable: false, identity: true),
                        Prato = c.String(),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CozinhaId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        Cliente = c.String(),
                        Mesa = c.String(),
                    })
                .PrimaryKey(t => t.PedidoId);
            
            CreateTable(
                "dbo.PedidoCopas",
                c => new
                    {
                        PedidoCopaId = c.Int(nullable: false, identity: true),
                        Copa_CopaId = c.Int(),
                        Pedido_PedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.PedidoCopaId)
                .ForeignKey("dbo.Copas", t => t.Copa_CopaId)
                .ForeignKey("dbo.Pedidoes", t => t.Pedido_PedidoId)
                .Index(t => t.Copa_CopaId)
                .Index(t => t.Pedido_PedidoId);
            
            CreateTable(
                "dbo.PedidoCozinhas",
                c => new
                    {
                        PedidoCozinhaId = c.Int(nullable: false, identity: true),
                        Cozinha_CozinhaId = c.Int(),
                        Pedido_PedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.PedidoCozinhaId)
                .ForeignKey("dbo.Cozinhas", t => t.Cozinha_CozinhaId)
                .ForeignKey("dbo.Pedidoes", t => t.Pedido_PedidoId)
                .Index(t => t.Cozinha_CozinhaId)
                .Index(t => t.Pedido_PedidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoCozinhas", "Pedido_PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.PedidoCozinhas", "Cozinha_CozinhaId", "dbo.Cozinhas");
            DropForeignKey("dbo.PedidoCopas", "Pedido_PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.PedidoCopas", "Copa_CopaId", "dbo.Copas");
            DropIndex("dbo.PedidoCozinhas", new[] { "Pedido_PedidoId" });
            DropIndex("dbo.PedidoCozinhas", new[] { "Cozinha_CozinhaId" });
            DropIndex("dbo.PedidoCopas", new[] { "Pedido_PedidoId" });
            DropIndex("dbo.PedidoCopas", new[] { "Copa_CopaId" });
            DropTable("dbo.PedidoCozinhas");
            DropTable("dbo.PedidoCopas");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Cozinhas");
            DropTable("dbo.Copas");
        }
    }
}
