using System.ComponentModel.DataAnnotations;

namespace FastStore.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Usuário")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Senha")]
        public string Senha { get; set; }
        [Display(Name ="Lembrar-Me?")]
        public bool LembrarMe { get; set; }
    }
}