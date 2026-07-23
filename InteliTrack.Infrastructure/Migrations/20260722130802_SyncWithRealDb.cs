using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InteliTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SyncWithRealDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Stores_StoreId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Stores_StoreId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelves_Sections_SectionId",
                table: "Shelves");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovements_Employees_EmployeeId",
                table: "StockMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovements_Products_ProductId",
                table: "StockMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovements_Stores_StoreId",
                table: "StockMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Shelves_ShelfId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferItems_Products_ProductId",
                table: "TransferItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferItems_Transfers_TransferId",
                table: "TransferItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Stores_DestinationStoreId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Stores_SourceStoreId",
                table: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransferItems",
                table: "TransferItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockMovements",
                table: "StockMovements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shelves",
                table: "Shelves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Transfers",
                newName: "transfers");

            migrationBuilder.RenameTable(
                name: "TransferItems",
                newName: "transferitems");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "suppliers");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "stores");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "stocks");

            migrationBuilder.RenameTable(
                name: "StockMovements",
                newName: "stockmovements");

            migrationBuilder.RenameTable(
                name: "Shelves",
                newName: "shelves");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "sections");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "transfers",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "SourceStoreId",
                table: "transfers",
                newName: "sourcestoreid");

            migrationBuilder.RenameColumn(
                name: "DestinationStoreId",
                table: "transfers",
                newName: "destinationstoreid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "transfers",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "transfers",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_SourceStoreId",
                table: "transfers",
                newName: "ix_transfers_sourcestoreid");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_DestinationStoreId",
                table: "transfers",
                newName: "ix_transfers_destinationstoreid");

            migrationBuilder.RenameColumn(
                name: "TransferId",
                table: "transferitems",
                newName: "transferid");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "transferitems",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "transferitems",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "transferitems",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_TransferItems_TransferId",
                table: "transferitems",
                newName: "ix_transferitems_transferid");

            migrationBuilder.RenameIndex(
                name: "IX_TransferItems_ProductId",
                table: "transferitems",
                newName: "ix_transferitems_productid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "suppliers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "suppliers",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "suppliers",
                newName: "contactemail");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "suppliers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "stores",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "stores",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "stores",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "stores",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ShelfId",
                table: "stocks",
                newName: "shelfid");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "stocks",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "stocks",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "stocks",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "stocks",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_ShelfId",
                table: "stocks",
                newName: "ix_stocks_shelfid");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_ProductId",
                table: "stocks",
                newName: "ix_stocks_productid");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "stockmovements",
                newName: "storeid");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "stockmovements",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "stockmovements",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "MovementType",
                table: "stockmovements",
                newName: "movementtype");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "stockmovements",
                newName: "employeeid");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "stockmovements",
                newName: "createdat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "stockmovements",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovements_StoreId",
                table: "stockmovements",
                newName: "ix_stockmovements_storeid");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovements_ProductId",
                table: "stockmovements",
                newName: "ix_stockmovements_productid");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovements_EmployeeId",
                table: "stockmovements",
                newName: "ix_stockmovements_employeeid");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "shelves",
                newName: "sectionid");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "shelves",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "shelves",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "shelves",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "shelves",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Shelves_SectionId",
                table: "shelves",
                newName: "ix_shelves_sectionid");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "sections",
                newName: "storeid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "sections",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "sections",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "sections",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_StoreId",
                table: "sections",
                newName: "ix_sections_storeid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "roles",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "products",
                newName: "supplierid");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MinimumStockLevel",
                table: "products",
                newName: "minimumstocklevel");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "products",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "products",
                newName: "categoryid");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "products",
                newName: "barcode");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SupplierId",
                table: "products",
                newName: "ix_products_supplierid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "products",
                newName: "ix_products_categoryid");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "employees",
                newName: "storeid");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "employees",
                newName: "roleid");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "employees",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "employees",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "employees",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employees",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_StoreId",
                table: "employees",
                newName: "ix_employees_storeid");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleId",
                table: "employees",
                newName: "ix_employees_roleid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "categories",
                newName: "isactive");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                table: "transfers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "completedat",
                table: "transfers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "movementtype",
                table: "stockmovements",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "reason",
                table: "stockmovements",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_transfers",
                table: "transfers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transferitems",
                table: "transferitems",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_suppliers",
                table: "suppliers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stores",
                table: "stores",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stocks",
                table: "stocks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stockmovements",
                table: "stockmovements",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shelves",
                table: "shelves",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sections",
                table: "sections",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employees_roles_roleid",
                table: "employees",
                column: "roleid",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_employees_stores_storeid",
                table: "employees",
                column: "storeid",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_categoryid",
                table: "products",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_suppliers_supplierid",
                table: "products",
                column: "supplierid",
                principalTable: "suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sections_stores_storeid",
                table: "sections",
                column: "storeid",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_shelves_sections_sectionid",
                table: "shelves",
                column: "sectionid",
                principalTable: "sections",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stockmovements_employees_employeeid",
                table: "stockmovements",
                column: "employeeid",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stockmovements_products_productid",
                table: "stockmovements",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stockmovements_stores_storeid",
                table: "stockmovements",
                column: "storeid",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stocks_products_productid",
                table: "stocks",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stocks_shelves_shelfid",
                table: "stocks",
                column: "shelfid",
                principalTable: "shelves",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_transferitems_products_productid",
                table: "transferitems",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_transferitems_transfers_transferid",
                table: "transferitems",
                column: "transferid",
                principalTable: "transfers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_transfers_stores_destinationstoreid",
                table: "transfers",
                column: "destinationstoreid",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_transfers_stores_sourcestoreid",
                table: "transfers",
                column: "sourcestoreid",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_roles_roleid",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "fk_employees_stores_storeid",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_categoryid",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "fk_products_suppliers_supplierid",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "fk_sections_stores_storeid",
                table: "sections");

            migrationBuilder.DropForeignKey(
                name: "fk_shelves_sections_sectionid",
                table: "shelves");

            migrationBuilder.DropForeignKey(
                name: "fk_stockmovements_employees_employeeid",
                table: "stockmovements");

            migrationBuilder.DropForeignKey(
                name: "fk_stockmovements_products_productid",
                table: "stockmovements");

            migrationBuilder.DropForeignKey(
                name: "fk_stockmovements_stores_storeid",
                table: "stockmovements");

            migrationBuilder.DropForeignKey(
                name: "fk_stocks_products_productid",
                table: "stocks");

            migrationBuilder.DropForeignKey(
                name: "fk_stocks_shelves_shelfid",
                table: "stocks");

            migrationBuilder.DropForeignKey(
                name: "fk_transferitems_products_productid",
                table: "transferitems");

            migrationBuilder.DropForeignKey(
                name: "fk_transferitems_transfers_transferid",
                table: "transferitems");

            migrationBuilder.DropForeignKey(
                name: "fk_transfers_stores_destinationstoreid",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "fk_transfers_stores_sourcestoreid",
                table: "transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transfers",
                table: "transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transferitems",
                table: "transferitems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_suppliers",
                table: "suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stores",
                table: "stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stocks",
                table: "stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stockmovements",
                table: "stockmovements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shelves",
                table: "shelves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sections",
                table: "sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "completedat",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "reason",
                table: "stockmovements");

            migrationBuilder.RenameTable(
                name: "transfers",
                newName: "Transfers");

            migrationBuilder.RenameTable(
                name: "transferitems",
                newName: "TransferItems");

            migrationBuilder.RenameTable(
                name: "suppliers",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "stores",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "stocks",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "stockmovements",
                newName: "StockMovements");

            migrationBuilder.RenameTable(
                name: "shelves",
                newName: "Shelves");

            migrationBuilder.RenameTable(
                name: "sections",
                newName: "Sections");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Transfers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "sourcestoreid",
                table: "Transfers",
                newName: "SourceStoreId");

            migrationBuilder.RenameColumn(
                name: "destinationstoreid",
                table: "Transfers",
                newName: "DestinationStoreId");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "Transfers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Transfers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_transfers_sourcestoreid",
                table: "Transfers",
                newName: "IX_Transfers_SourceStoreId");

            migrationBuilder.RenameIndex(
                name: "ix_transfers_destinationstoreid",
                table: "Transfers",
                newName: "IX_Transfers_DestinationStoreId");

            migrationBuilder.RenameColumn(
                name: "transferid",
                table: "TransferItems",
                newName: "TransferId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "TransferItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "TransferItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TransferItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_transferitems_transferid",
                table: "TransferItems",
                newName: "IX_TransferItems_TransferId");

            migrationBuilder.RenameIndex(
                name: "ix_transferitems_productid",
                table: "TransferItems",
                newName: "IX_TransferItems_ProductId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Suppliers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Suppliers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "contactemail",
                table: "Suppliers",
                newName: "ContactEmail");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Suppliers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Stores",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Stores",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Stores",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Stores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "shelfid",
                table: "Stocks",
                newName: "ShelfId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Stocks",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "Stocks",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Stocks",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Stocks",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_stocks_shelfid",
                table: "Stocks",
                newName: "IX_Stocks_ShelfId");

            migrationBuilder.RenameIndex(
                name: "ix_stocks_productid",
                table: "Stocks",
                newName: "IX_Stocks_ProductId");

            migrationBuilder.RenameColumn(
                name: "storeid",
                table: "StockMovements",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "StockMovements",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "StockMovements",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "movementtype",
                table: "StockMovements",
                newName: "MovementType");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                table: "StockMovements",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "StockMovements",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "StockMovements",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_stockmovements_storeid",
                table: "StockMovements",
                newName: "IX_StockMovements_StoreId");

            migrationBuilder.RenameIndex(
                name: "ix_stockmovements_productid",
                table: "StockMovements",
                newName: "IX_StockMovements_ProductId");

            migrationBuilder.RenameIndex(
                name: "ix_stockmovements_employeeid",
                table: "StockMovements",
                newName: "IX_StockMovements_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "sectionid",
                table: "Shelves",
                newName: "SectionId");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Shelves",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Shelves",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Shelves",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shelves",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_shelves_sectionid",
                table: "Shelves",
                newName: "IX_Shelves_SectionId");

            migrationBuilder.RenameColumn(
                name: "storeid",
                table: "Sections",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Sections",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Sections",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sections",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_sections_storeid",
                table: "Sections",
                newName: "IX_Sections_StoreId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Roles",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "supplierid",
                table: "Products",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "minimumstocklevel",
                table: "Products",
                newName: "MinimumStockLevel");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Products",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "barcode",
                table: "Products",
                newName: "Barcode");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_products_supplierid",
                table: "Products",
                newName: "IX_Products_SupplierId");

            migrationBuilder.RenameIndex(
                name: "ix_products_categoryid",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "storeid",
                table: "Employees",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "roleid",
                table: "Employees",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "Employees",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Employees",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "Employees",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_employees_storeid",
                table: "Employees",
                newName: "IX_Employees_StoreId");

            migrationBuilder.RenameIndex(
                name: "ix_employees_roleid",
                table: "Employees",
                newName: "IX_Employees_RoleId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isactive",
                table: "Categories",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Transfers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "MovementType",
                table: "StockMovements",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfers",
                table: "Transfers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransferItems",
                table: "TransferItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockMovements",
                table: "StockMovements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shelves",
                table: "Shelves",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Stores_StoreId",
                table: "Employees",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Stores_StoreId",
                table: "Sections",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shelves_Sections_SectionId",
                table: "Shelves",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovements_Employees_EmployeeId",
                table: "StockMovements",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovements_Products_ProductId",
                table: "StockMovements",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovements_Stores_StoreId",
                table: "StockMovements",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Shelves_ShelfId",
                table: "Stocks",
                column: "ShelfId",
                principalTable: "Shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferItems_Products_ProductId",
                table: "TransferItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferItems_Transfers_TransferId",
                table: "TransferItems",
                column: "TransferId",
                principalTable: "Transfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Stores_DestinationStoreId",
                table: "Transfers",
                column: "DestinationStoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Stores_SourceStoreId",
                table: "Transfers",
                column: "SourceStoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
