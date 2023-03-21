/*Desenvolva um jogo de adivinhação. O computador pensará em um número, e você, jogador, precisará adivinhá-lo.
A cada erro, a máquina lhe dirá se o número chutado foi maior ou menor do que o pensado. Você também poderá
escolher o nível de dificuldade do jogo, e isso lhe dará mais ou menos oportunidades de chutar um número. Ao
final, se você ganhar, o computador lhe dirá quantos pontos você fez, baseando-se em quão bons eram seus
chutes.*/

bool continuar = true;
const int FACIL = 1;
const int MEDIO = 2;
const int DIFICIL = 3;
const int SAIR = 4;
const int NUMERO_MAXIMO = 20;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("--- Jogo de Adivinhação ---\n");
    Console.WriteLine("Escolha o nível de dificuldade\n");
    Console.WriteLine("[1] Fácil = 15 chances");
    Console.WriteLine("[2] Médio = 10 chances");
    Console.WriteLine("[3] Difícil = 5 chances");
    Console.WriteLine("[4] Sair do Jogo\n");
    Console.Write("=> ");

    int dificuldade = Convert.ToInt32(Console.ReadLine());
    string nivel = "";
    int chances = 0;

    switch (dificuldade)
    {
        case FACIL:
            chances = 15;
            nivel = "FÁCIL";
            break;

        case MEDIO:
            chances = 10;
            nivel = "MÉDIO";
            break;

        case DIFICIL:
            chances = 5;
            nivel = "DIFÍCIL";
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
    int numeroSorteado = random.Next(1, NUMERO_MAXIMO);

    int pontuacaoInicial = 1000;

    for (int i = 1; i <= chances; i++)
    {
        Console.Clear();
        Console.WriteLine($"Tentativa {i} de {chances}. Nível: {nivel}\n");

        Console.WriteLine($"Qual o seu {i}º chute?\n");

        int numeroChutado = Convert.ToInt32(Console.ReadLine());



        if (numeroSorteado != numeroChutado)
        {
            if (numeroChutado > NUMERO_MAXIMO)
            {
                Console.WriteLine($"\nUma dica: O número máximo é: {NUMERO_MAXIMO}"); 
            }
            if (numeroChutado < numeroSorteado && numeroChutado <= NUMERO_MAXIMO)
            {
                Console.WriteLine("Seu chute foi menor que o número secreto.");
            }
            if (numeroChutado > numeroSorteado && numeroChutado <= NUMERO_MAXIMO)
            {
                Console.WriteLine("Seu chute foi maior que o número secreto.");
            }

            pontuacaoInicial -= CalcularPontos(numeroChutado, numeroSorteado);
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"\nParabéns, você acertou! Nr - {numeroSorteado}");
            Console.WriteLine($"\nVocê fez {pontuacaoInicial} pontos.\n\nTecle para continuar...");
            Console.ReadKey();
            break;
        }

        if (i == chances)
        {
            Console.Clear();
            Console.WriteLine($"Fim de jogo! Você fez {pontuacaoInicial} pontos.\n");
            Console.WriteLine($"O número secreto era: {numeroSorteado}");
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
    Console.Clear();
    Console.WriteLine("Deseja jogar novamente? [1] Sim [2] Não");
    var opcao = Console.ReadLine();

    if (opcao == "2")
        continuar = false;
}




