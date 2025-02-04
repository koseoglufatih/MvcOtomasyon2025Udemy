namespace MvcOtomasyon2025Udemy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                        Password = c.String(maxLength: 30, unicode: false),
                        Authority = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Brand = c.String(),
                        Stock = c.Short(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        ProductImage = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.SalesTransactions",
                c => new
                    {
                        SalesTransactionId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Piece = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductID = c.Int(nullable: false),
                        CurrentID = c.Int(nullable: false),
                        PersonelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesTransactionId)
                .ForeignKey("dbo.Currents", t => t.CurrentID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.PersonelID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CurrentID)
                .Index(t => t.PersonelID);
            
            CreateTable(
                "dbo.Currents",
                c => new
                    {
                        CurrentID = c.Int(nullable: false, identity: true),
                        CurrentName = c.String(maxLength: 30, unicode: false),
                        CurrentSurname = c.String(maxLength: 30, unicode: false),
                        CurrentCity = c.String(maxLength: 13, unicode: false),
                        CurrentMail = c.String(maxLength: 50, unicode: false),
                        CurrentPassword = c.String(maxLength: 20, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CurrentID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        PersonelName = c.String(maxLength: 30, unicode: false),
                        PersonelSurName = c.String(maxLength: 30, unicode: false),
                        EmployeeVisiual = c.String(maxLength: 250, unicode: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 30, unicode: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        productInformation = c.String(),
                    })
                .PrimaryKey(t => t.DetailID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Int(nullable: false, identity: true),
                        Explanation = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpenseID);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceItemsID = c.Int(nullable: false, identity: true),
                        Explanation = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceItemsID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceSerialNumber = c.String(),
                        InvoiceSequenceNumber = c.String(),
                        Date = c.String(),
                        TaxOffice = c.String(),
                        Hour = c.DateTime(nullable: false),
                        Deliverer = c.String(),
                        Recipient = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        ToDoID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ToDoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItems", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.SalesTransactions", "ProductID", "dbo.Products");
            DropForeignKey("dbo.SalesTransactions", "PersonelID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.SalesTransactions", "CurrentID", "dbo.Currents");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceID" });
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            DropIndex("dbo.SalesTransactions", new[] { "PersonelID" });
            DropIndex("dbo.SalesTransactions", new[] { "CurrentID" });
            DropIndex("dbo.SalesTransactions", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.ToDoes");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Expenses");
            DropTable("dbo.Details");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Currents");
            DropTable("dbo.SalesTransactions");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
