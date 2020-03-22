using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Cw1finalfinal
{
    class Program
    {
        static void Main(string[] args)
        {
             var inputPath = args.Length > 0 ? args[0] : @"Files\data.csv";
            var outputPath = args.Length > 1 ? args[1] : @"Files\result";
            var outputType = args.Length > 2 ? args[2] : "xml";


            try
            {


                if (!File.Exists(inputPath))
                    throw new FileNotFoundException("Nie znaleziono pliku:", inputPath.Split("\\")[^1]);

                var university = new Uczelnia
                {
                    Author = "Jan Kowalski"
                };


                foreach (var line in File.ReadAllLines(inputPath))
                {
                    var splitted = line.Split(",");

                    if (splitted.Length != 9)
                    {
                        File.AppendAllText(@"Files\Log.txt", $"{DateTime.UtcNow} wrong informations\n");
                        continue;
                    }
                    
                    if (splitted[0] == "" || splitted[1] == "" || splitted[2] == "" || splitted[3] == "" || splitted[4] == "" ||
                        splitted[5] == "" || splitted[6] == "" || splitted[7] == "" || splitted[8] == "")
                    {
                        File.AppendAllText(@"Files\Log.txt", $"ERR Empty column in line { line}\n");
                        continue;
                    }

                    var student = new Student
                    {
                        
                        Imie = splitted[0],
                        Nazwisko = splitted[1],
                        s = "s"+splitted[4],
                        date = splitted[5],
                        Mail = splitted[6],
                        MothersName = splitted[7],
                        FathersName= splitted[8],
                        Studies = new Studies()
                        {
                        name = splitted[2],
                        mode = splitted[3],
                    }
                        
                    };
                    
                    var activ = new ActiveStudies
                    {
                        Name = splitted[2],
                        CountOfStudents = 1
                    };
                    
                    university.Students.Add(student);
                    
                    
                    if(university.getActive(activ) != null)
                    {
                        university.getActive(activ).CountOfStudents++;
                    }
                    else
                    {
                        university.ActiveStudies.Add(activ);
                    }
                    
                }





                //xml
                using var writer = new FileStream($"{outputPath}.{outputType}", FileMode.Create);
                var serializer = new XmlSerializer(typeof(Uczelnia));
                serializer.Serialize(writer, university);

                //json
                var jsonString = JsonSerializer.Serialize(university);
                 File.WriteAllText($"{outputPath}.json", jsonString);



            }
            catch (FileNotFoundException e)
            {
                File.AppendAllText(@"Files\Log.txt", $"{DateTime.UtcNow} {e.Message} File not found ({e.FileName})\n");
            }
        }
    }
}
