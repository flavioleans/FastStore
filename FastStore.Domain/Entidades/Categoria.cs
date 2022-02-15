using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastStore.Domain.Entidades
{
    [Table("Categorias")]
    public class Categoria
    {
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
