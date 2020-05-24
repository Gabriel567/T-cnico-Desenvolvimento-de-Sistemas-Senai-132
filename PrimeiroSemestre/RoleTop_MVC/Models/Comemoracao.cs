namespace RoleTop.Models
{
    public class Comemoracao : Produto
    {
        public Comemoracao()
        {

        }

        public Comemoracao(string nome, double preco)
        {
            this.Nome = nome;

            this.Preco = preco;
        }
    }
}