namespace Bigschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Followings", new[] { "Follower_Id" });
            DropColumn("dbo.Followings", "FollowerId");
            RenameColumn(table: "dbo.Followings", name: "Follower_Id", newName: "FollowerId");
            DropPrimaryKey("dbo.Followings");
            AlterColumn("dbo.Followings", "FollowerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
            CreateIndex("dbo.Followings", "FollowerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropPrimaryKey("dbo.Followings");
            AlterColumn("dbo.Followings", "FollowerId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "Follower_Id");
            AddColumn("dbo.Followings", "FollowerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Followings", "Follower_Id");
        }
    }
}
