bool continuar = true;

const int FACIL = 1;
const int MEDIO = 2;
const int DIFICIL = 3;
const int SAIR = 4;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("--- Jogo do Adivinha ---\n");
    Console.WriteLine("Escolha o nível de dificuldade");
    Console.WriteLine("[1] Fácil = 15 chances");
    Console.WriteLine("[2] Médio = 10 chances");
    Console.WriteLine("[3] Difícil = 5 chances");
    Console.WriteLine("[4] Sair do Jogo");

    int dificuldade = Convert.ToInt32(Console.ReadLine());

    int chances = 0;

    switch (dificuldade)
    {
        case FACIL:
            chances = 15;
            break;

        case MEDIO:
            chances = 10;
            break;

        case DIFICIL:
            chances = 5;
            break;

        case SAIR:
            continuar = false;
            break;

        default:
            Console.WriteLine("Opção Inválida!");
            Console.ReadKey();
            continue;
    }

    if (continuar == false)
        break;

    Random random = new Random();
    int numeroSorteado = random.Next(1, 20);

    int pontuacaoInicial = 1000;

    for (int i = 1; i <= chances; i++)
    {
        Console.Clear();
        Console.WriteLine($"Tentativa {i} de {chances}.\n");

        Console.WriteLine($"Qual o seu {i}º chute.\n");

        int numeroChutado = Convert.ToInt32(Console.ReadLine());

        if (numeroSorteado != numeroChutado)
        {
            if (numeroChutado < numeroSorteado)
            {
                Console.WriteLine("Seu chute foi menor que o número secreto.");
            }
            if (numeroChutado > numeroSorteado)
            {
                Console.WriteLine("Seu chute foi maior que o número secreto.");
            }

            pontuacaoInicial -= CalcularPontos(numeroChutado, numeroSorteado);
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"\nParabéns voçe acertou o Nr {numeroSorteado}");
            Console.WriteLine($"Voçe fez {pontuacaoInicial} pontos.\n");
            break;
        }

        if (i == chances)
        {
            Console.Clear();
            Console.WriteLine($"Fim de jogo voçe fez {pontuacaoInicial} pontos.\n");
        }

        Console.ReadKey();
    }

    JogarNovamente();
}


int CalcularPontos(int numeroChutado, int numeroSorteado)
{
    return Math.Abs((numeroChutado - numeroSorteado) / 2);
}

void JogarNovamente()
{
    Console.WriteLine("Deseja jogar novamente [1] Sim [2] Não");
    var opcao = Console.ReadLine();

    if (opcao == "2")
        continuar = false;
}

