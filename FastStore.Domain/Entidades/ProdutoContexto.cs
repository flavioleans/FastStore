using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStore.Domain.Entidades
{
   public class ProdutoContexto: DbContext
    {
        public ProdutoContexto(): base("name=ConexaoFastStore")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProdutoContexto>(new CreateDatabaseIfNotExists<ProdutoContexto>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<UsuarioPermissao> UsuarioPermissoes { get; set; }

    }
}
