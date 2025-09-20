using ScreenSound.Menus;
using ScreenSound.Modelos;

Band beatles = new("the Beatles");
beatles.AddRating(new Rating(10));
beatles.AddRating(new Rating(8));
beatles.AddRating(new Rating(6));

Dictionary<string, Band> registeredBands = new();
registeredBands.Add(beatles.Name, beatles);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegisterBand());
opcoes.Add(2, new MenuRegisterAlbum());
opcoes.Add(3, new MenuShowRegisteredBands());
opcoes.Add(4, new MenuRateBand());
opcoes.Add(5, new MenuRateAlbum());
opcoes.Add(6, new MenuShowDetails());
opcoes.Add(-1, new MenuExit());

void ShowLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}
void ShowMenuOptions()
{
    ShowLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para avaliar um álbum");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuToShow = opcoes[opcaoEscolhidaNumerica];
        menuToShow.Execute(registeredBands);
        if (opcaoEscolhidaNumerica > 0 )
        {
            ShowMenuOptions();
        }
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }

}

ShowMenuOptions();