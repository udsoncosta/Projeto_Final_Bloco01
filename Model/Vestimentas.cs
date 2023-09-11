using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final_bloco_01.Model
{
    public class Vestimenta : Produto
    {
        private string tecido, tamanho;
        public Vestimenta(float preco, string nomeProduto, int id, int tipo, string tecido, string tamanho) :
            base(preco, nomeProduto, id, tipo)
        {
            this.tecido = tecido;
            this.tamanho = tamanho;
        }

        public string GetTecido() 
        { 
            return this.tecido; 
        }

        public void SetCor(string cor) 
        { 
            this.tecido = tecido; 
        }

        public string GetTamanho() 
        { 
            return this.tamanho; 
        }

        public void SetTamanho(string tamanho) 
        { 
            this.tamanho = tamanho; 
        }

        public override void Visualizar()
        {
            base.Visualizar();
            Console.WriteLine("Cor do produto: " + this.tecido);
            Console.WriteLine("Tamanho do produto: " + this.tamanho);
        }
    }
}