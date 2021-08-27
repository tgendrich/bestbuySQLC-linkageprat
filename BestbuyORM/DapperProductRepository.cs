using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;


namespace BestbuyORM
{
    class DapperProductRepository : IproductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM Products;");
        }
    
        public void InsertProduct()
        {
            // add name, price, and catagoryID
            Console.WriteLine("What is the name of your product that you would like to add?");
            var newProductName = Console.ReadLine();
            Console.WriteLine("what is its price?");
            var newProductPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("What category does this item belong to?");
            Console.WriteLine("1: Computers. 2: Appliances. 3: Phones. 4: Audio. 5: Home Theater. 6: Printers. 7: Music. 8: Games. 9: Services. 10: Other.");
            var newProductCategoryID = int.Parse(Console.ReadLine());
            _connection.Execute("INSERT INTO PRODUCTS(Name, Price, CategoryID) VALUES (@productName,@productPrice,@productCategoryID); ",
                new { productName = newProductName, productPrice = newProductPrice, productCategoryID = newProductCategoryID });
        }
        public void UpdateProduct()
        {
            Console.WriteLine("What is the name of the product you wish to change?");
            var updateItem = Console.ReadLine();
            Console.WriteLine("What is the new name of the product?");
            var newName = Console.ReadLine();
            Console.WriteLine("What is the new price?");
            var newPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("What is the new category that this item belongs to?");
            var newCategory = int.Parse(Console.ReadLine());


            _connection.Execute("UPDATE PRODUCTS SET Name = @productName, Price = @productPrice, CategoryID = @productCategoryID WHERE Name = @updateItem; ",
                new { productName = newName, productPrice = newPrice, productCategoryID = newCategory, updateItem = updateItem });
            Console.WriteLine("Product has been updated");
        }
    
        public void DeleteProduct()
        {
            Console.WriteLine("What is the name of the product you wish to delete?");
            var deleteItem = Console.ReadLine();
            _connection.Execute("DELETE FROM PRODUCTS WHERE Name = @deleteItem; ",
                new { deleteItem = deleteItem });
            Console.WriteLine("Product has been deleted");
        }
    }
}
