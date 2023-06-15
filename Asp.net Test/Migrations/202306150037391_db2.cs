namespace Assets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        AssetId = c.Int(nullable: false, identity: true),
                        AssetName = c.String(),
                        Model = c.Int(nullable: false),
                        VendorName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AssetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Assets");
        }
    }
}
