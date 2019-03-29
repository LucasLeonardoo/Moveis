namespace MoveisCreator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiraMigração : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MoveisCriados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovelId = c.Int(nullable: false),
                        EstiloId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estilos", t => t.EstiloId, cascadeDelete: true)
                .ForeignKey("dbo.Moveis", t => t.MovelId, cascadeDelete: true)
                .Index(t => t.MovelId)
                .Index(t => t.EstiloId);
            
            CreateTable(
                "dbo.Estilos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDoEstilo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moveis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDoMovel = c.String(nullable: false),
                        Estilo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estilos", t => t.Estilo_Id)
                .Index(t => t.Estilo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoveisCriados", "MovelId", "dbo.Moveis");
            DropForeignKey("dbo.Moveis", "Estilo_Id", "dbo.Estilos");
            DropForeignKey("dbo.MoveisCriados", "EstiloId", "dbo.Estilos");
            DropIndex("dbo.Moveis", new[] { "Estilo_Id" });
            DropIndex("dbo.MoveisCriados", new[] { "EstiloId" });
            DropIndex("dbo.MoveisCriados", new[] { "MovelId" });
            DropTable("dbo.Moveis");
            DropTable("dbo.Estilos");
            DropTable("dbo.MoveisCriados");
        }
    }
}
