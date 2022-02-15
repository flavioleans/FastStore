using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStore.Domain.Entidades
{
    [Table("UsuarioPermissoes")]
    public class UsuarioPermissao
    {
        [Key]
        public int PermissaoUsuarioId { get; set; }
        
        [Display(Name = "Permissão")]
        public int PermissaoId { get; set; }
        
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }

        public virtual Permissao Permissao { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
