using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_shop.Shared
{
    public class Artikal
    {
        public string SKU { get; set; }
        public string Naziv { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }
         
        public Artikal() { }


        public Artikal(string s, string n, double c, int k)
        {
            SKU = s;
            Naziv = n;
            Cena = c;
            Kolicina = k;
        }

        public override string ToString()
        {
            return $"{Naziv}  - {Cena}  - {Kolicina}";
        }

        public ICollection<ArtikalRacuni> Racuni { get; set; }
    }
}
