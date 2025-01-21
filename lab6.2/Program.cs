public enum StatusZamowienia
{
    Oczekujace,
    Przyjete,
    Zrealizowane,
    Anulowane
}

class Program
{
   
    private static Dictionary<int, (List<string> produkty, StatusZamowienia status)> zamowienia = new();

    static void Main(string[] args)
    {
     
        zamowienia[1] = (new List<string> { "produkt1", "produkt2" }, StatusZamowienia.Oczekujace);
        zamowienia[2] = (new List<string> { "produkt3" }, StatusZamowienia.Przyjete);

       
        string opcja;
        do
        {
            Console.WriteLine("\nZarządzanie zamówieniami w sklepie:");
            Console.WriteLine("1. Wyświetl wszystkie zamówienia");
            Console.WriteLine("2. Zmień status zamówienia");
            Console.WriteLine("3. Wyjdz");
            Console.Write("Wybierz opcję: ");
            opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    WyswietlZamowienia();
                    break;
                case "2":
                    ZmienStatusZamowienia();
                    break;
                case "3":
                    Console.WriteLine("Do widzenia");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja");
                    break;
            }
        } while (opcja != "3");
    }

   
    static void WyswietlZamowienia()
    {
        Console.WriteLine("\nLista zamówień:");
        foreach (var zamowienie in zamowienia)
        {
            Console.WriteLine($"Numer zamówienia: {zamowienie.Key}, Produkty: {string.Join(", ", zamowienie.Value.produkty)}, Status: {zamowienie.Value.status}");
        }
    }

  
    static void ZmienStatusZamowienia()
    {
        try
        {
            Console.Write("\nPodaj numer zamówienia: ");
            int numerZamowienia = int.Parse(Console.ReadLine());

            if (!zamowienia.ContainsKey(numerZamowienia))
            {
                throw new KeyNotFoundException("Zamówienie o podanym numerze nie istnieje.");
            }

            Console.WriteLine("Dostępne statusy:");
            foreach (var status in Enum.GetValues(typeof(StatusZamowienia)))
            {
                Console.WriteLine(status);
            }

            Console.Write("Podaj nowy status: ");
            StatusZamowienia nowyStatus = (StatusZamowienia)Enum.Parse(typeof(StatusZamowienia), Console.ReadLine(), true);

            var obecnyStatus = zamowienia[numerZamowienia].status;
            if (obecnyStatus == nowyStatus)
            {
                throw new ArgumentException("Nowy status jest taki sam jak obecny.");
            }

            zamowienia[numerZamowienia] = (zamowienia[numerZamowienia].produkty, nowyStatus);
            Console.WriteLine("Status zamówienia został zmieniony.");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
        }
    }
}

