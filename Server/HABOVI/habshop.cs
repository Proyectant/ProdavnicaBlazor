using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor_shop.Shared;
using Blazor_shop.Server.BAZA;

namespace Blazor_shop.Server.HABOVI
{
    public class habshop : Hub
    {
        public async Task KaServeru()
        {
            Console.WriteLine("Evo me u ArtikliIzBaze");
            baza bazasaservera = new baza();
            List<Artikal> lista = new List<Artikal>();

            lista = bazasaservera.Artikals.ToList();

            await Clients.Caller.SendAsync("SaljeServer", lista); //server salje podatke klijentu koji poziva metodu "SaljeServer" na shop.razor

        }


    }
}
