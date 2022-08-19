using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Data
{
    public class DbContextDesafio : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-T2TQ3C8\SQLEXPRESS;Initial Catalog=DesafioTecnico;Integrated Security=True");
        }
    }
}
