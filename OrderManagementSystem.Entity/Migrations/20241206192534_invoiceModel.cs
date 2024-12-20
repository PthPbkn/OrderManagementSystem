using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagementSystem.Entity.Migrations
{
    /// <inheritdoc />
    public partial class invoiceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Order_Customer_CustomerId",
            //    table: "Order");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Customer",
            //    table: "Customer");

            //migrationBuilder.DropColumn(
            //    name: "CompanyName",
            //    table: "Customer");

            //migrationBuilder.RenameTable(
            //    name: "Customer",
            //    newName: "tbl_Customer");

            //migrationBuilder.RenameColumn(
            //    name: "ContactTitle",
            //    table: "tbl_Customer",
            //    newName: "Title");

            //migrationBuilder.RenameColumn(
            //    name: "ContactName",
            //    table: "tbl_Customer",
            //    newName: "CustomerName");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_tbl_Customer",
            //    table: "tbl_Customer",
            //    column: "CustomerId");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Suppliers",
            //    columns: table => new
            //    {
            //        SupplierId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Suppliers", x => x.SupplierId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tbl_Products",
            //    columns: table => new
            //    {
            //        ProductId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SupplierId = table.Column<int>(type: "int", nullable: true),
            //        CategoryId = table.Column<int>(type: "int", nullable: true),
            //        QuantityPerUnit = table.Column<int>(type: "int", nullable: true),
            //        UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
            //        UnitsInStock = table.Column<short>(type: "smallint", nullable: true),
            //        UnitsOnOrder = table.Column<short>(type: "smallint", nullable: true),
            //        RecorderLevel = table.Column<short>(type: "smallint", nullable: true),
            //        Discontinued = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbl_Products", x => x.ProductId);
            //        table.ForeignKey(
            //            name: "FK_tbl_Products_Category_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Category",
            //            principalColumn: "CategoryId");
            //        table.ForeignKey(
            //            name: "FK_tbl_Products_tbl_Suppliers_SupplierId",
            //            column: x => x.SupplierId,
            //            principalTable: "tbl_Suppliers",
            //            principalColumn: "SupplierId");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderDetail",
            //    columns: table => new
            //    {
            //        OrderId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductId = table.Column<int>(type: "int", nullable: true),
            //        UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
            //        Quantity = table.Column<short>(type: "smallint", nullable: true),
            //        Discount = table.Column<float>(type: "real", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderDetail", x => x.OrderId);
            //        table.ForeignKey(
            //            name: "FK_OrderDetail_tbl_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "tbl_Products",
            //            principalColumn: "ProductId");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderDetail_ProductId",
            //    table: "OrderDetail",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_Products_CategoryId",
            //    table: "tbl_Products",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_Products_SupplierId",
            //    table: "tbl_Products",
            //    column: "SupplierId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Order_tbl_Customer_CustomerId",
            //    table: "Order",
            //    column: "CustomerId",
            //    principalTable: "tbl_Customer",
            //    principalColumn: "CustomerId");
        }

        ///// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Order_tbl_Customer_CustomerId",
        //        table: "Order");

        //    migrationBuilder.DropTable(
        //        name: "OrderDetail");

        //    migrationBuilder.DropTable(
        //        name: "tbl_Products");

        //    migrationBuilder.DropTable(
        //        name: "Category");

        //    migrationBuilder.DropTable(
        //        name: "tbl_Suppliers");

        //    migrationBuilder.DropPrimaryKey(
        //        name: "PK_tbl_Customer",
        //        table: "tbl_Customer");

        //    migrationBuilder.RenameTable(
        //        name: "tbl_Customer",
        //        newName: "Customer");

        //    migrationBuilder.RenameColumn(
        //        name: "Title",
        //        table: "Customer",
        //        newName: "ContactTitle");

        //    migrationBuilder.RenameColumn(
        //        name: "CustomerName",
        //        table: "Customer",
        //        newName: "ContactName");

        //    migrationBuilder.AddColumn<string>(
        //        name: "CompanyName",
        //        table: "Customer",
        //        type: "nvarchar(max)",
        //        nullable: true);

        //    migrationBuilder.AddPrimaryKey(
        //        name: "PK_Customer",
        //        table: "Customer",
        //        column: "CustomerId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Order_Customer_CustomerId",
        //        table: "Order",
        //        column: "CustomerId",
        //        principalTable: "Customer",
        //        principalColumn: "CustomerId");
        //}
    }
}
