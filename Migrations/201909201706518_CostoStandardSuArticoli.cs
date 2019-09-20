namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CostoStandardSuArticoli : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articoli",
                c => new
                    {
                        IdArticolo = c.Int(nullable: false, identity: true),
                        CodArt = c.String(nullable: false, maxLength: 25),
                        DesArt = c.String(nullable: false, maxLength: 50),
                        CodFamiglia = c.String(nullable: false, maxLength: 6),
                        CostoStandard = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdArticolo)
                .ForeignKey("dbo.Famiglie", t => t.CodFamiglia)
                .Index(t => t.CodFamiglia);
            
            CreateTable(
                "dbo.Famiglie",
                c => new
                    {
                        CodFamiglia = c.String(nullable: false, maxLength: 6),
                        DesFamiglia = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CodFamiglia);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articoli", "CodFamiglia", "dbo.Famiglie");
            DropIndex("dbo.Articoli", new[] { "CodFamiglia" });
            DropTable("dbo.Famiglie");
            DropTable("dbo.Articoli");
        }
    }
}
