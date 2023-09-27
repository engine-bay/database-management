using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineBay.DatabaseManagement.Migrations.MasterDb.SqliteMigrations
{
    /// <inheritdoc />
    public partial class ActorEngineColumnEncryption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "SessionLogs",
                newName: "EncryptedMessage");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DataVariableStates",
                newName: "EncryptedValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EncryptedMessage",
                table: "SessionLogs",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "EncryptedValue",
                table: "DataVariableStates",
                newName: "Value");
        }
    }
}
