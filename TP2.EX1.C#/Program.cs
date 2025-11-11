namespace TP2.EX1.C_
{
    using System;
    using System.Globalization;

    public class CalculadoraIdade
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Calculadora de Idade Exata");
            Console.WriteLine("Insira sua data de nascimento (formato DD/MM/AAAA):");

            DateTime dataNascimento;
            bool entradaValida = false;

            while (!entradaValida)
            {
                Console.Write("Data: ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
                {
                    DateTime hoje = DateTime.Today;

                    if (dataNascimento > hoje)
                    {
                        Console.WriteLine("Erro: A data de nascimento não pode estar no futuro. Tente novamente.");
                    }
                    else
                    {
                        entradaValida = true;

                        int anos = hoje.Year - dataNascimento.Year;
                        int meses = 0;
                        int dias = 0;

                        if (hoje.Month < dataNascimento.Month || (hoje.Month == dataNascimento.Month && hoje.Day < dataNascimento.Day))
                        {
                            anos--;
                        }

                        DateTime dataReferencia = dataNascimento.AddYears(anos);
                        while (dataReferencia.AddMonths(meses + 1) <= hoje)
                        {
                            meses++;
                        }

                        dias = hoje.Subtract(dataReferencia.AddMonths(meses)).Days;

                        Console.WriteLine($"Você nasceu em: {dataNascimento.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($"Hoje é: {hoje.ToString("dd/MM/yyyy")}");

                        Console.WriteLine($"Sua idade exata é: {anos} anos, {meses} meses e {dias} dias.");

                    }
                }
                else
                {
                    Console.WriteLine("Erro: Formato de data inválido. Use DD/MM/AAAA (ex: 25/12/1990).");
                }
            }
        }
    }
}
