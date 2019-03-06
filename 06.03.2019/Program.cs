using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _06._03._2019
{
    [Serializable]
    public class Person
    {
        public Person()
        {

        }
        public string Name { get; set; }
        public int Year { get; set; }
        [NonSerialized]
        public string iin;
        public Person(string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }

        public void Methodi()
        {
            Console.WriteLine("Holla");
        }
    }
    public class MyClass : IDisposable
    {
        public MyClass()
        {
            //con.Open();
        }
        ~MyClass()
        {
            //Con.Close();
            Console.WriteLine("Hello from destrcutor");
        }

        public void Dispose()
        {
            Console.WriteLine("worked");
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            //MyClass myClass = new MyClass();
            //GC.Collect();
            //using (MyClass myClass1 = new MyClass())
            //{

            //}
            //Console.ReadKey();
            //myClass = null;

            //Person person = new Person("Set", 30);
            //Console.WriteLine("object created");
            //BinaryFormatter formatter = new BinaryFormatter();

            //using (FileStream fs=new FileStream("people.data", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, person);
            //    Console.WriteLine("objecr serialized");
            //}

            //using (FileStream fs=new FileStream("people.data", FileMode.Open))
            //{
            //    Person data = (Person)formatter.Deserialize(fs);
            //    Console.WriteLine(data.Name);
            //    Console.WriteLine(data.Year);
            //}

            //Person person1 = new Person("Set", 30);
            //Person person2 = new Person("Met", 30);
            //Person[] persons = new Person[] { person1, person2 };

            //BinaryFormatter formatter = new BinaryFormatter();

            //using (FileStream fs = new FileStream("people.data", FileMode.OpenOrCreate))
            //{

            //    formatter.Serialize(fs, persons);
            //    Console.WriteLine("objecr serialized");
            //}

            //using (FileStream fs = new FileStream("people.data", FileMode.Open))
            //{

            //    Person[] data2 = (Person[])formatter.Deserialize(fs);


            //}

            example5();
        }

        static void example1()
        {
            Person person1 = new Person("Set", 30);
            Person person2 = new Person("Met", 30);
            Person[] persons = new Person[] { person1, person2 };

            SoapFormatter formatter = new SoapFormatter();



            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, persons);
                Console.WriteLine("objecr serialized");
            }

            using (FileStream fs = new FileStream("people.soap", FileMode.Open))
            {

                Person[] data2 = (Person[])formatter.Deserialize(fs);
            }
        }

        static void example2()
        {
            Person person1 = new Person("Set", 30);
            Person person2 = new Person("Met", 30);
            Person[] persons = new Person[] { person1, person2 };

            XmlSerializer formatter = new XmlSerializer(typeof(Person[]));

            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, persons);
                Console.WriteLine("objecr serialized");
            }

            using (FileStream fs = new FileStream("people.xml", FileMode.Open))
            {

                Person[] data2 = (Person[])formatter.Deserialize(fs);
            }
        }

        static void example3()
        {
            Person person1 = new Person("Set", 30);
            Person person2 = new Person("Met", 30);
            Person[] persons = new Person[] { person1, person2 };
            string json = JsonConvert.SerializeObject(persons);
            Console.WriteLine(json);
        }

        static void example4()
        {
            Person person1 = new Person("Set", 30);
            Person person2 = new Person("Met", 30);
            Person[] persons = new Person[] { person1, person2 };
            string json = JsonConvert.SerializeObject(persons);
            Console.WriteLine(json);
            var data2 = JsonConvert.DeserializeObject<Person[]>(json);
        }

        static void example5()
        {
            FileInfo fileInfo = new FileInfo("Phonebook.csv");
            if (!fileInfo.Exists)
            {

                using (FileStream fs = fileInfo.Create())
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            var user = RandomUser.GenerateUser.GetUser();
                            string str = string.Format("{0};{1};{2};{3}", user.name.title, user.name.first, GetPhone(), user.location.city);
                            sw.WriteLine(str);
                        }
                    }
                }
            }
        }

        static string GetPhone()
        {
            Random rns = new Random();

            string phone = string.Format("+7 {0} {1}-{2}-{3}", rns.Next(111, 999), rns.Next(111, 999), rns.Next(11, 99), rns.Next(11, 99));
            return phone;
        }

    }
}
