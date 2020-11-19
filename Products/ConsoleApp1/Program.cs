using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products;
using ReadingFromFile;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Read read = new Read(@"D:\Products.txt");

            var list = read.CreateList();
        }
    }
}
