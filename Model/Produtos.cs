using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_final_bloco_01.Model
{
    public abstract class Produto
    {
        private float preco;
        private string nomeProduto;
        private int id, tipo;

        public Produto(float preco, string nomeProduto, int id, int tipo)
        {
            this.preco = preco;
            this.nomeProduto = nomeProduto;
            this.id = id;
            this.tipo = tipo;
        }

        public float GetPreco() 
        { 
            return preco; 
        }

        public void SetPreco(float preco) 
        { 
            this.preco = preco; 
        }

        public string GetNomeDoProduto() 
        { 
            return nomeProduto; 
        }

        public void SetNomeDoProduto(string nomeDoProduto) 
        { 
            this.nomeProduto = nomeProduto; 
        }

        public int GetId() 
        { 
            return id; 
        }

        public void SetId(int id) 
        { 
            this.id = id; 
        }

        public int GetTipo() 
        { 
            return tipo; 
        }

        public void SetTipo(int tipo) 
        { 
            this.tipo = tipo; 
        }

        public virtual void Visualizar()
        {
            string tipo = "";

            switch (this.tipo)
            {
                case 1:
                    tipo = "Roupa";
                    break;
                case 2:
                    tipo = "Calçado";
                    break;
            }
            Console.WriteLine("Dados do Produto:");
            Console.WriteLine("**********************");
            Console.WriteLine("Id: " + this.id);
            Console.WriteLine("Nome: " + this.nomeProduto);
            Console.WriteLine("Preço: " + (this.preco).ToString(format: "C"));
            Console.WriteLine("Tipo: " + tipo);
        }
    }
}