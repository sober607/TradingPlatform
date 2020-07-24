using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Models
{
    public class TradingPlatformContext : IdentityDbContext<User>
    {
        public TradingPlatformContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(


            new Country
            {
                Id = 1,
                Name = "Afghanistan"
            },

            new Country
            {
                Id = 2,
                Name = "Albania"
            },

            new Country
            {
                Id = 3,
                Name = "Algeria"
            },

            new Country
            {
                Id = 4,
                Name = "Argentina"
            },

            new Country
            {
                Id = 5,
                Name = "Armenia"
            },

            new Country
            {
                Id = 6,
                Name = "Australia"
            },

            new Country
            {
                Id = 7,
                Name = "Austria"
            },

            new Country
            {
                Id = 8,
                Name = "Azerbaijan"
            },

            new Country
            {
                Id = 9,
                Name = "Bahrain"
            },

            new Country
            {
                Id = 10,
                Name = "Bangladesh"
            },

            new Country
            {
                Id = 11,
                Name = "Belarus"
            },

            new Country
            {
                Id = 12,
                Name = "Belgium"
            },

            new Country
            {
                Id = 13,
                Name = "Belize"
            },

            new Country
            {
                Id = 14,
                Name = "Bolivarian Republic of Venezuela"
            },

            new Country
            {
                Id = 15,
                Name = "Bolivia"
            },

            new Country
            {
                Id = 16,
                Name = "Bosnia and Herzegovina"
            },

            new Country
            {
                Id = 17,
                Name = "Brazil"
            },

            new Country
            {
                Id = 18,
                Name = "Brunei Darussalam"
            },

            new Country
            {
                Id = 19,
                Name = "Bulgaria"
            },

            new Country
            {
                Id = 20,
                Name = "Cambodia"
            },

            new Country
            {
                Id = 21,
                Name = "Canada"
            },

            new Country
            {
                Id = 22,
                Name = "Caribbean"
            },

            new Country
            {
                Id = 23,
                Name = "Colombia"
            },

            new Country
            {
                Id = 24,
                Name = "Costa Rica"
            },

            new Country
            {
                Id = 25,
                Name = "Croatia"
            },

            new Country
            {
                Id = 26,
                Name = "Czech Republic"
            },

            new Country
            {
                Id = 27,
                Name = "Denmark"
            },

            new Country
            {
                Id = 28,
                Name = "Dominican Republic"
            },

            new Country
            {
                Id = 29,
                Name = "Ecuador"
            },

            new Country
            {
                Id = 30,
                Name = "Egypt"
            },

            new Country
            {
                Id = 31,
                Name = "El Salvador"
            },

            new Country
            {
                Id = 32,
                Name = "Estonia"
            },

            new Country
            {
                Id = 33,
                Name = "Ethiopia"
            },

            new Country
            {
                Id = 34,
                Name = "Faroe Islands"
            },

            new Country
            {
                Id = 35,
                Name = "Finland"
            },

            new Country
            {
                Id = 36,
                Name = "France"
            },

            new Country
            {
                Id = 37,
                Name = "Georgia"
            },

            new Country
            {
                Id = 38,
                Name = "Germany"
            },

            new Country
            {
                Id = 39,
                Name = "Greece"
            },

            new Country
            {
                Id = 40,
                Name = "Greenland"
            },

            new Country
            {
                Id = 41,
                Name = "Guatemala"
            },

            new Country
            {
                Id = 42,
                Name = "Honduras"
            },

            new Country
            {
                Id = 43,
                Name = "Hong Kong"
            },

            new Country
            {
                Id = 44,
                Name = "Hungary"
            },

            new Country
            {
                Id = 45,
                Name = "Iceland"
            },

            new Country
            {
                Id = 46,
                Name = "India"
            },

            new Country
            {
                Id = 47,
                Name = "Indonesia"
            },

            new Country
            {
                Id = 48,
                Name = "Iran"
            },

            new Country
            {
                Id = 49,
                Name = "Iraq"
            },

            new Country
            {
                Id = 50,
                Name = "Ireland"
            },

            new Country
            {
                Id = 51,
                Name = "Pakistan"
            },

            new Country
            {
                Id = 52,
                Name = "Israel"
            },

            new Country
            {
                Id = 53,
                Name = "Italy"
            },

            new Country
            {
                Id = 54,
                Name = "Jamaica"
            },

            new Country
            {
                Id = 55,
                Name = "Japan"
            },

            new Country
            {
                Id = 56,
                Name = "Jordan"
            },

            new Country
            {
                Id = 57,
                Name = "Kazakhstan"
            },

            new Country
            {
                Id = 58,
                Name = "Kenya"
            },

            new Country
            {
                Id = 59,
                Name = "Korea"
            },

            new Country
            {
                Id = 60,
                Name = "Kuwait"
            },

            new Country
            {
                Id = 61,
                Name = "Kyrgyzstan"
            },

            new Country
            {
                Id = 62,
                Name = "Lao P.D.R."
            },

            new Country
            {
                Id = 63,
                Name = "Latvia"
            },
            new Country
            {
                Id = 64,
                Name = "Lebanon"
            },

            new Country
            {
                Id = 65,
                Name = "Libya"
            },

            new Country
            {
                Id = 66,
                Name = "Liechtenstein"
            },

            new Country
            {
                Id = 67,
                Name = "Lithuania",
                CurrencyId = 5
            },

            new Country
            {
                Id = 68,
                Name = "Luxembourg"
            },

            new Country
            {
                Id = 69,
                Name = "Macao S.A.R."
            },

            new Country
            {
                Id = 70,
                Name = "Macedonia (FYROM)"
            },

            new Country
            {
                Id = 71,
                Name = "Malaysia"
            },

            new Country
            {
                Id = 72,
                Name = "Maldives"
            },

            new Country
            {
                Id = 73,
                Name = "Malta"
            },

            new Country
            {
                Id = 74,
                Name = "Mexico"
            },

            new Country
            {
                Id = 75,
                Name = "Mongolia"
            },

            new Country
            {
                Id = 76,
                Name = "Montenegro"
            },

            new Country
            {
                Id = 77,
                Name = "Morocco"
            },

            new Country
            {
                Id = 78,
                Name = "Nepal"
            },

            new Country
            {
                Id = 79,
                Name = "Netherlands",
                CurrencyId = 5
            },

            new Country
            {
                Id = 80,
                Name = "New Zealand"
            },

            new Country
            {
                Id = 81,
                Name = "Nicaragua"
            },

            new Country
            {
                Id = 82,
                Name = "Nigeria"
            },

            new Country
            {
                Id = 83,
                Name = "Norway"
            },

            new Country
            {
                Id = 84,
                Name = "Oman"
            },

            new Country
            {
                Id = 85,
                Name = "Panama"
            },

            new Country
            {
                Id = 86,
                Name = "Paraguay"
            },

            new Country
            {
                Id = 87,
                Name = "China"
            },

            new Country
            {
                Id = 88,
                Name = "Peru",
                CurrencyId = 4
            },

            new Country
            {
                Id = 89,
                Name = "Philippines"
            },

            new Country
            {
                Id = 90,
                Name = "Poland"
            },

            new Country
            {
                Id = 91,
                Name = "Portugal"
            },

            new Country
            {
                Id = 92,
                Name = "Principality of Monaco"
            },

            new Country
            {
                Id = 93,
                Name = "Puerto Rico"
            },

            new Country
            {
                Id = 94,
                Name = "Qatar"
            },

            new Country
            {
                Id = 95,
                Name = "Philippines"
            },

            new Country
            {
                Id = 96,
                Name = "Romania"
            },

            new Country
            {
                Id = 97,
                Name = "Russia"
            },

            new Country
            {
                Id = 98,
                Name = "Rwanda"
            },

            new Country
            {
                Id = 99,
                Name = "Saudi Arabia"
            },

            new Country
            {
                Id = 100,
                Name = "Senegal"
            },

            new Country
            {
                Id = 101,
                Name = "Serbia"
            },

            new Country
            {
                Id = 102,
                Name = "Serbia and Montenegro (Former)"
            },

            new Country
            {
                Id = 103,
                Name = "Singapore"
            },

            new Country
            {
                Id = 104,
                Name = "Slovakia"
            },

            new Country
            {
                Id = 105,
                Name = "Slovenia"
            },

            new Country
            {
                Id = 106,
                Name = "South Africa"
            },

            new Country
            {
                Id = 107,
                Name = "Spain"
            },

            new Country
            {
                Id = 108,
                Name = "Sri Lanka"
            },

            new Country
            {
                Id = 109,
                Name = "Sweden"
            },

            new Country
            {
                Id = 110,
                Name = "Switzerland"
            },

            new Country
            {
                Id = 111,
                Name = "Syria"
            },

            new Country
            {
                Id = 112,
                Name = "Taiwan"
            },

            new Country
            {
                Id = 113,
                Name = "Tajikistan"
            },

            new Country
            {
                Id = 114,
                Name = "Thailand"
            },

            new Country
            {
                Id = 115,
                Name = "Trinidad and Tobago"
            },

            new Country
            {
                Id = 116,
                Name = "Tunisia"
            },

            new Country
            {
                Id = 117,
                Name = "Turkey",
                CurrencyId = 2
            },

            new Country
            {
                Id = 118,
                Name = "Turkmenistan"
            },

            new Country
            {
                Id = 119,
                Name = "U.A.E."
            },

            new Country
            {
                Id = 120,
                Name = "Ukraine",
                CurrencyId = 1
            },

            new Country
            {
                Id = 121,
                Name = "United Kingdom"
            },

            new Country
            {
                Id = 122,
                Name = "United States",
                CurrencyId = 3,
            },

            new Country
            {
                Id = 123,
                Name = "Uruguay"
            },

            new Country
            {
                Id = 124,
                Name = "Uzbekistan"
            },

            new Country
            {
                Id = 125,
                Name = "Vietnam"
            },

            new Country
            {
                Id = 126,
                Name = "Yemen"
            },

            new Country
            {
                Id = 127,
                Name = "Zimbabwe"
            }





            );


            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id=1,
                    Name = "Ukrainian Grivna",
                    ShortName = "UAH",
                },

                new Currency
                {
                    Id = 2,
                    Name = "Turkish Lira",
                    ShortName = "TRY"
                },

                new Currency
                {
                    Id = 3,
                    Name = "US Dollar",
                    ShortName = "USD"
                },

                new Currency
                {
                Id = 4,
                Name = "Peruvian Nuevo Sol",
                ShortName = "PEN"
                },

                new Currency
                {
                Id = 5,
                Name = "Euro",
                ShortName = "EUR"
                }
                );

            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    Id=1,
                    Name = "Books",
                },

                new Category
                {
                    Id = 2,
                    Name = "Business & Industrial",
                },
                new Category
                {
                    Id = 3,
                    Name = "Clothing, Shoes & Accessories",
                },

                new Category
                {
                    Id = 4,
                    Name = "Collectibles",
                },

                new Category
                {
                    Id = 5,
                    Name = "Consumer Electronics",
                },

                new Category
                {
                    Id = 6,
                    Name = "Crafts",
                },

                new Category
                {
                    Id = 7,
                    Name = "Dolls & Bears",
                },

                new Category
                {
                    Id = 8,
                    Name = "Home & Garden",
                },

                new Category
                {
                    Id = 9,
                    Name = "Motors",
                },

                new Category
                {
                    Id = 10,
                    Name = "Pet Supplies",
                },

                new Category
                {
                    Id = 11,
                    Name = "Sporting Goods",
                },

                new Category
                {
                    Id = 12,
                    Name = "Sports Mem, Cards & Fan Shop",
                },

                new Category
                {
                    Id = 13,
                    Name = "Toy & Hobbies",
                },

                new Category
                {
                    Id = 14,
                    Name = "Antiques",
                },

                new Category
                {
                    Id = 15,
                    Name = "Computers/Tablets & Networking",
                }

                );

        }

    }
}
