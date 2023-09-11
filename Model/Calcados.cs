using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final_bloco_01.Model
{
    public class Calcado : Produto
    {
        private int tamanho;
        public Calcado(float preco, string nomeProduto, int id, int tipo, int tamanho) : base(preco, nomeProduto, id, tipo)
        {
            this.tamanho = tamanho;
        }

        public int GetTamanhoCalcado() { return tamanho; }
        public void SetTamanhoCalcado(int tamanhoCalcado) { this.tamanho = tamanhoCalcado; }

        public override void Visualizar()
        {
            base.Visualizar();
            Console.WriteLine("Tamanho do calçado: " + this.tamanho);
        }
    }
}