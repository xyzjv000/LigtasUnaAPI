using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ligtasUnaAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firstaids",
                columns: table => new
                {
                    FaidPR_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaidPR_Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaidPR_Des = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firstaids", x => x.FaidPR_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Type = table.Column<string>(type: "varchar(50)", nullable: true),
                    User_Fname = table.Column<string>(type: "varchar(50)", nullable: true),
                    User_Lname = table.Column<string>(type: "varchar(50)", nullable: true),
                    User_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_ConNum = table.Column<string>(type: "varchar(20)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    Secret = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ogranization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_Long = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_Lat = table.Column<string>(type: "varchar(50)", nullable: true),
                    User_CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    User_UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Cat_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    FaidPR_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Cat_ID);
                    table.ForeignKey(
                        name: "FK_Categories_Firstaids_FaidPR_ID",
                        column: x => x.FaidPR_ID,
                        principalTable: "Firstaids",
                        principalColumn: "FaidPR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    FaidPR_ImgID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaidPR_ImgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaidPR_ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaidPR_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.FaidPR_ImgID);
                    table.ForeignKey(
                        name: "FK_Images_Firstaids_FaidPR_ID",
                        column: x => x.FaidPR_ID,
                        principalTable: "Firstaids",
                        principalColumn: "FaidPR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    FaidPR_VidID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaidPR_VidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaidPR_VidUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaidPR_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.FaidPR_VidID);
                    table.ForeignKey(
                        name: "FK_Videos_Firstaids_FaidPR_ID",
                        column: x => x.FaidPR_ID,
                        principalTable: "Firstaids",
                        principalColumn: "FaidPR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    Bookmark_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bookmark_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    User_ID = table.Column<int>(nullable: true),
                    FaidPR_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.Bookmark_ID);
                    table.ForeignKey(
                        name: "FK_Bookmarks_Firstaids_FaidPR_ID",
                        column: x => x.FaidPR_ID,
                        principalTable: "Firstaids",
                        principalColumn: "FaidPR_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookmarks_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Feed_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feed_Descrp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feed_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    User_ID = table.Column<int>(nullable: true),
                    FaidPR_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Feed_ID);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Firstaids_FaidPR_ID",
                        column: x => x.FaidPR_ID,
                        principalTable: "Firstaids",
                        principalColumn: "FaidPR_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Report_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Report_Subc = table.Column<bool>(type: "BIT", nullable: false),
                    Report_Feedback = table.Column<bool>(type: "BIT", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    User_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Report_ID);
                    table.ForeignKey(
                        name: "FK_Reports_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Sub_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sub_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    User_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Sub_ID);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_FaidPR_ID",
                table: "Bookmarks",
                column: "FaidPR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_User_ID",
                table: "Bookmarks",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FaidPR_ID",
                table: "Categories",
                column: "FaidPR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FaidPR_ID",
                table: "Feedbacks",
                column: "FaidPR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_User_ID",
                table: "Feedbacks",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_FaidPR_ID",
                table: "Images",
                column: "FaidPR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_User_ID",
                table: "Reports",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_User_ID",
                table: "Subscriptions",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_FaidPR_ID",
                table: "Videos",
                column: "FaidPR_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmarks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Firstaids");
        }
    }
}
