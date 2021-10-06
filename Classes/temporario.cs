// using System;

// namespace DIO.Series
// {
//     class ChamaFilme
//     {
//         static FilmeRepositorio repositorio = new FilmeRepositorio();
//         static void Main(string[] args)
//         {
//             string opcaoUsuarioFil = ObterOpcaoUsuarioFil();

//             while (opcaoUsuarioFil.ToUpper() != "X")
//             {
//                 switch (opcaoUsuarioFil)
//                 {
//                     case "6":
//                         ListarFilme();
//                         break;
//                     case "7":
//                         InserirFilme();
//                         break;
//                     case "8":
//                         AtualizarFilme();
//                         break;
//                     case "9":
//                         ExcluirFilme();
//                         break;
//                     case "10":
//                         VisualizarFilme();
//                         break;
//                     case "C":
//                         Console.Clear();
//                         break;

//                     default:
//                         throw new ArgumentOutOfRangeException();
//                 }

//                 opcaoUsuarioFil = ObterOpcaoUsuarioFil();
//             }

//             Console.WriteLine("Obrigado por utilizar nossos serviços.");
//             Console.ReadLine();
//         }

//         private static void ExcluirFilme()
//         {
//             Console.WriteLine("Tem certeza que deseja excluir Filme?");
//             Console.WriteLine("sim ou não");
//             string ctz = Console.ReadLine();
            
//             switch (ctz)
//             { 
//                 case ("sim"):
//                     Console.Write("Digite o ID da série: ");
//                     int indiceFilme = int.Parse(Console.ReadLine());

//                     repositorio.Exclui(indiceFilme); 

//                     Console.WriteLine();
//                     Console.WriteLine("Exclusão bem sucedida!");
//                     break;

//                 case ("não"):
//                     Console.WriteLine();
//                     Console.WriteLine("OK!");
//                     break;

//                 default:
//                     Console.WriteLine();
//                     Console.WriteLine("Essa opção é invalida. tente sim ou não, tudo em minusculo.");
//                     break;

//             }
            
//         }

//         private static void VisualizarFilme()
//         {
//             Console.Write("Digite o ID do filme: ");
//             int indiceFilme = int.Parse(Console.ReadLine());

//             var filme = repositorio.RetornaPorId(indiceFilme);

//             Console.WriteLine(filme);
//         }

//         private static void AtualizarFilme()
//         {
//             Console.WriteLine("Digite o ID do filme: ");
//             int indiceFilme = int.Parse(Console.ReadLine());

//             foreach (int i in Enum.GetValues(typeof(Genero)))
//             {
//                 Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
//             }
//             Console.WriteLine("Digite o gênero entre as opções a cima: ");
//             int entradaGenero = int.Parse(Console.ReadLine());
//             Console.WriteLine("Digite o Título da série: ");
//             string entradaTitulo = Console.ReadLine();
//             Console.WriteLine("Digite o ano de início da série: ");
//             int entradaAno = int.Parse(Console.ReadLine());
//             Console.WriteLine("Digite a descrição da série: ");
//             string entradaDescricao = Console.ReadLine();
            
//             Filme atualizaFilme = new Filme(id: indiceFilme,
//                                         genero: (Genero)entradaGenero,
//                                         titulo: entradaTitulo,
//                                         ano: entradaAno,
//                                         descricao: entradaDescricao);
//             repositorio.Atualiza(indiceFilme, atualizaFilme);

//         }

//         private static void ListarFilme()
//         {
//             Console.WriteLine("Listar séries");

//             var lista = repositorio.Lista();

//             if (lista.Count == 0)
//             {
//                 Console.WriteLine("Nenhuma série cadastrada.");
//                 return;
//             }

//             foreach (var filme in lista)
//             {
//                 var excluido = filme.retornaExcluido();
//                     Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluido*" : "")); 
//             } //Quando trabalhar com banco de dados não se deve reaproveitar um ID que já foi usado, não é uma boa prática
//         }

//         private static void InserirFilme()
//         {
//             Console.WriteLine("Inserir nova série");

//             foreach (int i in Enum.GetValues(typeof(Genero)))
//             {
//                 Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
//             }
//             Console.WriteLine("Digite o gênero entre as opções a cima: ");
//             int entradaGenero = int.Parse(Console.ReadLine());
//             Console.WriteLine("Digite o Título da série: ");
//             string entradaTitulo = Console.ReadLine();
//             Console.WriteLine("Digite o ano de início da série: ");
//             int entradaAno = int.Parse(Console.ReadLine());
//             Console.WriteLine("Digite a descrição da série: ");
//             string entradaDescricao = Console.ReadLine();

//             Filme novaFilme = new Filme(id: repositorio.ProximoId(), 
//                                         genero: (Genero)entradaGenero,
//                                         titulo: entradaTitulo,
//                                         ano: entradaAno,
//                                         descricao: entradaDescricao);
//             repositorio.Insere(novaFilme);
//         }

//         private static string ObterOpcaoUsuarioFil()
//         {
//             Console.WriteLine();
//             Console.WriteLine("DIO Series e filmes a seu dispor!!!");
//             Console.WriteLine("Informe a opção desejada:");

//             Console.WriteLine("6- Listar filmes");
//             Console.WriteLine("7- Inserir nova filme");
//             Console.WriteLine("8- Atualizar filme");
//             Console.WriteLine("9- Excluir filme");
//             Console.WriteLine("10- Visualizar filme");
//             Console.WriteLine("C- Limpar tela");
//             Console.WriteLine("X- Sair");
//             Console.WriteLine();

//             string opcaoUsuarioFil = Console.ReadLine().ToUpper();
//             Console.WriteLine();
//             return opcaoUsuarioFil;
//         }
//     }
// }