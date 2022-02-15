using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FastStore.Web.Models
{
    public class RegistroViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter no mínimo 5 caracteres.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmaSenha { get; set; }
    }
}