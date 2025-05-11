namespace Exercicios;
public class Questao3
{
    public void Calculos()
    {
        Console.Write("Digite o valor 1: ");
        string? input1 = Console.ReadLine();
        double valor1 = Convert.ToDouble(input1);
        Console.Write("Digite o valor 2: ");
        string? input2 = Console.ReadLine();
        double valor2 = Convert.ToDouble(input2);
        // Somar
        Console.WriteLine($"Soma: {Somar(valor1, valor2)}");
        // Subtrair
        Console.WriteLine($"Subtração: {Subtrair(valor1, valor2)}");
        // Multiplicação
        Console.WriteLine($"Multiplicação: {Multiplicar(valor1, valor2)}");
        // Divisão
        Console.WriteLine($"Divisão: {Dividir(valor1, valor2)}");
        // Média
        Console.WriteLine($"Média: {Media(valor1, valor2)}");
    }
    public static double Somar(double valor1, double valor2)
    {
        double resultado = valor1 + valor2;
        return resultado;
    }

    public static double Subtrair(double valor1, double valor2)
    {
        double resultado = valor1 - valor2;
        return resultado;
    }

    public static double Multiplicar(double valor1, double valor2)
    {
        double resultado = valor1 * valor2;
        return resultado;
    }

    public static double Dividir(double valor1, double valor2)
    {
        if (valor2 == 0)
        {
            return double.NaN;
        }
        double resultado = valor1 / valor2;
        return resultado;
    }

    public static double Media(double valor1, double valor2)
    {
        double resultado = (valor1 + valor2) / 2;
        return resultado;
    }
}
