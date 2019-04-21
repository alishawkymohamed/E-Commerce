using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZipCode = table.Column<int>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Governorate = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenderNameAr = table.Column<string>(nullable: true),
                    GenderNameEn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 450, nullable: false),
                    Password = table.Column<string>(maxLength: 450, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false, defaultValue: false),
                    LastLoggedIn = table.Column<DateTimeOffset>(nullable: true),
                    ProfileImage = table.Column<byte[]>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    FullNameEn = table.Column<string>(maxLength: 100, nullable: true),
                    FullNameAr = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    NotificationByMail = table.Column<bool>(nullable: true),
                    NotificationBySMS = table.Column<bool>(nullable: true),
                    DefaultCulture = table.Column<string>(maxLength: 5, nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryNameAr = table.Column<string>(nullable: false),
                    CategoryNameEn = table.Column<string>(nullable: true),
                    CategoryCode = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Localizations",
                columns: table => new
                {
                    LocalizationId = table.Column<int>(nullable: false),
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    ValueAr = table.Column<string>(nullable: false),
                    ValueEn = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizations", x => x.LocalizationId);
                    table.ForeignKey(
                        name: "FK_Localizations_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Localizations_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleNameAr = table.Column<string>(maxLength: 100, nullable: true),
                    RoleNameEn = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessTokenHash = table.Column<string>(nullable: true),
                    AccessTokenExpiresDateTime = table.Column<DateTimeOffset>(nullable: false),
                    RefreshTokenIdHash = table.Column<string>(maxLength: 450, nullable: false),
                    RefreshTokenIdHashSource = table.Column<string>(maxLength: 450, nullable: true),
                    RefreshTokenExpiresDateTime = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubCategoryNameAr = table.Column<string>(nullable: false),
                    SubCategoryNameEn = table.Column<string>(nullable: true),
                    SubCategoryCode = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCategories_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCategories_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCategories_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    LastSelected = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductNameAr = table.Column<string>(nullable: true),
                    ProductNameEn = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Deduction = table.Column<decimal>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false, defaultValue: false),
                    UserId = table.Column<int>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoNameAr = table.Column<string>(nullable: true),
                    PhotoNameEn = table.Column<string>(nullable: true),
                    PhotoName = table.Column<string>(nullable: true),
                    IsMainPhoto = table.Column<bool>(nullable: true),
                    IsRealPhoto = table.Column<bool>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    SpecificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecificationNameAr = table.Column<string>(nullable: true),
                    SpecificationNameEn = table.Column<string>(nullable: true),
                    SpecificationValueAr = table.Column<string>(nullable: true),
                    SpecificationValueEn = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.SpecificationId);
                    table.ForeignKey(
                        name: "FK_Specifications_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specifications_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specifications_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[,]
                {
                    { 1, null, null, "Agree", null, null, "موافق", "Ok" },
                    { 27, null, null, "DeleteConfirmation", null, null, "تأكيد الحذف", "Delete Confirmation" },
                    { 28, null, null, "WantDelete", null, null, "هل أنت متأكد من الحذف ؟", "Do you want to delete this record ?" },
                    { 30, null, null, "DeletedSuccess", null, null, "تم الحذف بنجاح", "Deleted Successfully" },
                    { 31, null, null, "DeletedFail", null, null, "لم يتم الحذف", "Deleted Failed" },
                    { 32, null, null, "Category", null, null, "تصنيف", "Category" },
                    { 33, null, null, "SubCategory", null, null, "تصنيف فرعي", "Sub Category" },
                    { 34, null, null, "SignIn", null, null, "تسجيل دخول", "Sign In" },
                    { 35, null, null, "SignUp", null, null, "إنشاء حساب", "Sign Up" },
                    { 36, null, null, "ForgetPassword", null, null, "نسيت كلمة السر ؟", "Forget Password ?" },
                    { 26, null, null, "Update", null, null, "تعديل", "Update" },
                    { 37, null, null, "SignUpNewAccount", null, null, "إنشاء حساب جديد", "Sign up new account" },
                    { 39, null, null, "SignInWithFacebook", null, null, "دخول بواسطة فيسبوك", "Sign in with Facebook" },
                    { 40, null, null, "SignUpWithFacebook", null, null, "إنشاء حساب بواسطة فيسبوك", "Sign up with Facebook" },
                    { 41, null, null, "SignInWithGmail", null, null, "دخول بواسطة جوجل", "Sign in With Gmail" },
                    { 42, null, null, "SignUpWithGmail", null, null, "إنشاء حساب بواسطة جوجل", "Sign up with Gmail" },
                    { 43, null, null, "FullName", null, null, "الإسم بالكامل", "Full Name" },
                    { 44, null, null, "ConfirmPassword", null, null, "تأكيد كلمة السر", "Confirm Password" },
                    { 45, null, null, "Back", null, null, "عودة", "Back" },
                    { 46, null, null, "WaitApprove", null, null, "تم إرسال طلب إنضمامك للموقع للمدير المسئول و سيتم إخطارك عن الموافقة علي طلبك", "Your request to join our website is sent to admin and you'll be notified after his approval" },
                    { 47, null, null, "Admin", null, null, "مدير النظام", "Admin" },
                    { 38, null, null, "EmailAddress", null, null, "البريد الإلكتروني", "Email Address" },
                    { 24, null, null, "Create", null, null, "إضافة", "Create" },
                    { 25, null, null, "Delete", null, null, "حذف", "Delete" },
                    { 11, null, null, "InvalidCredentials", null, null, "خطأ في إسم المستخدم أو كلمة السر", "Invalid Username Or Password" },
                    { 4, null, null, "Yes", null, null, "نعم", "Yes" },
                    { 5, null, null, "No", null, null, "لا", "No" },
                    { 6, null, null, "Save", null, null, "حفظ", "Save" },
                    { 7, null, null, "SavedSuccess", null, null, "تم الحفظ بنجاح", "Saved Successfully" },
                    { 8, null, null, "ErrorOccured", null, null, "حدث خطأ ما", "Error Occured" },
                    { 9, null, null, "Seller", null, null, "بائع", "Seller" },
                    { 10, null, null, "User", null, null, "مستخدم", "User" },
                    { 23, null, null, "GlobalFilter", null, null, "بحث", "Search" },
                    { 12, null, null, "UserName", null, null, "إسم المستخدم", "Username" },
                    { 13, null, null, "Password", null, null, "كلمة السر", "Password" },
                    { 14, null, null, "Login", null, null, "دخول", "Login" },
                    { 15, null, null, "ChangeLang", null, null, "تغيير اللغة", "Change Language" },
                    { 16, null, null, "AccountIsDisabled", null, null, "الحساب متوقف من قبل الإدارة", "Account is disabled by administration" },
                    { 17, null, null, "NameAr", null, null, "الإسم بالعربي", "Arabic Name" },
                    { 18, null, null, "NameEn", null, null, "الإسم بالإنجليزي", "English Name" },
                    { 19, null, null, "Code", null, null, "الكود", "Code" },
                    { 20, null, null, "Categories", null, null, "التصنيفات", "Categories" },
                    { 21, null, null, "SystemComponents", null, null, "أجزاء الموقع", "System Components" },
                    { 22, null, null, "SubCategories", null, null, "التصنيفات الفرعية", "Sub Categories" },
                    { 3, null, null, "Close", null, null, "إغلاق", "Close" },
                    { 2, null, null, "Reject", null, null, "إلغاء", "Cancel" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "CreatedBy", "CreatedOn", "RoleNameAr", "RoleNameEn", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 2, null, new DateTimeOffset(new DateTime(2019, 4, 22, 1, 30, 52, 518, DateTimeKind.Unspecified).AddTicks(5130), new TimeSpan(0, 2, 0, 0, 0)), "بائع", "Seller", null, null },
                    { 1, null, new DateTimeOffset(new DateTime(2019, 4, 22, 1, 30, 52, 515, DateTimeKind.Unspecified).AddTicks(5848), new TimeSpan(0, 2, 0, 0, 0)), "مدير النظام", "Admin", null, null },
                    { 3, null, new DateTimeOffset(new DateTime(2019, 4, 22, 1, 30, 52, 518, DateTimeKind.Unspecified).AddTicks(5142), new TimeSpan(0, 2, 0, 0, 0)), "مستخدم", "User", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryCode",
                table: "Categories",
                column: "CategoryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryNameAr",
                table: "Categories",
                column: "CategoryNameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryNameEn",
                table: "Categories",
                column: "CategoryNameEn",
                unique: true,
                filter: "[CategoryNameEn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedBy",
                table: "Categories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DeletedBy",
                table: "Categories",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedBy",
                table: "Categories",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_GenderNameAr",
                table: "Genders",
                column: "GenderNameAr",
                unique: true,
                filter: "[GenderNameAr] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_GenderNameEn",
                table: "Genders",
                column: "GenderNameEn",
                unique: true,
                filter: "[GenderNameEn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_CreatedBy",
                table: "Localizations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_Key",
                table: "Localizations",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_UpdatedBy",
                table: "Localizations",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_ValueAr",
                table: "Localizations",
                column: "ValueAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_ValueEn",
                table: "Localizations",
                column: "ValueEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_DeletedBy",
                table: "Photos",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedBy",
                table: "Products",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedBy",
                table: "Products",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpdatedBy",
                table: "Products",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedBy",
                table: "Roles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleNameAr",
                table: "Roles",
                column: "RoleNameAr",
                unique: true,
                filter: "[RoleNameAr] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleNameEn",
                table: "Roles",
                column: "RoleNameEn",
                unique: true,
                filter: "[RoleNameEn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UpdatedBy",
                table: "Roles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_CreatedBy",
                table: "Specifications",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_DeletedBy",
                table: "Specifications",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ProductId",
                table: "Specifications",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_UpdatedBy",
                table: "Specifications",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CreatedBy",
                table: "SubCategories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_DeletedBy",
                table: "SubCategories",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_SubCategoryCode",
                table: "SubCategories",
                column: "SubCategoryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_SubCategoryNameAr",
                table: "SubCategories",
                column: "SubCategoryNameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_SubCategoryNameEn",
                table: "SubCategories",
                column: "SubCategoryNameEn",
                unique: true,
                filter: "[SubCategoryNameEn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_UpdatedBy",
                table: "SubCategories",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreatedBy",
                table: "UserRoles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UpdatedBy",
                table: "UserRoles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedBy",
                table: "Users",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedBy",
                table: "Users",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                table: "UserToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localizations");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
