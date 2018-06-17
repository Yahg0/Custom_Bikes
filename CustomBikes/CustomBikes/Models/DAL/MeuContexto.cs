using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomBikes.Models.DAL
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConn")
        {
            Database.SetInitializer<MeuContexto>(new DropCreateDatabaseIfModelChanges<MeuContexto>());
        }
        // Faz a ligação com o banco
        public DbSet<Aro> Aros { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Bicicleta> Bicicletas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Guidao> Guidoes { get; set; }
        public DbSet<Pneu> Pneus { get; set; }
        public DbSet<Quadro> Quadros { get; set; }
    }
}