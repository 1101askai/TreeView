namespace TreeHierarchy.Migrations.DbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTreeNodesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreeNodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TreeNodes");
        }
    }
}
