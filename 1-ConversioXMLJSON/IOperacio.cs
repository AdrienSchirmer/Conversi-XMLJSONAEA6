namespace _1_ConversioXMLJSON;

public interface IOperacio
{
    Persona GetPersonaFromRandom();
    void DesarPersonaAsXml(string fitxer, Persona persona);
    void DesarPersonaAsJson(string fitxer, Persona persona);
    Persona GetPersonaFromXml(string fitxer);
    Persona GetPersonaFromJson(string fitxer);
    void PintaPersonaPerConsola(Persona persona);
}