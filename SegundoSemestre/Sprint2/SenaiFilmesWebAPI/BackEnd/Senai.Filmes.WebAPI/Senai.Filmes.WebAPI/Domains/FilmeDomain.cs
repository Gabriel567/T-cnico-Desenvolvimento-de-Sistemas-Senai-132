using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebAPI.Domains
{
    public class FilmeDomain
    {
        public int ID_Filme { get; set; }
        public string NomeFilme { get; set; }
        public int ID_Genero { get; set; }
        public GeneroDomain Genero { get; set; }
    }
}
