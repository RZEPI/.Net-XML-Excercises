using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                where car.GetModel() == "A6"
                select new
                {
                    engineType = car.GetEngine().GetModel() == "TDI" ? "diesel" : "petrol",
                    hppl = car.GetEngine().GetHppl()
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
        }
    }
}
