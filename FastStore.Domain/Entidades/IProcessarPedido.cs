using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastStore.Domain.Entidades
{
    public interface IProcessarPedido
    {
        void ProcessarPedido(Carrinho carrinho, Despacho despacho);
    }
}
