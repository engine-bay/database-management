using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineBay.DatabaseManagement.Migrations.MasterDb.PostgresMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataVariableStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identity = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Namespace = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataVariableStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    LogLevel = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityName = table.Column<string>(type: "text", nullable: false),
                    ActionType = table.Column<string>(type: "text", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityId = table.Column<string>(type: "text", nullable: false),
                    Changes = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditEntries_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasicAuthCredentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicAuthCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicAuthCredentials_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workbooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workbooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workbooks_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workbooks_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Blueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    WorkbookId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blueprints_Workbooks_WorkbookId",
                        column: x => x.WorkbookId,
                        principalTable: "Workbooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataTableBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Namespace = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    BlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTableBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTableBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTableBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTableBlueprints_Blueprints_BlueprintId",
                        column: x => x.BlueprintId,
                        principalTable: "Blueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataVariableBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Namespace = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DefaultValue = table.Column<string>(type: "text", nullable: true),
                    BlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataVariableBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataVariableBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataVariableBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataVariableBlueprints_Blueprints_BlueprintId",
                        column: x => x.BlueprintId,
                        principalTable: "Blueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TriggerBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    OutputDataVariableBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    BlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TriggerBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TriggerBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TriggerBlueprints_Blueprints_BlueprintId",
                        column: x => x.BlueprintId,
                        principalTable: "Blueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataTableColumnBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DataTableBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTableColumnBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTableColumnBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTableColumnBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTableColumnBlueprints_DataTableBlueprints_DataTableBlue~",
                        column: x => x.DataTableBlueprintId,
                        principalTable: "DataTableBlueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataTableRowBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataTableBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTableRowBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTableRowBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTableRowBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTableRowBlueprints_DataTableBlueprints_DataTableBluepri~",
                        column: x => x.DataTableBlueprintId,
                        principalTable: "DataTableBlueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OutputDataVariableBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Namespace = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ExpressionBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    TriggerBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputDataVariableBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputDataVariableBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutputDataVariableBlueprints_ApplicationUsers_LastUpdatedBy~",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutputDataVariableBlueprints_TriggerBlueprints_TriggerBluep~",
                        column: x => x.TriggerBlueprintId,
                        principalTable: "TriggerBlueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TriggerExpressionBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Expression = table.Column<string>(type: "text", nullable: false),
                    Objective = table.Column<string>(type: "text", nullable: true),
                    TriggerBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    InputDataVariableBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerExpressionBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TriggerExpressionBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TriggerExpressionBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TriggerExpressionBlueprints_TriggerBlueprints_TriggerBluepr~",
                        column: x => x.TriggerBlueprintId,
                        principalTable: "TriggerBlueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataTableCellBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Namespace = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DataTableRowBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTableCellBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataTableCellBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTableCellBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataTableCellBlueprints_DataTableRowBlueprints_DataTableRow~",
                        column: x => x.DataTableRowBlueprintId,
                        principalTable: "DataTableRowBlueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpressionBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Expression = table.Column<string>(type: "text", nullable: false),
                    Objective = table.Column<string>(type: "text", nullable: true),
                    BlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    OutputDataVariableBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpressionBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpressionBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpressionBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpressionBlueprints_Blueprints_BlueprintId",
                        column: x => x.BlueprintId,
                        principalTable: "Blueprints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpressionBlueprints_OutputDataVariableBlueprints_OutputDat~",
                        column: x => x.OutputDataVariableBlueprintId,
                        principalTable: "OutputDataVariableBlueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InputDataTableBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Namespace = table.Column<string>(type: "text", nullable: false),
                    ExpressionBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputDataTableBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputDataTableBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputDataTableBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputDataTableBlueprints_ExpressionBlueprints_ExpressionBlu~",
                        column: x => x.ExpressionBlueprintId,
                        principalTable: "ExpressionBlueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InputDataVariableBlueprints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Namespace = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ExpressionBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataTableBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    TriggerExpressionBlueprintId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputDataVariableBlueprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputDataVariableBlueprints_ApplicationUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputDataVariableBlueprints_ApplicationUsers_LastUpdatedById",
                        column: x => x.LastUpdatedById,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InputDataVariableBlueprints_DataTableBlueprints_DataTableBl~",
                        column: x => x.DataTableBlueprintId,
                        principalTable: "DataTableBlueprints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputDataVariableBlueprints_ExpressionBlueprints_Expression~",
                        column: x => x.ExpressionBlueprintId,
                        principalTable: "ExpressionBlueprints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputDataVariableBlueprints_TriggerExpressionBlueprints_Tri~",
                        column: x => x.TriggerExpressionBlueprintId,
                        principalTable: "TriggerExpressionBlueprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Username",
                table: "ApplicationUsers",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditEntries_ApplicationUserId",
                table: "AuditEntries",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicAuthCredentials_ApplicationUserId",
                table: "BasicAuthCredentials",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blueprints_CreatedById",
                table: "Blueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Blueprints_LastUpdatedById",
                table: "Blueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Blueprints_Name_WorkbookId",
                table: "Blueprints",
                columns: new[] { "Name", "WorkbookId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blueprints_WorkbookId",
                table: "Blueprints",
                column: "WorkbookId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableBlueprints_BlueprintId",
                table: "DataTableBlueprints",
                column: "BlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableBlueprints_CreatedById",
                table: "DataTableBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableBlueprints_LastUpdatedById",
                table: "DataTableBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableBlueprints_Name_BlueprintId",
                table: "DataTableBlueprints",
                columns: new[] { "Name", "BlueprintId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataTableCellBlueprints_CreatedById",
                table: "DataTableCellBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableCellBlueprints_DataTableRowBlueprintId",
                table: "DataTableCellBlueprints",
                column: "DataTableRowBlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableCellBlueprints_LastUpdatedById",
                table: "DataTableCellBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableColumnBlueprints_CreatedById",
                table: "DataTableColumnBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableColumnBlueprints_DataTableBlueprintId",
                table: "DataTableColumnBlueprints",
                column: "DataTableBlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableColumnBlueprints_LastUpdatedById",
                table: "DataTableColumnBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableColumnBlueprints_Name_DataTableBlueprintId",
                table: "DataTableColumnBlueprints",
                columns: new[] { "Name", "DataTableBlueprintId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataTableRowBlueprints_CreatedById",
                table: "DataTableRowBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableRowBlueprints_DataTableBlueprintId",
                table: "DataTableRowBlueprints",
                column: "DataTableBlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_DataTableRowBlueprints_LastUpdatedById",
                table: "DataTableRowBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataVariableBlueprints_BlueprintId",
                table: "DataVariableBlueprints",
                column: "BlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_DataVariableBlueprints_CreatedById",
                table: "DataVariableBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataVariableBlueprints_LastUpdatedById",
                table: "DataVariableBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataVariableBlueprints_Name_BlueprintId_Namespace",
                table: "DataVariableBlueprints",
                columns: new[] { "Name", "BlueprintId", "Namespace" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataVariableStates_Identity",
                table: "DataVariableStates",
                column: "Identity");

            migrationBuilder.CreateIndex(
                name: "IX_DataVariableStates_Name_Namespace_Type_SessionId_CreatedAt",
                table: "DataVariableStates",
                columns: new[] { "Name", "Namespace", "Type", "SessionId", "CreatedAt" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataVariableStates_Namespace",
                table: "DataVariableStates",
                column: "Namespace");

            migrationBuilder.CreateIndex(
                name: "IX_DataVariableStates_SessionId",
                table: "DataVariableStates",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpressionBlueprints_BlueprintId",
                table: "ExpressionBlueprints",
                column: "BlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpressionBlueprints_CreatedById",
                table: "ExpressionBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExpressionBlueprints_LastUpdatedById",
                table: "ExpressionBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExpressionBlueprints_OutputDataVariableBlueprintId",
                table: "ExpressionBlueprints",
                column: "OutputDataVariableBlueprintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputDataTableBlueprints_CreatedById",
                table: "InputDataTableBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InputDataTableBlueprints_ExpressionBlueprintId",
                table: "InputDataTableBlueprints",
                column: "ExpressionBlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_InputDataTableBlueprints_LastUpdatedById",
                table: "InputDataTableBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InputDataTableBlueprints_Name_Namespace_ExpressionBlueprint~",
                table: "InputDataTableBlueprints",
                columns: new[] { "Name", "Namespace", "ExpressionBlueprintId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputDataVariableBlueprints_CreatedById",
                table: "InputDataVariableBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InputDataVariableBlueprints_DataTableBlueprintId",
                table: "InputDataVariableBlueprints",
                column: "DataTableBlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_InputDataVariableBlueprints_ExpressionBlueprintId",
                table: "InputDataVariableBlueprints",
                column: "ExpressionBlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_InputDataVariableBlueprints_LastUpdatedById",
                table: "InputDataVariableBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InputDataVariableBlueprints_TriggerExpressionBlueprintId",
                table: "InputDataVariableBlueprints",
                column: "TriggerExpressionBlueprintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutputDataVariableBlueprints_CreatedById",
                table: "OutputDataVariableBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OutputDataVariableBlueprints_LastUpdatedById",
                table: "OutputDataVariableBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OutputDataVariableBlueprints_Name_ExpressionBlueprintId_Tri~",
                table: "OutputDataVariableBlueprints",
                columns: new[] { "Name", "ExpressionBlueprintId", "TriggerBlueprintId", "Namespace" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutputDataVariableBlueprints_TriggerBlueprintId",
                table: "OutputDataVariableBlueprints",
                column: "TriggerBlueprintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_LogLevel",
                table: "SessionLogs",
                column: "LogLevel");

            migrationBuilder.CreateIndex(
                name: "IX_SessionLogs_SessionId",
                table: "SessionLogs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerBlueprints_BlueprintId",
                table: "TriggerBlueprints",
                column: "BlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerBlueprints_CreatedById",
                table: "TriggerBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerBlueprints_LastUpdatedById",
                table: "TriggerBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerBlueprints_Name_BlueprintId_OutputDataVariableBluepr~",
                table: "TriggerBlueprints",
                columns: new[] { "Name", "BlueprintId", "OutputDataVariableBlueprintId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TriggerExpressionBlueprints_CreatedById",
                table: "TriggerExpressionBlueprints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerExpressionBlueprints_Expression_TriggerBlueprintId_I~",
                table: "TriggerExpressionBlueprints",
                columns: new[] { "Expression", "TriggerBlueprintId", "InputDataVariableBlueprintId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TriggerExpressionBlueprints_LastUpdatedById",
                table: "TriggerExpressionBlueprints",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerExpressionBlueprints_TriggerBlueprintId",
                table: "TriggerExpressionBlueprints",
                column: "TriggerBlueprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Workbooks_CreatedById",
                table: "Workbooks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Workbooks_LastUpdatedById",
                table: "Workbooks",
                column: "LastUpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditEntries");

            migrationBuilder.DropTable(
                name: "BasicAuthCredentials");

            migrationBuilder.DropTable(
                name: "DataTableCellBlueprints");

            migrationBuilder.DropTable(
                name: "DataTableColumnBlueprints");

            migrationBuilder.DropTable(
                name: "DataVariableBlueprints");

            migrationBuilder.DropTable(
                name: "DataVariableStates");

            migrationBuilder.DropTable(
                name: "InputDataTableBlueprints");

            migrationBuilder.DropTable(
                name: "InputDataVariableBlueprints");

            migrationBuilder.DropTable(
                name: "SessionLogs");

            migrationBuilder.DropTable(
                name: "DataTableRowBlueprints");

            migrationBuilder.DropTable(
                name: "ExpressionBlueprints");

            migrationBuilder.DropTable(
                name: "TriggerExpressionBlueprints");

            migrationBuilder.DropTable(
                name: "DataTableBlueprints");

            migrationBuilder.DropTable(
                name: "OutputDataVariableBlueprints");

            migrationBuilder.DropTable(
                name: "TriggerBlueprints");

            migrationBuilder.DropTable(
                name: "Blueprints");

            migrationBuilder.DropTable(
                name: "Workbooks");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
