using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaat.Shared
{
	public class Korisnik
	{
		public int ID { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
	}

	public class KorisnikValidator : AbstractValidator<Korisnik>
	{
		public KorisnikValidator()
		{
			RuleFor(k => k.Username).MinimumLength(3).WithMessage("Prekratki username!");
			RuleFor(k => k.Password).MinimumLength(3).WithMessage("Prekratka sifra!");
			RuleFor(k => k.Email).EmailAddress().WithMessage("Unesite validan mejl!");
		}
	}
}
