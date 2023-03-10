﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> myCars = new List<Car>()
            {
                new Car("E250", new Engine(1.8, 204, "CGI"), 2009),
                new Car("E350", new Engine(3.5, 292, "CGI"), 2009),
                new Car("A6", new Engine(2.5, 187, "FSI"), 2012),
                new Car("A6", new Engine(2.8, 220, "FSI"), 2012),
                new Car("A6", new Engine(3.0, 295, "TFSI"), 2012),
                new Car("A6", new Engine(2.0, 175, "TDI"), 2011),
                new Car("A6", new Engine(3.0, 309, "TDI"), 2011),
                new Car("S6", new Engine(4.0, 414, "TFSI"), 2012),
                new Car("S8", new Engine(4.0, 513, "TFSI"), 2012)
            };
            // zad 1 
            var a6Query =
                from car in myCars
                where car.model == "A6"
                select new
                {
                    engineType = car.motor.model == "TDI" ? "diesel" : "petrol",
                    hppl = car.motor.GetHppl()
                };
            var engineQuery = 
                from engine in a6Query
                group engine.hppl by engine.engineType into engineGroup
                select new
                {
                    EngineType = engineGroup.Key,
                    AverageHppl = engineGroup.Average()
                };
            foreach( var engine in engineQuery)
                Console.WriteLine("{0}: {1}", engine.EngineType, engine.AverageHppl);
            Console.ReadKey();

            //zad 2
            FileStream fileStream = new FileStream("CarsCollection.xml", FileMode.Create);
            fileStream.Close();
            SerializeList(myCars, fileStream.Name);
            LinqSerialization(myCars);
            myCars = DeserializeList(fileStream.Name) as List<Car>;
            XPathCalculations(myCars);
        }
        private static void LinqSerialization(List<Car> myCars)
        {
            IEnumerable<XElement> nodes = myCars.Select(n =>
                new XElement("car",
                    //new XElement("model", n.model),
                    new XElement("engine",
                        new XAttribute("model", n.motor.model),
                        new XElement("displacement", n.motor.displacement),
                        new XElement("horsePower", n.motor.horsePower),
                    new XElement("year", n.year))));
            XElement rootNode = new XElement("cars", nodes);
            rootNode.Save("CarsCollectionLinq.xml");
        }
        public static List<Car> DeserializeList(string fileName)
        {
            List<Car> deserializedList = new List<Car>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("cars"));
            FileStream fileToDeserialization = new FileStream(fileName, FileMode.Open);
            deserializedList = (List<Car>)serializer.Deserialize(fileToDeserialization);
            fileToDeserialization.Close();
            return deserializedList;
        }

        public static void SerializeList(List<Car> listOfCars, string fileName)
        {
            XmlSerializer serializedList= new XmlSerializer(typeof(List<Car>), new XmlRootAttribute("cars"));
            TextWriter fileToSerialize = new StreamWriter(fileName);
            serializedList.Serialize(fileToSerialize, listOfCars);
            fileToSerialize.Close();
        }

        public static void XPathCalculations(List<Car> listOfCars)
        {
            XElement rootNode = XElement.Load("CarsCollection.xml");
            double avgHP = (double)rootNode.XPathEvaluate("sum(//car/engine[@model!=\"TDI\"]/horsePower) div count(//car/engine[@model!=\"TDI\"]/horsePower)"); 
            Console.WriteLine("Srednia: " + avgHP.ToString());
            IEnumerable<XElement> models = rootNode.XPathSelectElements("//car[not(preceding-sibling::car/model/text() = model/text())]");
            Console.WriteLine("Modele samochodow bez powtorzen");
            foreach (var model in models)
                Console.Write(model.ToString());
            Console.ReadKey();
        }
    }
}
