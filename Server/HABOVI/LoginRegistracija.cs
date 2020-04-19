using Blazor_shop.Shared;
using Blazor_shop.Server.BAZA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Blazor_shop.Server.HABOVI
{
	public class LoginRegistracija : Hub
	{
		public async Task ProveriKorisnika(User LogIn)
		{
			baza DB = new baza();

			var juzer = DB.Users.Where(us => us.Equals(LogIn)).FirstOrDefault();

			if (juzer != null)
			{
				await Clients.Caller.SendAsync("EvoJuzera", juzer);
				Console.WriteLine("Ulogovani ste!");
			}
		}
		public async Task PrihvatiKorisnika(User u)
		{
			baza DB = new baza();
			DB.Add(u);
			await DB.SaveChangesAsync();

		}
	}
}