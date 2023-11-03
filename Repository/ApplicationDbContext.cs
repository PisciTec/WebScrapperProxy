using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebScrapperProxy.Models;
using Microsoft.EntityFrameworkCore.Sqlite;
namespace WebScrapperProxy.Database;

public class ApplicationContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ExtratorProxy.db");
    }
    public DbSet<Extracao> Extracoes { get; set; }
}
