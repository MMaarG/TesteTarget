using System;
using System.Text.Json;


namespace TesteTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            // Executar operação 2
            Desafio2.ExecutarFibonacci();

            // Executar operação 3
            Desafio3.ExecutarJson();

            // Executar operação 4
            Desafio4.ExecutarDistribuidora();

            // Executar operação 5
            Desafio5.ExecutarStringInvertida();
        }
    }

    class Desafio2
    {
        public static void ExecutarFibonacci()
        {
            // Input do número 
            Console.Write("Digite um número para verificar se faz parte da sequência de Fibonacci: ");
            string n = Console.ReadLine();

            int number = Convert.ToInt32(n);

            // 5 * N * N + 4 
            int quadrado1 = 5 * number * number + 4;
            int raiz1 = (int)Math.Sqrt(quadrado1);

            //5 * N * N - 4
            int quadrado2 = 5 * number * number - 4;
            int raiz2 = (int)Math.Sqrt(quadrado2);

            if (raiz1 * raiz1 == quadrado1 || raiz2 * raiz2 == quadrado2)
            {
                Console.WriteLine("{0} É um número Fibonacci!", number);
            }
            else
            {
                Console.WriteLine("{0} Não é um número Fibonacci!", number);
            }
        }
    }

    class Desafio3
    {
        public static void ExecutarJson()
        {

            // Caminho do arquivo JSON
            string Arquivo = "dados.json";

            // Verifica se o arquivo existe
            if (File.Exists(Arquivo))
            {

                // Lê todo o conteúdo do arquivo
                string jsonContent = File.ReadAllText(Arquivo);

                // Desserializa o conteúdo JSON em uma lista de objetos
                List<Item> items = JsonSerializer.Deserialize<List<Item>>(jsonContent);

                // Armazena os dados em um Dictionary
                Dictionary<int, double> dados = new Dictionary<int, double>();

                foreach (var item in items)
                {
                    if (item.valor > 0)
                    {
                        dados.Add(item.dia, item.valor);
                    }
                }

                // Calcula média
                double media = Math.Round(dados.Values.Average(), 2);


                // Valor acima da média
                foreach (var kvp in dados)
                {
                    if (kvp.Value >= media)
                    {
                        Console.Write("Valores acima da Média de {0}: ", media);
                        Console.WriteLine("Dia: {0} | Valor: {1}", kvp.Key, kvp.Value);
                    }
                }

                //  Dia com maior faturamento
                double maxValue = (double)dados.Max(x => x.Value);
                foreach (var kvp in dados)
                {
                    if (kvp.Value == maxValue)
                    {
                        Console.WriteLine("Maior faturamento no mês. DIA: {0} | VALOR: {1}", kvp.Key, Math.Round(kvp.Value,2));
                    }
                }

                // Dia com menor faturamento
                double minValue = (double)dados.Min(x => x.Value);
                foreach (var kvp in dados)
                {
                    if (kvp.Value == minValue)
                    {
                        Console.WriteLine("Menor faturamento no mês. DIA: {0} | VALOR: {1}", kvp.Key, Math.Round(kvp.Value, 2));
                    }
                }
            }
            else
            {
                Console.WriteLine("O arquivo JSON não foi encontrado.");
            }
        }
    
    }

    class Desafio4
    {
        public static void ExecutarDistribuidora()
        {
            
                double sp = 67836.43, rj = 36678.66, mg = 29229.88, es = 27165.48, outro = 19849.53;
                double total = sp + rj + mg + es + outro;

                Console.WriteLine("SP : {0}%. RJ : {1}%. MG : {2}%. ES : {3}%. OUTRO : {4}%. TOTAL: {5}",
                    Math.Round((sp / total) * 100, 2),
                    Math.Round((rj / total) * 100, 2),
                    Math.Round((mg / total) * 100, 2),
                    Math.Round((es / total) * 100, 2),
                    Math.Round((outro / total) * 100, 2),
                    total);

        }
    }

    class Desafio5
    {
        public static void ExecutarStringInvertida()
        {
            Console.Write("Digite a string para invertê-la: ");
            string Frase = Console.ReadLine();
            string variavelInvertida = "";
            for (int i = Frase.Length - 1; i >= 0; i--)
            {
                variavelInvertida += Frase[i];
            }
            Console.WriteLine(variavelInvertida);
        }

    }

    // Classe para objetos dentro do JSON 
    public class Item
    {
        public int dia { get; set; }
        public double valor { get; set; }
    }
}
