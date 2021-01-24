using System;
using Databases;
using University;
using CRUD;
using Excels;

namespace Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = @"Data source=(localdb)\MSSQLLocalDB;Database=Task6;Integrated Security=true;";
            Database database = Database.GetDatabase(str);
            //var result = database.ExecuteQuery<Group>("select GroupName from Groups");
            //foreach(var t in result)
            //Console.WriteLine(t);
            Console.WriteLine("Hello World!");
            //new GroupGRUD().Insert(new Group("ITI-1231"));
            //new StudentGRUD().Delete(new Student("Dens", "Shumilov", new DateTime(2002, 2, 10), "Man", 1));
            // new ExamCRUD().Update(5, new Exam("OOP", new DateTime(2021, 1, 13), 1, 2));
            //  foreach (var t in groups)
            //Console.WriteLine(t);
            CreateTable table = new CreateTable();
            table.CreateTableWithAllData(@"D:\test3.xlsx", Excels.SortFunction.SortBy.StudentsDateBirth, Excels.SortFunction.TypeOfSort.Ascending);
        }
    }
}
