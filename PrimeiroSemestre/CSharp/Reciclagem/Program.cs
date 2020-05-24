using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Reciclagem.Interfaces;
using Reciclagem.Models;

namespace Reciclagem {
    enum ProdutosEnum : uint {
        Garrafa,
        Garrafa_Pet,
        Guarda_Chuva,
        Latinha,
        Papelão,
        Pote_Manteiga
    }
    enum CategoriaEnum : uint {
        Plástico,
        Papel,
        Metal,
        Vidro,
        Orgânico
    }
    class Program {
        static void Main (string[] args) {
            bool querSair = false;

            string[] itensMenuPrincipal = Enum.GetNames (typeof (ProdutosEnum));
            string[] itensMenuCategoria = Enum.GetNames (typeof (CategoriaEnum));

            int espaco = 0;

            bool lixoPreenchido = false;

            do {

                #region Adição de produtos à categoria Papel

                espaco = 6;
                do {
                    ExibirMenuPrincipal ();

                    System.Console.WriteLine ("Digite o número do produto a ser reciclado em Papel: ");
                    int codigo = int.Parse (Console.ReadLine ());
                    var produto = Deposito.Produtos[codigo];

                    Type interfaceEncontrada = produto.GetType ().GetInterface ("IPapel");

                    if (interfaceEncontrada != null) {
                        espaco--;
                        Reciclar ((IPapel) produto);
                    } else {
                        System.Console.WriteLine ("O produto selecionado não pertence a categoria Papel.");
                        continue;
                    }

                    System.Console.WriteLine ("Lixo reciclado na categoria Papel com sucesso!");
                    Console.ReadLine ();

                    #endregion

                    #region  Adição de produtos à categoria Metal

                    ExibirMenuPrincipal ();

                    System.Console.WriteLine ("Digite o número a ser reciclado em Metal: ");
                    codigo = int.Parse (Console.ReadLine ());
                    produto = Deposito.Produtos[codigo];

                    interfaceEncontrada = produto.GetType ().GetInterface ("IMetal");

                    if (interfaceEncontrada != null) {
                        espaco--;
                        Reciclar ((IMetal) produto);
                    } else {
                        System.Console.WriteLine ("O produto selecionado não pertence a categoria Metal.");
                        continue;
                    }

                    System.Console.WriteLine ("Lixo reciclado na categoria Metal com sucesso!");
                    Console.ReadLine ();

                    #endregion

                    #region Adição de produtos à categoria Vidro

                    ExibirMenuPrincipal ();

                    System.Console.WriteLine ("Digite o número a ser reciclado em Vidro: ");
                    codigo = int.Parse (Console.ReadLine ());
                    produto = Deposito.Produtos[codigo];

                    interfaceEncontrada = produto.GetType ().GetInterface ("IVidro");

                    if (interfaceEncontrada != null) {
                        espaco--;
                        Reciclar ((IVidro) produto);
                    } else {
                        System.Console.WriteLine ("O produto selecionado não pertence a categoria Vidro.");
                        continue;
                    }

                    System.Console.WriteLine ("Lixo reciclado na categoria Vidro com sucesso!");
                    Console.ReadLine ();

                    #endregion

                    #region Adição de produtos à categoria Plástico

                    ExibirMenuPrincipal ();

                    System.Console.WriteLine ("Digite o número a ser reciclado em Plástico: ");
                    codigo = int.Parse (Console.ReadLine ());
                    produto = Deposito.Produtos[codigo];

                    interfaceEncontrada = produto.GetType ().GetInterface ("IPlastico");

                    if (interfaceEncontrada != null) {
                        espaco--;
                        Reciclar ((IPlastico) produto);
                    } else {
                        System.Console.WriteLine ("O produto selecionado não pertence a categoria Plástico.");
                        continue;
                    }

                    System.Console.WriteLine ("Lixo reciclado na categoria Plástico com sucesso!");
                    Console.ReadLine ();

                    if (espaco == 0) {
                        lixoPreenchido = true;
                    }
                } while (!lixoPreenchido);

                #endregion

            } while (!querSair);
        }

        public static void ExibirMenuPrincipal () {
            var produtos = Enum.GetNames (typeof (ProdutosEnum));
            int codigo = 1;
            string menuProdutos = "=========================";

            System.Console.WriteLine (menuProdutos);
            System.Console.WriteLine ("#        Produtos        #");
            System.Console.WriteLine (menuProdutos);

            foreach (var produto in produtos) {
                System.Console.WriteLine ($"  {codigo++}.{TratarTituloMenu(produto)}");
            }

            System.Console.WriteLine (menuProdutos);
        }

        public static void ExibirMenuDeCategorias () {
            var categorias = Enum.GetNames (typeof (CategoriaEnum));
            int codigo = 1;
            string menuProdutos = "=========================";
            System.Console.WriteLine (menuProdutos);
            System.Console.WriteLine ("#          Categorias        #");

            foreach (var categoria in categorias) {

                System.Console.WriteLine ($"  {codigo++}.{TratarTituloMenu(categoria)}");
            }

            System.Console.WriteLine (menuProdutos);

        }

        public static string TratarTituloMenu (string titulo) {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase (titulo.Replace ("_", " ").ToLower ());
        }

        public static bool Reciclar (IMetal metal) {
            metal.FeitoDeMetal ();
            System.Console.WriteLine (metal.GetType ().BaseType + " foi incluído");
            return true;
        }

        public static bool Reciclar (IPapel papel) {
            papel.FeitoDePapel ();
            System.Console.WriteLine (papel.GetType ().BaseType + " foi incluído");
            return true;
        }

        public static bool Reciclar (IPlastico plastico) {
            plastico.FeitoDePlastico ();
            System.Console.WriteLine (plastico.GetType ().BaseType + " foi incluído");
            return true;
        }

        public static bool Reciclar (IVidro vidro) {
            vidro.FeitoDeVidro ();
            System.Console.WriteLine (vidro.GetType ().BaseType + " foi incluído");
            return true;
        }
    }
}