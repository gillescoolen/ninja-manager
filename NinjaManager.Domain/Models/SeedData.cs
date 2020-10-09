using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NinjaManager.Domain.Data;

namespace NinjaManager.Domain.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new DatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DatabaseContext>>());
            // Look for any ninjas.
            if (context.Ninja.Any())
            {
                return; // Don't seed if there is existing data.
            }

            context.Ninja.AddRange(
                new Ninja{Name = "Dwiky", Gold = 100000000},
                new Ninja{Name = "Gilles.", Gold = 300},
                new Ninja{Name = "Taylor S.", Gold = 900},
                new Ninja{Name = "Troye S.", Gold = 400},
                new Ninja{Name = "Ariana G.", Gold = 1200},
                new Ninja{Name = "Chang", Gold = 200}
            );
                
            context.Gear.AddRange(
                new Gear
                {
                    Price = 2500,
                    Name = "Gucci Flip-Flops",
                    Intelligence = -100,
                    Strength = 10,
                    Agility = 90,
                    Slot = GearType.Feet
                },
                new Gear
                {
                    Price = 25,
                    Name = "Fila Flip-Flops",
                    Intelligence = 100,
                    Strength = 10,
                    Agility = 80,
                    Slot = GearType.Feet
                },
                new Gear
                {
                    Price = 50000,
                    Name = "Light-Blue Converse Shoes",
                    Intelligence = 150,
                    Strength = 30,
                    Agility = 80,
                    Slot = GearType.Feet
                },
                new Gear
                {
                    Price = 5,
                    Name = "Clown Shoes",
                    Intelligence = 0,
                    Strength = 0,
                    Agility = -10,
                    Slot = GearType.Feet
                },
                new Gear
                {
                    Price = 300,
                    Name = "Socks & Sandals",
                    Intelligence = 200,
                    Strength = -100,
                    Agility = 0,
                    Slot = GearType.Feet
                },
                new Gear
                {
                    Price = 10,
                    Name = "White Sneakers",
                    Intelligence = 0,
                    Strength = 10,
                    Agility = 10,
                    Slot = GearType.Feet
                },
                new Gear
                {
                    Price = 10000,
                    Name = "Kakkerschoentjes",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Feet
                },
                new Gear
                {
                    Price = 0,
                    Name = "Skere patta's",
                    Intelligence = 0,
                    Strength = 0,
                    Agility = 0,
                    Slot = GearType.Feet
                },
                new Gear
                {
                    Price = 10,
                    Name = "Zwarte GPS Tracker",
                    Intelligence = -1000,
                    Strength = -1000,
                    Agility = -1000,
                    Slot = GearType.Feet
                },
                new Gear
                {
                    Price = 20,
                    Name = "Gedragen Hoofdband",
                    Intelligence = -10,
                    Strength = 10,
                    Agility = 0,
                    Slot = GearType.Head
                },
                new Gear
                {
                    Price = 150,
                    Name = "Papieren Hoedje",
                    Intelligence = 100,
                    Strength = -100,
                    Agility = 0,
                    Slot = GearType.Head
                },
                new Gear
                {
                    Price = 150,
                    Name = "Latex Zwemkapje",
                    Intelligence = -10,
                    Strength = -10,
                    Agility = 500,
                    Slot = GearType.Head
                },
                new Gear
                {
                    Price = 50,
                    Name = "Toffe pruik",
                    Intelligence = 20,
                    Strength = 0,
                    Agility = -10,
                    Slot = GearType.Head
                },
                new Gear
                {
                    Price = 30000,
                    Name = "Donkerbruine Krulharen",
                    Intelligence = 1000,
                    Strength = 500,
                    Agility = 1000,
                    Slot = GearType.Head
                },
                new Gear
                {
                    Price = 20000,
                    Name = "Cubensis Lenses",
                    Intelligence = 300,
                    Strength = 8000,
                    Agility = 100,
                    Slot = GearType.Head
                },
                new Gear
                {
                    Price = 60,
                    Name = "Troye Sivan 'Easy' Sweater",
                    Intelligence = 20,
                    Strength = -20,
                    Agility = 20,
                    Slot = GearType.Chest
                },
                new Gear
                {
                    Price = 20000,
                    Name = "Witte Cardigan",
                    Intelligence = 300,
                    Strength = 200,
                    Agility = 500,
                    Slot = GearType.Chest
                },
                new Gear
                {
                    Price = 100,
                    Name = "Blauwe Winterjas 'Gerritsen'",
                    Intelligence = -3000,
                    Strength = 2000,
                    Agility = -5000,
                    Slot = GearType.Chest
                },
                new Gear
                {
                    Price = 20,
                    Name = "Gele Sweater",
                    Intelligence = -10,
                    Strength = 10,
                    Agility = 0,
                    Slot = GearType.Chest
                },
                new Gear
                {
                    Price = 100,
                    Name = "Mr. Prism Tee",
                    Intelligence = -100,
                    Strength = 1000,
                    Agility = 0,
                    Slot = GearType.Chest
                },
                new Gear
                {
                    Price = 500,
                    Name = "Belly Button Blues",
                    Intelligence = 200,
                    Strength = 200,
                    Agility = 0,
                    Slot = GearType.Chest
                },
                new Gear
                {
                    Price = 0,
                    Name = "Mannelijk borsthaar",
                    Intelligence = 0,
                    Strength = 10000,
                    Agility = -20,
                    Slot = GearType.Chest
                },
                new Gear
                {
                    Price = 10000,
                    Name = "80cm Zwart Zwaard 'De Ramino'",
                    Intelligence = 1000,
                    Strength = 1000,
                    Agility = 100,
                    Slot = GearType.Hand
                },
                new Gear
                {
                    Price = 5,
                    Name = "Schrale hand",
                    Intelligence = -100,
                    Strength = 0,
                    Agility = 20,
                    Slot = GearType.Hand
                },
                new Gear
                {
                    Price = 10,
                    Name = "Papieren boksbeugel",
                    Intelligence = 10,
                    Strength = -10,
                    Agility = -10,
                    Slot = GearType.Hand
                },
                new Gear
                {
                    Price = 30000,
                    Name = "Logitech G403 met een gat in de zijkant",
                    Intelligence = 1000,
                    Strength = 1000,
                    Agility = 1000,
                    Slot = GearType.Hand
                },
                new Gear
                {
                    Price = 100,
                    Name = "Kleine witte action muis",
                    Intelligence = -2000,
                    Strength = 1000,
                    Agility = 60000,
                    Slot = GearType.Hand
                },
                new Gear
                {
                    Price = 250,
                    Name = "1/2 Lily58 w/ metal plate",
                    Intelligence = 200,
                    Strength = 10000,
                    Agility = -1000,
                    Slot = GearType.Hand
                },
                new Gear
                {
                    Price = 20,
                    Name = "Houten Gamma Plank",
                    Intelligence = -10,
                    Strength = 10,
                    Agility = 0,
                    Slot = GearType.Hand
                },
                new Gear
                {
                    Price = 900000,
                    Name = "Stalen buis 'chromeo'",
                    Intelligence = 200,
                    Strength = 999999,
                    Agility = 200,
                    Slot = GearType.Hand
                },
                new Gear
                {
                    Price = 100,
                    Name = "De ringbaan",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Ring
                },
                new Gear
                {
                    Price = 100,
                    Name = "De singel",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Ring
                },
                new Gear
                {
                    Price = 100,
                    Name = "Rotonde op Boshoven",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Ring
                },
                new Gear
                {
                    Price = 100,
                    Name = "Paper Ring",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Ring
                },
                new Gear
                {
                    Price = 100,
                    Name = "7 inch vinyl single",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Ring
                },
                new Gear
                {
                    Price = 100,
                    Name = "avans strop",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Necklace
                },
                new Gear
                {
                    Price = 100,
                    Name = "gebruikte noose",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Necklace
                },
                new Gear
                {
                    Price = 100,
                    Name = "gouden chain",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Necklace
                },
                new Gear
                {
                    Price = 100,
                    Name = "hondenriem",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Necklace
                },
                new Gear
                {
                    Price = 100,
                    Name = "rattenriem",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Necklace
                },
                new Gear
                {
                    Price = 100,
                    Name = "elektrische nekband",
                    Intelligence = 100,
                    Strength = 100,
                    Agility = 100,
                    Slot = GearType.Necklace
                }
            );
                
            context.SaveChanges();
        }
    }
}