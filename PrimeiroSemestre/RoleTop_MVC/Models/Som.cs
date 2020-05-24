namespace RoleTop.Models
{
    public class Som : Produto
    {
        public Som()
        {

        }

        public Som(string nome, double preco)
        {
            this.Nome = nome;

            this.Preco = preco;
        }
    }
}