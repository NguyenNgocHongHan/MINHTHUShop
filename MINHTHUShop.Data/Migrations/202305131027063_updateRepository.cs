namespace MINHTHUShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRepository : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationCustomerRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        Tb_Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.Tb_Customer", t => t.Tb_Customer_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.Tb_Customer_Id);
            
            CreateTable(
                "dbo.Tb_About",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        Fanpage = c.String(maxLength: 250),
                        Address = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                        Status = c.Boolean(),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Tb_Banner",
                c => new
                    {
                        BannerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Image = c.String(nullable: false, maxLength: 250),
                        Link = c.String(maxLength: 250),
                        Sort = c.Int(),
                        Position = c.Int(),
                        CreateDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.BannerID);
            
            CreateTable(
                "dbo.Tb_Brand",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        BrandOrigin = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Tb_Config",
                c => new
                    {
                        ConfigID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ValueNum = c.Int(),
                        ValueString = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ConfigID);
            
            CreateTable(
                "dbo.Tb_Error",
                c => new
                    {
                        ErrorID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ErrorID);
            
            CreateTable(
                "dbo.Tb_FAQCategory",
                c => new
                    {
                        FAQCateID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sort = c.Int(),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.FAQCateID);
            
            CreateTable(
                "dbo.Tb_FAQ",
                c => new
                    {
                        FAQID = c.Int(nullable: false, identity: true),
                        FAQCateID = c.Int(nullable: false),
                        Question = c.String(nullable: false, maxLength: 250),
                        Answer = c.String(nullable: false),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.FAQID)
                .ForeignKey("dbo.Tb_FAQCategory", t => t.FAQCateID, cascadeDelete: true)
                .Index(t => t.FAQCateID);
            
            CreateTable(
                "dbo.Tb_Feedback",
                c => new
                    {
                        FeedbackID = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        Message = c.String(nullable: false),
                        CreateDate = c.DateTime(),
                        IsRead = c.Boolean(),
                    })
                .PrimaryKey(t => t.FeedbackID)
                .ForeignKey("dbo.Tb_Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Tb_Customer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.Boolean(),
                        DateOfBirth = c.DateTime(),
                        Avatar = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        IsLoggedIn = c.Boolean(),
                        LastLogin = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationCustomerClaims",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Tb_Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Tb_Customer", t => t.Tb_Customer_Id)
                .Index(t => t.Tb_Customer_Id);
            
            CreateTable(
                "dbo.ApplicationCustomerLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Tb_Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Tb_Customer", t => t.Tb_Customer_Id)
                .Index(t => t.Tb_Customer_Id);
            
            CreateTable(
                "dbo.Tb_MenuGroup",
                c => new
                    {
                        MenuGroup = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sort = c.Int(),
                    })
                .PrimaryKey(t => t.MenuGroup);
            
            CreateTable(
                "dbo.Tb_Menu",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        MenuGroupID = c.Int(nullable: false),
                        TargetID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Icon = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                        Link = c.String(nullable: false, maxLength: 250),
                        Sort = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.MenuID)
                .ForeignKey("dbo.Tb_MenuGroup", t => t.MenuGroupID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_Target", t => t.TargetID, cascadeDelete: true)
                .Index(t => t.MenuGroupID)
                .Index(t => t.TargetID);
            
            CreateTable(
                "dbo.Tb_Target",
                c => new
                    {
                        TargetID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.TargetID);
            
            CreateTable(
                "dbo.Tb_News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsCateID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 250),
                        Description = c.String(nullable: false),
                        Tag = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.Tb_NewsCategory", t => t.NewsCateID, cascadeDelete: true)
                .Index(t => t.NewsCateID);
            
            CreateTable(
                "dbo.Tb_NewsCategory",
                c => new
                    {
                        NewsCateID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sort = c.Int(),
                        ParentID = c.Int(),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.NewsCateID);
            
            CreateTable(
                "dbo.Tb_OrderDetail",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Tb_Order", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Tb_Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        StaffID = c.Int(nullable: false),
                        OrderStatusID = c.Int(nullable: false),
                        ShippingMethodID = c.Int(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        Total = c.Decimal(precision: 18, scale: 2),
                        CreateDate = c.DateTime(nullable: false),
                        Note = c.String(maxLength: 500),
                        IsCancel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Tb_Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_OrderStatus", t => t.OrderStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_PaymentMethod", t => t.PaymentMethodID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_ShippingMethod", t => t.ShippingMethodID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_Staff", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.StaffID)
                .Index(t => t.OrderStatusID)
                .Index(t => t.ShippingMethodID)
                .Index(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.Tb_OrderStatus",
                c => new
                    {
                        OrderStatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.Tb_PaymentMethod",
                c => new
                    {
                        PaymentMethodID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.Tb_ShippingMethod",
                c => new
                    {
                        ShippingMethodID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShippingMethodID);
            
            CreateTable(
                "dbo.Tb_Staff",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        Address = c.String(nullable: false, maxLength: 250),
                        Gender = c.Boolean(),
                        DateOfBirth = c.DateTime(),
                        Avatar = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        IsLoggedIn = c.Boolean(),
                        LastLogin = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StaffID)
                .ForeignKey("dbo.Tb_RoleStaff", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Tb_RoleStaff",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Tb_Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        CateID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Image = c.String(maxLength: 250),
                        ListImg = c.String(),
                        OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(),
                        Detail = c.String(),
                        Tag = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Tb_Brand", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_ProductCategory", t => t.CateID, cascadeDelete: true)
                .Index(t => t.CateID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Tb_ProductCategory",
                c => new
                    {
                        CateID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sort = c.Int(),
                        ParentID = c.Int(),
                        MetaTitle = c.String(nullable: false, maxLength: 250),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CateID);
            
            CreateTable(
                "dbo.Tb_Page",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                        URL = c.String(nullable: false, maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageID);
            
            CreateTable(
                "dbo.Tb_Payment",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        PaymentDate = c.DateTime(),
                        PaymentAmount = c.Decimal(precision: 18, scale: 2),
                        IsPaid = c.Boolean(),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Tb_Order", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Tb_ProductComment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        Vote = c.Single(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Tb_Customer", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Tb_Shipping",
                c => new
                    {
                        ShippingID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ShippingDate = c.DateTime(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsShipping = c.Boolean(),
                    })
                .PrimaryKey(t => t.ShippingID)
                .ForeignKey("dbo.Tb_Order", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Tb_TagNews",
                c => new
                    {
                        NewsID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.NewsID, t.TagID })
                .ForeignKey("dbo.Tb_News", t => t.NewsID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_Tag", t => t.TagID, cascadeDelete: true)
                .Index(t => t.NewsID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tb_Tag",
                c => new
                    {
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.Tb_TagProduct",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Tb_Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tb_Tag", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_TagProduct", "TagID", "dbo.Tb_Tag");
            DropForeignKey("dbo.Tb_TagProduct", "ProductID", "dbo.Tb_Product");
            DropForeignKey("dbo.Tb_TagNews", "TagID", "dbo.Tb_Tag");
            DropForeignKey("dbo.Tb_TagNews", "NewsID", "dbo.Tb_News");
            DropForeignKey("dbo.Tb_Shipping", "OrderID", "dbo.Tb_Order");
            DropForeignKey("dbo.Tb_ProductComment", "ProductID", "dbo.Tb_Product");
            DropForeignKey("dbo.Tb_ProductComment", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.Tb_Payment", "OrderID", "dbo.Tb_Order");
            DropForeignKey("dbo.Tb_OrderDetail", "ProductID", "dbo.Tb_Product");
            DropForeignKey("dbo.Tb_Product", "CateID", "dbo.Tb_ProductCategory");
            DropForeignKey("dbo.Tb_Product", "BrandID", "dbo.Tb_Brand");
            DropForeignKey("dbo.Tb_OrderDetail", "OrderID", "dbo.Tb_Order");
            DropForeignKey("dbo.Tb_Order", "StaffID", "dbo.Tb_Staff");
            DropForeignKey("dbo.Tb_Staff", "RoleID", "dbo.Tb_RoleStaff");
            DropForeignKey("dbo.Tb_Order", "ShippingMethodID", "dbo.Tb_ShippingMethod");
            DropForeignKey("dbo.Tb_Order", "PaymentMethodID", "dbo.Tb_PaymentMethod");
            DropForeignKey("dbo.Tb_Order", "OrderStatusID", "dbo.Tb_OrderStatus");
            DropForeignKey("dbo.Tb_Order", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.Tb_News", "NewsCateID", "dbo.Tb_NewsCategory");
            DropForeignKey("dbo.Tb_Menu", "TargetID", "dbo.Tb_Target");
            DropForeignKey("dbo.Tb_Menu", "MenuGroupID", "dbo.Tb_MenuGroup");
            DropForeignKey("dbo.Tb_Feedback", "CustomerID", "dbo.Tb_Customer");
            DropForeignKey("dbo.ApplicationCustomerRoles", "Tb_Customer_Id", "dbo.Tb_Customer");
            DropForeignKey("dbo.ApplicationCustomerLogins", "Tb_Customer_Id", "dbo.Tb_Customer");
            DropForeignKey("dbo.ApplicationCustomerClaims", "Tb_Customer_Id", "dbo.Tb_Customer");
            DropForeignKey("dbo.Tb_FAQ", "FAQCateID", "dbo.Tb_FAQCategory");
            DropForeignKey("dbo.ApplicationCustomerRoles", "IdentityRole_Id", "dbo.ApplicationRoles");
            DropIndex("dbo.Tb_TagProduct", new[] { "TagID" });
            DropIndex("dbo.Tb_TagProduct", new[] { "ProductID" });
            DropIndex("dbo.Tb_TagNews", new[] { "TagID" });
            DropIndex("dbo.Tb_TagNews", new[] { "NewsID" });
            DropIndex("dbo.Tb_Shipping", new[] { "OrderID" });
            DropIndex("dbo.Tb_ProductComment", new[] { "CustomerID" });
            DropIndex("dbo.Tb_ProductComment", new[] { "ProductID" });
            DropIndex("dbo.Tb_Payment", new[] { "OrderID" });
            DropIndex("dbo.Tb_Product", new[] { "BrandID" });
            DropIndex("dbo.Tb_Product", new[] { "CateID" });
            DropIndex("dbo.Tb_Staff", new[] { "RoleID" });
            DropIndex("dbo.Tb_Order", new[] { "PaymentMethodID" });
            DropIndex("dbo.Tb_Order", new[] { "ShippingMethodID" });
            DropIndex("dbo.Tb_Order", new[] { "OrderStatusID" });
            DropIndex("dbo.Tb_Order", new[] { "StaffID" });
            DropIndex("dbo.Tb_Order", new[] { "CustomerID" });
            DropIndex("dbo.Tb_OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.Tb_OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.Tb_News", new[] { "NewsCateID" });
            DropIndex("dbo.Tb_Menu", new[] { "TargetID" });
            DropIndex("dbo.Tb_Menu", new[] { "MenuGroupID" });
            DropIndex("dbo.ApplicationCustomerLogins", new[] { "Tb_Customer_Id" });
            DropIndex("dbo.ApplicationCustomerClaims", new[] { "Tb_Customer_Id" });
            DropIndex("dbo.Tb_Feedback", new[] { "CustomerID" });
            DropIndex("dbo.Tb_FAQ", new[] { "FAQCateID" });
            DropIndex("dbo.ApplicationCustomerRoles", new[] { "Tb_Customer_Id" });
            DropIndex("dbo.ApplicationCustomerRoles", new[] { "IdentityRole_Id" });
            DropTable("dbo.Tb_TagProduct");
            DropTable("dbo.Tb_Tag");
            DropTable("dbo.Tb_TagNews");
            DropTable("dbo.Tb_Shipping");
            DropTable("dbo.Tb_ProductComment");
            DropTable("dbo.Tb_Payment");
            DropTable("dbo.Tb_Page");
            DropTable("dbo.Tb_ProductCategory");
            DropTable("dbo.Tb_Product");
            DropTable("dbo.Tb_RoleStaff");
            DropTable("dbo.Tb_Staff");
            DropTable("dbo.Tb_ShippingMethod");
            DropTable("dbo.Tb_PaymentMethod");
            DropTable("dbo.Tb_OrderStatus");
            DropTable("dbo.Tb_Order");
            DropTable("dbo.Tb_OrderDetail");
            DropTable("dbo.Tb_NewsCategory");
            DropTable("dbo.Tb_News");
            DropTable("dbo.Tb_Target");
            DropTable("dbo.Tb_Menu");
            DropTable("dbo.Tb_MenuGroup");
            DropTable("dbo.ApplicationCustomerLogins");
            DropTable("dbo.ApplicationCustomerClaims");
            DropTable("dbo.Tb_Customer");
            DropTable("dbo.Tb_Feedback");
            DropTable("dbo.Tb_FAQ");
            DropTable("dbo.Tb_FAQCategory");
            DropTable("dbo.Tb_Error");
            DropTable("dbo.Tb_Config");
            DropTable("dbo.Tb_Brand");
            DropTable("dbo.Tb_Banner");
            DropTable("dbo.Tb_About");
            DropTable("dbo.ApplicationCustomerRoles");
            DropTable("dbo.ApplicationRoles");
        }
    }
}
