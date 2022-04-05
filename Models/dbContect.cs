using System;
using Microsoft.EntityFrameworkCore;

namespace A1.Models
{
	public class dbContect : DbContext
	{
        public dbContect(DbContextOptions<dbContect> options) : base(options) { }


		public DbSet<Country> Countries { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Technician> Technician { get; set; }
		public DbSet<Incident> Incidents { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{


			modelBuilder.Entity<Country>().HasData(
				new Country { CountryId = 1, Name = "Bolivia" },
				new Country { CountryId = 2, Name = "Cameroon" }
			);
			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					ProductID = 1,
					code = "22N39FD",
					name = "Toothbrush",
					releaseDate = DateTime.Today,
					yearlyPrice = 28.00

				},
				new Product
				{
					ProductID = 2,
					code = "383IIFD",
					name = "Mug Holder",
					releaseDate = DateTime.Today,
					yearlyPrice = 32.92

				},
				new Product
				{
					ProductID = 3,
					code = "00SEDR3",
					name = "Banana",
					releaseDate = DateTime.Today,
					yearlyPrice = 392.03

				}
				);

			modelBuilder.Entity<Technician>().HasData(
				new Technician
				{
					TechnicianID = 1,
					name = "Rufus",
					email = "rufushasanemail@email.com",
					phone = "290-292-9332"
				},
				new Technician
				{
					TechnicianID = 2,
					name = "Anthony",
					email = "anthony@email.com",
					phone = "290-832-2201"
				},
				new Technician
				{
					TechnicianID = 3,
					name = "Michaela",
					email = "michaela@email.com",
					phone = "290-215-1322"
				}

				);

			modelBuilder.Entity<Customer>().HasData(
				new Customer
				{
					customerID = 1,
					firstName = "Mergitu",
					lastName = "Megersa",
					address = "2040 Bunny Road",
					city = "Toronto",
					state = "Ontario",
					postCode = "H4A 1H1",
					CountryId = 1,
					email = "mergitu.m.megersa@gmail.com",
					phone = "525-223-9201"
				},
				new Customer
				{
					customerID = 2,
					firstName = "Cookie",
					lastName = "Aba Tamam",
					address = "440 Round Avenue",
					city = "Phnom Penh",
					state = "Ta Khmau",
					postCode = "12100",
					CountryId = 1,
					email = "cookietamam@gmail.com",
					phone = "456-995-3795"
				}
				);
			modelBuilder.Entity<Incident>().HasData(
				new Incident
				{
					IncidentID = 1,
					customerID = 1,
					productID = 1,
					technicianID = 1,
					title = "Error launching program",
					description = "Bleep bleep, bloop bloop",
					dateClosed = DateTime.Now,
					dateOpened = DateTime.Now
				},
				new Incident
				{
					IncidentID = 2,
					customerID = 2,
					productID = 2,
					technicianID = 2,
					title = "Redirect to wrong page",
					description = "Bloop bloop, bleep bleep",
					dateClosed = DateTime.Now,
					dateOpened = DateTime.Now
				}
				);

		}

	}
}

