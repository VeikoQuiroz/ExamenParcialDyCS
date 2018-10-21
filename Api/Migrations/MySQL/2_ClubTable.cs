using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(4)]
    public class ClubTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2_ClubTable.sql");
        }

        public override void Down()
        {
        }
    }
}
