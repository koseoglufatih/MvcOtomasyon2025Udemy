namespace MvcOtomasyon2025Udemy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Sender = c.String(maxLength: 50, unicode: false),
                        Receiver = c.String(maxLength: 50, unicode: false),
                        Subject = c.String(maxLength: 50, unicode: false),
                        Contents = c.String(maxLength: 2000, unicode: false),
                        DateTime = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
