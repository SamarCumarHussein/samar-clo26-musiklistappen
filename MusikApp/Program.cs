using Microsoft.Extensions.Configuration;
using MusikApp;

// Läser inställningar från appsettings.json (samma sätt som i hero_databas).
// Databasens sökväg ligger där, så du slipper skriva den i koden.
var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionString = config.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Hittar ingen connection string 'Default' i appsettings.json.");

// Börja här. Den här raden visar att inställningarna lästes in, ta bort den när du vill.
Console.WriteLine($"Musiklistappen: börja med att få menyn att fungera!  (databas: {connectionString})");

// Tips på ordning (se UPPGIFT.md):
//   2. Skapa ett DbHandler-objekt: new DbHandler(connectionString
var db = new DbHandler(connectionString);

bool running = true;
while (running)
{
 // Tips på ordning (se UPPGIFT.md):
//   1. Rita upp huvudmenyn (alternativ numrerade 1-N) och läs in ett val med Console.ReadLine().
//      Skriv ut "Här kommer en lista senare" tills databasen är kopplad.
    Console.Clear();
    Console.WriteLine("=== MUSIKLISTAPPEN ===");
    Console.WriteLine("1. Visa alla låtar");
    Console.WriteLine("2. Sök låt");
    Console.WriteLine("3. Lägg till låt");
    Console.WriteLine("4. Ta bort låt");
    Console.WriteLine("5. Avsluta");
    Console.Write("\nVälj alternativ (1-5): ");

    string? choice = Console.ReadLine();
//   3. Anropa DbHandlers metoder från menyn. Här ska ALDRIG SQL stå.
 
    switch (choice)
    {
        case "1":
            {
                var songs = db.GetAllSongs();
                Console.WriteLine("\n--- Alla låtar ---");
                foreach (var s in songs)
                {
                    Console.WriteLine($"ID: {s.Id} | {s.Title} ({s.LengthSong}s)");
                }
                break;
            }
        case "2":
            {
                Console.Write("Sökord: ");
                string term = Console.ReadLine() ?? "";
                var result = db.SearchSongs(term);
                Console.WriteLine("\n--- Sökresultat ---");
                foreach (var s in result)
                {
                    Console.WriteLine($"ID: {s.Id} | {s.Title} ({s.LengthSong}s)");
                }
                break;
            }
        case "3":
            {
                Console.Write("Titel: ");
                string title = Console.ReadLine() ?? "";
                Console.Write("Längd (sekunder): ");
                int.TryParse(Console.ReadLine(), out int length);

                db.AddSong(new Song { Title = title, LengthSong = length });
                Console.WriteLine("Låten har lagts till!");
                break;
            }
        case "4":
            {
                Console.Write("Ange ID att ta bort: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Write("Är du säker? (j/n): ");
                    if (Console.ReadLine()?.ToLower() == "j")
                    {
                        bool deleted = db.DeleteSong(id);
                        Console.WriteLine(deleted ? "Låten togs bort." : "Hittade inte låten.");
                    }
                }
                break;
            }
        case "5":
            {
               
//   4. Avsluta snyggt när användaren väljer "Avsluta".
                Console.WriteLine("Programmet avslutas.");
                break;
            }
        default:
            {
                Console.WriteLine("Ogiltigt val.");
                break;
            }
    }

    if (running)
    {
        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }
}

