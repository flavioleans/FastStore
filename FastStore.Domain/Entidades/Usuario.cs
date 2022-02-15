using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStore.Domain.Entidades
{
    [Table("Usuarios")]
   public class Usuario
    {
        public Usuario()
        {
            this.UsuarioPermissao = new HashSet<UsuarioPermissao>();
        }

        [Key]
        public int Usuarioid { get; set; }
        [Required(ErrorMessage ="Informe o login.")]
        [Display(Name ="Usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe o login.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Informe o E-mail.")]
        public virtual ICollection<UsuarioPermissao> UsuarioPermissao { get; set; }

    }
}
