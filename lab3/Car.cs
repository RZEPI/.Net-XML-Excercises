using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Car
    {
        private string model;
        private Engine motor;
        private int year;
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
        public Engine GetEngine()
        { 
            return this.motor; 
        }
    }
}
