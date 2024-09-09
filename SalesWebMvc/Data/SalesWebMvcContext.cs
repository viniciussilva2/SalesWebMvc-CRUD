using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        //INJETAR AS CLASSES/TABELAS NOVAS NO CONTEXTO DO BANCO.
        public DbSet<SalesWebMvc.Models.Department> Departament { get; set; } = default!;
        public DbSet<SalesWebMvc.Models.Tarefas> Tarefas { get; set; } = default!;
        public DbSet<SalesWebMvc.Models.Seller> Seller { get; set; } = default!;
        public DbSet<SalesWebMvc.Models.SalesRecord> SalesRecord { get; set; } = default!;
        public DbSet<SalesWebMvc.Models.Funcionarios> Funcionarios { get; set; } = default!;

    }
}
