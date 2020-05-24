using System;
using System.Collections.Generic;
using System.IO;
namespace TodoList {
    class Program {
        //Método Main
        static int Main (string[] args) {
            List<TodoItem> todoList = new List<TodoItem> ();
            string fileName = "todo.csv"; //* Tipo de arquivo */
            string filePath = ".\\" + fileName; //* Caminho da Pasta de origem */

            todoList = initList (@filePath);

            if (todoList == null) {
                return -1;
            }

            int opcao = 0;
            do {
                Console.Clear ();
                Console.WriteLine ("Todo List");
                Console.WriteLine ();
                ListaItens (todoList);
                Console.WriteLine ();
                Console.WriteLine ("Digite uma opção");
                Console.WriteLine ("1 - Adicionar item");
                Console.WriteLine ("2 - Remover item");
                Console.WriteLine ("3 - Terminar ");
                Console.Write ("Opção: ");
                opcao = int.Parse (Console.ReadLine ());

                switch (opcao) {
                    case 1:
                        AddItem (todoList);
                        break;
                    case 2:
                        RemoveItem (todoList);
                        break;
                    case 3:
                        Console.WriteLine ("Tchau!");
                        SaveList (todoList, @filePath);
                        break;
                    default:
                        Console.WriteLine ("Opção invalida");
                        Console.ReadLine ();
                        break;
                }
            } while (opcao != 3);
            return 0;
        }

        //Método List
        static List<TodoItem> initList (string filePath) {
            List<TodoItem> todoList = new List<TodoItem> ();
            try {
                string[] todoFile = File.ReadAllLines (@filePath);
                foreach (string line in todoFile) {
                    string[] itens = line.Split (",");
                    string titulo = itens[0].Replace ("\"", "");
                    string nota = itens[1].Replace ("\"", "");
                    TodoItem todoItem = new TodoItem (titulo, nota);
                    todoList.Add (todoItem);

                }
                todoList.RemoveAt (0);
                return todoList;
            } catch (IOException e) {
                Console.WriteLine ("Erro de Acesso.");
                System.Console.WriteLine (e.Message);
                return null; //* -1:Linguagem universal para deu Merda */
            }
        }

        static void ListaItens (List<TodoItem> todoList) {
            Console.Clear ();
            int count = 1;
            Console.WriteLine ("Todo List");
            Console.WriteLine ();
            Console.WriteLine ($"ID{"",2} Titulo{"",12} Notas");
            foreach (TodoItem item in todoList) {
                System.Console.WriteLine ($"{count,3}, {item.Titulo,-15} - {item.Nota}");
                count++;
            }
        }

        static void AddItem (List<TodoItem> todoList) {
            Console.Clear ();
            Console.WriteLine ("Novo item");
            Console.WriteLine ();
            Console.WriteLine ("Titulo: ");
            string titulo = Console.ReadLine ();
            Console.Write ("Nota: ");
            string nota = Console.ReadLine ();
            TodoItem item = new TodoItem (titulo, nota);
            todoList.Add (item);
        }

        static void RemoveItem (List<TodoItem> todoList) {
            int index = 0;

            do {
                Console.Clear ();
                Console.WriteLine ("Remove Item");
                Console.WriteLine ();
                ListaItens (todoList);
                Console.WriteLine ();
                Console.WriteLine ("Digite o ID ou x para terminar");
                Console.WriteLine ("ID: ");
                string id = Console.ReadLine ();

                if (id.ToLower () == "x") {
                    break;
                } else {
                    index = int.Parse (id) - 1;
                }

                if ((index < 0) || (index > todoList.Count - 1)) {
                    Console.WriteLine ("ID Inválido");
                    Console.WriteLine ("Pressione <ENTER> Para CONTINUAR");
                    Console.ReadLine ();
                } else {
                    todoList.RemoveAt (index);
                }
            } while (true);
        }

        static void SaveList (List<TodoItem> lista, string path) {
            //Local de salvamento dos itens em direção ao arquivo
            List<string> linhas = new List<string> (); // new List<string>() = instanciou como método 
            //Fim
            linhas.Add("titulo, nota");
            foreach (TodoItem item in lista) {
                //Concatenação = juntar
                string titulo = "\"" + item.Titulo + "\"";
                string nota = "\"" + item.Nota + "\"";
                linhas.Add (titulo + "," + nota);
            }
            string tryAgain = "n";
            do {
                try {
                    File.WriteAllLines (@path, linhas);
                    tryAgain = "n";
                } catch (IOException e) {
                    System.Console.WriteLine ("Erro na leitura do arquivo.");
                    System.Console.WriteLine (e.Message);
                    do {
                        System.Console.WriteLine ("Deseja tentar novamente (S/N)?");
                        tryAgain = Console.ReadLine ().ToLower ();

                        if ((tryAgain != "n") || (tryAgain != "s")) {
                            System.Console.WriteLine ("Opção inválida");
                        }
                    } while ((tryAgain == "s") || (tryAgain == "n"));
                }
            } while(tryAgain != "n");
        }
    }
}