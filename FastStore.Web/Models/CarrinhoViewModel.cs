using FastStore.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FastStore.Web.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }
        public string ReturnUrl { get; set; }
    }
}