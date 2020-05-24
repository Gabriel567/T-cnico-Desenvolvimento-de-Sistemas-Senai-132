namespace RoleTop.Models
{
    public class Iluminacao : Produto
    {
        public Iluminacao()
        {

        }

        public Iluminacao(string nome, double preco)
        {
            this.Nome = nome;

            this.Preco = preco;
        }
    }
}