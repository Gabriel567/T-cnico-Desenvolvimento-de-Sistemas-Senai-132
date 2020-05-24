using System;

namespace ByteBank {
    public class Cliente {

        private string Nome;
        private string Email;
        private string Cpf;
        private string Senha;

        public string nome {
            get {return Nome;}
        }

        public string email {
            get {return Email;}
        }

        public string cpf {
            get {return Cpf;}
            set { Cpf = value;} //usuario.Cpf =
        }

        public string senha {
            get {return Senha;}
        }
        public Cliente (string Nome, string Cpf, string Email) {

            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Email = Email;
        }

        public bool TrocaSenha (string senha) {
            if ((senha.Length > 6) && (senha.Length < 16)) {
                this.Senha = senha;
                return true;
            } else {
                return false;
            }
        }
    }
}