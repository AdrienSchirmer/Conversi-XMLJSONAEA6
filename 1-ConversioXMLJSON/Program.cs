namespace _1_ConversioXMLJSON;

class Program
{
    static void Main()
    {
        IOperacio operacio = new Operacio();
        Persona persona = operacio.GetPersonaFromRandom();
        string fitxer = "persona";

        int opcio;
        do
        {
            Console.WriteLine("MENÚ:");
            Console.WriteLine("0) Sortir");
            Console.WriteLine("1) Desar persona com XML");
            Console.WriteLine("2) Desar persona com JSON");
            Console.WriteLine("3) Llegir persona des d'XML");
            Console.WriteLine("4) Llegir persona des de JSON");
            Console.WriteLine("5) Definir nom de fitxer");
            Console.WriteLine("9) Pintar dades");
            Console.Write("Opció: ");

            if (!int.TryParse(Console.ReadLine(), out opcio)) continue;

            switch (opcio)
            {
                case 0:
                    Console.WriteLine("Adéu!");
                    break;
                case 1:
                    operacio.DesarPersonaAsXml(fitxer, persona);
                    Console.WriteLine("Persona desada com XML a " + fitxer+".xml");
                    break;
                case 2:
                    operacio.DesarPersonaAsJson(fitxer, persona);
                    Console.WriteLine("Persona desada com JSON a " + fitxer+".json");
                    break;
                case 3:
                    persona = operacio.GetPersonaFromXml(fitxer);
                    Console.WriteLine("Persona carregada des d'XML.");
                    operacio.PintaPersonaPerConsola(persona);
                    break;
                case 4:
                    persona = operacio.GetPersonaFromJson(fitxer);
                    Console.WriteLine("Persona carregada des de JSON.");
                    operacio.PintaPersonaPerConsola(persona);
                    break;
                case 5:
                    Console.Write("Introdueix el nom del fitxer (sense extensió): ");
                    fitxer = Console.ReadLine() ?? "persona";
                    break;
                case 9:
                    operacio.PintaPersonaPerConsola(persona);
                    break;
                default:
                    Console.WriteLine("Opció no vàlida.");
                    break;
            }

        } while (opcio != 0);
    }
}