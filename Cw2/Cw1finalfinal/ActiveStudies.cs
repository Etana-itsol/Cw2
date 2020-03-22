using System.Collections;
using System.Xml.Serialization;

namespace Cw1finalfinal
{
    public class ActiveStudies
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        
        [XmlAttribute(AttributeName = "numberof students")]
        public int CountOfStudents { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is ActiveStudies element))
            {
                return false;
            }

            return element.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
