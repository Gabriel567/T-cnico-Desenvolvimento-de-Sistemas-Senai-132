using System;
using MateODragao.Models;
//Assinaturas de método ficam em amarelo (Main, WriteLine, ToUpper, etc)
//                Alt Shift F - deixar o código alinhado

namespace MateODragao {
    class Program {

        static void Main (string[] args) {

            //bool = verdadeiro ou falso
            bool jogadorNaoDesistiu = true;

            do {
                System.Console.WriteLine ("==============================");
                System.Console.WriteLine ("Mate o Dragão");
                System.Console.WriteLine ("==============================");

                System.Console.WriteLine (" 1 - Iniciar jogo");
                System.Console.WriteLine (" 0 - Sair do jogo");

                string opcaoJogador = Console.ReadLine ();

                switch (opcaoJogador) {

                    case "1":

                        Console.Clear ();

                        //Foi estabelecido uma variável para que exista um local para salvar os dados obtidos, no caso, os dados do guerreiro criado pelo método "CriarGuerreiro ()"
                        Guerreiro guerreiro = CriarGuerreiro ();

                        //Idem ao comentário superior
                        Dragao dragao = CriarDragao ();
                        
                        // ToUpper = deixa a palavra/frase em maiusculo
                        //\n = pula linha
                        //                                        Inicio do primeiro dialogo

                        CriarDialogo (guerreiro.Nome, $"{dragao.Nome}, Agora, vil criatura, você conhecerá a morte.");
                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: {guerreiro.Nome}, Vem tranquilo.");

                        FinalizarDialogo ();

                        //                                        Fim do primeiro dialogo

                        //                                        Inicio do segundo dialogo

                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Meu nome é {guerreiro.Nome}, da família {guerreiro.Sobrenome}.");
                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Vim de {guerreiro.CidadeNatal} para matá-lo.");
                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Não me importo com quem você seja, e nem de onde você é, e muito menos com o seu objetivo, hoje você perecerá perante mim.");

                        //Colocar parenteses no método para chama-lo, senão, o C# irá achar que é uma class
                        FinalizarDialogo ();

                        //                                        Fim do segundo dialogo

                        bool jogadorAtacaPrimeiro = guerreiro.Destreza > dragao.Destreza? true : false;

                        bool jogadorNaoCorreu = true;

                        int poderAtaqueGuerreiro = guerreiro.Forca > guerreiro.Inteligencia? guerreiro.Forca + guerreiro.Destreza : guerreiro.Inteligencia + guerreiro.Destreza;

                        //                                          Inicio da luta

                        if (jogadorAtacaPrimeiro) {

                            Console.Clear ();
                            System.Console.WriteLine ("Turno do Jogador");
                            System.Console.WriteLine ("Escolha sua ação:");
                            System.Console.WriteLine (" 1 - Atacar");
                            System.Console.WriteLine (" 2 - Fugir");

                            string opcaoBatalhaJogador = Console.ReadLine ();

                            switch (opcaoBatalhaJogador) {

                                case "1":
                                    //"Número aleatório"
                                    Random geradorNumeroAleatorio = new Random ();
                                    //Next adiciona numeros inteiros

                                    int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                                    int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                                    int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    int dragaoDestrezaTotal = dragao.Destreza + numeroAleatorioDragao;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Sinta a lâmina da minha espada!");
                                        //dragao.HP -= poderAtaqueGuerreiro + 5;
                                        dragao.HP = dragao.HP - (poderAtaqueGuerreiro + 10);
                                        System.Console.WriteLine ("----------");
                                        System.Console.WriteLine ($"HP Dragão: {dragao.HP}");
                                        System.Console.WriteLine ($"HP Guerreiro: {guerreiro.HP}");
                                    } else {
                                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Isso não me afeta boneco de barro.");
                                    }
                                    break;

                                case "2":
                                    jogadorNaoCorreu = false;
                                    System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Terei que recuar.");
                                    System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Fuja se quiser viver.");
                                    break;

                            }

                        }
                        //                                           Fim da luta

                        System.Console.WriteLine ("Aperte ENTER para prosseguir");
                        Console.ReadLine ();

                        while (dragao.HP > 0 && guerreiro.HP > 0 && jogadorNaoCorreu) {
                            Console.Clear ();
                            System.Console.WriteLine ("Turno do Dragão");
                            //"Número aleatório"
                            Random geradorNumeroAleatorio = new Random ();
                            //Next adiciona numeros inteiros

                            int numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                            int numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                            int guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                            int dragaoDestrezaTotal = dragao.Destreza + numeroAleatorioDragao;

                            if (dragaoDestrezaTotal > guerreiroDestrezaTotal) {
                                System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Queime.");
                                System.Console.WriteLine ("----------");
                                System.Console.WriteLine ($"HP Dragão: {dragao.HP}");
                                System.Console.WriteLine ($"HP Guerreiro: {guerreiro.HP}");
                            } else {
                                System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Isso é tudo o que você tem?");
                            }
                            System.Console.WriteLine ();
                            System.Console.WriteLine ("Aperte ENTER para prosseguir");
                            Console.ReadLine ();
                            //Inicio do turno do Jogador
                            Console.Clear ();
                            System.Console.WriteLine ("Turno do Jogador");
                            System.Console.WriteLine ("Escolha sua ação:");
                            System.Console.WriteLine (" 1 - Atacar");
                            System.Console.WriteLine (" 2 - Fugir");

                            string opcaoBatalhaJogador = Console.ReadLine ();

                            switch (opcaoBatalhaJogador) {

                                case "1":
                                    //"Número aleatório"
                                    geradorNumeroAleatorio = new Random ();
                                    //Next adiciona numeros inteiros

                                    numeroAleatorioJogador = geradorNumeroAleatorio.Next (0, 5);
                                    numeroAleatorioDragao = geradorNumeroAleatorio.Next (0, 5);
                                    guerreiroDestrezaTotal = guerreiro.Destreza + numeroAleatorioJogador;
                                    dragaoDestrezaTotal = dragao.Destreza + numeroAleatorioDragao;

                                    if (guerreiroDestrezaTotal > dragaoDestrezaTotal) {
                                        System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Sinta a lâmina da minha espada!");
                                        //dragao.HP -= poderAtaqueGuerreiro + 5;
                                        dragao.HP = dragao.HP - poderAtaqueGuerreiro + 5;
                                        System.Console.WriteLine ("----------");
                                        System.Console.WriteLine ($"HP Dragão: {dragao.HP}");
                                        System.Console.WriteLine ($"HP Guerreiro: {guerreiro.HP}");
                                    } else {
                                        System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Isso não me afeta boneco de barro.");
                                    }

                                    if (guerreiro.HP <= 0) {
                                        System.Console.WriteLine ("Jogador morreu.");
                                    }
                                    if (dragao.HP <= 0) {
                                        System.Console.WriteLine ("O Dragão morreu.");
                                    }
                                    System.Console.WriteLine ();
                                    System.Console.WriteLine ("Aperte ENTER para prosseguir");
                                    Console.ReadLine ();
                                    Console.Clear ();

                                    break;

                                case "2":
                                    jogadorNaoCorreu = false;
                                    System.Console.WriteLine ($"{guerreiro.Nome.ToUpper()}: Terei que recuar.");
                                    System.Console.WriteLine ($"{dragao.Nome.ToUpper()}: Fuja se quiser viver.");
                                    break;

                            }

                        }

                        System.Console.WriteLine ("Aperte ENTER para prosseguir");
                        Console.ReadLine ();

                        //Fim do turno do Jogador

                        break;
                    case "0":
                        jogadorNaoDesistiu = false;
                        break;

                    default:
                        System.Console.WriteLine ("Comando inválido");
                        break;
                }

            } while (jogadorNaoDesistiu);
        }

