using Databases;
using Excels;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = Database.GetDatabase(@"Data source=(localdb)\MSSQLLocalDB;Database=Task6;Integrated Security=true;");
            CreateTable table = new CreateTable();
            table.CreateTableBySubjects(@"D:\SessionSub.xlsx");

            Console.WriteLine("Succesful");
        }
    }
}
