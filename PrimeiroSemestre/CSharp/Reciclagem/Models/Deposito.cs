using System.Collections.Generic;

namespace Reciclagem.Models {
    public class Deposito {
        public static Dictionary<int, ProdutosReciclaveis> Produtos = new Dictionary<int, ProdutosReciclaveis> () { 
            { 1, new Garrafa () }, 
            { 2, new GarrafaPet () }, 
            { 3, new GuardaChuva () }, 
            { 4, new Latinha () }, 
            { 5, new Papelao () }, 
            { 6, new PoteManteiga () }
        };
    }
}