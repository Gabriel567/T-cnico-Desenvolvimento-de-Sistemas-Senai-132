namespace McBonaldsMVC.Repositories
{
    public class RepositoryBase
    {
        protected string ExtrairvalordoCampo(string nomeCampo, string linha){
            var chave = nomeCampo;
            var indiceChave = linha.IndexOf(chave);//!busca qual o indice da chave"nome" no CSV

            var indiceTerminal = linha.IndexOf(";", indiceChave);
            var valor = "";

            if(indiceTerminal != -1){
                //! busca uma parte da string
                valor = linha.Substring(indiceChave, indiceTerminal - indiceChave);
            }else{
                valor = linha.Substring(indiceChave);
            }

            System.Console.WriteLine($"Campo {nomeCampo} tem valor {valor}");

            //! Replace: troca o que esta a esquerda pelo o que esta a direita
            return valor.Replace(nomeCampo + "=", "");


        }
    }
}