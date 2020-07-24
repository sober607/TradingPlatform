using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingPlatform.Migrations
{
    public partial class FirsMigraio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    Code = table.Column<int>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    RateLastSyncTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    IsService = table.Column<bool>(nullable: false),
                    IsMultiCountryPossible = table.Column<bool>(nullable: false),
                    IsArchive = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    UserId1 = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    UserId1 = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: true),
                    TrackingNumber = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DateTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Books" },
                    { 15, null, "Computers/Tablets & Networking" },
                    { 13, null, "Toy & Hobbies" },
                    { 12, null, "Sports Mem, Cards & Fan Shop" },
                    { 11, null, "Sporting Goods" },
                    { 10, null, "Pet Supplies" },
                    { 9, null, "Motors" },
                    { 14, null, "Antiques" },
                    { 7, null, "Dolls & Bears" },
                    { 6, null, "Crafts" },
                    { 5, null, "Consumer Electronics" },
                    { 4, null, "Collectibles" },
                    { 3, null, "Clothing, Shoes & Accessories" },
                    { 2, null, "Business & Industrial" },
                    { 8, null, "Home & Garden" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CurrencyId", "Name" },
                values: new object[,]
                {
                    { 82, null, "Nigeria" },
                    { 83, null, "Norway" },
                    { 84, null, "Oman" },
                    { 85, null, "Panama" },
                    { 86, null, "Paraguay" },
                    { 91, null, "Portugal" },
                    { 89, null, "Philippines" },
                    { 90, null, "Poland" },
                    { 92, null, "Principality of Monaco" },
                    { 93, null, "Puerto Rico" },
                    { 81, null, "Nicaragua" },
                    { 87, null, "China" },
                    { 80, null, "New Zealand" },
                    { 71, null, "Malaysia" },
                    { 77, null, "Morocco" },
                    { 76, null, "Montenegro" },
                    { 75, null, "Mongolia" },
                    { 74, null, "Mexico" },
                    { 73, null, "Malta" },
                    { 72, null, "Maldives" },
                    { 94, null, "Qatar" },
                    { 70, null, "Macedonia (FYROM)" },
                    { 69, null, "Macao S.A.R." },
                    { 68, null, "Luxembourg" },
                    { 66, null, "Liechtenstein" },
                    { 65, null, "Libya" },
                    { 64, null, "Lebanon" },
                    { 78, null, "Nepal" },
                    { 95, null, "Philippines" },
                    { 102, null, "Serbia and Montenegro (Former)" },
                    { 97, null, "Russia" },
                    { 127, null, "Zimbabwe" },
                    { 126, null, "Yemen" },
                    { 125, null, "Vietnam" },
                    { 124, null, "Uzbekistan" },
                    { 123, null, "Uruguay" },
                    { 121, null, "United Kingdom" },
                    { 119, null, "U.A.E." },
                    { 118, null, "Turkmenistan" },
                    { 116, null, "Tunisia" },
                    { 115, null, "Trinidad and Tobago" },
                    { 114, null, "Thailand" },
                    { 113, null, "Tajikistan" },
                    { 112, null, "Taiwan" },
                    { 111, null, "Syria" },
                    { 110, null, "Switzerland" },
                    { 109, null, "Sweden" },
                    { 108, null, "Sri Lanka" },
                    { 107, null, "Spain" },
                    { 106, null, "South Africa" },
                    { 105, null, "Slovenia" },
                    { 104, null, "Slovakia" },
                    { 103, null, "Singapore" },
                    { 63, null, "Latvia" },
                    { 101, null, "Serbia" },
                    { 100, null, "Senegal" },
                    { 99, null, "Saudi Arabia" },
                    { 98, null, "Rwanda" },
                    { 96, null, "Romania" },
                    { 62, null, "Lao P.D.R." },
                    { 56, null, "Jordan" },
                    { 60, null, "Kuwait" },
                    { 27, null, "Denmark" },
                    { 26, null, "Czech Republic" },
                    { 25, null, "Croatia" },
                    { 24, null, "Costa Rica" },
                    { 23, null, "Colombia" },
                    { 22, null, "Caribbean" },
                    { 21, null, "Canada" },
                    { 20, null, "Cambodia" },
                    { 19, null, "Bulgaria" },
                    { 18, null, "Brunei Darussalam" },
                    { 17, null, "Brazil" },
                    { 16, null, "Bosnia and Herzegovina" },
                    { 15, null, "Bolivia" },
                    { 14, null, "Bolivarian Republic of Venezuela" },
                    { 13, null, "Belize" },
                    { 12, null, "Belgium" },
                    { 11, null, "Belarus" },
                    { 10, null, "Bangladesh" },
                    { 9, null, "Bahrain" },
                    { 8, null, "Azerbaijan" },
                    { 7, null, "Austria" },
                    { 6, null, "Australia" },
                    { 5, null, "Armenia" },
                    { 4, null, "Argentina" },
                    { 3, null, "Algeria" },
                    { 2, null, "Albania" },
                    { 1, null, "Afghanistan" },
                    { 61, null, "Kyrgyzstan" },
                    { 29, null, "Ecuador" },
                    { 28, null, "Dominican Republic" },
                    { 31, null, "El Salvador" },
                    { 59, null, "Korea" },
                    { 58, null, "Kenya" },
                    { 57, null, "Kazakhstan" },
                    { 55, null, "Japan" },
                    { 54, null, "Jamaica" },
                    { 53, null, "Italy" },
                    { 52, null, "Israel" },
                    { 51, null, "Pakistan" },
                    { 50, null, "Ireland" },
                    { 49, null, "Iraq" },
                    { 48, null, "Iran" },
                    { 30, null, "Egypt" },
                    { 46, null, "India" },
                    { 47, null, "Indonesia" },
                    { 44, null, "Hungary" },
                    { 32, null, "Estonia" },
                    { 33, null, "Ethiopia" },
                    { 34, null, "Faroe Islands" },
                    { 45, null, "Iceland" },
                    { 36, null, "France" },
                    { 37, null, "Georgia" },
                    { 35, null, "Finland" },
                    { 39, null, "Greece" },
                    { 40, null, "Greenland" },
                    { 41, null, "Guatemala" },
                    { 42, null, "Honduras" },
                    { 43, null, "Hong Kong" },
                    { 38, null, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "Name", "Rate", "RateLastSyncTime", "ShortName" },
                values: new object[,]
                {
                    { 4, null, "Peruvian Nuevo Sol", 0m, null, "PEN" },
                    { 1, null, "Ukrainian Grivna", 0m, null, "UAH" },
                    { 2, null, "Turkish Lira", 0m, null, "TRY" },
                    { 3, null, "US Dollar", 0m, null, "USD" },
                    { 5, null, "Euro", 0m, null, "EUR" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CurrencyId", "Name" },
                values: new object[,]
                {
                    { 120, 1, "Ukraine" },
                    { 117, 2, "Turkey" },
                    { 122, 3, "United States" },
                    { 88, 4, "Peru" },
                    { 67, 5, "Lithuania" },
                    { 79, 5, "Netherlands" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId1",
                table: "Items",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemId",
                table: "Orders",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId1",
                table: "Orders",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
