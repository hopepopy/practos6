using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace Практ_6
{
    public class Converter
    {
        private string GetFrormat(string path)
        {
            if (path.EndsWith(".json"))
            {
                return "json";
            }
            else if (path.EndsWith(".xml"))
            {
                return "xml";
            }
            else if (path.EndsWith(".txt"))
            {
                return "txt";
            }
            else
            {
                return "other";
            }
        }

        public List<Car> Load(string path)
        {
            List<Car> cars;
            string format = GetFrormat(path);
            if (format == "json")
            {
                string text = File.ReadAllText(path);
                cars = JsonConvert.DeserializeObject<List<Car>>(text);
            }
            else if (format == "xml")
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Car>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    cars = (List<Car>)xml.Deserialize(fs);
                }
            }
            else if (format == "txt")
            {
                List<string> strings = File.ReadAllLines(path).ToList();
                cars = new List<Car>();
                for (int i = 0; i < strings.Count / 3; i++)
                {
                    Car car = new Car();
                    car.owner = strings[i * 3];
                    car.mark = strings[i * 3 + 1];
                    car.year = Convert.ToInt32(strings[i * 3 + 2]);
                    cars.Add(car);
                }
            }
            else
            {
                cars = new List<Car>();
            }

            return cars;
        }

        public void Save(List<Car> cars, string path)
        {
            string format = GetFrormat(path);

            if (format == "json")
            {
                string text = JsonConvert.SerializeObject(cars);
                File.WriteAllText(path, text);
            }
            else if (format == "xml")
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Car>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, cars);
                }
            }
            else if (format == "txt")
            {
                List<string> strings = new List<string>();
                foreach (Car car in cars)
                {
                    strings.Add(car.owner);
                    strings.Add(car.mark);
                    strings.Add(car.year.ToString());
                }
                File.WriteAllLines(path, strings);
            }
        }
    }
}
