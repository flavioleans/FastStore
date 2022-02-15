using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastStore.Domain.Entidades
{
    [Table("Produtos")]
    public class Produto
    {
        public int ProdutoId { get; set; }
        [Required(ErrorMessage ="Informe o nome do produto")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Informe a descrição do produto")]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe o preço do produto")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        public byte[] Imagem { get; set; }
        public string ImagemTipo { get; set; }
        [Display(Name ="Categoria")]
        public int CategoriaId { get; set; }
        [Display(Name = "Categoria")]
        public virtual Categoria Categoria { get; set; }
    }
}
