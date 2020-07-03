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
	}
}
