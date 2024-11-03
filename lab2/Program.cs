/*
Zadanie 1.
Napisz klasę Osoba, która będzie przechowywać informacje o imieniu, nazwisku oraz wieku osoby.
• Zaimplementuj konstruktor, który będzie przyjmował wszystkie trzy wartości.
• Użyj właściwości Imie, Nazwisko, Wiek, z walidacją:
o Imię i Nazwisko muszą mieć co najmniej 2 znaki.
o Wiek musi być liczbą dodatnią.
• Zaimplementuj metodę WyswietlInformacje(), która wyświetli informacje o osobie.
*/
using System.Collections.Generic;
class Osoba
{

    private string name;
    private string lname;
    private int age;
    
    public Osoba(string name, string lname, int age)
    {
        Name = name;
        Lname = lname;
        Age = age;
    }



    public string Lname
    {
        get { return lname; }
        set
        {
            if (value.Length < 2)
            {
                Console.WriteLine("no");
                lname = null;
            }
            else
            {
                lname = value;
            }

        }
    }


    public string Name
    {
        get { return name; }
        set 
        {
            if (value.Length < 2)
            {
                Console.WriteLine("no");
                name = null;
            }
            else
            {
                name = value;
            }
             
        }
    }
    
    public int Age
    {
        get { return age; }

        set 
        {
            if (age < 0)
            {
                Console.WriteLine("no");
            }
            else
            {
                age = value;
            } 
        }
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Name: {name}, last name: {lname}, age: {age}");
    }


}


/*
Zadanie 2.
Napisz klasę BankAccount, która będzie symulowała konto bankowe.
• Zaimplementuj właściwości Saldo (publiczne, tylko do odczytu) i Wlasciciel.
• Dodaj metodę Wplata(decimal kwota), która pozwala na zwiększenie salda, oraz metodę
Wyplata(decimal kwota), która sprawdzi, czy jest wystarczająca ilość środków, a następnie
odejmie odpowiednią kwotę.
• Użyj operatorów dostępu, aby zabezpieczyć saldo przed bezpośrednią modyfikacją.
Przykład użycia:
BankAccount konto = new BankAccount("Jan Kowalski", 1000);
konto.Wplata(500);
konto.Wyplata(200);
Console.WriteLine($"Saldo: {konto.Saldo}");
*/

class BankAccount
{
    private decimal saldo;
    private string wlasciciel;

    public BankAccount(string wlasciciel, decimal saldo)
    {
        this.saldo = saldo;
        this.wlasciciel = wlasciciel;
    }


    public decimal Saldo
    {
        get { return saldo; }
    }
    public string Wlasciciel
    {
        get { return wlasciciel; }
        
    }

    public void Wplata(decimal kwota)
    {
        saldo += kwota;
    }
    public void Wyplata(decimal kwota)
    {
        if (saldo - kwota < 0)
        {
            Console.WriteLine("Not enough");
        }
        else
        {
            saldo -= kwota;
        }
    }
}

/*
Zadanie 3.
Napisz klasę Student, która będzie przechowywała imię, nazwisko i tablicę ocen.
• Zaimplementuj właściwość SredniaOcen, która obliczy i zwróci średnią ocen.
• Dodaj metodę DodajOcene(int ocena), która doda nową ocenę do tablicy.
• Zaimplementuj konstruktor inicjujący imię i nazwisko studenta.
*/
class Student
{
    private List<int> grades = new List<int>();
    public string Name { get; set; }
    public string Fname { get; set; }

    public Student(string name, string fname)
    {
        Name = name;
        Fname = fname;
    }
    public double AvgGrade()
    {
        return grades.Average();
    }
    public void AddGrade(int grade)
    {
        grades.Add(grade);
    }
}





class Program
{
    static void Main(string[] args)
    {
        Osoba ktos = new Osoba("g", "g", 15);
        string x = ktos.Lname;
        Console.WriteLine(x);

        BankAccount konto = new BankAccount("Jan Kowalski", 1000);
        konto.Wplata(500);
        konto.Wyplata(200);
        Console.WriteLine($"Saldo: {konto.Saldo}, User: {konto.Wlasciciel}");

        Student student1 = new Student("Jan", "Kowalski");
        student1.AddGrade(5);
        student1.AddGrade(3);
        double y = student1.AvgGrade();
        Console.WriteLine(y);

    }
}


