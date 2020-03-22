using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cw1finalfinal
{
    public class Uczelnia
    {
        public Uczelnia()
        {
            Students = new HashSet<Student>();
            DateEst = DateTime.Now.ToString("yyyy-mm-dd");
            ActiveStudies = new HashSet<ActiveStudies>();
        }

        [XmlAttribute] public String Author { get; set; }

        [XmlAttribute(AttributeName = "Created at")]
        public string DateEst { get; set; }

        public HashSet<Student> Students { get; set; }
        public HashSet<ActiveStudies> ActiveStudies { get; set; }

        public ActiveStudies getActive(ActiveStudies element)
        {
            if (ActiveStudies.Contains(element))
            {
                foreach (ActiveStudies activ in ActiveStudies)
                {
                    if (element.Equals(activ))
                        return activ;
                }
            }

            return null;
        }
    }
}

