bool Continuar = true;

Console.Clear();
System.Console.WriteLine("Jogo do Adivinha\n");

while (Continuar)
{
    Console.Clear();
    Console.WriteLine("Escolha o nível de dificuldade");
    Console.WriteLine("[1] Fácil = 15 chances");
    Console.WriteLine("[2] Médio = 10 chances");
    Console.WriteLine("[3] Difícil = 5 chances");

    int dificuldade = Convert.ToInt32(Console.ReadLine());

    int chances = 0;

    switch (dificuldade)
    {
        case 1:
            chances = 15;
            break;

        case 2:
            chances = 10;
            break;

        case 3:
            chances = 5;
            break;

        default:
            Console.WriteLine("Opção Inválida!");
            Console.ReadKey();
            continue;
    }

    Random random = new Random();
    int numeroSorteado = random.Next(1, 20);

    int pontuacaoInicial = 1000;

    for (int i = 1; i < chances; i++)
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
                Console.WriteLine("Seu numero foi maior que o numero secreto.");
            }

            pontuacaoInicial -= CalcularPontos(numeroChutado, numeroSorteado);

            Console.WriteLine($"Voçe fez {pontuacaoInicial} pontos.");

        }
        else
        {
            Console.WriteLine("Parabens voçê acertou!!!");
            break;
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
        Continuar = false;
}

