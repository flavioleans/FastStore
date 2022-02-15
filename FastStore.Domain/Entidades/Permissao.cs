using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStore.Domain.Entidades
{
    [Table("Permissoes")]
    public class Permissao
    {
        public Permissao()
        {
            this.UsuarioPermissao = new HashSet<UsuarioPermissao>();

        }

        [Key]
        public int PermissaoId { get; set; }
        [Required(ErrorMessage = "Informe a permissão.")]
        [Display(Name ="Permissão")]
        public string Nome { get; set; }

        public virtual ICollection<UsuarioPermissao> UsuarioPermissao { get; set; }

    }
}
