﻿// <auto-generated />
using System;
using DbContexts.DatabaseExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbContexts.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20190206173550_FieldsRequired")]
    partial class FieldsRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.DbModels.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("District");

                    b.Property<string>("Governorate");

                    b.Property<string>("Street");

                    b.Property<int?>("ZipCode");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Models.DbModels.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryCode")
                        .IsRequired();

                    b.Property<string>("CategoryNameAr")
                        .IsRequired();

                    b.Property<string>("CategoryNameEn");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTimeOffset?>("CreatedOn");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedOn");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedOn");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryCode")
                        .IsUnique();

                    b.HasIndex("CategoryNameAr")
                        .IsUnique();

                    b.HasIndex("CategoryNameEn")
                        .IsUnique()
                        .HasFilter("[CategoryNameEn] IS NOT NULL");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Models.DbModels.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderNameAr");

                    b.Property<string>("GenderNameEn");

                    b.HasKey("GenderId");

                    b.HasIndex("GenderNameAr")
                        .IsUnique()
                        .HasFilter("[GenderNameAr] IS NOT NULL");

                    b.HasIndex("GenderNameEn")
                        .IsUnique()
                        .HasFilter("[GenderNameEn] IS NOT NULL");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Models.DbModels.Localization", b =>
                {
                    b.Property<int>("LocalizationId");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTimeOffset?>("CreatedOn");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedOn");

                    b.Property<string>("ValueAr")
                        .IsRequired();

                    b.Property<string>("ValueEn")
                        .IsRequired();

                    b.HasKey("LocalizationId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("ValueAr")
                        .IsUnique();

                    b.HasIndex("ValueEn")
                        .IsUnique();

                    b.ToTable("Localizations");

                    b.HasData(
                        new
                        {
                            LocalizationId = 11,
                            Key = "InvalidCredentials",
                            ValueAr = "خطأ في إسم المستخدم أو كلمة المرور",
                            ValueEn = "Invalid Username Or Password"
                        },
                        new
                        {
                            LocalizationId = 12,
                            Key = "UserName",
                            ValueAr = "إسم المستخدم",
                            ValueEn = "Username"
                        },
                        new
                        {
                            LocalizationId = 13,
                            Key = "Password",
                            ValueAr = "كلمة المرور",
                            ValueEn = "Password"
                        },
                        new
                        {
                            LocalizationId = 14,
                            Key = "Login",
                            ValueAr = "دخول",
                            ValueEn = "Login"
                        },
                        new
                        {
                            LocalizationId = 15,
                            Key = "ChangeLang",
                            ValueAr = "تغيير اللغة",
                            ValueEn = "Change Language"
                        },
                        new
                        {
                            LocalizationId = 16,
                            Key = "AccountIsDisabled",
                            ValueAr = "الحساب متوقف من قبل الإدارة",
                            ValueEn = "Account is disabled by administration"
                        },
                        new
                        {
                            LocalizationId = 17,
                            Key = "CategoryNameAr",
                            ValueAr = "الإسم التصنيف بالعربي",
                            ValueEn = "Category Arabic Name"
                        },
                        new
                        {
                            LocalizationId = 18,
                            Key = "CategoryNameEn",
                            ValueAr = "الإسم التصنيف بالإنجليزي",
                            ValueEn = "Category English Name"
                        },
                        new
                        {
                            LocalizationId = 19,
                            Key = "CategoryCode",
                            ValueAr = "كود التصنيف",
                            ValueEn = "Category Code"
                        },
                        new
                        {
                            LocalizationId = 20,
                            Key = "Categories",
                            ValueAr = "التصنيفات",
                            ValueEn = "Categories"
                        },
                        new
                        {
                            LocalizationId = 21,
                            Key = "SystemComponents",
                            ValueAr = "أجزاء الموقع",
                            ValueEn = "System Components"
                        },
                        new
                        {
                            LocalizationId = 22,
                            Key = "SubCategories",
                            ValueAr = "التصنيفات الفرعية",
                            ValueEn = "Sub Categories"
                        });
                });

            modelBuilder.Entity("Models.DbModels.Photo", b =>
                {
                    b.Property<long>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedOn");

                    b.Property<bool?>("IsMainPhoto");

                    b.Property<bool?>("IsRealPhoto");

                    b.Property<string>("PhotoName");

                    b.Property<string>("PhotoNameAr");

                    b.Property<string>("PhotoNameEn");

                    b.Property<long?>("ProductId");

                    b.HasKey("PhotoId");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ProductId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Models.DbModels.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(50);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTimeOffset?>("CreatedOn");

                    b.Property<decimal>("Deduction");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedOn");

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductNameAr");

                    b.Property<string>("ProductNameEn");

                    b.Property<int>("SubCategoryId");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedOn");

                    b.Property<int?>("UserId");

                    b.HasKey("ProductId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Models.DbModels.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTimeOffset?>("CreatedOn");

                    b.Property<string>("RoleNameAr")
                        .HasMaxLength(100);

                    b.Property<string>("RoleNameEn")
                        .HasMaxLength(100);

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedOn");

                    b.HasKey("RoleId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("RoleNameAr")
                        .IsUnique()
                        .HasFilter("[RoleNameAr] IS NOT NULL");

                    b.HasIndex("RoleNameEn")
                        .IsUnique()
                        .HasFilter("[RoleNameEn] IS NOT NULL");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            CreatedOn = new DateTimeOffset(new DateTime(2019, 2, 6, 19, 35, 49, 309, DateTimeKind.Unspecified).AddTicks(3972), new TimeSpan(0, 2, 0, 0, 0)),
                            RoleNameAr = "مدير النظام",
                            RoleNameEn = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            CreatedOn = new DateTimeOffset(new DateTime(2019, 2, 6, 19, 35, 49, 311, DateTimeKind.Unspecified).AddTicks(4853), new TimeSpan(0, 2, 0, 0, 0)),
                            RoleNameAr = "بائع",
                            RoleNameEn = "Seller"
                        },
                        new
                        {
                            RoleId = 3,
                            CreatedOn = new DateTimeOffset(new DateTime(2019, 2, 6, 19, 35, 49, 311, DateTimeKind.Unspecified).AddTicks(4876), new TimeSpan(0, 2, 0, 0, 0)),
                            RoleNameAr = "مستخدم",
                            RoleNameEn = "User"
                        });
                });

            modelBuilder.Entity("Models.DbModels.Specification", b =>
                {
                    b.Property<int>("SpecificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTimeOffset?>("CreatedOn");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedOn");

                    b.Property<long?>("ProductId");

                    b.Property<string>("SpecificationNameAr");

                    b.Property<string>("SpecificationNameEn");

                    b.Property<string>("SpecificationValueAr");

                    b.Property<string>("SpecificationValueEn");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedOn");

                    b.HasKey("SpecificationId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ProductId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("Models.DbModels.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTimeOffset?>("CreatedOn");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedOn");

                    b.Property<string>("SubCategoryCode")
                        .IsRequired();

                    b.Property<string>("SubCategoryNameAr")
                        .IsRequired();

                    b.Property<string>("SubCategoryNameEn");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedOn");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("SubCategoryCode")
                        .IsUnique();

                    b.HasIndex("SubCategoryNameAr")
                        .IsUnique();

                    b.HasIndex("SubCategoryNameEn")
                        .IsUnique()
                        .HasFilter("[SubCategoryNameEn] IS NOT NULL");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Models.DbModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTimeOffset?>("CreatedOn");

                    b.Property<string>("DefaultCulture")
                        .HasMaxLength(5);

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTimeOffset?>("DeletedOn");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Enabled");

                    b.Property<DateTimeOffset?>("EnabledUntil");

                    b.Property<string>("FullNameAr")
                        .HasMaxLength(100);

                    b.Property<string>("FullNameEn")
                        .HasMaxLength(100);

                    b.Property<int?>("GenderId");

                    b.Property<DateTimeOffset?>("LastLoggedIn");

                    b.Property<bool?>("NotificationByMail");

                    b.Property<bool?>("NotificationBySMS");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50);

                    b.Property<byte[]>("ProfileImage");

                    b.Property<string>("SerialNumber");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedOn");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("UserId");

                    b.HasIndex("AddressId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GenderId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.DbModels.UserRole", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTimeOffset?>("CreatedOn");

                    b.Property<DateTimeOffset?>("EnabledSince");

                    b.Property<DateTimeOffset?>("EnabledUntil");

                    b.Property<bool?>("LastSelected");

                    b.Property<string>("Notes");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTimeOffset?>("UpdatedOn");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Models.DbModels.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("AccessTokenExpiresDateTime");

                    b.Property<string>("AccessTokenHash");

                    b.Property<DateTimeOffset>("RefreshTokenExpiresDateTime");

                    b.Property<string>("RefreshTokenIdHash")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("RefreshTokenIdHashSource")
                        .HasMaxLength(450);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Models.DbModels.Category", b =>
                {
                    b.HasOne("Models.DbModels.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.DbModels.Localization", b =>
                {
                    b.HasOne("Models.DbModels.User", "CreatedByUser")
                        .WithMany("LocalizationCreatedUser")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "UpdatedByUser")
                        .WithMany("LocalizationUpdatedUser")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.DbModels.Photo", b =>
                {
                    b.HasOne("Models.DbModels.User", "DeletedByUser")
                        .WithMany("PhotoDeletedUser")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.Product", "Product")
                        .WithMany("Photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.DbModels.Product", b =>
                {
                    b.HasOne("Models.DbModels.User", "CreatedByUser")
                        .WithMany("ProductCreatedUser")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "DeletedByUser")
                        .WithMany("ProductDeletedUser")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "UpdatedByUser")
                        .WithMany("ProductUpdatedUser")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.DbModels.Role", b =>
                {
                    b.HasOne("Models.DbModels.User", "CreatedByUser")
                        .WithMany("RoleCreatedUser")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "UpdatedByUser")
                        .WithMany("RoleUpdatedUser")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.DbModels.Specification", b =>
                {
                    b.HasOne("Models.DbModels.User", "CreatedByUser")
                        .WithMany("SpecificationCreatedUser")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "DeletedByUser")
                        .WithMany("SpecificationDeletedUser")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.Product", "Product")
                        .WithMany("Specifications")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "UpdatedByUser")
                        .WithMany("SpecificationUpdatedUser")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.DbModels.SubCategory", b =>
                {
                    b.HasOne("Models.DbModels.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.DbModels.User", b =>
                {
                    b.HasOne("Models.DbModels.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "CreatedByUser")
                        .WithMany("UserCreatedUser")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "DeletedByUser")
                        .WithMany("UserDeletedUser")
                        .HasForeignKey("DeletedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "UpdatedByUser")
                        .WithMany("UserUpdatedUser")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.DbModels.UserRole", b =>
                {
                    b.HasOne("Models.DbModels.User", "CreatedByUser")
                        .WithMany("UserRoleCreatedUser")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "UpdatedByUser")
                        .WithMany("UserRoleUpdatedUser")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Models.DbModels.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Models.DbModels.UserToken", b =>
                {
                    b.HasOne("Models.DbModels.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
