using System;
using System.IO;
using ExercicioLambdaLINQ.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace ExercicioLambdaLINQ {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("Enter full file Path: ");
            string path = Console.ReadLine();
            // string path = @"C:\Apps C#\ExercicioLambdaLINQ\Products.txt";

            List<Products> ProdList = new List<Products>();

            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] line = sr.ReadLine().Split(',');
                    string name = line[0];
                    double price = double.Parse(line[1], CultureInfo.InvariantCulture);
                    ProdList.Add(new Products(name, price));
                }
            }
            var avg = ProdList.Select(p => p.Price).Average();
            Console.WriteLine("Average Price: R$ " + avg.ToString("F2", CultureInfo.InvariantCulture));

            var ProductName = ProdList.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);

            foreach (var x in ProductName) {
                Console.WriteLine(x);
            }

        }
    }
}
