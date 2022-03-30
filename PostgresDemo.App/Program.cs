using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace PostgresDemo.App;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n***** POSTGRES *****\n");

        using (var db = new PostgresDemoContext())
        //using (var db = new BloggingContext())
        {
            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");
                
            // Create
            Console.WriteLine("Inserting a new weather");
            db.Add(new Models.Weather { WeatherId = 3, City = "Shakhtersk", TempLo = 0, TempHi = 25, Prcp = 0, Date = new DateOnly(2022, 03, 30)});
            db.SaveChanges();

            // Read
            Console.WriteLine("Querying for a weather");
            var weathers = db.Weathers.OrderBy(b => b.City);
            // var weather = db.Weathers.OrderBy(b => b.City).First();
            foreach (var weather in weathers)
            {
                Console.WriteLine($"{weather.City}");   
            }

            // // Update
            // Console.WriteLine("Updating the blog and adding a post");
            // blog.Url = "https://devblogs.microsoft.com/dotnet";
            // blog.Posts.Add(
            //     new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
            // db.SaveChanges();

            // // Delete
            // Console.WriteLine("Delete the blog");
            // db.Remove(blog);
            // db.SaveChanges();
        }   
    }
}