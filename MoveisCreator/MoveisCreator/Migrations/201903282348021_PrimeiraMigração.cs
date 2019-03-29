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
                        CadeiraId = c.Int(nullable: false),
                        Estilo_Id = c.Int(),
                        Movel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estilos", t => t.Estilo_Id)
                .ForeignKey("dbo.Moveis", t => t.Movel_Id)
                .Index(t => t.Estilo_Id)
                .Index(t => t.Movel_Id);
            
            CreateTable(
                "dbo.Estilos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDoEstilo = c.String(),
                        NomeEstilo = c.String(),
                        NomeEstilo1 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moveis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDoMovel = c.String(),
                        NomeDoEstilo = c.String(),
                        Estilo = c.String(),
                        Estilo1 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoveisCriados", "Movel_Id", "dbo.Moveis");
            DropForeignKey("dbo.MoveisCriados", "Estilo_Id", "dbo.Estilos");
            DropIndex("dbo.MoveisCriados", new[] { "Movel_Id" });
            DropIndex("dbo.MoveisCriados", new[] { "Estilo_Id" });
            DropTable("dbo.Moveis");
            DropTable("dbo.Estilos");
            DropTable("dbo.MoveisCriados");
        }
    }
}
