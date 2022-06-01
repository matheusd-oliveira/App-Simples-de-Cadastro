SerieRepositorio repositorio = new SerieRepositorio();

string opcaoUsuario = obterOpcaoUsuario();

while (opcaoUsuario.ToUpper() != "X")
{
    switch (opcaoUsuario)
    {
        case "1":
            ListarSeries();
            break;
        case "2":
            InserirSerie();
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
        case "C":
            Console.Clear();
            break;

        default:
            throw new ArgumentOutOfRangeException();
    }

    opcaoUsuario = obterOpcaoUsuario();
}
Console.WriteLine("Obrigado por utilizar nossos serviços.");
Console.ReadLine();



// Métodos: 

static string obterOpcaoUsuario()
{
    Console.WriteLine();
    Console.WriteLine("DIO Séries a seu dispor!!!");
    Console.WriteLine("Informe a opção desejada:");

    Console.WriteLine("1- Listar séries");
    Console.WriteLine("2- Inserir nova série");
    Console.WriteLine("3- Atualizar série");
    Console.WriteLine("4- Excluir série");
    Console.WriteLine("5- Visualizar série");
    Console.WriteLine("C- Limpar Tela");
    Console.WriteLine("X- Sair");
    Console.WriteLine();

    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
}

void ListarSeries()
{

    Console.WriteLine("Listar Séries");

    var lista = repositorio.List();

    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhuma série cadastrada. ");
        return;
    }

    foreach (var serie in lista)
    {
        var excluido = serie.retornaExcluido();

        Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
    }
}


void InserirSerie()
{
    Console.WriteLine("Inserir nova série");

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
    }
    Console.Write("Digite o gênero entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.Write("Digite o Título da Série: ");
    string entradaTitulo = Console.ReadLine();

    Console.Write("Digite o Ano de Início da Série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    Console.Write("Digite a Descrição da Série: ");
    string entradaDescricao = Console.ReadLine();

    Series novaSerie = new Series(Id: repositorio.ProximoId(),
                                genero: (Genero)entradaGenero,
                                titulo: entradaTitulo,
                                ano: entradaAno,
                                descricao: entradaDescricao);

    repositorio.Insere(novaSerie);
}

void ExcluirSerie()
{
    Console.Write("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    repositorio.Exclui(indiceSerie);
}

void VisualizarSerie()
{
    Console.Write("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    var serie = repositorio.RetornaPorId(indiceSerie);

    Console.WriteLine(serie);
}

void AtualizarSerie()
{
    Console.Write("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
    // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
    }
    Console.Write("Digite o gênero entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.Write("Digite o Título da Série: ");
    string entradaTitulo = Console.ReadLine();

    Console.Write("Digite o Ano de Início da Série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    Console.Write("Digite a Descrição da Série: ");
    string entradaDescricao = Console.ReadLine();

    Series atualizaSerie = new Series(Id: indiceSerie,
                                genero: (Genero)entradaGenero,
                                titulo: entradaTitulo,
                                ano: entradaAno,
                                descricao: entradaDescricao);

    repositorio.Atualiza(indiceSerie, atualizaSerie);
}


