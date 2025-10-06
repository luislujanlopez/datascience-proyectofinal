using Microsoft.EntityFrameworkCore;
using ProyectoFinalWebApi.Models;
using System.Collections.Generic;

namespace ProyectoFinalWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<SubProducto> SubProductos { get; set; }
    }
}
