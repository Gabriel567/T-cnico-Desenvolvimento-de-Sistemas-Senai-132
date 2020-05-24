using System.Collections.Generic;
using System.IO;
using RoleTop.Controllers;
using RoleTop.Models;

namespace RoleTop.Repositories
{
    public class EventoRepository : RepositoryBase
    {
        private const string PATH = "DataBase/Evento.csv";

        public EventoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Models.Evento evento)
        {
            var quantidadeLinhas = File.ReadAllLines(PATH).Length;

            evento.ID = (ulong)++quantidadeLinhas;

            var linha = new string[] {PrepararRegistroCSV(evento)};

            File.AppendAllLines(PATH, linha);

            return true;
        }

        public List<Evento> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);

            List<Evento> eventos = new List<Evento>();

            foreach(var linha in linhas)
            {
                Evento evento = new Evento();

                evento.ID = ulong.Parse(ExtrairValorDoCampo("id", linha));

                evento.Status = uint.Parse(ExtrairValorDoCampo("status_evento", linha));

                evento.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);

                evento.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);

                evento.Comemoracao.Nome = ExtrairValorDoCampo("comemoracao_nome", linha);

                evento.Comemoracao.Preco = double.Parse(ExtrairValorDoCampo("comemoracao_preco", linha));

                evento.Convidados.Valor = int.Parse(ExtrairValorDoCampo("convidados_valor", linha));

                evento.Convidados.Preco = double.Parse(ExtrairValorDoCampo("convidados_preco", linha));

                evento.MesaCadeira.Valor = int.Parse(ExtrairValorDoCampo("mesaCadeira_valor", linha));

                evento.MesaCadeira.Preco = double.Parse(ExtrairValorDoCampo("mesaCadeira_preco", linha));

                evento.Iluminacao.Nome = ExtrairValorDoCampo("iluminacao_nome", linha);

                evento.Iluminacao.Preco = double.Parse(ExtrairValorDoCampo("iluminacao_preco", linha));

                evento.Som.Nome = ExtrairValorDoCampo("som_nome", linha);

                evento.Som.Preco = double.Parse(ExtrairValorDoCampo("som_preco", linha));

                eventos.Add(evento);
            }
            return eventos;
        }

        public List<Evento> ObterTodosPorCliente(string senha)
        {
            var eventoCompleto = ObterTodos();

            List<Evento> eventosCliente = new List<Evento>();

            foreach(var evento in eventoCompleto)
            {
                if(evento.Cliente.Email.Equals(senha))
                {
                    eventosCliente.Add(evento);
                }
            }
            return eventosCliente;
        }

        public Evento ObterPor(ulong id)
        {
            var eventoCompleto = ObterTodos();

            foreach(var evento in eventoCompleto)
            {
                if(evento.ID == id)
                {
                    return evento;
                }
            }
            return null;
        }

        public bool Atualizar(Evento evento)
        {
            var EventoCompleto = File.ReadAllLines(PATH);

            var eventoCSV = PrepararRegistroCSV(evento);

            var linhaEvento = -1;

            var resultado = false;

            for(int i = 0; i < EventoCompleto.Length; i++)
            {
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("id", EventoCompleto[i]));

                if(evento.ID.Equals(idConvertido))
                {
                    linhaEvento = i;

                    resultado = true;

                    break;
                }
            }

            if(resultado)
            {
                EventoCompleto[linhaEvento] = eventoCSV;

                File.WriteAllLines(PATH, EventoCompleto);
            }

            return resultado;
        }

        private string PrepararRegistroCSV(Evento evento)
        {
            return $"id={evento.ID};status_evento={evento.Status};client_nome={evento.Cliente.Nome};cliente_email={evento.Cliente.Email};comemoracao_nome={evento.Comemoracao.Nome};comemoracao_preco={evento.Comemoracao.Preco};convidados_valor={evento.Convidados.Valor};convidados_preco={evento.Convidados.Preco};mesaCadeira_valor={evento.MesaCadeira.Valor};mesaCadeira_preco={evento.MesaCadeira.Preco};som_nome={evento.Som.Nome};som_preco={evento.Som.Preco};iluminacao_nome={evento.Iluminacao.Nome};iluminacao_preco={evento.Iluminacao.Preco}";
        }
    }
}