        //                         Exemplo de comentario de método
        //                                     Método 1
        private static void CriarDialogo (string nome, string frase) {

            System.Console.WriteLine ($"{nome.ToUpper()}: {frase}.");

        }
        //                                  Fim do método 1
        //      Métodos ficam dentro da class e fora do Main, são independentes do Main, no caso, estes métodos estão dentro da class Program

        private static void FinalizarDialogo () {

            System.Console.WriteLine ();
            System.Console.WriteLine ("Aperte ENTER para prosseguir");
            Console.ReadLine ();
            Console.Clear ();
        }

        //Guerreiro ficou no lugar de void, pois é necessário um retorno do programa, no caso, o retorno é um guerreiro
        private static Guerreiro CriarGuerreiro () {

            Console.ReadLine ();

            Guerreiro guerreiro = new Guerreiro ();
            guerreiro.Nome = "Igris";
            guerreiro.Sobrenome = "Hanthalts";
            guerreiro.CidadeNatal = "Avalon";
            guerreiro.DataNascimento = DateTime.Parse ("09.01.476");
            guerreiro.FerramentaDeAtaque = "Espada de folha larga";
            guerreiro.FerramentaDeProtecao = "Dominio do Monarca";
            guerreiro.Forca = 3;
            guerreiro.Destreza = 2;
            guerreiro.Inteligencia = 2;
            guerreiro.HP = 20;

            //Retornar a variável guerreiro, pois é o que o programa usará
            return guerreiro;

        }

        private static Dragao CriarDragao () {

            Console.ReadLine ();

            Dragao dragao = new Dragao ();
            dragao.Nome = "Kamish";
            dragao.Forca = 5;
            dragao.Destreza = 1;
            dragao.Inteligencia = 3;
            dragao.HP = 300;

            return dragao;

        }
    }
}