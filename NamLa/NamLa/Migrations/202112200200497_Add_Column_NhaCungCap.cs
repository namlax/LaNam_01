namespace NamLa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Column_NhaCungCap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Account");
        }
    }
}
