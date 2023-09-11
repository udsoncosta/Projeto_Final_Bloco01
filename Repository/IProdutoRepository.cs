using projeto_final_bloco_01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final_bloco_01.Repository
{
    public interface IProdutoInterface
    {
        //Métodos CRUD
        public void CriarProduto(Produto produto);
        public void ListarTodosProdutos();
        public void ConsultarProduto(int numero);
        public void Atualizar(Produto produto);
        public void Remover(int numero);
    }
}