using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NormalizedName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    MinLength = table.Column<int>(type: "integer", nullable: false),
                    MaxLength = table.Column<int>(type: "integer", nullable: false),
                    IsNullable = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultValue = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContactNo = table.Column<string>(type: "text", nullable: false),
                    AltContactNo = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RawDetails = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CustomName = table.Column<string>(type: "text", nullable: true),
                    MinLength = table.Column<int>(type: "integer", nullable: false),
                    MaxLength = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    IsCreatable = table.Column<bool>(type: "boolean", nullable: false),
                    IsEditable = table.Column<bool>(type: "boolean", nullable: false),
                    IsFilterable = table.Column<bool>(type: "boolean", nullable: false),
                    IsListed = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantFields_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadDynamics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantFieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    GroupKey = table.Column<string>(type: "text", nullable: true),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadDynamics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadDynamics_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadDynamics_TenantFields_TenantFieldId",
                        column: x => x.TenantFieldId,
                        principalTable: "TenantFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadDynamics_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadAutditHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    FieldName = table.Column<string>(type: "text", nullable: false),
                    TenantFieldId = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadDynamicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    GroupKey = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAutditHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadAutditHistories_LeadDynamics_LeadDynamicId",
                        column: x => x.LeadDynamicId,
                        principalTable: "LeadDynamics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadAutditHistories_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadAutditHistories_TenantFields_TenantFieldId",
                        column: x => x.TenantFieldId,
                        principalTable: "TenantFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadAutditHistories_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadHistoryVisibilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadAuditHistoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadHistoryVisibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadHistoryVisibilities_LeadAutditHistories_LeadAuditHistor~",
                        column: x => x.LeadAuditHistoryId,
                        principalTable: "LeadAutditHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadHistoryVisibilities_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutditHistories_LeadDynamicId",
                table: "LeadAutditHistories",
                column: "LeadDynamicId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutditHistories_LeadId",
                table: "LeadAutditHistories",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutditHistories_TenantFieldId",
                table: "LeadAutditHistories",
                column: "TenantFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAutditHistories_TenantId",
                table: "LeadAutditHistories",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadDynamics_LeadId",
                table: "LeadDynamics",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadDynamics_TenantFieldId",
                table: "LeadDynamics",
                column: "TenantFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadDynamics_TenantId",
                table: "LeadDynamics",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadHistoryVisibilities_LeadAuditHistoryId",
                table: "LeadHistoryVisibilities",
                column: "LeadAuditHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadHistoryVisibilities_TenantId",
                table: "LeadHistoryVisibilities",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_TenantId",
                table: "Leads",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantFields_FieldId",
                table: "TenantFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantFields_TenantId",
                table: "TenantFields",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeadHistoryVisibilities");

            migrationBuilder.DropTable(
                name: "LeadAutditHistories");

            migrationBuilder.DropTable(
                name: "LeadDynamics");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "TenantFields");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
