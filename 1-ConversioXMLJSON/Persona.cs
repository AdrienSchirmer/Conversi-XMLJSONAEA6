using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace _1_ConversioXMLJSON;

[XmlRoot("Persona")]
public class Persona
{
    [XmlAttribute("Id")]
    public int Id { get; set; }

    [XmlElement("Nom")]
    [JsonPropertyName("Nom")]
    public string NomCognoms { get; set; } = default!;

    [XmlElement("Edat")]
    public int Edat { get; set; }

    [XmlArray("Mascotes")]
    [XmlArrayItem("Mascota")]
    public List<Mascota> Mascotes { get; set; } = new();
}