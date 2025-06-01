using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Persistence.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.account_id);
                });

            migrationBuilder.CreateTable(
                name: "training_specialization",
                columns: table => new
                {
                    training_specialization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_specialization", x => x.training_specialization_id);
                });

            migrationBuilder.CreateTable(
                name: "partnership",
                columns: table => new
                {
                    partnership_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trainer_account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partnership", x => x.partnership_id);
                    table.ForeignKey(
                        name: "FK_partnership_account_client_account_id",
                        column: x => x.client_account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_partnership_account_trainer_account_id",
                        column: x => x.trainer_account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personal_profile",
                columns: table => new
                {
                    personal_profile_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_profile", x => x.personal_profile_id);
                    table.ForeignKey(
                        name: "FK_personal_profile_account_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "training_exercise",
                columns: table => new
                {
                    training_exercise_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    publicity = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by_account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_exercise", x => x.training_exercise_id);
                    table.ForeignKey(
                        name: "FK_training_exercise_account_created_by_account_id",
                        column: x => x.created_by_account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "training_plan",
                columns: table => new
                {
                    training_plan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_personal_plan = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    client_account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_by_account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_plan", x => x.training_plan_id);
                    table.ForeignKey(
                        name: "FK_training_plan_account_client_account_id",
                        column: x => x.client_account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_training_plan_account_created_by_account_id",
                        column: x => x.created_by_account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "weight_goal",
                columns: table => new
                {
                    weight_goal_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    target_weight = table.Column<decimal>(type: "decimal(5,1)", precision: 5, scale: 1, nullable: false),
                    unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    target_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by_account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weight_goal", x => x.weight_goal_id);
                    table.ForeignKey(
                        name: "FK_weight_goal_account_created_by_account_id",
                        column: x => x.created_by_account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weight_log",
                columns: table => new
                {
                    weight_log_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    weight = table.Column<decimal>(type: "decimal(5,1)", precision: 5, scale: 1, nullable: false),
                    unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by_account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weight_log", x => x.weight_log_id);
                    table.ForeignKey(
                        name: "FK_weight_log_account_created_by_account_id",
                        column: x => x.created_by_account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainer_specialization",
                columns: table => new
                {
                    trainer_specialization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    trainer_account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    training_specialization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainer_specialization", x => x.trainer_specialization_id);
                    table.ForeignKey(
                        name: "FK_trainer_specialization_account_trainer_account_id",
                        column: x => x.trainer_account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trainer_specialization_training_specialization_training_specialization_id",
                        column: x => x.training_specialization_id,
                        principalTable: "training_specialization",
                        principalColumn: "training_specialization_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "exercise_specialization",
                columns: table => new
                {
                    exercise_specialization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    training_specialization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    training_exercise_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_specialization", x => x.exercise_specialization_id);
                    table.ForeignKey(
                        name: "FK_exercise_specialization_training_exercise_training_exercise_id",
                        column: x => x.training_exercise_id,
                        principalTable: "training_exercise",
                        principalColumn: "training_exercise_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_exercise_specialization_training_specialization_training_specialization_id",
                        column: x => x.training_specialization_id,
                        principalTable: "training_specialization",
                        principalColumn: "training_specialization_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "training_plan_goal",
                columns: table => new
                {
                    training_plan_goal_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    target_weight = table.Column<decimal>(type: "decimal(5,1)", precision: 5, scale: 1, nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    training_plan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_plan_goal", x => x.training_plan_goal_id);
                    table.ForeignKey(
                        name: "FK_training_plan_goal_training_plan_training_plan_id",
                        column: x => x.training_plan_id,
                        principalTable: "training_plan",
                        principalColumn: "training_plan_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "training_session",
                columns: table => new
                {
                    training_session_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    training_plan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_session", x => x.training_session_id);
                    table.ForeignKey(
                        name: "FK_training_session_training_plan_training_plan_id",
                        column: x => x.training_plan_id,
                        principalTable: "training_plan",
                        principalColumn: "training_plan_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "training_session_goal",
                columns: table => new
                {
                    training_session_goal_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    target_reps = table.Column<int>(type: "int", nullable: true),
                    target_sets = table.Column<int>(type: "int", nullable: true),
                    target_lifting_weight = table.Column<decimal>(type: "decimal(5,1)", precision: 5, scale: 1, nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    training_session_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    training_exercise_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_session_goal", x => x.training_session_goal_id);
                    table.ForeignKey(
                        name: "FK_training_session_goal_training_exercise_training_exercise_id",
                        column: x => x.training_exercise_id,
                        principalTable: "training_exercise",
                        principalColumn: "training_exercise_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_training_session_goal_training_session_training_session_id",
                        column: x => x.training_session_id,
                        principalTable: "training_session",
                        principalColumn: "training_session_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "training_session_log",
                columns: table => new
                {
                    training_session_log_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reps_completed = table.Column<int>(type: "int", nullable: true),
                    sets_completed = table.Column<int>(type: "int", nullable: true),
                    lifted_weight = table.Column<decimal>(type: "decimal(5,1)", precision: 5, scale: 1, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    training_session_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    training_exercise_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_by_account_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_session_log", x => x.training_session_log_id);
                    table.ForeignKey(
                        name: "FK_training_session_log_account_created_by_account_id",
                        column: x => x.created_by_account_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_training_session_log_training_exercise_training_exercise_id",
                        column: x => x.training_exercise_id,
                        principalTable: "training_exercise",
                        principalColumn: "training_exercise_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_training_session_log_training_session_training_session_id",
                        column: x => x.training_session_id,
                        principalTable: "training_session",
                        principalColumn: "training_session_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_exercise_specialization_training_exercise_id",
                table: "exercise_specialization",
                column: "training_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_specialization_training_specialization_id",
                table: "exercise_specialization",
                column: "training_specialization_id");

            migrationBuilder.CreateIndex(
                name: "IX_partnership_client_account_id",
                table: "partnership",
                column: "client_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_partnership_trainer_account_id",
                table: "partnership",
                column: "trainer_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_profile_account_id",
                table: "personal_profile",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainer_specialization_trainer_account_id",
                table: "trainer_specialization",
                column: "trainer_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_trainer_specialization_training_specialization_id",
                table: "trainer_specialization",
                column: "training_specialization_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_exercise_created_by_account_id",
                table: "training_exercise",
                column: "created_by_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_plan_client_account_id",
                table: "training_plan",
                column: "client_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_plan_created_by_account_id",
                table: "training_plan",
                column: "created_by_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_plan_goal_training_plan_id",
                table: "training_plan_goal",
                column: "training_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_session_training_plan_id",
                table: "training_session",
                column: "training_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_session_goal_training_exercise_id",
                table: "training_session_goal",
                column: "training_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_session_goal_training_session_id",
                table: "training_session_goal",
                column: "training_session_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_session_log_created_by_account_id",
                table: "training_session_log",
                column: "created_by_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_session_log_training_exercise_id",
                table: "training_session_log",
                column: "training_exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_training_session_log_training_session_id",
                table: "training_session_log",
                column: "training_session_id");

            migrationBuilder.CreateIndex(
                name: "IX_weight_goal_created_by_account_id",
                table: "weight_goal",
                column: "created_by_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_weight_log_created_by_account_id",
                table: "weight_log",
                column: "created_by_account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exercise_specialization");

            migrationBuilder.DropTable(
                name: "partnership");

            migrationBuilder.DropTable(
                name: "personal_profile");

            migrationBuilder.DropTable(
                name: "trainer_specialization");

            migrationBuilder.DropTable(
                name: "training_plan_goal");

            migrationBuilder.DropTable(
                name: "training_session_goal");

            migrationBuilder.DropTable(
                name: "training_session_log");

            migrationBuilder.DropTable(
                name: "weight_goal");

            migrationBuilder.DropTable(
                name: "weight_log");

            migrationBuilder.DropTable(
                name: "training_specialization");

            migrationBuilder.DropTable(
                name: "training_exercise");

            migrationBuilder.DropTable(
                name: "training_session");

            migrationBuilder.DropTable(
                name: "training_plan");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
