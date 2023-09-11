using projeto_final_bloco_01.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using projeto_final_bloco_01.Controller;
using System.Text.RegularExpressions;

namespace projeto_final_bloco_01
{
    public class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao, tipo, numero, tamCalcado;
            string? nome, tamRoupa, tecido;
            float preco;

            ProdutoController produtos = new();

            //Produtos Pré-Cadastrados
            Vestimenta v1 = new Vestimenta(90, "Calça", produtos.GerarNumero(), 1, "Jeans", "G");
            produtos.CriarProduto(v1);

            Calcado c1 = new Calcado(120, "Tênis", produtos.GerarNumero(), 2, 44);
            produtos.CriarProduto(c1);

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n*******************************************");
                Console.WriteLine("                                             ");
                Console.WriteLine("               Calçados & Cia                ");
                Console.WriteLine("                                             ");
                Console.WriteLine("*********************************************");
                Console.WriteLine("                                             ");
                Console.WriteLine("         1 - Cadastrar Produto               ");
                Console.WriteLine("         2 - Listar todos os Produtos        ");
                Console.WriteLine("         3 - Consultar Produto por Id        ");
                Console.WriteLine("         4 - Atualizar Produto               ");
                Console.WriteLine("         5 - Remover Produto                 ");
                Console.WriteLine("         6 - Sair                            ");
                Console.WriteLine("                                             ");
                Console.WriteLine("*********************************************");
                Console.WriteLine("                                             ");
                Console.WriteLine("Entre com a opção desejada:                  ");
                Console.WriteLine("                                             ");
                Console.ResetColor();

                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nDigite um valor inteiro entre 1 e 6");
                    opcao = 0;
                    Console.ResetColor();
                }

                if (opcao == 6)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nObrigado pela sua compra, volte sempre!");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }

                switch (opcao)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Cadastrar Produto: \n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o nome do Produto: ");
                        nome = Console.ReadLine();
                        nome ??= string.Empty;

                        Console.WriteLine("Digite o preço do Produto: ");
                        preco = Convert.ToSingle(Console.ReadLine());

                        do
                        {
                            Console.WriteLine("Digite o tipo do Produto: ");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1 && tipo != 2);

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite o tamanho do produto: ");
                                tamRoupa = Console.ReadLine();

                                Console.WriteLine("Digite o tipo de tecido do produto: ");
                                tecido = Console.ReadLine();

                                tamRoupa ??= string.Empty;
                                produtos.CriarProduto(new Vestimenta(preco, nome, produtos.GerarNumero(), tipo, tecido, tamRoupa));
                                break;

                            case 2:
                                Console.WriteLine("Digite o tamanho do produto: ");
                                tamCalcado = Convert.ToInt32(Console.ReadLine());

                                produtos.CriarProduto(new Calcado(preco, nome, produtos.GerarNumero(), tipo, tamCalcado));
                                break;
                        }
                        Keypress();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Listar todos os Produtos\n");
                        Console.ResetColor();

                        produtos.ListarTodosProdutos();

                        Keypress();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Consultar Produto por Id\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o Id do produto: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        produtos.ConsultaProdutoID(numero);

                        Keypress();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Atualizar dados do produto\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o Id do produto: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var produto = produtos.BuscarNaCollection(numero);

                        if (produto is not null)
                        {
                            Console.WriteLine("Digite o nome do produto: ");
                            nome = Console.ReadLine();

                            Console.WriteLine("Digite o preço do produto ");
                            preco = Convert.ToSingle(Console.ReadLine());

                            nome ??= string.Empty;

                            tipo = produto.GetTipo();

                            switch (tipo)
                            {
                                case 1:
                                    Console.WriteLine("Digite o tamanho do produto: ");
                                    tamRoupa = Console.ReadLine();

                                    Console.WriteLine("Digite o tipo de tecido do produto: ");
                                    tecido = Console.ReadLine();

                                    tamRoupa ??= string.Empty;
                                    produtos.Atualizar(new Vestimenta(preco, nome, produto.GetId(), tipo, tecido, tamRoupa));
                                    break;

                                case 2:
                                    Console.WriteLine("Digite o tamanho do produto: ");
                                    tamCalcado = Convert.ToInt32(Console.ReadLine());

                                    produtos.Atualizar(new Calcado(preco, nome, produto.GetId(), tipo, tamCalcado));
                                    break;
                            }
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"o Id do produto {numero} não foi encontrado!");
                            Console.ResetColor();
                        }


                        Keypress();
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Remover Produto\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o Id do produto para remover: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        produtos.Deletar(numero);

                        Keypress();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção Inválida!\n");
                        Console.ResetColor();

                        Keypress();
                        break;

                }

                static void Sobre()
                {
                    Console.WriteLine("\n**********************************************");
                    Console.WriteLine("                                                ");
                    Console.WriteLine("      Projeto desenvolvido por: Udson Costa     ");
                    Console.WriteLine("         udsoncostasantana@gmail.com            ");
                    Console.WriteLine(            "github.com/udsoncosta               ");
                    Console.WriteLine("                                                ");
                    Console.WriteLine("************************************************");
                }

                static void Keypress()
                {
                    do
                    {
                        Console.Write("Pressione ENTER para continuar");
                        consoleKeyInfo = Console.ReadKey();
                    } 
                    
                    while (consoleKeyInfo.Key != ConsoleKey.Enter);
                }

            }
        }

    }
}