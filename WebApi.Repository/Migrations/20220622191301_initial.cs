using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ProfilePicture = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActionTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ActionTypes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionTypes_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PictureGroups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PictureImage = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PictureGroups_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PictureGroups_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Statuses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statuses_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAuthentications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserRole = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthentications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAuthentications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VehicleTypes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleTypes_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlateNo = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    VehicleTypeID = table.Column<int>(type: "int4", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeID",
                        column: x => x.VehicleTypeID,
                        principalTable: "VehicleTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleID = table.Column<int>(type: "int4", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PictureGroupID = table.Column<int>(type: "int4", nullable: true),
                    ExpectedTimeToFix = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResponsibleUserID = table.Column<int>(type: "integer", nullable: false),
                    LocationLongitude = table.Column<string>(type: "text", nullable: true),
                    LocationLatitude = table.Column<string>(type: "text", nullable: true),
                    StatusID = table.Column<int>(type: "int4", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Maintenances_PictureGroups_PictureGroupID",
                        column: x => x.PictureGroupID,
                        principalTable: "PictureGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_Users_ResponsibleUserID",
                        column: x => x.ResponsibleUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenances_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaintenanceID = table.Column<int>(type: "int4", nullable: false),
                    ActionTypeID = table.Column<int>(type: "int4", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ModifyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MaintenanceHistories_ActionTypes_ActionTypeID",
                        column: x => x.ActionTypeID,
                        principalTable: "ActionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceHistories_Maintenances_MaintenanceID",
                        column: x => x.MaintenanceID,
                        principalTable: "Maintenances",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceHistories_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceHistories_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "CreateDate", "CreatedBy", "FirstName", "IsDeleted", "LastName", "ModifiedBy", "ModifyDate", "PhoneNumber", "ProfilePicture" },
                values: new object[] { 1, null, new DateTime(2022, 6, 22, 22, 13, 1, 807, DateTimeKind.Local).AddTicks(2506), 1, "admin", false, "admin", 1, new DateTime(2022, 6, 22, 22, 13, 1, 807, DateTimeKind.Local).AddTicks(2521), "0", null });

            migrationBuilder.InsertData(
                table: "UserAuthentications",
                columns: new[] { "ID", "Password", "UserID", "UserName", "UserRole" },
                values: new object[] { 1, "123456", 1, "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_CreatedBy",
                table: "ActionTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActionTypes_ModifiedBy",
                table: "ActionTypes",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceHistories_ActionTypeID",
                table: "MaintenanceHistories",
                column: "ActionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceHistories_CreatedBy",
                table: "MaintenanceHistories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceHistories_MaintenanceID",
                table: "MaintenanceHistories",
                column: "MaintenanceID");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceHistories_ModifiedBy",
                table: "MaintenanceHistories",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_CreatedBy",
                table: "Maintenances",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_ModifiedBy",
                table: "Maintenances",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_PictureGroupID",
                table: "Maintenances",
                column: "PictureGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_ResponsibleUserID",
                table: "Maintenances",
                column: "ResponsibleUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_StatusID",
                table: "Maintenances",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_UserID",
                table: "Maintenances",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_VehicleID",
                table: "Maintenances",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_PictureGroups_CreatedBy",
                table: "PictureGroups",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PictureGroups_ModifiedBy",
                table: "PictureGroups",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_CreatedBy",
                table: "Statuses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_ModifiedBy",
                table: "Statuses",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthentications_UserID",
                table: "UserAuthentications",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedBy",
                table: "Users",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CreatedBy",
                table: "Vehicles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModifiedBy",
                table: "Vehicles",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserID",
                table: "Vehicles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeID",
                table: "Vehicles",
                column: "VehicleTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_CreatedBy",
                table: "VehicleTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_ModifiedBy",
                table: "VehicleTypes",
                column: "ModifiedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceHistories");

            migrationBuilder.DropTable(
                name: "UserAuthentications");

            migrationBuilder.DropTable(
                name: "ActionTypes");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "PictureGroups");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
