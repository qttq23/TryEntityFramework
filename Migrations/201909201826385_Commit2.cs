namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Commit2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articoli", "CostoStandard2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articoli", "CostoStandard2");
        }
    }
}
