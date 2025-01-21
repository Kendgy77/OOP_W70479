/*
Zadanie 1.
Zaimplementuj klasę Shape, posiadającą właściwości X, Y, Height, Width oraz virutalną metodę Draw.
Następnie zaimplementuj klasy:
• Rectangle,
• Triangle,
• Circle
które będą implementować metodę draw poprzez wypisanie na okno konsoli jaką figurę próbujemy
narysować. Następnie napisz program, który do listy List<Shape>, doda po obiekcie każdego typu z klas
dziedziczących. Następnie wywołaj dla każdego elementu w liście funkcję draw.
*/

public class Shape
{
    public int x { get; set; }
    public int y { get; set; }
    public int height { get; set; }
    public int width { get; set; }

    public virtual void Draw()
    {
        Console.WriteLine("Rysowanie");
    }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie prostokąta");
    }
}

public class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie trójkąta");
    }
}

public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysowanie koła");
    }
}

/*class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape> {new Rectangle(), new Triangle(), new Circle()};
        
        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}*/




/*
Zadanie 2.
Napisz program wykorzystując polimorfizm, który będzie sprawdzał czy nauczyciel może wypuścić do
domu uczniów swojej klasy bez opieki dorosłego
*/

public abstract class Osoba
{
    public string Imie { get; private set; }
    public string Nazwisko { get; private set; }
    public string Pesel { get; private set; }

    public abstract string GetEducationInfo();
    public abstract string GetFullName();
    public abstract bool CanGoAloneToHome();

    public void SetFirstName(string imie)
    {
        Imie = imie;
    }

    public void SetLastName(string nazwisko)
    {
        Nazwisko = nazwisko;
    }

    public void SetPesel(string pesel)
    {
        if (pesel.Length == 11)
        {
            Pesel = pesel;
        }
        else
        {
            throw new ArgumentException("PESEL musi mieć 11 znaków.");
        }
    }

    public int GetAge() //??
    {
        int year = int.Parse(Pesel.Substring(0, 2));
        int month = int.Parse(Pesel.Substring(2, 2));
        int century = (month > 20) ? 2000 : 1900;

        year += century;
        DateTime birthDate = new DateTime(year, month % 20, int.Parse(Pesel.Substring(4, 2)));
        return DateTime.Now.Year - birthDate.Year - (DateTime.Now < birthDate.AddYears(DateTime.Now.Year - birthDate.Year) ? 1 : 0);
    }
    

    public string GetGender()
    {
        int genderDigit = int.Parse(Pesel.Substring(9, 1));
        if (genderDigit % 2 == 0)
        {
            return "Kobieta";
        }
        else
        {
            return "Mężczyzna";
        }
        
    }

  

}
public class Uczen : Osoba
{
    public string Szkola { get; private set; }
    public bool MozeSamWracacDoDomu { get; private set; }

    public void SetSchool(string szkola)
    {
        Szkola = szkola;
    }

    public void ChangeSchool(string nowaSzkola)
    {
        Szkola = nowaSzkola;
    }

    public void SetCanGoHomeAlone(bool canGo)
    {
        MozeSamWracacDoDomu = canGo;
    }
    public override string GetEducationInfo()
    {
        return $"Szkoła: {Szkola}";
    }

    public override string GetFullName()
    {
        return $"{Imie} {Nazwisko}";
    }

    public override bool CanGoAloneToHome()
    {
        int age = GetAge();
        return age >= 12 || MozeSamWracacDoDomu;
    }
   
}
class Program
{
    static void Main(string[] args)
    {
        try
        {
            
            Uczen uczen = new Uczen();
            uczen.SetFirstName("Tima");
            uczen.SetLastName("Waflenko");
            uczen.SetPesel("55041087394"); 
            uczen.SetSchool("WSIZ");
            uczen.SetCanGoHomeAlone(false);

            
            Console.WriteLine($"Imię i nazwisko: {uczen.GetFullName()}");
            Console.WriteLine($"Wiek: {uczen.GetAge()}");
            Console.WriteLine($"Płeć: {uczen.GetGender()}");
            Console.WriteLine(uczen.GetEducationInfo());
            Console.WriteLine($"Może wracać sam do domu: {(uczen.CanGoAloneToHome() ? "Tak" : "Nie")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }
}

/*
class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape> { new Rectangle(), new Triangle(), new Circle() };

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}
*/





