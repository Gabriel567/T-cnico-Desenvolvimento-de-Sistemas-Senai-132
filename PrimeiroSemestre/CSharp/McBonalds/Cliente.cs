namespace McBonalds
{
    public class Cliente {

        //Atributos

        public string Nome {get;set;} //Nome do cliente
        public string endereço {get;set;} //Endereço do cliente
        public string Telefone {get;set;} //Telefone do cliente
        public string senha {get;set;} //Senha do cliente
        public string Email {get;set;} //Email do cliente
        public string datenasc {get;set;} //Data de nascimento do cliente

        //Fim dos atributos

        //Construtor

        public Cliente (string nome, string telefone, string email) {

            //Usar this. para não haver conflito

            //nome passou a informação para Nome e assim por diante

            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
        }
    }
}