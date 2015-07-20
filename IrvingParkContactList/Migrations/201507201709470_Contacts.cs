namespace IrvingParkContactList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CityBlocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Street = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        PreferSms = c.Boolean(nullable: false),
                        PreferEmail = c.Boolean(nullable: false),
                        Notes = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Block_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CityBlocks", t => t.Block_Id)
                .Index(t => t.Block_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Block_Id", "dbo.CityBlocks");
            DropIndex("dbo.Contacts", new[] { "Block_Id" });
            DropTable("dbo.Contacts");
            DropTable("dbo.CityBlocks");
        }
    }
}
