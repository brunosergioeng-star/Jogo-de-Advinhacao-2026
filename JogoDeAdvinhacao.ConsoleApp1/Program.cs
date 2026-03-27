using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("------  Jogo de Adivinhação ------");
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("------ Nível de dificuldade: -----");
                Console.WriteLine("----------------------------------\n");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1 - Fácil (10 tentativas)");
                Console.WriteLine("2 - Normal (5 tentativas)");
                Console.WriteLine("3 - Difícil (3 tentativas)");
                Console.WriteLine("----------------------------------");

                Console.Write("Digite sua escolha: ");
                string escolhaDificuldade = Console.ReadLine();

                int totalDasTentativas = 0;
                if (escolhaDificuldade == "1")
                    totalDasTentativas = 10;

                else if (escolhaDificuldade == "2")
                    totalDasTentativas = 5;

                else
                    totalDasTentativas = 3;

                Random geradorDeNumeros = new Random();

                int numeroAleatorio = geradorDeNumeros.Next(1, 21);

                int[] numerosChutados = new int[100];
                int contadorNumerosChutados = 0;

                int pontuacao = 1000;

                for (int tentativa = 1; tentativa <= totalDasTentativas; tentativa++)
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Tentativa {tentativa} de {totalDasTentativas}");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Pontuação: " + pontuacao + " pontos");
                    Console.WriteLine("--------------------------------------------");
                    Console.Write("Números já chutados: ");

                    for (int i = 0; i < numerosChutados.Length; i++)
                    {
                        if (numerosChutados[i] > 0)
                            Console.Write(numerosChutados[i] + " ");
                    }

                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------");

                    int numeroDigitado;
                    bool numeroRepetido;

                    do
                    {
                        numeroRepetido = false;

                        Console.Write("Digite um número (de 1 a 20) para chutar: ");
                        numeroDigitado = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < numerosChutados.Length; i++)
                        {
                            if (numerosChutados[i] == numeroDigitado)
                            {
                                Console.WriteLine("Número já digitado! Pressione ENTER para digitar um novo número...");
                                Console.ReadLine();

                                numeroRepetido = true;
                                break;
                            }
                        }
                    }
                    while (numeroRepetido == true);

                    numerosChutados[contadorNumerosChutados] = numeroDigitado;
                    contadorNumerosChutados++;

                    if (numeroDigitado == numeroAleatorio)
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Parabéns, você acertou!");
                        Console.WriteLine("--------------------------------------------");
                        break;
                    }
                    else if (numeroDigitado > numeroAleatorio)
                    {
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("\n--- O número digitado foi maior que o número secreto! ---");
                        Console.WriteLine("---------------------------------------------------------");

                        pontuacao -= Math.Abs((numeroDigitado - numeroAleatorio) / 2);
                    }
                    else
                    {
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("--- O número digitado foi menor que o número secreto! ---");
                        Console.WriteLine("---------------------------------------------------------");

                        pontuacao -= Math.Abs((numeroDigitado - numeroAleatorio) / 2);
                    }

                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }

                Console.Write("Deseja continuar? (S/N): ");
                string opcaoContinuar = Console.ReadLine().ToUpper();

                if (opcaoContinuar != "S")
                    break;
            }
        }
    }
}