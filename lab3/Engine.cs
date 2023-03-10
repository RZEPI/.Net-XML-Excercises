using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab3
{
    [XmlRoot(ElementName = "engine")]
    public class Engine
    {
        public double displacement;
        public double horsePower;
        [XmlAttribute]
        public string model;
        public Engine() { }

        public Engine(double displacement, double horsePower, string model)
        {
            this.displacement = displacement;
            this.horsePower = horsePower;
            this.model = model;
        }

        public double GetHppl()
        {
            double hppl = this.horsePower / this.displacement;
            return hppl;
        }
    }
}
