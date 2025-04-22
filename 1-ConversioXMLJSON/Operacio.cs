using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace _1_ConversioXMLJSON;

public class Operacio : IOperacio
{
    public Persona GetPersonaFromRandom()
    {
        var random = new Random();
        var noms = new[] { "Laura", "Pau", "Joan", "Marta", "Carla", "Marc", "Arnau", "Adrien" };
        var nomsMascotes = new[] { "Nina", "Mimi", "Toby", "Luna", "Max", "Kira", "Rocky", "Gala", "Rita" };
        var tipusMascotes = new[] { "Gos", "Gat", "Conill", "Tortuga", "Peix", "Hàmster" };

        string nomPersona = noms[random.Next(noms.Length)];
        int edat = random.Next(1, 101);
        int nombreMascotes = random.Next(1, 4);

        var mascotes = new List<Mascota>();
        for (int i = 0; i < nombreMascotes; i++)
        {
            string nomMascota = nomsMascotes[random.Next(nomsMascotes.Length)];
            string tipus = tipusMascotes[random.Next(tipusMascotes.Length)];
            mascotes.Add(new Mascota { Nom = nomMascota, Tipus = tipus });
        }

        return new Persona
        {
            Id = random.Next(1000),
            NomCognoms = nomPersona,
            Edat = edat,
            Mascotes = mascotes
        };
    }

    public void DesarPersonaAsXml(string fitxer, Persona persona)
    {
        XmlSerializer serializer = new(typeof(Persona));
        using FileStream fs = new(fitxer + ".xml", FileMode.Create);
        serializer.Serialize(fs, persona);
    }

    public void DesarPersonaAsJson(string fitxer, Persona persona)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(persona, options);
        File.WriteAllText(fitxer + ".json", json);
    }

    public Persona GetPersonaFromXml(string fitxer)
    {
        try
        {
            XmlSerializer serializer = new(typeof(Persona));
            using FileStream fs = new(fitxer + ".xml", FileMode.Open);
            return (Persona)(serializer.Deserialize(fs)
                             ?? throw new InvalidOperationException("Deserialització fallida"));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"No s'ha trobat el fitxer \"{fitxer}.xml\"");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error llegint XML: {ex.Message}");
            throw;
        }
    }

    public Persona GetPersonaFromJson(string fitxer)
    {
        try
        {
            string json = File.ReadAllText(fitxer + ".json");
            return JsonSerializer.Deserialize<Persona>(json)
                   ?? throw new InvalidOperationException("Deserialització fallida");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"No s'ha trobat el fitxer \"{fitxer}.json\"");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error llegint JSON: {ex.Message}");
            throw;
        }
    }

    public void PintaPersonaPerConsola(Persona persona)
    {
        Console.WriteLine($"Persona: {persona.NomCognoms}, Edat: {persona.Edat}");
        foreach (var m in persona.Mascotes)
        {
            Console.WriteLine($" - Mascota: {m.Nom}, Tipus: {m.Tipus}");
        }
    }
}
