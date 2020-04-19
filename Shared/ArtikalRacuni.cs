using System;
using System.Collections.Generic;
using System.Text;
using Blazor_shop.Shared;

namespace Blazor_shop.Shared
{
    public class ArtikalRacuni
    {
        public string IDartikla { get; set; }
        public Artikal artikal { get; set; }
        public int IDracuna { get; set; }
        public Racun racun { get; set; }



        public ArtikalRacuni() { }

        public ArtikalRacuni(Artikal A, Racun R)
        {
            IDartikla = A.SKU;
            artikal = A;
            IDracuna = R.ID;
            racun = R;
        }

    }
}