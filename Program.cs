using System;

namespace CRUD.Produto
{
    class Program
    {
        static ProdutoRepositorio repositorio = new ProdutoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarProduto();
						break;
					case "2":
						InserirProduto();
						break;
					case "3":
						AtualizarProduto();
						break;
					case "4":
						ExcluirProduto();
						break;
					case "5":
						VisualizarProduto();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirProduto()
		{
			Console.Write("Digite o id do produto: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarProduto()
		{
			Console.Write("Digite o id do produto: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			var produto = repositorio.RetornaPorId(indiceProduto);

			Console.WriteLine(produto);
		}

        private static void AtualizarProduto()
		{
			Console.Write("Digite o id do produto: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Setor)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Setor), i));
			}
			Console.Write("Digite o setor entre as opções acima: ");
			int entradasetor = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do Produto: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Ano de validade do Produto: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Produto: ");
			string entradaDescricao = Console.ReadLine();

			Produto atualizaProduto = new Produto(id: indiceProduto,
										setor: (Setor)entradasetor,
										nome: entradaNome,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceProduto, atualizaProduto);
		}
        private static void ListarProduto()
		{
			Console.WriteLine("Listar Produtos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Produto cadastrado.");
				return;
			}

			foreach (var produto in lista)
			{
                var excluido = produto.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", produto.retornaId(), produto.retornaNome(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirProduto()
		{
			Console.WriteLine("Inserir novo Produto");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Setor)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Setor), i));
			}
			Console.Write("Digite o setor entre as opções acima: ");
			int entradasetor = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do Produto: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Ano de validade do Produto: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Produto: ");
			string entradaDescricao = Console.ReadLine();

			Produto novoProduto = new Produto(id: repositorio.ProximoId(),
										setor: (Setor)entradasetor,
										nome: entradaNome,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoProduto);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("SUPERMERCADO!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Produtos");
			Console.WriteLine("2- Inserir novo Produto");
			Console.WriteLine("3- Atualizar Produtos");
			Console.WriteLine("4- Excluir Produto");
			Console.WriteLine("5- Visualizar Produtos");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}