using Microsoft.EntityFrameworkCore.Migrations;

namespace ParentContactWeb.Migrations
{
    public partial class addstoredprocedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string procedure1 = @"CREATE DEFINER = 'root'@'localhost'
                    PROCEDURE sp_follwupneeded ()
                    BEGIN
                      SELECT
                        parent.FirstName,
                        parent.FamilyName,
                        contact.ContactReason,
                        contact.ContactDate,
                        contact.ContactID,
                        contact.FollowUpNeeded
                      FROM contact
                        INNER JOIN parent
                          ON contact.ParentID = parent.parentID
                      WHERE contact.FollowUpNeeded = TRUE
                      ORDER BY contact.ContactDate DESC
                      LIMIT 10;
                    END";
            migrationBuilder.Sql(procedure1);



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure1 = @"DROP PROCEDURE IF EXISTS sp_follwupneeded";
            migrationBuilder.Sql(procedure1);
        }
    }
}
