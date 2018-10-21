using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(1)]
    public class JugadorTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("1_JugadorTable.sql");
        }

        public override void Down()
        {
        }
    }
}
