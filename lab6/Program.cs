/*
Napisz program kalkulator, który wykonuje operacje matematyczne na dwóch liczbach. Użyj typu
wyliczeniowego (enum) do reprezentowania dostępnych operacji: dodawanie, odejmowanie,
mnożenie, dzielenie. Program powinien obsługiwać błędy wprowadzania danych przez użytkownika
(np. wpisanie tekstu zamiast liczby) oraz wyjątek dzielenia przez zero.
*/





class Program
{

    enum Operations
    {
        dodawanie,
        odejmowanie,
        mnozenie,
        dzielenie
    }

    static void Main(string[] args)
    {
        List<double> results = new List<double>();

        while (true)
        {
            try
            {
                Console.WriteLine("Podaj pierwszą liczbę:");
                double liczba1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Podaj drugą liczbę:");
                double liczba2 = double.Parse(Console.ReadLine());

                Console.WriteLine("Wybierz operację (Dodawanie, Odejmowanie, Mnożenie, Dzielenie):");
                Operations operacja = (Operations)Enum.Parse(typeof(Operations), Console.ReadLine(), true);


                double result = 0;

                switch (operacja)
                {
                    case Operations.dodawanie:
                        result = liczba1 + liczba2;
                        break;
                    case Operations.odejmowanie:
                        result = liczba1 - liczba2;
                        break;
                    case Operations.mnozenie:
                        result = liczba1 * liczba2;
                        break;
                    case Operations.dzielenie:
                        if (liczba2 == 0)
                            throw new DivideByZeroException("Nie można dzielić przez zero.");
                        result = liczba1 / liczba2;
                        break;
                    default:
                        throw new ArgumentException("Nieznana operacja.");
                }


                results.Add(result);
                Console.WriteLine($"Wynik: {result}");


            }
            catch (FormatException)
            {
                Console.WriteLine("Wprowadzono nieprawidłową liczbę. Spróbuj ponownie.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }

            Console.WriteLine("Czy chcesz kontynuować? (tak/nie):");
            if (Console.ReadLine().Trim().ToLower() != "tak")
                break;
        }
    }

}



