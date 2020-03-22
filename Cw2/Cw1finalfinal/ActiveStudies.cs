using System.Collections;

namespace Cw1finalfinal
{
    public class ActiveStudies
    {
        public string Name { get; set; }
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