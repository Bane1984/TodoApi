using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OsnoveCsharpa
{
    class Program
    {
        //public interface IBane
        //{
        //    void SetTutorial(int a, string b);
        //    string GetTutorial();
        //}

        //public class Bane : IBane
        //{
        //    protected int id;
        //    protected string nameT;



        //    public void SetTutorial(int a, string b)
        //    {
        //        id = a;
        //        nameT = b;
        //    }
        //    public string GetTutorial()
        //    {
        //        return nameT;
        //    }

        //    static void Main(string[] args)
        //    {
        //        Bane p = new Bane();
        //        p.SetTutorial(1, "Asp.Net Core");
        //        Console.WriteLine(p.GetTutorial());
        //        Console.ReadKey();
        //    }
        //}
        //static int Kvadrat(int i) => i * i;

        //static double Mnozenje(double a, double b)
        //{
        //    return a * b;
        //}

        //static int Prost(int a)
        //{
        //    if (a==0||a==1)
        //    {
        //        Console.WriteLine("Uneseni broj nije prost.");
        //    }
        //    for (int i = 2; i < a; i++)
        //    {
        //        if (a % i != 0)
        //        {
        //            Console.WriteLine("Uneseni broj je prost.");
        //            continue;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Uneseni broj nije prost.");
        //            break;
        //        }
        //    }

        //    return a;
        //}
        //public void Main(string[] args)
        //{
        //    //Tutorial p = new Tutorial();
        //    //p.SetTutorial(1, ".Net");
        //    //Console.WriteLine(p.GetTutorial());
        //    //Tutorial a = new Tutorial();
        //    //Console.WriteLine($"Kreiran objekat a sa difoltnom vrijednosti name: {a.GetTutorial()}");
        //    //Console.ReadKey();

        //    //string pass = string.Empty;
        //    //do
        //    //{
        //    //    Console.Write("Unesite sifru: ");
        //    //    pass = Console.ReadLine();

        //    //} while (pass!="sifra");
        //    //Console.WriteLine("Uspjesno unesena sifra!");

        //    //string[] ime = {"Bane", "Ana", "Jole", "Sanja"};
        //    //foreach (var a in ime)
        //    //{
        //    //    Console.WriteLine($"U stringu {a} ima ukupno {a.Length} karaktera!");
        //    //}

        //    //double a = 9.5;
        //    //int b = (int) a;
        //    //Console.WriteLine(b);

        //    //int a;
        //    //int.TryParse("15", out a);
        //    //Console.WriteLine(a);

        //    //try
        //    //{
        //    //    checked
        //    //    {
        //    //        int x = int.MaxValue - 1;
        //    //        for (int i = 0; i < 4; i++)
        //    //        {
        //    //            Console.WriteLine(x);
        //    //            x++;
        //    //        }
        //    //    }

        //    //}
        //    //catch (OverflowException)
        //    //{
        //    //    Console.WriteLine("Uhvacen izuzetak!");
        //    //    //throw;
        //    //}

        //    //tablica mnozenja od 1 do 10
        //    //for (int i = 1; i <= 10; i++)
        //    //{
        //    //    for (int j = 1; j <= 10; j++)
        //    //    {
        //    //        Console.WriteLine($"{i} x {j} = {i * j}");
        //    //    }

        //    //}
        //    //Console.WriteLine("Unesite broj a:");
        //    //double a = double.Parse(Console.ReadLine());
        //    //Console.WriteLine("Unesite broj b:");
        //    //double b = double.Parse(Console.ReadLine());

        //    //Console.WriteLine($"Proizvod brojeva {a} i {b} je {Mnozenje(a,b)}");
        //    //string[] names = new string[]{"Bane", "Dejan"};
        //    //foreach (var a in names)
        //    //{
        //    //    Console.WriteLine(a);
        //    //}
        //    //Console.WriteLine("Unesite cio broj:");
        //    //int m = int.Parse(Console.ReadLine());


        //    //Console.WriteLine("Unesi broj koji zelis kvadrirati:");
        //    //int a = int.Parse(Console.ReadLine());
        //    //Console.WriteLine($"Kvadrat broja {a} je {Kvadrat(a)}");


        //}

        static void Main(string[] args)
        {
            //ArrayList a = new ArrayList();
            //a.Add(5);
            //a.Add("nana");
            //a.Add(true);
            //foreach (var b in a)
            //{
            //    Console.WriteLine(b);
            //}

            
            //Console.WriteLine(a.Contains(1));

            //a.RemoveAt(0);

            //for (int i = 0; i < a.Count; i++)
            //{
            //    Console.WriteLine(a[i]);
            //}

            //Stack c = new Stack();
            //c.Push("a");
            //c.Push("b");
            //c.Push("1");
            //foreach (var d in c)
            //{
            //    Console.WriteLine(d);
            //}

            ////sada cemo obrisati poslednji element tj 1
            //c.Pop();

            ////provjerimo da li je obrisan
            //foreach (var d in c)
            //{
            //    Console.WriteLine(d);
            //}

            ////da li sadrzi obrisano 1

            //Console.WriteLine($"Da li postoji 1 u steku: {c.Contains(1)}");

        //    Queue d = new Queue();
        //    d.Enqueue("Asp");
        //    d.Enqueue(".Net Core");
        //    d.Enqueue(2.2);
        //    d.Enqueue("verzija");
        //    foreach (var e in d)
        //    {
        //        Console.WriteLine(e);
        //    }

        //    d.Dequeue();

        //    Console.WriteLine($"Broj elemenata u redu je: {d.Count}");
        //
        //Hashtable m = new Hashtable();
        //    m.Add("001", 5);
        //    m.Add("002", "Asp");
        //    m.Add("003", ".Net");
        //    m.Add("004", 1.44);

        //    ICollection n = m.Keys;
        //    foreach (var b in n)
        //    {
        //        Console.WriteLine(m[b]);
        //    }


        //    Console.WriteLine(m.ContainsKey("002"));
        //    Console.WriteLine(m.ContainsValue(15));

            string path = @"C:\Users\Bild33\source\repos\TodoApi\example.txt";
            string[] lines = File.ReadAllLines(path);
            string allLines = File.ReadAllText(path);
            string copyPath = @"C:\Users\Bild33\source\repos\TodoApi\Copy\example.txt";

            Console.WriteLine(allLines);

            File.Copy(path, copyPath);

            File.Delete(copyPath);

            if (File.Exists(path))
            {
                Console.WriteLine("Fajl postoji!");
            }
            else
            {
                Console.WriteLine("Fajl ne postoji!");
            }

            Console.WriteLine(lines[0]);
            Console.WriteLine(lines[1]);
            Console.WriteLine(lines[3]);
            Console.WriteLine(lines[2]);
        }
    }
}
