namespace TheMachineCafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBoisson : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Boissons(nom) Values ('The a la menthe')");
            Sql("Insert INTO Boissons(nom) Values ('The citron')");
            Sql("Insert INTO Boissons(nom) Values ('Cafe')");
            Sql("Insert INTO Boissons(nom) Values ('Chocolat')");
        }
        
        public override void Down()
        {
        }
    }
}
