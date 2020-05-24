using System;

namespace RoleTop.Models 
{
    public class Cliente 
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string RepitaSenha { get; set; }
        public uint TipoUsuario {get;set;}

        public Cliente () 
        {

        }

        public Cliente (string nome, DateTime dataNascimento, string email, string senha, string repitaSenha) 
        {
            this.Nome = nome;
            this.DataNascimento = DataNascimento;
            this.Email = email;
            this.Senha = senha;
            this.RepitaSenha = repitaSenha;
            this.TipoUsuario = 1;
        }
    }
}