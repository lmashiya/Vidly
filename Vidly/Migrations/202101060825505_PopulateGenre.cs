namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Id, Name) Values (1, 'Action')");
            Sql("Insert Into Genres (Id, Name) Values (2, 'Comedy')");
            Sql("Insert Into Genres (Id, Name) Values (3, 'Horror')");
            Sql("Insert Into Genres (Id, Name) Values (4, 'Romance')");
            Sql("Insert Into Genres (Id, Name) Values (5, 'Thriller')");
            Sql("Insert Into Genres (Id, Name) Values (6, 'Animation')");
            Sql("Insert Into Genres (Id, Name) Values (7, 'Documentary')");
        }
        
        public override void Down()
        {
        }
    }
}
