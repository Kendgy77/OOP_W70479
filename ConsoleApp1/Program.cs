//1
bool run = true;

while (run)
{
    Console.WriteLine("Calculator: choose an option \n" +
        "1 suma" +
        "2 subs" +
        "3 multiply" +
        "4 divide" +
        "5 power" +
        "6 sqrt" +
        "7 trygonometry" +
        "8 exit");


    Console.Write("Wybór: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Add();
            break;
        case "2":
            Substract();
            break;
        case "3":
            Multiply();
            break;
        case "4":
            Divide();
            break;
        case "5":
            Power();
            break;
        case "6":
            Sqrt();
            break;
        case "7":
            Trygonometry();
            break;
        case "8":
            run = false;
            break;

    }
}


static void Add()
{
    Console.WriteLine("Give your two numbers: ");
    double a = double.Parse(Console.ReadLine());
    double b = double.Parse(Console.ReadLine());
    double sum = a + b;
    Console.WriteLine("Result: " + sum);
}

static void Substract()
{
    Console.WriteLine("Give your two numbers: ");
    double a = double.Parse(Console.ReadLine());
    double b = double.Parse(Console.ReadLine());
    double result = a - b;
    Console.WriteLine("Result: " + result);
}

static void Multiply()
{
    Console.WriteLine("Give your two numbers: ");
    double a = double.Parse(Console.ReadLine());
    double b = double.Parse(Console.ReadLine());
    double result = a * b;
    Console.WriteLine("Result: " + result);
}

static void Divide()
{
    Console.WriteLine("Give your two numbers: ");
    double a = double.Parse(Console.ReadLine());
    double b = double.Parse(Console.ReadLine());

    if (b != 0)
    {
        double result = a / b;
        Console.WriteLine("Result: " + result);
    }
    else
    {
        Console.WriteLine("Can not divide by 0.");
    }
}

static void Power()
{
    Console.WriteLine("Give your two numbers: ");
    double a = double.Parse(Console.ReadLine());
    double b = double.Parse(Console.ReadLine());
    double result = Math.Pow(a, b);
    Console.WriteLine("Result: " + result);
}

static void Sqrt()
{
    Console.WriteLine("Give me a number: ");
    double a = double.Parse(Console.ReadLine());
    double result = Math.Sqrt(a);
    Console.WriteLine("Result: " + result);
}

static void Trygonometry()
{
    Console.WriteLine("Give me a number: ");
    double a = double.Parse(Console.ReadLine());
    double sina = Math.Sin(a);
    double cosa = Math.Cos(a);
    Console.WriteLine("Result: " + sina + " " + cosa);
}

//2
double[] values = new double[10];


for (int i = 0; i < values.Length; i++)
{
    Console.Write("Podaj liczbę pod indeksem: " + i);
    double a = double.Parse(Console.ReadLine());
    values[i] = a;
}


Console.WriteLine("Tablica od pierwszego do ostatniego indeksu:");
for (int i = 0; i < values.Length; i++)
{
    Console.WriteLine(values[i]);
}

Console.WriteLine("Tablica od ostatniego do pierwszego indeksu:");
for (int i = values.Length - 1; i >= 0; i--)
{
    Console.WriteLine(values[i]);
}

Console.WriteLine("\nElementy o nieparzystych indeksach:");
for (int i = 1; i < values.Length; i += 2)
{
    Console.WriteLine($"Element {i}: {values[i]}");
}

Console.WriteLine("\nElementy o parzystych indeksach:");
for (int i = 0; i < values.Length; i += 2)
{
    Console.WriteLine($"Element {i}: {values[i]}");
}
    