using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestbuyORM
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            Console.WriteLine(connString);
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Type a New Department name");
            var newDepartment = Console.ReadLine();
            //repo.InsertDepartment(newDepartment);
            var departments = repo.GetAllDepartments();
            foreach (var item in departments)
            {
                Console.WriteLine(item.Name);
            }
            var repoProducts = new DapperProductRepository(conn);
            var products = repoProducts.GetAllProducts();
            //repoProducts.InsertProduct();
            //repoProducts.UpdateProduct();
            repoProducts.DeleteProduct();
            
            Console.WriteLine("Hello World!");
        }
    }
}
