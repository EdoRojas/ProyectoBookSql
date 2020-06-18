using System;
using System.Collections.Generic;
using System.Text;
using BookWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Perfiles> perfiles { get; set; }
        public DbSet<Empleados> empleados { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Empresas> empresas { get; set; }

        public DbSet<Rubros> rubros { get; set; }


    }
}
