using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_shop.Shared
{
    public class Racun
    {
        public int ID { get; set; }
        public DateTime DatumIzdavanjaRacuna { get; set; } = DateTime.Now;
        public User Korisnik { get; set; }
        public string KorisnikID { get; set; }

        public ICollection<ArtikalRacuni> PoruceniArtikli { get; set; }

        public Racun() { }

    }
}