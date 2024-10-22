
    bool exit = false;

    while (!exit)
    {
        Console.WriteLine("\nKalkulator - wybierz opcję:");
        Console.WriteLine("1. Suma");
        Console.WriteLine("2. Różnica");
        Console.WriteLine("3. Iloczyn");
        Console.WriteLine("4. Iloraz");
        Console.WriteLine("5. Potęga");
        Console.WriteLine("6. Pierwiastek kwadratowy");
        Console.WriteLine("7. Funkcje trygonometryczne");
        Console.WriteLine("8. Wyjście");

        Console.Write("Wybór: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                PerformAddition();
                break;
            case "2":
                PerformSubtraction();
                break;
            case "3":
                PerformMultiplication();
                break;
            case "4":
                PerformDivision();
                break;
            case "5":
                PerformPower();
                break;
            case "6":
                PerformSquareRoot();
                break;
            case "7":
                PerformTrigonometricFunctions();
                break;
            case "8":
                exit = true;
                Console.WriteLine("Zamykanie programu...");
                break;
            default:
                Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                break;
        }
    }
}

static void PerformAddition()
{
    double a = GetInput("Podaj pierwszą liczbę: ");
    double b = GetInput("Podaj drugą liczbę: ");
    Console.WriteLine($"Suma: {a} + {b} = {a + b}");
}

static void PerformSubtraction()
{
    double a = GetInput("Podaj pierwszą liczbę: ");
    double b = GetInput("Podaj drugą liczbę: ");
    Console.WriteLine($"Różnica: {a} - {b} = {a - b}");
}

static void PerformMultiplication()
{
    double a = GetInput("Podaj pierwszą liczbę: ");
    double b = GetInput("Podaj drugą liczbę: ");
    Console.WriteLine($"Iloczyn: {a} * {b} = {a * b}");
}

static void PerformDivision()
{
    double a = GetInput("Podaj pierwszą liczbę: ");
    double b = GetInput("Podaj drugą liczbę: ");
    if (b != 0)
    {
        Console.WriteLine($"Iloraz: {a} / {b} = {a / b}");
    }
    else
    {
        Console.WriteLine("Dzielenie przez zero jest niedozwolone.");
    }
}

static void PerformPower()
{
    double a = GetInput("Podaj podstawę: ");
    double b = GetInput("Podaj wykładnik: ");
    Console.WriteLine($"Potęga: {a} ^ {b} = {Math.Pow(a, b)}");
}

static void PerformSquareRoot()
{
    double a = GetInput("Podaj liczbę: ");
    if (a >= 0)
    {
        Console.WriteLine($"Pierwiastek kwadratowy: √{a} = {Math.Sqrt(a)}");
    }
    else
    {
        Console.WriteLine("Nie można obliczyć pierwiastka z liczby ujemnej.");
    }
}

static void PerformTrigonometricFunctions()
{
    double angle = GetInput("Podaj kąt w radianach: ");
    Console.WriteLine($"Sin({angle}) = {Math.Sin(angle)}");
    Console.WriteLine($"Cos({angle}) = {Math.Cos(angle)}");
    Console.WriteLine($"Tan({angle}) = {Math.Tan(angle)}");
}

static double GetInput(string message)
{
    Console.Write(message);
    double.TryParse(Console.ReadLine(), out double result);
    return result;
}
}