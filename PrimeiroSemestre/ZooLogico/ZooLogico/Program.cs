using System;
using System.Collections.Generic;
using ZooLogico.Interfaces;
using ZooLogico.Models;

namespace ZooLogico {
    class Program {
        private const int V = 1;

        enum Animais : uint {
            Tubarão_Martelo,
            Tucano,
            Arara,
            Leão,
            Orangotango,
            Chimpanzé,
            Pinguim,
            Tartaruga,
            Golfinho
        }
        static void Main (string[] args) {
            string[] MenuAnimais = Enum.GetNames (typeof (Animais));
            System.Console.WriteLine ("#                           #");
            System.Console.WriteLine ("         Zoo Lógico        ");
            System.Console.WriteLine ("#                           #");
            System.Console.WriteLine ();
            ExibirAnimais ();
            System.Console.WriteLine ();
            System.Console.WriteLine ("Digite o código desejado: ");
            int codigo = int.Parse (Console.ReadLine ());
            var animal = Arca.ArcaNoé[codigo];
            var type = animal;
            var allInterfaces = new HashSet<Type> (type.GetType ().GetInterfaces ());
            // int escolha = 0;

            switch(codigo) {
                case 1:
                ColocarJaula((IAquario)animal);
                break;

                case 2:
                ColocarJaula((IGaiola)animal);
                break;

                case 3:
                ColocarJaula((IGaiola)animal);
                break;

                case 4:
                ColocarJaula((ICaverna)animal);
                break;

                case 5:
                ColocarJaula((ICasaArvore)animal);
                break;

                case 6:
                ColocarJaula((ICasaArvore)animal);
                break;

                case 7:
                ColocarJaula((IPiscinaGelada)animal);
                break;

                case 8:
                ColocarJaula((IPiscina)animal);
                break;

                case 9:
                ColocarJaula((IAquario)animal);
                break;
            }
        }

        public static void ExibirAnimais () {
            int codigo = 1;
            var animais = Enum.GetNames (typeof (Animais));
            foreach (var animal in animais) {
                System.Console.WriteLine ($"  {codigo++}.{TratarTituloMenu(animal)}");
            }
        }
        public static string TratarTituloMenu (string titulo) {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase (titulo.Replace ("_", " ").ToLower ());
        }

        public static bool ColocarJaula (IAquario aquario) {
            aquario.AgrupaMarinhos ();
            System.Console.WriteLine (aquario.GetType ().BaseType + "foi colocado");
            return true;
        }

        public static bool ColocarJaula (ICasaArvore casaArvore) {
            casaArvore.AgrupaSimios ();
            System.Console.WriteLine (casaArvore.GetType ().BaseType + "foi colocado");
            return true;
        }

        public static bool ColocarJaula (ICaverna caverna) {
            caverna.AgrupaCavernosos ();
            System.Console.WriteLine (caverna.GetType ().BaseType + "foi colocado");
            return true;
        }

        public static bool ColocarJaula (IGaiola gaiola) {
            gaiola.AgrupaAereos ();
            System.Console.WriteLine (gaiola.GetType ().BaseType + "foi colocado");
            return true;
        }

        public static bool ColocarJaula (IPiscina piscina) {
            piscina.AgrupaDoce ();
            System.Console.WriteLine (piscina.GetType ().BaseType + "foi colocado");
            return true;
        }

        public static bool ColocarJaula (IPiscinaGelada piscinaGelada) {
            piscinaGelada.AgrupaGelidos ();
            System.Console.WriteLine (piscinaGelada.GetType ().BaseType + "foi colocado");
            return true;
        }
    }
}