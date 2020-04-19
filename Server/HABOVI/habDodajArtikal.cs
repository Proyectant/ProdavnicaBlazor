using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor_shop.Shared;
using Microsoft.AspNetCore.SignalR;
using Blazor_shop.Server.BAZA;

namespace Blazor_shop.Server.HABOVI
{
    public class habDodajArtikal : Hub
    {

        public async Task PrihvatiArtikal(List<Artikal> la)
        {
            baza bazanaserveru = new baza();
            var lista = bazanaserveru.Artikals.ToList();


            if (lista == null)
            {
                foreach (Artikal art in la)
                {
                    bazanaserveru.Artikals.Add(new Artikal(art.SKU, art.Naziv, art.Cena, art.Kolicina));

                }
            } else
            {
                foreach (Artikal artikal in la)
                {
                    var uporedniartikal = bazanaserveru.Artikals.Find(artikal.SKU); //referenca 
                    if (uporedniartikal != null)
                    {
                        uporedniartikal.Kolicina += artikal.Kolicina;
                    } else
                    {
                        bazanaserveru.Artikals.Add(new Artikal(artikal.SKU, artikal.Naziv, artikal.Cena, artikal.Kolicina));
                    }
                }
            }

            await bazanaserveru.SaveChangesAsync();

        }
    }
}
