using System;
using System.Collections.Generic;
using System.IO;
using McBonaldsMVC.Models;

namespace McBonaldsMVC.Repositories
{
    public class PedidoRepository : RepositoryBase
    {
        private const string PATH = "Database/Pedido.csv";

        public PedidoRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Pedido pedido)
        {
            var quantidadeLinhas = File.ReadAllLines(PATH).Length;

            var linha = new string[] { PrepararRegistroCSV(pedido) };

            pedido.ID = (ulong)++quantidadeLinhas;

            File.AppendAllLines(PATH, linha);

            return true;
        }

        public List<Pedido> ObterTodos()
        {
            var linhas =File.ReadAllLines(PATH);

            List<Pedido> pedidos = new List<Pedido>();

            foreach(var linha in linhas)
            {
                    Pedido pedido = new Pedido();
                    
                    pedido.ID = ulong.Parse(ExtrairvalordoCampo("id", linha));

                    pedido.Status = uint.Parse(ExtrairvalordoCampo("status_pedido", linha));

                    pedido.Cliente.Nome = ExtrairvalordoCampo("cliente_nome",linha);

                    pedido.Cliente.Endereco = ExtrairvalordoCampo("cliente_endereco",linha);

                    pedido.Cliente.Telefone = ExtrairvalordoCampo("cliente_telefone",linha);

                    pedido.Cliente.Email = ExtrairvalordoCampo("cliente_email",linha);

                    pedido.Hamburguer.Nome = ExtrairvalordoCampo("hamburguer_nome",linha);

                    pedido.Hamburguer.Preco = double.Parse(ExtrairvalordoCampo("hamburguer_preco",linha));

                    pedido.Shake.Nome =ExtrairvalordoCampo("shake_nome",linha);

                    pedido.Shake.Preco = double.Parse(ExtrairvalordoCampo("shake_preco",linha));

                    pedido.DataDoPedido = DateTime.Parse(ExtrairvalordoCampo("dataDoPedido",linha));

                    pedido.PrecoTotal = double.Parse(ExtrairvalordoCampo("precoTotal",linha));

                    pedidos.Add(pedido);
            }
            return pedidos;
        }

        public List<Pedido>ObterTodosPorCliente(string email)
        {
            var pedidosTotais = ObterTodos();
            
            List<Pedido> pedidosCliente = new List<Pedido>();

            foreach(var pedido in pedidosTotais)
            {
                if(pedido.Cliente.Email.Equals(email))
                {
                    pedidosCliente.Add(pedido);
                }
            }
            return pedidosCliente;
        }

        public Pedido ObterPor(ulong id)
        {
            var pedidosTotais = ObterTodos();

            foreach(var pedido in pedidosTotais)
            {
                if(pedido.ID == id)
                {
                    return pedido;
                }
            }
            return null;
        }

        public bool Atualizar(Pedido pedido)
        {
            var PedidosTotais = File.ReadAllLines(PATH);

            var pedidoCSV = PrepararRegistroCSV(pedido);

            var linhaPedido = -1;

            var resultado = false;

            for(int i = 0; i < PedidosTotais.Length; i++)
            {
                var idConvertido = ulong.Parse(ExtrairvalordoCampo("id", PedidosTotais[i]));
                
                if(pedido.ID.Equals(idConvertido))
                {
                    linhaPedido = i;
                    resultado = true;
                    break;
                }
            }

            if(resultado)
            {
                PedidosTotais[linhaPedido] = pedidoCSV;

                File.WriteAllLines(PATH, PedidosTotais);
            }

            return resultado;
        }

        private string PrepararRegistroCSV (Pedido pedido)
        {
            return $"id={pedido.ID};status_pedido={pedido.Status};cliente_nome={pedido.Cliente.Nome};cliente_endereco={pedido.Cliente.Endereco};cliente_telefone={pedido.Cliente.Telefone};cliente_email={pedido.Cliente.Email};hamburguer_nome={pedido.Hamburguer.Nome};hamburguer_preco={pedido.Hamburguer.Preco};shake_nome={pedido.Shake.Nome};shake_preco={pedido.Shake.Preco};dataDoPedido={pedido.DataDoPedido};precoTotal={pedido.PrecoTotal}";
        }

    }
}