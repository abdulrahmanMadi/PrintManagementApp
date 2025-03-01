namespace PrintManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFileTransferPrintJobTabels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileTransfers",
                c => new
                    {
                        FileTransferId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FilePath = c.String(),
                        TransferredAt = c.DateTime(nullable: false),
                        SenderUserId = c.Int(nullable: false),
                        ReceiverUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileTransferId)
                .ForeignKey("dbo.Users", t => t.ReceiverUserId)
                .ForeignKey("dbo.Users", t => t.SenderUserId)
                .Index(t => t.SenderUserId)
                .Index(t => t.ReceiverUserId);
            
            CreateTable(
                "dbo.PrintJobs",
                c => new
                    {
                        PrintJobId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FilePath = c.String(),
                        Status = c.String(),
                        SubmittedAt = c.DateTime(nullable: false),
                        ProcessedAt = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        PrinterName = c.String(),
                        PrinterLocation = c.String(),
                    })
                .PrimaryKey(t => t.PrintJobId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileTransfers", "SenderUserId", "dbo.Users");
            DropForeignKey("dbo.FileTransfers", "ReceiverUserId", "dbo.Users");
            DropForeignKey("dbo.PrintJobs", "UserId", "dbo.Users");
            DropIndex("dbo.PrintJobs", new[] { "UserId" });
            DropIndex("dbo.FileTransfers", new[] { "ReceiverUserId" });
            DropIndex("dbo.FileTransfers", new[] { "SenderUserId" });
            DropTable("dbo.PrintJobs");
            DropTable("dbo.FileTransfers");
        }
    }
}
