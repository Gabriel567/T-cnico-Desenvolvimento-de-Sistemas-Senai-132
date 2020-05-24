using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuario
    {
        InLockContext ctx = new InLockContext();
        
        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuario.ToList();
        }

        public TiposUsuario BuscaPorId(int id)
        {
            return ctx.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastro(TiposUsuario novoTipoUsuario)
        {
            ctx.TiposUsuario.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }
    }
}
