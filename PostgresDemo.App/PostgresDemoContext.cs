using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PostgresDemo.App.Models;

namespace PostgresDemo.App;

public class PostgresDemoContext : DbContext
{

    public DbSet<City> Cities { get; set; }
    public DbSet<Weather> Weathers { get; set; }
    public DbSet<State> States { get; set; }

    public string DbPath { get; }

    public PostgresDemoContext()
    {
        DbPath = "Host=localhost;Database=postgresdemo;Username=dotnetuser;Password=dotnetuser";
    }

    public PostgresDemoContext(string filename)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var connectionPath = System.IO.Path.Join(path, filename);
        // var connectionPath = System.IO.Path.Join(path, "postgresdemo.txt");

        if(!File.Exists(connectionPath))
        {
            DbPath = File.ReadAllLines(connectionPath)[0];
        }
        else
        {
            DbPath = "Host=localhost;Database=postgresdemo;Username=dotnetuser;Password=dotnetuser";    
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(DbPath);
        }
    }
}
