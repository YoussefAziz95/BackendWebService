using Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SD_InsertFile_Address_Organizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insert FileTypes
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[FileType] ON");

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "Id", "Type", "Extentions", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
                values: new object[,]
                {
                    { (int)FileTypeEnum.Video, (int)FileTypeEnum.Video, ".mp4;.avi;.mov", "System", DateTime.UtcNow, true, false, true },
                    { (int)FileTypeEnum.Audio, (int)FileTypeEnum.Audio, ".mp3;.wav;.aac", "System", DateTime.UtcNow, true, false, true },
                    { (int)FileTypeEnum.Document, (int)FileTypeEnum.Document, ".pdf;.docx;.txt", "System", DateTime.UtcNow, true, false, true },
                    { (int)FileTypeEnum.Archive, (int)FileTypeEnum.Archive, ".zip;.rar;.7z", "System", DateTime.UtcNow, true, false, true },
                    { (int)FileTypeEnum.Executable, (int)FileTypeEnum.Executable, ".exe;.msi", "System", DateTime.UtcNow, true, false, true },
                    { (int)FileTypeEnum.Other, (int)FileTypeEnum.Other, ".*", "System", DateTime.UtcNow, true, false, true },
                    { (int)FileTypeEnum.Image, (int)FileTypeEnum.Image, ".png;.jpg;.jpeg;.bmp;.gif", "System", DateTime.UtcNow, true, false, true }
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[FileType] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[FileType] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[FileLog] ON");

            migrationBuilder.InsertData(
                table: "FileLog",
                columns: new[] { "Id", "FullPath", "FileName", "Extention", "FileTypeId", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
                values: new object[,]
                {
                    { 1, "C:\\FDF\\FDFBackupImageSecond.png", "FDFBackupImageSecond", ".png", (int)FileTypeEnum.Image, "System", DateTime.Now, true, false, true },
                    { 2, "C:\\FDF\\FDFBackupImage.jpg", "FDFBackupImage", ".jpg", (int)FileTypeEnum.Image, "System", DateTime.Now, true, false, true }
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[FileLog] OFF");

            // ===== 1. Insert Organizations =====

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Organization] ON");
            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[]
                {"Id","FileId", "Type", "Name", "TaxNo", "Email", "Phone", "FaxNo", "CreatedBy", "CreatedDate", "IsActive","IsDeleted", "IsSystem", "Country", "City", "StreetAddress"},

                values: new object[,]
                {
                    { 1, 2,(int)OrganizationEnum.Organization ,"The Framework", "321456789", "info@domain.net", "321-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Detroit", "123 Motorway Ave" },
                    { 2, 2,(int)OrganizationEnum.Organization ,"AutoParts Global", "321456789", "info@domain.net", "321-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Detroit", "123 Motorway Ave" },
                    { 3, 2,(int)OrganizationEnum.Company ,"Turbo Engines Ltd.", "321456789", "info@domain.net", "321-456-789","321456789",  "System", DateTime.Now, true, false, true,"Germany", "Stuttgart", "45 Engine Blvd" },
                    { 4, 2,(int)OrganizationEnum.Company ,"Elite Brake Systems", "123456789", "support@domain.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"Italy", "Milan", "78 Brake Street" },
                    { 5, 2,(int)OrganizationEnum.Supplier ,"Titan Tires Co.", "123456789", "contac4t@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"Japan", "Osaka", "250 Tire Road" },
                    { 6, 2,(int)OrganizationEnum.Supplier ,"Speedy Lubricants", "123456789", "contact5@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"UAE", "Abu Dhabi", "99 Oil Street" },
                    { 7, 2,(int)OrganizationEnum.Supplier ,"EcoAuto Batteries", "123456789", "contac6t@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"China", "Beijing", "600 Battery Lane" },
                    { 8, 2,(int)OrganizationEnum.Supplier ,"Global Exhaust Solutions", "123456789", "contact7@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"Brazil", "São Paulo", "18 Exhaust Blvd" },
                    { 9, 2,(int)OrganizationEnum.Supplier ,"CarTech Electronics", "123456789", "contact8@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Silicon Valley", "777 Tech Park" },
                    { 10, 2,(int)OrganizationEnum.Supplier ,"Global Electronics", "123456789", "contact9@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Silicon Valley", "777 Tech Park" },
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Organization] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Address] ON");

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "OrganizationId", "FullAddress", "Street", "City", "State", "Zone", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem", "IsAdministration" },
                values: new object[,]
                {
                    { 1,1,"45 Engine Blvd, Stuttgart, Germany Stuttgart Baden-Württemberg Germany", "45 Engine Blvd, Stuttgart, Germany", "Stuttgart", "Baden-Württemberg", "Germany", "System", DateTime.Now, true, false, true , false},
                    { 2,1,"78 Brake Street, Milan, Italy","78 Brake Street", "Milan", "Lombardy", "Italy","System", DateTime.Now, true, false, true , false}
                });

            // Disable IDENTITY_INSERT for Address table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Address] OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
