using System.Text.RegularExpressions;

namespace Exercicios;

public class Program
{
    public static void Main(string[] args)
    {
        int escolha = 0;

        while (escolha != 7)
        {
            Console.WriteLine("1. Bem-Vindo");
            Console.WriteLine("2. Nome Completo");
            Console.WriteLine("3. Calculos");
            Console.WriteLine("4. Quantidade de Caracteres em uma String");
            Console.WriteLine("5. Placa de Carro");
            Console.WriteLine("6. Formatação da Data Atual");
            Console.WriteLine("7. Sair");
            Console.Write("Escolha uma Opção: ");

            string? entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out escolha))
            {
                escolha = 0;
            }

            Console.Clear();

            switch (escolha)
            {
                case 1:
                    Questao1();
                    Console.WriteLine();
                    break;
                case 2:
                    Questao2();
                    Console.WriteLine();
                    break;
                case 3:
                    Questao3();
                    Console.WriteLine();
                    break;
                case 4:
                    Questao4();
                    Console.WriteLine();
                    break;
                case 5:
                    Questao5();
                    Console.WriteLine();
                    break;
                case 6:
                    Questao6();
                    Console.WriteLine();
                    break;
                case 7:
                    Console.WriteLine("Encerrando Programa...");
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }

        }
    }

    public static void Questao1()
    {
        Console.Write("Digite o seu nome: ");
        string? input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Bem vindo " + input + "!");
        }
        else
        {
            Console.WriteLine("Nenhum valor inserido!");
        }
    }

    public static void Questao2()
    {
        Console.Write("Digite seu primeiro nome: ");
        string? nome = Console.ReadLine();
        Console.Write("Digite seu sobrenome: ");
        string? sobrenome = Console.ReadLine();

        string nomeCompleto = nome + " " + sobrenome;

        Console.WriteLine(nomeCompleto);
    }

    public static void Questao3()
    {
        var q = new Questao3();
        q.Calculos();
    }

    public static void Questao4()
    {
        Console.Write("Digite uma string qualquer: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("String nula");
        }
        else
        {
            Console.Write("Quantidade de caracteres na string: " + input?.Replace(" ", "").Length);
        }
    }

    public static void Questao5()
    {
        Console.WriteLine("Digite uma placa de com os seguintes padrões:");
        Console.WriteLine("1. Deve conter 7 caracteres alfanuméricos");
        Console.WriteLine("2. Os três primeiros precisam ser letras (maiúsculas ou minúsculas)");
        Console.WriteLine("3. Os quatro últimos devem ser números");
        Console.Write("Digite a placa a seguir: ");

        string? input = Console.ReadLine();

        string pattern = "^[a-zA-Z]{3}[0-9]{4}$";

        Regex rg = new(pattern);

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Nenhum valor inserido!");
            return;
        }

        input = input.Trim();

        if (rg.IsMatch(input))
        {
            Console.WriteLine($"Placa válida: {input.ToUpper()}");
        }
        else
        {
            Console.WriteLine($"Placa Inválida: {input.ToUpper()}");
        }
    }

    public static void Questao6()
    {
        int escolha = 0;
        while (escolha != 5)
        {
            Console.WriteLine("1. Data formato completo ");
            Console.WriteLine("2. Data formato \"XX/XX/XXXX\"");
            Console.WriteLine("3. Apenas Hora no formato 24h");
            Console.WriteLine("4. Data com mês por extenso");
            Console.WriteLine("5. Encerrar");
            Console.Write("Escolha uma Opção: ");

            string? entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out escolha))
            {
                escolha = 0;
            }

            Console.Clear();
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("=================Formato Completo=================");
                    Console.WriteLine(DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy. 'Hora: 'HH:mm:ss\n"));
                    break;
                case 2:
                    Console.WriteLine("=====Formato Reduzido=====");
                    Console.WriteLine(DateTime.Now.ToString("d/M/yyyy\n"));
                    break;
                case 3:
                    Console.WriteLine("=====Horário=====");
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss\n"));
                    break;
                case 4:
                    Console.WriteLine("=====Mês por Extenso=====");
                    Console.WriteLine(DateTime.Now.ToString("d 'de' MMMM 'de' yyyy\n"));
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }
    }
}