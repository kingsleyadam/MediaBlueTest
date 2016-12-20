namespace MediaBlueTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRatedImageToImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Scale", "RatedImage_RatedImageId", "dbo.RatedImage");
            DropForeignKey("dbo.SessionSubmitScale", "RatedImageId", "dbo.RatedImage");
            DropIndex("dbo.Scale", new[] { "RatedImage_RatedImageId" });
            DropIndex("dbo.SessionSubmitScale", new[] { "RatedImageId" });
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImageURL = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.ImageId);
            
            AddColumn("dbo.Scale", "Image_ImageId", c => c.Int());
            AddColumn("dbo.SessionSubmitScale", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Scale", "Image_ImageId");
            CreateIndex("dbo.SessionSubmitScale", "ImageId");
            AddForeignKey("dbo.Scale", "Image_ImageId", "dbo.Image", "ImageId");
            AddForeignKey("dbo.SessionSubmitScale", "ImageId", "dbo.Image", "ImageId", cascadeDelete: true);
            DropColumn("dbo.Scale", "RatedImage_RatedImageId");
            DropColumn("dbo.SessionSubmitScale", "RatedImageId");
            DropTable("dbo.RatedImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RatedImage",
                c => new
                    {
                        RatedImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImageURL = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.RatedImageId);
            
            AddColumn("dbo.SessionSubmitScale", "RatedImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Scale", "RatedImage_RatedImageId", c => c.Int());
            DropForeignKey("dbo.SessionSubmitScale", "ImageId", "dbo.Image");
            DropForeignKey("dbo.Scale", "Image_ImageId", "dbo.Image");
            DropIndex("dbo.SessionSubmitScale", new[] { "ImageId" });
            DropIndex("dbo.Scale", new[] { "Image_ImageId" });
            DropColumn("dbo.SessionSubmitScale", "ImageId");
            DropColumn("dbo.Scale", "Image_ImageId");
            DropTable("dbo.Image");
            CreateIndex("dbo.SessionSubmitScale", "RatedImageId");
            CreateIndex("dbo.Scale", "RatedImage_RatedImageId");
            AddForeignKey("dbo.SessionSubmitScale", "RatedImageId", "dbo.RatedImage", "RatedImageId", cascadeDelete: true);
            AddForeignKey("dbo.Scale", "RatedImage_RatedImageId", "dbo.RatedImage", "RatedImageId");
        }
    }
}
