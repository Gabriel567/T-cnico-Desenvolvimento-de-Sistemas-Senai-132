using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class JogoRepository : IJogosRepository
    {
        InLockContext ctx = new InLockContext();

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }

        public void Cadastrar(Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);
            ctx.SaveChanges();
        }

        public Jogos BuscaPorID(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }
    }
}
