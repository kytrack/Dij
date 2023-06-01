using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doga
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("nobel.csv");
            List<Nobel> nobelek = new List<Nobel>();
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                nobelek.Add(new Nobel(int.Parse(adatok[0]), adatok[1], adatok[2], adatok[3]));
            }
            sr.Close();
            foreach (var item in nobelek)
            {
                if (item.Ev==2017 && item.Tipus=="irodalmi")
                {
                    Console.WriteLine($"4.feladat: {item.Keresztnev} {item.Vezeteknev}");
                }
            }

            Console.WriteLine($"6.feladat:");
            var eredmeny6=nobelek.GroupBy(n => n.Vezeteknev).ToList();
            foreach (var item in eredmeny6)
            {
                if (item.Key.Contains("Curie"))
                {
                    Console.WriteLine($"\n\t{item.Key}");
                }
            }

            Console.WriteLine($"7.feladat:");
            nobelek.GroupBy(n => n.Tipus).ToList().ForEach(n => Console.WriteLine($"\t{n.Key}\t {n.Count()}db"));

            Console.WriteLine($"8.feladat: orvosi.txt");

            StreamWriter sw = new StreamWriter("orvosi.txt",append:true);
            foreach (var item in nobelek)
            {
                sw.WriteLine($"{item.Ev},{item.Keresztnev} {item.Vezeteknev}");
            }
        }
    }
}
