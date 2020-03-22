using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Cw1finalfinal
{
    public class Student
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        [XmlElement(ElementName = "birthdate")]
        [JsonPropertyName("bithtdate")]
        public string date { get; set; }

        [XmlAttribute(AttributeName = "indexNumber")]
        [JsonPropertyName("indexNumber")]
        public string s { get; set; }

        public string Mail { get; set; }
        
        [JsonPropertyName("MothersName")]
        public string MothersName { get; set; }
        [JsonPropertyName("FathersName")]
        public string FathersName { get; set; }


        public Studies Studies { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is Student element))
            {
                return false;
            }

            return element.Imie == this.Imie;
        }

        public override int GetHashCode()
        {
            return Imie.GetHashCode();
        }
    }
}