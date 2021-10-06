using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositoriofilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        ListarFilme();
                        break;
                    case "7":
                        InserirFilme();
                        break;
                    case "8":
                        AtualizarFilme();
                        break;
                    case "9":
                        ExcluirFilme();
                        break;
                    case "10":
                        VisualizarFilme();
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

        private static void ExcluirSerie()
        {
            Console.WriteLine("Tem certeza que deseja excluir serie?");
            Console.WriteLine("sim ou não");
            string ctz = Console.ReadLine();
            
            switch (ctz)
            { 
                case ("sim"):
                    Console.Write("Digite o ID da série: ");
                    int indiceSerie = int.Parse(Console.ReadLine());

                    repositorio.Exclui(indiceSerie); 

                    Console.WriteLine();
                    Console.WriteLine("Exclusão bem sucedida!");
                    break;

                case ("não"):
                    Console.WriteLine();
                    Console.WriteLine("OK!");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Essa opção é invalida. tente sim ou não, tudo em minusculo.");
                    break;

            }
            
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            
            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : "")); 
            } //Quando trabalhar com banco de dados não se deve reaproveitar um ID que já foi usado, não é uma boa prática
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine("Tem certeza que deseja excluir Filme?");
            Console.WriteLine("sim ou não");
            string ctz = Console.ReadLine();
            
            switch (ctz)
            { 
                case ("sim"):
                    Console.Write("Digite o ID do filme: ");
                    int indiceFilme = int.Parse(Console.ReadLine());

                    repositoriofilme.Exclui(indiceFilme); 

                    Console.WriteLine();
                    Console.WriteLine("Exclusão bem sucedida!");
                    break;

                case ("não"):
                    Console.WriteLine();
                    Console.WriteLine("OK!");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Essa opção é invalida. tente sim ou não, tudo em minusculo.");
                    break;

            }
            
        }

        private static void VisualizarFilme()
        {
            Console.Write("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositoriofilme.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano de estréia do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();
            
            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositoriofilme.Atualiza(indiceFilme, atualizaFilme);

        }

        private static void ListarFilme()
        {
            Console.WriteLine("Listar filmes");

            var lista = repositoriofilme.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                    Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : "")); 
            } //Quando trabalhar com banco de dados não se deve reaproveitar um ID que já foi usado, não é uma boa prática
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano de estréia do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novaFilme = new Filme(id: repositorio.ProximoId(), 
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositoriofilme.Insere(novaFilme);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Filmes e Series a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1- Listar séries          6- Listar filmes");
            Console.WriteLine("2- Inserir nova série     7- Inserir novo filme");
            Console.WriteLine("3- Atualizar Série        8- Atualizar filme");
            Console.WriteLine("4- Excluir série          9- Excluir filme");
            Console.WriteLine("5- Visualizar série       10- Visualizar filme");
            Console.WriteLine("//////////////////////////////////////////////");
            Console.WriteLine();

            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
