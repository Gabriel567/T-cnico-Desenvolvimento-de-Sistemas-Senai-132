namespace Senaizinho
{
    public class Sala
    {
        public int CapacidadeAtual;
        public int CapacidadeTotal;
        public int NumeroSala;
        public string[] Alunos;
        public Sala (int numeroDaSala, int capacidadeTotalDaSala);
        public string AlocarAluno (string alunoAlocado);
        public string RemoverAluno (string alunoRemovido);
        public string MostrarAlunos ();

        public Sala (int CapacidadeAtual, int CapacidadeTotal, int NumeroDaSala, string[] Alunos, string AlocarAluno, string RemoverAluno, string MostrarAlunos) {
            this.CapacidadeAtual = CapacidadeAtual;
            this.CapacidadeTotal = CapacidadeTotal;
            this.NumeroDaSala = NumeroDaSala;
            this.Alunos = Alunos;
            this.AlocarAluno = AlocarAluno;
            this.RemoverAluno = RemoverAluno;
            this.MostrarAlunos = MostrarAlunos;
        }
    }
}