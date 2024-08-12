namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adedforeign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblBooks", "Authors_AuthorId", c => c.Int());
            CreateIndex("dbo.tblBooks", "Authors_AuthorId");
            AddForeignKey("dbo.tblBooks", "Authors_AuthorId", "dbo.Authors", "AuthorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblBooks", "Authors_AuthorId", "dbo.Authors");
            DropIndex("dbo.tblBooks", new[] { "Authors_AuthorId" });
            DropColumn("dbo.tblBooks", "Authors_AuthorId");
        }
    }
}
