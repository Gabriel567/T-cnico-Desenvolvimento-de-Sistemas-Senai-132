using FilmesWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesWebAPI.Controllers
{
    public class FilmeDomain
    {
        public int ID_Filme { get; set; }

        public string NomeFilme { get; set; }

        public int ID_Genero { get; set; }

        public GeneroDomain Genero { get; set; }
    }
}
