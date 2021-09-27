using System;

namespace CRUD.Produto
{
    public class Produto : EntidadeBase
    {

		private Setor Setor { get; set; }
		private string Nome { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

		public Produto(int id, Setor setor, string nome, string descricao, int ano)
		{
			this.Id = id;
			this.Setor = setor;
			this.Nome = nome;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			
            string retorno = "";
            retorno += "Gênero: " + this.Setor + Environment.NewLine;
            retorno += "Titulo: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaNome()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}