using System.Xml.Serialization;
namespace _1_ConversioXMLJSON;

public class Mascota
{
    [XmlAttribute("Nom")]
    public string Nom { get; set; } = default!;

    [XmlElement("Tipus")]
    public string Tipus { get; set; } = default!;
}