using projeto_final_bloco_01.Model;
using projeto_final_bloco_01.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final_bloco_01.Controller
{
    public class ProdutoController : IProdutoRepository
    {
        private readonly List<Produto> listaProduto = new List<Produto>();
        int numero = 0;
        public void Atualizar(Produto produto)
        {
            var procurarProduto = BuscarNaCollection(produto.GetId());

            if (procurarProduto is not null)
            {
                var index = listaProduto.IndexOf(procurarProduto);

                listaProduto[index] = produto;

                Console.WriteLine($"O Produto do Id {produto.GetId()} foi atualizado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"O Produto do Id {produto.GetId()} não foi encontrado!");
                Console.ResetColor();
            }
        }

        public void ConsultaProdutoID(int numero)
        {
            var produto = BuscarNaCollection(numero);
            if (produto is not null)
            {
                produto.Visualizar();
            }
            else
            {
                Console.WriteLine($"O Produto do Id {numero} não foi encontrado");
                Console.ResetColor();
            }
        }

        public void CriarProduto(Produto produto)
        {
            listaProduto.Add(produto);
            Console.WriteLine($"O Produto com Id {produto.GetId()} foi criado com sucesso!");
        }

        public void Deletar(int numero)
        {
            var produto = BuscarNaCollection(numero);

            if (produto is not null)
            {
                if (listaProduto.Remove(produto) == true)
                    Console.WriteLine($"O produto do Id {numero} foi removido com sucesso!");
            }
            else
            {
                Console.WriteLine($"O produto do Id {numero} não foi encontrado!");
                Console.ResetColor();
            }
        }

        public void ListarTodosProdutos()
        {
            if (listaProduto.Count() > 0)
            {
                foreach (var produto in listaProduto)
                {
                    produto.Visualizar();
                }

            }
            else
            {
                Console.WriteLine("Sem produtos");
            }
        }

        public int GerarNumero()
        {
            return ++numero;
        }

        public Produto? BuscarNaCollection(int numero)
        {
            foreach (var produto in listaProduto)
            {
                if (produto.GetId() == numero)
                    return produto;
            }
            return null;
        }
    }

    public interface IProdutoRepository
    {
    }
}