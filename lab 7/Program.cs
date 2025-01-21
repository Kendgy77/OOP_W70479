using System.Text.Json;
//1

class zad1
{
    static void Main()
    {
        string numerAlbumu = "w70479";

        Console.Write("Podaj nazwę pliku do zapisu: ");
        string nazwaPliku = Console.ReadLine();

        try
        {
            File.WriteAllText(nazwaPliku, $"Numer albumu: {numerAlbumu}");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas zapisywania pliku: {ex.Message}");
        }
    }
}

//2
class zad2
{
    static void Main()
    {
        Console.Write("Podaj nazwę pliku do odczytu (z rozszerzeniem, np. '.txt'): ");
        string nazwaPliku = Console.ReadLine();

        try
        {
            string zawartosc = File.ReadAllText(nazwaPliku);
            Console.WriteLine("Zawartość pliku:");
            Console.WriteLine(zawartosc);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik o podanej nazwie nie istnieje.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas odczytu pliku: {ex.Message}");
        }
    }
}

//3
class zad3
{
    static void Main()
    {
        string plik = "pesels.txt";

        try
        {
            if (!File.Exists(plik))
            {
                Console.WriteLine($"Plik '{plik}' nie istnieje. Upewnij się, że został wygenerowany.");
                return;
            }

            string[] pesels = File.ReadAllLines(plik);

            Console.WriteLine("Wczytane numery PESEL:");
            foreach (var pesel in pesels)
            {
                Console.WriteLine(pesel);
            }

            int iloscZen = pesels.Count(IsFemalePesel);

            Console.WriteLine($"\nLiczba żeńskich PESEL-i: {iloscZen}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas przetwarzania pliku: {ex.Message}");
        }
    }
    static bool IsFemalePesel(string pesel)
    {
        if (pesel.Length != 11 || !pesel.All(char.IsDigit))
        {
            Console.WriteLine($"Nieprawidłowy numer PESEL: {pesel}");
            return false;
        }

        int ostatniaCyfra = int.Parse(pesel[9].ToString());
        return ostatniaCyfra % 2 == 0;
    }
}

//4
class zad4
{
    static void Main()
    {
        string dbPath = "db.json";

        if (!File.Exists(dbPath))
        {
            Console.WriteLine($"Plik '{dbPath}' nie istnieje.");
            return;
        }

        try
        {
            string jsonData = File.ReadAllText(dbPath);
            var populationData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<int, long>>>(jsonData);

            if (populationData == null)
            {
                Console.WriteLine("Błąd wczytywania danych.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nWybierz operację:");
                Console.WriteLine("1. Różnica populacji Indii (1970-2000)");
                Console.WriteLine("2. Różnica populacji USA (1965-2010)");
                Console.WriteLine("3. Różnica populacji Chin (1980-2018)");
                Console.WriteLine("4. Wyświetl populację dla roku i kraju");
                Console.WriteLine("5. Różnica populacji dla zakresu lat i kraju");
                Console.WriteLine("6. Procentowy wzrost populacji względem poprzedniego roku");
                Console.Write("Wybierz cyrfe: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PokazRoznice(populationData, "India", 1970, 2000);
                        break;
                    case "2":
                        PokazRoznice(populationData, "USA", 1965, 2010);
                        break;
                    case "3":
                        PokazRoznice(populationData, "China", 1980, 2018);
                        break;
                    case "4":
                        WybranaPopulacja(populationData);
                        break;
                    case "5":
                        ZakresLat(populationData);
                        break;
                    case "6":
                        WzrostPopulacji(populationData);
                        break;
                    case "7":
                        Console.WriteLine("Koniec programu.");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }

    static void PokazRoznice(Dictionary<string, Dictionary<int, long>> data, string country, int year1, int year2)
    {
        if (data.TryGetValue(country, out var years) && years.ContainsKey(year1) && years.ContainsKey(year2))
        {
            long difference = years[year2] - years[year1];
            Console.WriteLine($"Różnica populacji {country} między {year1} a {year2} wynosi: {difference:N0}");
        }
        else
        {
            Console.WriteLine($"Brak danych dla {country} lub lat {year1}/{year2}.");
        }
    }

    static void WybranaPopulacja(Dictionary<string, Dictionary<int, long>> data)
    {
        Console.Write("Podaj kraj: ");
        string kraj = Console.ReadLine();
        Console.Write("Podaj rok: ");
        if (int.TryParse(Console.ReadLine(), out int rok) && data.ContainsKey(kraj) && data[kraj].ContainsKey(rok))
        {
            Console.WriteLine($"Populacja {kraj} w roku {rok}: {data[kraj][rok]}");
        }
        else
        {
            Console.WriteLine("Brak danych.");
        }
    }

    static void ZakresLat(Dictionary<string, Dictionary<int, long>> data)
    {
        Console.Write("Podaj kraj: ");
        string kraj = Console.ReadLine();
        Console.Write("Podaj rok początkowy: ");
        if (int.TryParse(Console.ReadLine(), out int rok1) &&
            int.TryParse(Console.ReadLine(), out int rok2) &&
            data.ContainsKey(kraj) && data[kraj].ContainsKey(rok1) && data[kraj].ContainsKey(rok2))
        {
            long diff = data[kraj][rok2] - data[kraj][rok1];
            Console.WriteLine($"Różnica populacji {kraj} między {rok1} a {rok2}: {diff}");
        }
        else
        {
            Console.WriteLine("Brak danych.");
        }
    }

    static void WzrostPopulacji(Dictionary<string, Dictionary<int, long>> data)
    {
        foreach (var kraj in data.Keys)
        {
            Console.WriteLine($"\nWzrost populacji dla {kraj}:");
            var lata = data[kraj].Keys.OrderBy(x => x).ToList();
            for (int i = 1; i < lata.Count; i++)
            {
                long prev = data[kraj][lata[i - 1]];
                long curr = data[kraj][lata[i]];
                double growth = ((double)(curr - prev) / prev) * 100;
                Console.WriteLine($"Rok {lata[i]}: {growth:F2}%");
            }
        }
    }
}


