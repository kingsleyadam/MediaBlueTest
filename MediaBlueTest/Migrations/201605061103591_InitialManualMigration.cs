namespace MediaBlueTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialManualMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RatedImage", "ImageName", c => c.String(maxLength: 100));
            AlterColumn("dbo.RatedImage", "ImageURL", c => c.String(maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RatedImage", "ImageURL", c => c.String());
            AlterColumn("dbo.RatedImage", "ImageName", c => c.String());
        }
    }
}
