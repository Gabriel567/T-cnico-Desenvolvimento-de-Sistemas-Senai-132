using FilmesWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesWebAPI.Domains
{
    public class GeneroDomain
    {
        public int ID_Genero { get; set; }

        public string Genero { get; set; }

        public FilmeDomain Filme { get; set; }
    }
}
