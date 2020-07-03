using Chaat.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaat.Server
{
	public class ChatHub : Hub
	{
		public void Test(string poruka)
		{
			Console.WriteLine("Radi: " + poruka);
		}

		public void KaServeru(Poruka p)
		{
			Clients.All.SendAsync("PrimiPoruku", p);

		}

		public void Uloguj(Korisnik k)
		{
			DB baza = new DB();
			var korisnik = baza.Korisniks.Where(kor => kor.Username == k.Username && kor.Password == k.Password).FirstOrDefault();
			if (korisnik != null)
			{
				Clients.Caller.SendAsync("DobarKorisnik", korisnik);
			}
			else
			{
				Clients.Caller.SendAsync("ServerPoruka", "Neuspesno :(");
			}
		}

		public void KorisnikKaServeru(Korisnik k)
		{
			DB baza = new DB();
			if (baza.Korisniks.Where(kor => kor.Username == k.Username || kor.Email == k.Email).Count() > 0)
			{
				Clients.Caller.SendAsync("ServerPoruka", "Korisnik sa imenom/mejlom vec postoji!");
			} else
			{
				baza.Add(k);	
				baza.SaveChanges();
				Clients.Caller.SendAsync("ServerPoruka", "Registrovani ste!");
			}
		}
	}
}
