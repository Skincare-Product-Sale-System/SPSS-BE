using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class AddRowVersionToProductItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add RowVersion column to ProductItems table for Optimistic Locking
            // Using SQL to add rowversion column (SQL Server automatically manages this type)
            migrationBuilder.Sql(@"
                ALTER TABLE ProductItems 
                ADD RowVersion rowversion;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove RowVersion column from ProductItems table
            migrationBuilder.Sql(@"
                ALTER TABLE ProductItems 
                DROP COLUMN RowVersion;
            ");
        }
    }
}
