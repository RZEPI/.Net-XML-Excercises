using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab3
{
   
    public class Car
    {
        private string model;
        [XmlElement(ElementName = "engine")]
        private Engine motor;
        private int year;        
        public Car(){}
        public Car(string model, Engine motor, int year)
        {
            this.model = model;
            this.motor = motor;
            this.year = year;
        }
        public string GetModel()
        {
            return this.model;
        }
        public int GetYear()
        {
            return this.year;
        }
        public Engine GetEngine()
        { 
            return this.motor; 
        }
    }
}
