using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebScrapperProxy.Models;

namespace WebScrapperProxy.Database;

public class ApplicationContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ExtratorProxy.db");
    }
    public DbSet<Extracao> Extracoes { get; set; }
}
