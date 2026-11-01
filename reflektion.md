# Reflektion — Musiklistappen

**Namn:** [Samar Hussein]
**Datum:** [2026-11-01]

---

## Vad var svårast?

[Det svåraste var att få databasen att fungera tillsammans med programmet. Jag hade lite problem med att hämta låtar och förstå hur informationen skulle läsas från databasen. Jag behövde också rätta några fel i koden]

---

## Vad lärde du dig?

[Jag lärde mig hur man kopplar ett C#-program till en databas med SQLite. Jag lärde mig också att lägga till, söka efter, visa och ta bort låtar. Jag har även lärt mig mer om hur klasser och metoder fungerar.]

---

## Hur använde du ADO.NET i praktiken — vad kändes naturligt och vad var förvirrande?

Tänk på de fem stegen: öppna anslutning, skapa kommando, skriv SQL, skicka in värden, kör.

[Jag använde ADO.NET för att ansluta till databasen och hämta information. Jag använde SqliteConnection, CreateCommand() och ExecuteReader(). Det som kändes lite förvirrande var hur man läser information från databasen och skickar in parametrar.]

---

## Varför ska man använda parameteriserade queries?

Vad kan hända om man klistrar ihop SQL med strängar i stället? (Tänk på Bobby Tables.)
[Man använder parameteriserade queries för att skydda databasen mot SQL-injektioner. Om man skriver in användarens text direkt i SQL-frågan kan någon försöka ändra frågan och påverka databasen. Med parametrar blir det säkrar.]

---

## Om du hade mer tid — vad hade du lagt till eller gjort annorlunda?

[Om jag hade haft mer tid skulle jag vilja förbättra menyn och lägga till fler funktioner.]

---

## (VG) Varför delade du upp koden som du gjorde?

Resonera kring ditt designval: varför ligger databaskoden i `DbHandler` och inte i `Program.cs`? Vad hade blivit svårare om allt låg i samma fil?

[Skriv här]
